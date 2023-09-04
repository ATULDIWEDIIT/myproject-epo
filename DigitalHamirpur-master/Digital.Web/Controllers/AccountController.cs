using Digital.Core;
using Digital.Data.Models;
using Digital.Dto;
using Digital.Service;
using Digital.Web.Controllers;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital.Web
{
    public class AccountController : BaseController
    {


        private readonly IUserService userService;
        private readonly IPersonService personService;
        private readonly IRoleService roleService;
        public AccountController(IUserService _userService, IPersonService _personService, IRoleService _roleService)
        {
            userService = _userService;
            personService = _personService;
            roleService = _roleService;
        }

        #region login

        [HttpGet]
        public IActionResult Login()
        {
            LoginViewDto model = new LoginViewDto();
            if (CurrentUser.IsAuthenticated)
            {
                return RedirectToAction("index", "home");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = userService.GetUserEntityByUserName(model.UserName);

                    if (user != null)
                    {
                        if (ModelState.IsValid)
                        {
                            List<Users> users = userService.GetUser(model.UserName, model.Password);
                            if (users != null && users.Count() > 0)
                            {
                                userService.Save(users.First(), users.First().CreatedBy, false);
                                var userDto = new UserSessionDto
                                {
                                    UserId = user.UserId,
                                    UserName = user.UserName ?? "",
                                    FirstName = user.Person?.FirstName ?? "",
                                    LastName = user.Person?.LastName ?? "",
                                    Email = user.Email ?? "",
                                    RoleID = user.RoleId ?? 0,

                                };

                                await CreateAuthenticationTicket(userDto);

                                //HttpContext.Session.SetObjectAsJson("SessionUserActionAccess", menuService.GetActionMethodAccessbility(users.First().UserRole.RoleId));

                                switch (user.RoleId)
                                {
                                    case (int)UserRoles.SuperAdmin:
                                        return RedirectToAction("index", "SuperAdminDashboard");

                                    case (int)UserRoles.Admin:
                                        return RedirectToAction("index", "Dashboard", new { area = "Admin" });

                                    case (int)UserRoles.User:
                                        return RedirectToAction("index", "Dashboard", new { area = "User" });

                                    default:
                                        return RedirectToAction("Index", "Home");
                                }


                            }

                        }
                    }
                    ShowErrorMessage("Error!", "An Invalid user ID and / or Password has been entered, please re-enter.");
                    return View(model);
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Error!", "Failed to login due to some internal error");
                // ShowErrorMessage("Error!", ex.Message);
                return View(model);
            }
        }

        #endregion

        #region registration

        [HttpGet]
        public IActionResult UserRegistration(string id)
        {
            PersonViewDto model = new PersonViewDto();
            if (CurrentUser.IsAuthenticated)
            {
                return RedirectToAction("index", "home");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UserRegistration(PersonViewDto model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    if (!string.IsNullOrEmpty(model.UserName))
                    {
                        if (userService.IsUserNameExist(model.UserName))
                        {
                            ModelState.AddModelError("Error!", "Username already exist.");
                            ShowErrorMessage("Error!", "Username already exist.", false);
                            return View(model);
                        }
                    }

                    model.Gender = (int?)Gender.Male;
                    model.FirstName = !string.IsNullOrWhiteSpace(model.FirstName) ? model.FirstName.Trim() : model.FirstName;
                    model.LastName = !string.IsNullOrWhiteSpace(model.LastName) ? model.LastName.Trim() : model.LastName;
                    model.Address = !string.IsNullOrWhiteSpace(model.Address) ? model.Address?.Trim() : model.Address;
                    model.Disctrict = !string.IsNullOrWhiteSpace(model.Disctrict) ? model.Disctrict?.Trim() : model.Disctrict;

                    model.CreatedOn = DateTime.Now;
                    //model.Active = true;
                    model.UpdatedOn = DateTime.Now;
                    string randonSalt = Common.GetRandomPasswordSalt();

                    Person person = new Person();
                    person.CreatedBy = model.CreatedBy;
                    person.UpdatedBy = model.UpdatedBy;
                    person.FirstName = model.FirstName;
                    //  person.ActivIse = model.Active;
                    person.LastName = model.LastName;
                    person.Email = model.Email;
                    person.Address = model.Address;
                    person.Disctrict = model.Disctrict;
                    personService.Save(person);

                    TempData["PersonID"] = person.PersonId;

                    // Save Address
                    //Address address = new Address();
                    //address.HouseName = string.IsNullOrWhiteSpace(model.Addresses[0].HouseName) ? string.Empty : model.Addresses[0].HouseName;
                    //address.HouseNumber = model.Addresses[0].HouseNumber;
                    //address.StreetName = model.Addresses[0].StreetName;
                    //address.District = string.IsNullOrWhiteSpace(model.Addresses[0].District) ? string.Empty : model.Addresses[0].District;
                    //address.City = string.IsNullOrWhiteSpace(model.Addresses[0].City) ? string.Empty : model.Addresses[0].City;
                    //address.Postcode = model.Addresses[0].Postcode;
                    //address.CountryId = model.Addresses[0].CountryId;
                    //address.PersonId = person.PersonId;
                    //addressService.Save(address, address.AddressId == 0);
                    // End



                    if (!string.IsNullOrEmpty(model.UserName) && !string.IsNullOrEmpty(model.Password))
                    {
                        var user = new Users();
                        user.UserName = model.UserName;
                        user.Email = model.Email;
                        user.PasswordSalt = randonSalt;
                        //user.Password = EncryptionUtils.HashPassword(model.Password, user.PasswordSalt, DateTime.Now);
                        user.Password = model.Password;
                        user.IsActive = true;
                        user.CreatedOn = DateTime.Now;
                        user.UpdatedOn = DateTime.Now;
                        user.LastLoginDate = DateTime.Now;
                        user.LastPasswordChange = DateTime.Now;
                        // user.CreatedBy = CurrentUser.UserID;                       
                        //user.Ip = ContextProvider.HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress.ToString();
                        user.PersonId = person.PersonId;
                        user.RoleId = 3;
                        userService.Save(user, user.CreatedBy, true);
                    }

                    ShowSuccessMessage("Success!", "User saved successfully. Please login with your credentials.", false);
                    return RedirectToAction("login", "account");

                }


                catch (Exception ex)
                {
                    ShowErrorMessage("Error!", "Failed to login due to some internal error");
                    ShowErrorMessage("Error!", ex.Message);
                    return View(model);
                }
            }
            else
            {

                ShowErrorMessage("Error!", "Please fill all required fields!", false);
                return View(model);
            }


        }

        #endregion

        /// To logout the current user

        [HttpGet]
        public IActionResult Logout()
        {
            var abc = RemoveAuthentication();
            return Redirect("Login");
        }

    }
}

using Digital.Core;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Digital.Dto;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace Digital.Web.Controllers
{
    public class BaseController : Controller
    {


        #region "Public Properties"

        public CustomPrincipal CurrentUser => new CustomPrincipal(HttpContext.User);

        #endregion

        #region "Authentication"

        public async Task CreateAuthenticationTicket(UserSessionDto user)
        {
            if (user != null)
            {
                var claims = new List<Claim>{

                        new Claim(ClaimTypes.PrimarySid, Convert.ToString(user.UserId)),
                        new Claim(ClaimTypes.Email, !string.IsNullOrEmpty(user.Email)?user.Email : string.Empty),
                        new Claim(ClaimTypes.GivenName, user.FirstName),
                        new Claim(nameof(user.LastName), !string.IsNullOrEmpty(user.LastName)?user.LastName : string.Empty),
                        new Claim(nameof(user.UserName), user.UserName),
                        new Claim(nameof(user.RoleID), Convert.ToString(user.RoleID)),                       
                       
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
            }
        }

        public async Task RemoveAuthentication()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        #endregion


        #region "Notificatons"
        private void ShowMessages(string title, string message, MessageType messageType, bool isCurrentView)
        {
            Notification model = new Notification
            {
                Heading = title,
                Message = message,
                Type = messageType
            };

            if (isCurrentView)
                this.ViewData.AddOrReplace("NotificationModel", model);
            else
            {
                TempData["NotificationModel"] = JsonConvert.SerializeObject(model);
                TempData.Keep("NotificationModel");
            }
        }

        protected void ShowErrorMessage(string title, string message, bool isCurrentView = true)
        {
            ShowMessages(title, message, MessageType.Danger, isCurrentView);
        }

        protected void ShowSuccessMessage(string title, string message, bool isCurrentView = true)
        {
            ShowMessages(title, message, MessageType.Success, isCurrentView);
        }

        protected void ShowWarningMessage(string title, string message, bool isCurrentView = true)
        {
            ShowMessages(title, message, MessageType.Warning, isCurrentView);
        }

        protected void ShowInfoMessage(string title, string message, bool isCurrentView = true)
        {
            ShowMessages(title, message, MessageType.Info, isCurrentView);
        }
        #endregion

        public IActionResult NewtonSoftJsonResult(object data)
        {
            return Json(data);
        }

    }
}

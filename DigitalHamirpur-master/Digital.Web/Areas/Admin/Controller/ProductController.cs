using AutoMapper;
using Digital.Core;
using Digital.Data.Models;
using Digital.Dto;
using Digital.Service;
using Digital.Web;
using Digital.Web.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Digital.Web.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IToastNotification _toastNotification;

        public ProductController(IProductService productService, IWebHostEnvironment hostEnvironment, IMapper mapper, IToastNotification toastNotification)
        {

            _productService = productService;
            _hostEnvironment = hostEnvironment;
            _mapper = mapper;
            _toastNotification=toastNotification;   
        }
        public IActionResult Index()
        {
            var data = _productService.GetAllProduct();
            ViewBag.SubCategoryList = _productService.GetSubCategoryList().Select(s => new SelectListItem
            {
                Text = s.Title,
                Value = s.CategoryId.ToString()
            }).OrderBy(o => o.Text).ToList();
            var res = _mapper.Map<IReadOnlyList<ProductViewDto>>(data);
            return View(res);
        }

        [HttpPost]
        public IActionResult SaveProduct(ProductViewDto data)
        {
            try
            {
                if (data == null)
                {
                    return null; ;
                }
                //// Construct the path where the image will be saved
                //var path = Path.Combine(_hostingEnvironment.WebRootPath, "images", data.picture.FileName);

                //// Save the image to the specified path
                //using (var stream = new FileStream(path, FileMode.Create))
                //{
                //    data.picture.CopyTo(stream);
                //}
                var res = _mapper.Map<Products>(data);
                res.IsActive = true;
                res.CreadtedOn = DateTime.Now;
                // res.Profile = data.picture.FileName;
                if (res.ProductId != 0)
                {
                    var doc = _productService.Update(res);
                    _toastNotification.AddSuccessToastMessage("Data Updated Successfully");
                }
                else
                {
                    var doc = _productService.Save(res);
                    _toastNotification.AddSuccessToastMessage("Data Saved Successfully");
                }


                return RedirectToAction("~/Admin/Product");
            }
            catch (Exception)
            {
                _toastNotification.AddErrorToastMessage("Error Occured");
                return StatusCode(500, new { message = "Error adding Product. Please try again." });

            }
        }


        public  JsonResult UpdateProduct(string Data)
        {
            var doc =  _productService.GetById(Convert.ToInt32(Data));
            var res = _mapper.Map<ProductViewDto>(doc);
            return Json(res);
        }

        [HttpGet]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                var data = _productService.Delete(id);
                if (data)
                {
                    _toastNotification.AddSuccessToastMessage("Data Deleted Successfully");
                }
                else
                {
                    _toastNotification.AddSuccessToastMessage("Error Occured");
                }

                return RedirectToAction("Doctor");
            }
            catch (Exception)
            {
                _toastNotification.AddErrorToastMessage("Error Occured");
                return RedirectToAction("Doctor");
            }



        }












        #region[Add/Edit]
        [HttpGet]
        public IActionResult CreateEdit(int? id = null)
        {
            ProductViewDto res = null;
            if (id.HasValue)
            {
                Products entity = _productService.GetById(id.Value);
                 res = _mapper.Map<ProductViewDto>(entity);

            }
            res = BindSubCategoryList(res);
            return View(res);
        }
        [HttpPost]
        public IActionResult CreateEdit(int? id, ProductViewDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    bool isExist = id.HasValue && id.Value != 0;
                    bool isStaticPageNameExist = _productService.Exists(model.ProductId, model.Title);
                    if (isStaticPageNameExist)
                    {
                        return NewtonSoftJsonResult(new RequestOutcome<string> { Data = "Product already exists.", IsSuccess = false });
                    }
                    var entity = isExist ? _productService.GetById(model.ProductId) : new Products();
                    entity.ProductId = model.ProductId;
                    entity.Title = model.Title;
                    entity.Description = model.Description;
                    entity.CostPrice = entity.CostPrice;
                    entity.ComparePrice = entity.ComparePrice;
                    if (model.file != null && model.file.Length != 0)
                    {
                        var uniqueFileName = GetUniqueFileName(model.file.FileName);
                        // Combine the uploads directory path with the unique filename
                        string webRootPath = _hostEnvironment.WebRootPath;
                        model.ImagePath = Path.Combine(webRootPath, "uploads", uniqueFileName);
                        // Save the uploaded file to the specified path
                        using (var stream = new FileStream(model.ImagePath, FileMode.Create))
                        {
                            model.file.CopyTo(stream);
                        }
                        entity.UploadPath = model.ImagePath;
                    }

                    if (isExist && id > 0)
                    {

                        entity.CreadtedOn = entity.CreadtedOn;
                        entity.CreatedBy = entity.CreatedBy;
                        entity.IsActive = model.IsActive;                       
                        entity.UpdatedOn = DateTime.Now;
                    }
                    else
                    {
                        // entity.CreatedBy = CurrentUser.Id;
                        entity.CreadtedOn = DateTime.Now;
                        entity.IsActive = model.IsActive;
                    }
                    if (isExist)
                    {
                        _productService.Update(entity);
                    }
                    else
                    {
                        _productService.Save(entity);
                    }
                    ShowSuccessMessage("Success!", $"Product {(isExist ? "updated" : "created")} successfully", false);
                    return NewtonSoftJsonResult(new RequestOutcome<string> { RedirectUrl = Url.Action("Index"), IsSuccess = true });

                }
            }
            catch (Exception Ex)
            {
                return View(Ex);
            }
            return RedirectToAction("Index");
        }
        #endregion



        #region [DELETE] 
        [HttpGet]
        public IActionResult Delete()
        {
            return PartialView("_ModalDelete", new Modal
            {
                Message = "Are you sure you want to delete this  Product?",
                Size = ModalSize.Small,
                Header = new ModalHeader { Heading = "Delete  Product Master" },
                Footer = new ModalFooter { SubmitButtonText = "Yes", CancelButtonText = "No" }
            });
        }

        /// <summary>
        /// To delete the membership type
        /// </summary>
        /// <param name="id"></param>
        /// <param name="FC"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Delete(int id, IFormCollection FC)
        {
            string message;
            try
            {
                var data = _productService.GetById(id);
                if (data != null)
                {
                    _productService.Delete(id);
                }
                ShowSuccessMessage("Success!", "Product has been deleted successfully.", false);
                return RedirectToAction("index", "Product");
            }
            catch (Exception ex)
            {
                message = ex.GetBaseException().Message;
                if (message.Contains("DELETE statement conflicted"))
                    message = "Error";

                ShowErrorMessage("Success!", message, false);
                return RedirectToAction("index", "Agencies");
            }
        }

        #endregion [DELETE]
        private string GetUniqueFileName(string fileName)
        {
            // Generate a unique filename by appending a Guid to the file name
            var guid = Guid.NewGuid().ToString().Replace("-", "");
            var extension = Path.GetExtension(fileName).ToLower();
            return $"{guid}{extension}";
        }
        private ProductViewDto BindSubCategoryList(ProductViewDto model)
        {
            ViewBag.SubCategoryList = _productService.GetSubCategoryList().Select(s => new SelectListItem
            {
                Text = s.Title,
                Value = s.CategoryId.ToString()
            }).OrderBy(o => o.Text).ToList();

            return model;
        }

    }
}

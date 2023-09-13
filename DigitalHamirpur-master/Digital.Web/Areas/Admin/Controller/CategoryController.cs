using Digital.Core;
using Digital.Data.Models;
using Digital.Web.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Digital.Service;
using Digital.Dto;
using System.Linq;
using Digital.Web;

namespace Digital.Web.Areas.Admin.Controllers
{

    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;


        public CategoryController(ICategoryService categoryService)
        {

            _categoryService = categoryService;

        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(DataTables dataTable, bool? status)
        {
            CategoryViewDto vm = new CategoryViewDto();
            var sortColumnIndex = Convert.ToInt32(Request.Form["iSortCol_0"]);
            var sortDirection = Request.Form["sSortDir_0"];
            var projects = _categoryService.Get(dataTable, status, sortColumnIndex, sortDirection, out int totalCount);

            vm.BindGridViewData(dataTable, projects);

            return Ok(new DataTableResultExt(dataTable, vm.GridViewData.Count(), totalCount, vm.GridViewData));
        }

       

        #region[Add/Edit]
        [HttpGet]
        public IActionResult CreateEdit(int? id = null)
        {
            var model = new CategoryViewDto { };
            if (id.HasValue)
            {
                Categories entity = _categoryService.GetById(id.Value);
                model.CategoryId = entity.CategoryId;
                model.CategoryTitle = entity.CategoryTitle;
                model.CategoryDecription = entity.CategoryDecription;
                model.IsActive = entity.IsActive ?? true;

            }
            return View(model);
        }
        [HttpPost]
        public IActionResult CreateEdit(int? id, CategoryViewDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   
                    bool isExist = id.HasValue && id.Value != 0;                    
                    bool isStaticPageNameExist =_categoryService.Exists(model.CategoryId, model.CategoryTitle);
                    if (isStaticPageNameExist)
                    {
                        return NewtonSoftJsonResult(new RequestOutcome<string> { Data = "Category already exists.", IsSuccess = false });
                    }
                    var entity = isExist ? _categoryService.GetById(model.CategoryId) : new Categories();
                    entity.CategoryId = model.CategoryId;
                    entity.CategoryTitle = model.CategoryTitle;
                    entity.CategoryDecription = model.CategoryDecription;
                    if (isExist && id > 0)
                    {

                        entity.CreadtedOn = entity.CreadtedOn;
                        entity.CreatedBy = entity.CreatedBy;
                        entity.IsActive = model.IsActive;
                        // entity.UpdatedBy = CurrentUser.I;
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
                        _categoryService.Update(entity);
                    }
                    else
                    {
                        _categoryService.Save(entity);
                    }
                    ShowSuccessMessage("Success!", $"Category {(isExist ? "updated" : "created")} successfully", false);
                    return RedirectToAction("Index");
                    //return NewtonSoftJsonResult(new RequestOutcome<string> { RedirectUrl = Url.Action("Index"), IsSuccess = true });

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
                Message = "Are you sure you want to delete this  Category?",
                Size = ModalSize.Small,
                Header = new ModalHeader { Heading = "Delete  Category Master" },
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
                var data = _categoryService.GetById(id);
                if (data != null)
                {
                    _categoryService.Delete(id);
                }
                ShowSuccessMessage("Success!", "Category has been deleted successfully.", false);
                return RedirectToAction("index", "Category");
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







    }
}

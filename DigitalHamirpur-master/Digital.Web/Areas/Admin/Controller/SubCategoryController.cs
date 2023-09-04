using Digital.Data.Models;
using Digital.Dto;
using Digital.Service;
using Digital.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

namespace Digital.Web.Areas.Admin.Controllers
{

    public class SubCategoryController : BaseController
    {
        private readonly ISubcategoryService _subcategoryService;


        public SubCategoryController(ISubcategoryService subcategoryService)
        {

            _subcategoryService = subcategoryService;

        }

        public IActionResult Index()
        {
            return View();
        }

        

        #region[Add/Edit]
        [HttpGet]
        public IActionResult CreateEdit(int? id = null)
        {
            var model = new SubCategoryViewDto { };
            if (id.HasValue)
            {
                Subcategories entity = _subcategoryService.GetById(id.Value);
                model.CategoryId = entity.CategoryId;
                model.Title = entity.Title;
                model.Description = entity.Description;
                model.IsActive = entity.IsActive ?? true;

            }
            model = BindCategoryList(model);
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateEdit(int? id, SubCategoryViewDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    bool isExist = id.HasValue && id.Value != 0;
                    bool isStaticPageNameExist = _subcategoryService.Exists(model.SubcategoryId, model.Title);
                    if (isStaticPageNameExist)
                    {
                        return NewtonSoftJsonResult(new RequestOutcome<string> { Data = "Discount Category already exists.", IsSuccess = false });
                    }
                    var entity = isExist ? _subcategoryService.GetById(model.SubcategoryId) : new Subcategories();
                    entity.SubcategoryId = model.SubcategoryId;
                    entity.CategoryId = model.CategoryId;
                    entity.Title = model.Title;
                    entity.Description = model.Description;
                    if (isExist && id > 0)
                    {

                        entity.CreadetOn = entity.CreadetOn;
                        entity.CreatedBy = entity.CreatedBy;
                        entity.IsActive = model.IsActive;
                        // entity.UpdatedBy = CurrentUser.I;
                        entity.UpdatedOn = DateTime.Now;
                    }
                    else
                    {
                        // entity.CreatedBy = CurrentUser.Id;
                        entity.CreadetOn = DateTime.Now;
                        entity.IsActive = model.IsActive;
                    }
                    if (isExist)
                    {
                        _subcategoryService.Update(entity);
                    }
                    else
                    {
                        _subcategoryService.Save(entity);
                    }
                    //var entity1 = isExist ? _subcategoryService.Update(entity) : _subcategoryService.Save(entity);
                    ShowSuccessMessage("Success!", $"SubCategory {(isExist ? "updated" : "created")} successfully", false);
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

        private SubCategoryViewDto BindCategoryList(SubCategoryViewDto model)
        {
            ViewBag.CategoryList = _subcategoryService.GetCategoryList().Select(s => new SelectListItem
                {
                    Text = s.CategoryTitle,
                    Value = s.CategoryId.ToString()
                }).OrderBy(o => o.Text).ToList();

            return model;
        }
    }
}

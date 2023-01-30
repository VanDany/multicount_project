using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Multicount_Utility;
using Multicount_WEB.Models;
using Multicount_WEB.Models.Dto;
using Multicount_WEB.Models.VM;
using Multicount_WEB.Services;
using Multicount_WEB.Services.IServices;
using Newtonsoft.Json;
using System.Data;

namespace Multicount_WEB.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> IndexCategory()
        {
            List<CategoryDTO> list = new();
            var response = await _categoryService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response is not null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CategoryDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateCategory()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory(LocalUserCreateDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _categoryService.CreateAsync<APIResponse>(model, HttpContext.Session.GetString(SD.SessionToken));
                if (response is not null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexCategory));
                }
            }
            return View(model);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateCategory(int CategoryId)
        {
            CategoryUpdateVM categoryUpdateVM = new();
            var response = await _categoryService.GetAsync<APIResponse>(CategoryId, HttpContext.Session.GetString(SD.SessionToken));
            if (response is not null && response.IsSuccess)
            {
                CategoryDTO model = JsonConvert.DeserializeObject<CategoryDTO>(Convert.ToString(response.Result));
                categoryUpdateVM.Category = (_mapper.Map<CategoryUpdateDTO>(model));
            }
            response = await _categoryService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response is not null && response.IsSuccess)
            {
                return View(categoryUpdateVM);
            }
            return NotFound();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCategory(CategoryUpdateVM model)
        {
            if (ModelState.IsValid)
            {
                var response = await _categoryService.UpdateAsync<APIResponse>(model.Category, HttpContext.Session.GetString(SD.SessionToken));
                if (response is not null && response.IsSuccess)
                {
                    TempData["success"] = "Category updated successfully";
                    return RedirectToAction(nameof(IndexCategory));
                }
                else
                {
                    if (response.ErrorMessages.Count > 0)
                    {
                        ModelState.AddModelError("ErrorMessages", response.ErrorMessages.FirstOrDefault());
                    }
                }
            }
            TempData["error"] = "Error encountered.";
            return View(model);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            CategoryDeleteVM categoryDeleteVM = new();
            var response = await _categoryService.GetAsync<APIResponse>(categoryId, HttpContext.Session.GetString(SD.SessionToken));
            if (response is not null && response.IsSuccess)
            {
                CategoryDTO model = JsonConvert.DeserializeObject<CategoryDTO>(Convert.ToString(response.Result));
                categoryDeleteVM.Category = (_mapper.Map<CategoryDTO>(model));
            }
            response = await _categoryService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response is not null && response.IsSuccess)
            {
                return View(categoryDeleteVM);
            }
            return NotFound();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCategory(CategoryDTO model)
        {
            var response = await _categoryService.DeleteAsync<APIResponse>(model.Id, HttpContext.Session.GetString(SD.SessionToken));
            if (response is not null && response.IsSuccess)
            {
                TempData["success"] = "Category deleted successfully";
                return RedirectToAction(nameof(IndexCategory));
            }
            TempData["error"] = "Error encountered.";

            return View(model);
        }
    }
}

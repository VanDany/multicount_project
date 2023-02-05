using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Multicount_Utility;
using Multicount_WEB.Models;
using Multicount_WEB.Models.Dto;
using Multicount_WEB.Models.VM;
using Multicount_WEB.Services.IServices;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Claims;

namespace Multicount_WEB.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly ICategoryService _categoryService;
        private readonly ILocalUserService _localUserService;
        private readonly ITransactionUserService _transactionUserService;
        private readonly IMapper _mapper;

        public TransactionController(ICategoryService categoryService,ITransactionService transactionService, ILocalUserService localUserService, ITransactionUserService transactionUserService, IMapper mapper)
        {
            _transactionService = transactionService;
            _categoryService = categoryService;
            _mapper = mapper;
            _localUserService = localUserService;
            _transactionUserService= transactionUserService;
        }

        public async Task<IActionResult> IndexTransaction()
        {
            List<TransactionDTO> list = new();
            var response = await _transactionService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response is not null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<TransactionDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
        [Authorize(Roles ="admin")]
        public async Task<IActionResult> CreateTransaction()
        {
            TransactionCreateVM transactionCreateVM = new();
            var response = await _categoryService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response is not null && response.IsSuccess)
            {
                transactionCreateVM.CategoryList = JsonConvert.DeserializeObject<List<CategoryDTO>>(Convert.ToString(response.Result)).Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
            }

            var responseTransac = await _localUserService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (responseTransac is not null && responseTransac.IsSuccess)
            {
                transactionCreateVM.UsersId = JsonConvert.DeserializeObject<List<LocalUserDTO>>(Convert.ToString(responseTransac.Result)).Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
            }
            return View(transactionCreateVM);
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTransaction(TransactionCreateVM model)
        {
            if (ModelState.IsValid)
            {
                //var test = HttpContext.User.FindFirstValue("userId");
                var userId1 = model.Transaction.UsersId;
                var response = await _transactionService.CreateAsync<APIResponse>(model.Transaction, HttpContext.Session.GetString(SD.SessionToken));
                if (response is not null && response.IsSuccess)
                {
                    foreach (var user in userId1)
                    {
                        TransactionUserCreateDTO newTransactionUser = new TransactionUserCreateDTO
                        {
                            UserId = user,
                            TransactionId = JsonConvert.DeserializeObject<TransactionDTO>(Convert.ToString(response.Result)).Id
                        };
                        var responseTransactionUser = await _transactionUserService.CreateAsync<APIResponse>(newTransactionUser, HttpContext.Session.GetString(SD.SessionToken));
                    }
                    TempData["success"] = "Transaction created successfully";
                    return RedirectToAction(nameof(IndexTransaction));
                }

                else
                {
                    if (response.ErrorMessages.Count > 0 )
                    {
                        ModelState.AddModelError("ErrorMessages", response.ErrorMessages.FirstOrDefault());
                    }
                }
            }
            TempData["error"] = "Error encountered.";
            return View(model);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateTransaction(int TransactionId)
        {
            TransactionUpdateVM transactionVM = new();
            var response = await _transactionService.GetAsync<APIResponse>(TransactionId, HttpContext.Session.GetString(SD.SessionToken));
            if (response is not null && response.IsSuccess)
            {
                TransactionDTO model = JsonConvert.DeserializeObject<TransactionDTO>(Convert.ToString(response.Result));
                transactionVM.Transaction = (_mapper.Map<TransactionUpdateDTO>(model));
            }
            response = await _categoryService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response is not null && response.IsSuccess)
            {
                transactionVM.CategoryList = JsonConvert.DeserializeObject<List<CategoryDTO>>(Convert.ToString(response.Result)).Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
                return View(transactionVM);
            }
            return NotFound();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateTransaction(TransactionUpdateVM model)
        {
            if (ModelState.IsValid)
            {
                var response = await _transactionService.UpdateAsync<APIResponse>(model.Transaction, HttpContext.Session.GetString(SD.SessionToken));
                if (response is not null && response.IsSuccess)
                {
                    TempData["success"] = "Transaction updated successfully";
                    return RedirectToAction(nameof(IndexTransaction));
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
        public async Task<IActionResult> DeleteTransaction(int TransactionId)
        {
            TransactionDeleteVM transactionDeleteVM = new();
            var response = await _transactionService.GetAsync<APIResponse>(TransactionId, HttpContext.Session.GetString(SD.SessionToken));
            if (response is not null && response.IsSuccess)
            {
                TransactionDTO model = JsonConvert.DeserializeObject<TransactionDTO>(Convert.ToString(response.Result));
                transactionDeleteVM.Transaction = (_mapper.Map<TransactionDTO>(model));
            }
            response = await _categoryService.GetAllAsync<APIResponse>(HttpContext.Session.GetString(SD.SessionToken));
            if (response is not null && response.IsSuccess)
            {
                transactionDeleteVM.CategoryList = JsonConvert.DeserializeObject<List<CategoryDTO>>(Convert.ToString(response.Result)).Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
                return View(transactionDeleteVM);
            }
            return NotFound();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTransaction(TransactionDeleteVM model)
        {
            var response = await _transactionService.DeleteAsync<APIResponse>(model.Transaction.Id, HttpContext.Session.GetString(SD.SessionToken));
            if (response is not null && response.IsSuccess)
            {
                TempData["success"] = "Transaction deleted successfully";
                return RedirectToAction(nameof(IndexTransaction));
            }
            TempData["error"] = "Error encountered.";

            return View(model);
        }
    }
}

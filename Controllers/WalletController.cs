using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Real_Estate.Core.Application.Dto;
using Real_Estate.Core.Application.Interface.Service;

namespace Real_Estate.Controllers
{
    public class WalletController : Controller
    {
        private readonly IWalletservice _walletService;
        private readonly IProductService _productService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WalletController(IWalletservice walletService, IHttpContextAccessor httpContextAccessor, IProductService productService)
        {
            _walletService = walletService;
            _productService = productService;
            _httpContextAccessor = httpContextAccessor;
        }
        [Authorize]
        [HttpGet]
        public IActionResult CreditWallet()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreditWallet(AddToWalletRequestModel model)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (model.Amount <= 0)
            {
                ModelState.AddModelError("Amount", "Amount must be greater than Zero");
            }

            if (ModelState.IsValid)
            {
                var response = await _walletService.AddWallet(model, userId);

                if (response.Status)
                {
                    return RedirectToAction("Customer", "User");
                }
            }
            else
            {
                var wallet = await _walletService.Get(userId);
                return View(wallet.Data);
            }

            return View();
        }

        [Authorize]
        public async Task<IActionResult> Get(string id)
        {
            var wallet = await _walletService.Get(id);
            return View(wallet.Data);
        }

        [Authorize]
        [HttpGet]
        public IActionResult DebitWallet()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DebitWallet(double amount,string id)
        {
            var userId =  _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (amount <= 0)
            {
                ModelState.AddModelError("Amount", "Amount must be greater than Zero");
            }

            if (ModelState.IsValid)
            {
                var response = await _walletService.Debit(new DebitFromWalletRequestModel { Amount = amount }, userId);

                if (response.Status)
                {
                   var message = await _productService.PurchaseProduct(id);
                   if(message.Status)
                   {
                    TempData["SuccessMessage"]= message.Message;
                   }
                    return RedirectToAction("Customer", "User");
                }
                TempData["ErrorMessage"] = "Insufficient funds. Please make sure you have enough funds in your wallet.";
            }
            else
            {
                var wallet = await _walletService.Get(userId);
                return View(wallet.Data);
            }

            return RedirectToAction("List", "Product");
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using cookiesSource = Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Real_Estate.Core.Application.Dto;
using Real_Estate.Core.Application.Interface.Service;

namespace Real_Estate.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestModel model)
        {
            var response = await _userService.Login(model);
            if (response.Status)
            {
                var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,response.Data.Id),
                new Claim(ClaimTypes.Email, response.Data.Email),
                new Claim(ClaimTypes.Role, response.Data.Roles.Name),
            };
                var claimIdentity = new ClaimsIdentity(claims, cookiesSource.CookieAuthenticationDefaults.AuthenticationScheme);
                var claimPrincipal = new ClaimsPrincipal(claimIdentity);

                await HttpContext.SignInAsync(claimPrincipal);
                //    return RedirectToAction("Index, Home");
                TempData["Successful"] = response.Message;
                if (response.Data.Roles.Name =="Admin")
                {
                    return RedirectToAction("Admin");
                }
                else if (response.Data.Roles.Name == "Manager")
                {
                    return RedirectToAction("Manager");
                }
                else if (response.Data.Roles.Name == "customer")
                {
                    return RedirectToAction("Customer");
                }
            }
            TempData["message"] = response.Message;
            return View();
        }

        public IActionResult Admin()
        {
            return View();
        }

        public IActionResult Manager()
        {
            return View();
        }

        public IActionResult Customer()
        {
            return View();
        }
        public IActionResult Logout()
        {

            HttpContext.SignOutAsync(cookiesSource.CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
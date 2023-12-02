using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Real_Estate.Core.Application.Dto;
using Real_Estate.Core.Application.Interface.Service;

namespace Real_Estate.Controllers
{
    public class ProfileController : Controller
    {
      private readonly IProfileService _profileService;
      public ProfileController(IProfileService profile)
      {
         _profileService = profile;
      } 

      [HttpGet] 
      public IActionResult Register()
      {
         return View();
      }

      [HttpPost]
      public async Task<IActionResult> Register(ProfileRequestMode model)
        {
         var profile =  await _profileService.Register(model);
         if(profile != null)
         {
            TempData["message"] = profile.Message;
         }
         return RedirectToAction("Login","User");
        }

        public async Task<IActionResult> Get(string id)
        {
            var profile= await _profileService.GetById(id);
            return View(profile.Data);
        }

         public async Task<IActionResult> GetByEmail(string email)
        {
            var profile= await _profileService.GetByEmail(email);
            return View(profile.Data);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customer= await _profileService.GetAll();
            return View(customer.Data);
        }

    }
}
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
    public class RoleController : Controller
    {
       private readonly IRoleService _roleService;
       public RoleController(IRoleService roleService)
       {
         _roleService = roleService;
       } 

       [Authorize]
       [HttpGet]
       public IActionResult Add()
       {
         return View();
       }

       [Authorize]
       [HttpPost]
       
       public  async Task<IActionResult> Add(RoleRequestMode model)
       {
        if (ModelState.IsValid)
            {
                var response = await _roleService.Register(model);
                TempData["message"] = response.Message;
                if (response.Status)
                {
                    return RedirectToAction("List");
                }

            }
            return View(model);
       }

       [Authorize]
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var roles =  await _roleService.GetAll();
            return View(roles.Data);
        }
    }
}
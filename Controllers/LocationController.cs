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
    public class LocationController : Controller
    {
       private readonly ILocationService _locationService;
       public LocationController(ILocationService location)
       {
         _locationService = location;
       } 

       [HttpGet]
       public IActionResult Register()
       {
          return View();
       }

    //    [HttpPost]
    //    public async Task<IActionResult> Register(LocationRequestMode model)
    //    {
    //      var location = await _locationService.Register(model);
    //      if(location != null)
    //      {
    //         TempData["Exist"] = location.Message;
    //      }
    //      return RedirectToAction("GetAll");
    //    }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
           var location = await _locationService.Get(id);
            return View(location.Data);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> RealDelete(string id)
        {
            await _locationService.Delete(id);
            return RedirectToAction("GetAll");
        }

        public async Task<IActionResult> Get(string id)
        {
            var location= await _locationService.GetById(id);
            return View(location.Data);
        }

        public async Task<IActionResult> GetByState(string state)
        {
            var location= await _locationService.Get(state);
            return View(location.Data);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var location= await _locationService.GetAll();
            return View(location.Data);
        }
    } 
}
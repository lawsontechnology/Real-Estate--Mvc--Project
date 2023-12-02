using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Real_Estate.Core.Application.Interface.Service;

namespace Real_Estate.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Get()
        {
            return View();
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var customer = await _customerService.GetById(id);
            return View(customer.Data);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        public IActionResult RealDelete(string id)
        {
            _customerService.Delete(id);
            return RedirectToAction("GetAll");
        }

        public async Task<IActionResult> Get(string id)
        {
            var customer = await _customerService.GetById(id);
            return View(customer.Data);
        }



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customer = await _customerService.GetAll();
            return View(customer.Data);
        }
    }
}
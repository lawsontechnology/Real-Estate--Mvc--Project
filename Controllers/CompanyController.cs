using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Real_Estate.Core.Application.Dto;
using Real_Estate.Core.Application.Interface.Service;

namespace Real_Estate.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
           _companyService = companyService; 
        }

        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CompanyRequestMode model)
        {
           var company = await _companyService.Register(model);
           if(company != null)
           {
             TempData["message"] = company.Message;
           }
           return View();
        }
    }
}
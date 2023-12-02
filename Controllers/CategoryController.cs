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
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService category)
        {
          _categoryService = category; 
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        // [HttpPost]
        // public async Task<IActionResult> Add(CategoryRequestMode model)
        // {
        //     var category = await _categoryService.Add(model);
        //     if(category != null)
        //     {
        //         TempData["Exist"] = category.Message;
        //     }
        //     return RedirectToAction("List");
        // } 

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var category = await _categoryService.GetAll();
            return View(category.Data);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Details(string name)
        {
            var category = await _categoryService.GetByName(name);
            return View(category.Data);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get(double price)
        {
            var category = await _categoryService.GetByPrice(price);
            return View(category.Data);

        }

        [Authorize]
        [HttpGet]
        public IActionResult Delete (string id)
        {
            return View();
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> ActualDelete (string id)
        {
            await _categoryService.Delete(id);
            return RedirectToAction("List");
        }
    }
}
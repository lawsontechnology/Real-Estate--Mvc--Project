using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Real_Estate.Core.Application.Dto;
using Real_Estate.Core.Application.Interface.Service;
using System;
using System.IO;

namespace Real_Estate.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IProductService product, IWebHostEnvironment webHostEnvironment)
        {
            _productService = product;
            _webHostEnvironment = webHostEnvironment;
        }  

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(ProductRequestMode model, IFormFile ProductImage)
        {
            string productImagePath = Path.Combine(_webHostEnvironment.WebRootPath,"ProductImages");
            Directory.CreateDirectory(productImagePath);
            string ContextType = ProductImage.ContentType.Split('/')[1];
            string image = $"Property{Guid.NewGuid()}.{ContextType}";
            string fullPath = Path.Combine(productImagePath,image);
            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
              ProductImage.CopyTo(fileStream);  
            }
            model.ProductImage = image;
            var product = await _productService.Register(model);
            if (product is not null)
            {
                TempData["message"] = product.Message;
            }
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var product = await _productService.GetAll();
            return View(product.Data);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateValue(string name)
        {
            var product = await _productService.GetByName(name);
            var updateModel = new ProductUpdateModel
            {
                Price = product.Data.Price,
                ProductCode = product.Data.ProductCode,
                Type = product.Data.Type,
            };
            return View(updateModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Update(ProductUpdateModel model)
        {
            await _productService.Update(model);
            return RedirectToAction("Register");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var product = await _productService.GetById(id);
            return View(product.Data);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get(string name)
        {
            var product = await _productService.GetByName(name);
            return View(product.Data);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Delete(string id)
        {
            return View();
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        public IActionResult ActualDelete(string id)
        {
            _productService.Delete(id);
            return RedirectToAction("List");
        }
    }
}
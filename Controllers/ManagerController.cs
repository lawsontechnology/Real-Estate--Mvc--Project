using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Real_Estate.Core.Application.Dto;
using Real_Estate.Core.Application.Interface.Service;

namespace Real_Estate.Controllers
{
    public class ManagerController : Controller
    {
        private readonly IManagerService _managerService;
        public ManagerController(IManagerService manager)
        {
            _managerService = manager;
        }

    
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ManagerRequestMode model)
        {
            var manager = await _managerService.Register(model);
            if (manager != null)
            {
                TempData["message"] = manager.Message;
            }
            return RedirectToAction("List");

        }


        public async Task<IActionResult> List()
        {
            var manager = await _managerService.GetAll();
            return View(manager.Data);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get(string staffNumber)
        {
            var manager = await _managerService.Get(staffNumber);
            return View(manager.Data);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Delete(string id)
        {
            return View();
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> ActualDelete(string id)
        {
            await _managerService.Delete(id);
            return RedirectToAction("List");
        }
    }
}
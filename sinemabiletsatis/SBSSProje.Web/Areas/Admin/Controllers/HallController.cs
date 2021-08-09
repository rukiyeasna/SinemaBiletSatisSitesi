using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SBSSProje.Business.Interfaces;
using SBSSProje.Entities.Concrete;
using SBSSProje.Web.Areas.Admin.Models;

namespace SBSSProje.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class HallController : Controller
    {
        private readonly IBranchService _branchService;
        private readonly IHallService _hallService;
        public HallController(IBranchService branchService, IHallService hallService)
        {
            _branchService = branchService;
            _hallService = hallService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddHall()
        {
            ViewBag.Branches = new SelectList(_branchService.GetirHepsi(), "BranchId", "BranchName");
            return View(new HallAddViewModel());
        }

        [HttpPost]
        public IActionResult AddHall(HallAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                _hallService.Kaydet(new Hall
                {
                    HallName = model.HallName,
                    BranchId = model.BranchId
                });
                return RedirectToAction("Index","Branch");
            }
            return View(model);
        }

    }
}

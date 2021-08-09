using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SBSSProje.Business.Interfaces;
using SBSSProje.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using SBSSProje.Entities.Concrete;
using SBSSProje.Web.Areas.Admin.Models;

namespace SBSSProje.Web.Areas.Admin.Controllers
{

    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class BranchController : Controller
    {
        SbssContext db = new SbssContext();
        private readonly IBranchService _branchService;
        private readonly IHallService _hallService;
        public BranchController(IBranchService branchService, IHallService hallService)
        {
            _branchService = branchService;
            _hallService = hallService;
        }

        public IActionResult Index()
        {
            TempData["Active"] = "branches";
            List<Branch> branches = _branchService.GetirHepsi().Where(x => x.Status == true).ToList();
            List<BranchListViewModel> model = new List<BranchListViewModel>();
            foreach (var item in branches)
            {
                BranchListViewModel branchModel = new BranchListViewModel();
                branchModel.BranchId = item.BranchId;
                branchModel.BranchName = item.BranchName;
                branchModel.City = item.City;
                branchModel.Address = item.Address;

                model.Add(branchModel);
            }
            return View(model);
        }

        public IActionResult AddBranch()
        {
            TempData["Active"] = "sube";
            return View(new BranchListViewModel());
        }

        [HttpPost]
        public IActionResult AddBranch(BranchListViewModel model)
        {
            if (ModelState.IsValid)
            {
                _branchService.Kaydet(new Branch
                {
                    BranchId = model.BranchId,
                    BranchName = model.BranchName,
                    City = model.City,
                    Address = model.Address,
                    Status = true

                });

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult UpdateBranch(int id)
        {

            TempData["Active"] = "movie";
            var branch = _branchService.GetirIdile(id);
            BranchListViewModel model = new BranchListViewModel
            {
                BranchId = branch.BranchId,
                BranchName = branch.BranchName,
                City = branch.City,
                Address = branch.Address,               
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateBranch(BranchListViewModel model)
        {
            if (ModelState.IsValid)
            {
                _branchService.Guncelle(new Branch
                {
                    BranchId = model.BranchId,
                    BranchName = model.BranchName,
                    City = model.City,
                    Address = model.Address,
                    Status=true
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult DeleteBranch(int id)
        {
            var a = db.branches.Find(id);
            a.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

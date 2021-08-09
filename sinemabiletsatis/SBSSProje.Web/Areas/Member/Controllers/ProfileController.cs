using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SBSSProje.Business.Interfaces;
using SBSSProje.Entities.Concrete;
using SBSSProje.Web.Areas.Member.Models;

namespace SBSSProje.Web.Areas.Member.Controllers
{
    [Authorize(Roles = "Member")]
    [Area("Member")]
    public class ProfileController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly ISalesService _salesService;
        public ProfileController(UserManager<AppUser> userManager, ISalesService salesService)
        {
            _userManager = userManager;
            _salesService = salesService;
        }
        public async Task<IActionResult> Index()
        {
            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            AppUserListViewModel model = new AppUserListViewModel();
            model.Id = appUser.Id;
            model.Name = appUser.Name;
            model.Surname = appUser.SurName;
            model.Email = appUser.Email;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserListViewModel model)
        {
            var guncellenecekKullanici = _userManager.Users.FirstOrDefault(I => I.Id == model.Id);
            if (ModelState.IsValid)
            {
                guncellenecekKullanici.Name = model.Name;
                guncellenecekKullanici.SurName = model.Surname;
                guncellenecekKullanici.Email = model.Email;
                var result = await _userManager.UpdateAsync(guncellenecekKullanici);
                if (result.Succeeded)
                {
                    TempData["message"] = "Güncelleme işleminiz başarı ile gerçekleşti";
                    return RedirectToAction("Index");
                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Ticket()
        {
            List<Sales> sales = _salesService.GetirHepsi().ToList();
            var appUser = await _userManager.FindByIdAsync(User.Identity.Name);
            SalesViewModel model1 = new SalesViewModel();
            List<SalesViewModel> model = new List<SalesViewModel>();
            if (model1.Id == appUser.Id)
            {
                foreach (var item in sales)
                {
                    SalesViewModel movieModel = new SalesViewModel();
                    movieModel.MovieName = item.MovieName;     
                    movieModel.Date = item.Date;

                    model.Add(movieModel);
                }
            }
            //model.Id = appUser.Id;
            //model.Name = appUser.Name;
            //model.Surname = appUser.SurName;
          
            return View(model);
        }
    }
}

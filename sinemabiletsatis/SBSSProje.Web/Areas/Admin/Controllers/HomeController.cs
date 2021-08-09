using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SBSSProje.Business.Interfaces;
using SBSSProje.DataAccess.Concrete.EntityFrameworkCore.Contexts;

namespace SBSSProje.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IMBHService _mBHService;
        SbssContext db = new SbssContext();
        public HomeController(IMBHService mBHService)
        {         
            _mBHService = mBHService;   
        }
        public IActionResult Index()
        {
            TempData["Active"] = "home";
            var movie = _mBHService.GetirHepsi();
            var model = db.mBHs.ToList();       
            db.mBHs.Include(I => I.Branch).ToList();
            db.mBHs.Include(I => I.Hall).ToList();
            db.mBHs.Include(I => I.Movie).ToList();
            return View(model);
        }
    }
}

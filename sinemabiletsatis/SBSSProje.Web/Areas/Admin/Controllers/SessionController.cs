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
    public class SessionController : Controller
    {
        private readonly IBranchService _branchService;
        private readonly IHallService _hallService;
        private readonly IMBHService _mBHService;
        private readonly IMovieService _movieService;
        SbssContext db = new SbssContext();
        public SessionController(IBranchService branchService, IHallService hallService, 
            IMBHService mBHService, IMovieService movieService)
        {
            _movieService = movieService;
            _mBHService = mBHService;
            _branchService = branchService;
            _hallService = hallService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddSession()
        {           
            ViewBag.Movies = new SelectList(_movieService.GetirHepsi().Where(I => I.Status == true),
                "MovieId", "MovieName");
            ViewBag.Branches = new SelectList(_branchService.GetirHepsi(), "BranchId", "BranchName");
            ViewBag.Halls = new SelectList(_hallService.GetirHepsi(), "HallId", "HallName");
            return View(new SessionAddViewModel());

        }

        [HttpPost]
        public IActionResult AddSession(SessionAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                _mBHService.Kaydet(new MBH
                {
                    MovieId = model.MovieId,
                    BranchId = model.BranchId,
                    HallId = model.HallId,
                    Date = model.Date,
                    Hour = model.Hour
                });
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        public IActionResult DateSorting()
        {
            List<MBH> movies = _mBHService.GetirHepsi().ToList();
            List<SessionAddViewModel> model = new List<SessionAddViewModel>();
            foreach (var item in movies)
            {
                SessionAddViewModel movieModel = new SessionAddViewModel();
                movieModel.MovieId = item.MovieId;
                movieModel.BranchId = item.BranchId;
                movieModel.HallId = item.HallId;
                movieModel.Hour = item.Hour;
                movieModel.Date = item.Date;

                model.Add(movieModel);
            }
            return View(model);
        }      
    }
}

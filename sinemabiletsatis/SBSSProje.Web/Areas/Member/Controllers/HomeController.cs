using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SBSSProje.Business.Interfaces;
using SBSSProje.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using SBSSProje.Entities.Concrete;
using SBSSProje.Web.Areas.Member.Models;

namespace SBSSProje.Web.Areas.Member.Controllers
{
    [Authorize(Roles = "Member")]
    [Area("Member")]
    public class HomeController : Controller
    {
        SbssContext db = new SbssContext();
        private readonly IMovieService _movieService;
        private readonly IMBHService _mBHService;
        private readonly ISalesService _salesService;
        // private Object Button;
        public HomeController(IMovieService movieService, IMBHService mBHService, ISalesService salesService)
        {
            _movieService = movieService;
            _mBHService = mBHService;
            _salesService = salesService;
        }
        public IActionResult Index()
        {
            List<Movie> movies = _movieService.GetirHepsi().Where(x => x.Status == true).ToList();
            List<MovieViewModel> model = new List<MovieViewModel>();
            foreach (var item in movies)
            {
                MovieViewModel moviesModel = new MovieViewModel();
                moviesModel.MovieId = item.MovieId;
                moviesModel.MovieName = item.MovieName;
                moviesModel.Director = item.Director;
                moviesModel.Cast = item.Cast;
                moviesModel.Time = item.Time;
                moviesModel.Type = item.Type;
                moviesModel.Explanation = item.Explanation;
                moviesModel.Picture = item.Picture;
                moviesModel.Trailer = item.Trailer;
                moviesModel.Date = item.Date;
                model.Add(moviesModel);
            }
            return View(model);
        }

        public IActionResult Movieinformation(int id)
        {

            var movie = _movieService.GetirIdile(id);
            MovieViewModel model = new MovieViewModel();
            model.MovieId = movie.MovieId;
            model.MovieName = movie.MovieName;
            model.Director = movie.Director;
            model.Cast = movie.Cast;
            model.Explanation = movie.Explanation;
            model.Date = movie.Date;
            model.Time = movie.Time;
            model.Picture = movie.Picture;
            model.Type = movie.Type;
            model.Trailer = movie.Trailer;
            return View(model);
        }

        public IActionResult MovieInformation2(int id)
        {

            var movie = _movieService.GetirIdile(id);
            MovieViewModel model = new MovieViewModel();
            ViewBag.id = movie.MovieId;
            ViewBag.MovieName = movie.MovieName;
            ViewBag.Director = movie.Director;
            ViewBag.Cast = movie.Cast;
            ViewBag.Explanation = movie.Explanation;
            ViewBag.Date = movie.Date;
            ViewBag.Time = movie.Time;
            ViewBag.Picture = movie.Picture;
            ViewBag.Type = movie.Type;
            ViewBag.Trailer = movie.Trailer;

            var models = db.mBHs.Where(x => x.MovieId == movie.MovieId).ToList();
            db.mBHs.Include(I => I.Branch).ToList();
            db.mBHs.Include(I => I.Hall).ToList();
            db.mBHs.Include(I => I.Movie).ToList();
            return View(models);
        }

        public IActionResult koltukDeneme(int id)
        {

            //var movie = _movieService.GetirIdile(id);
            //MovieViewModel model = new MovieViewModel();
            //ViewBag.id = movie.MovieId;
            //ViewBag.MovieName = movie.MovieName;     
            //ViewBag.Picture = movie.Picture;            

            //var models = db.mBHs.Where(x => x.MovieId == movie.MovieId).FirstOrDefault();

            //db.mBHs.Include(I => I.Branch).FirstOrDefault();
            //db.mBHs.Include(I => I.Hall).FirstOrDefault();
            //db.mBHs.Include(I => I.Movie).FirstOrDefault();
            //ViewBag.a = models.Branch.BranchName;
            //ViewBag.b = models.Hall.HallName;
            //ViewBag.c = models.Date;
            //return View(models);
            var seans = _mBHService.GetirIdile(id);
            var models = db.mBHs.Where(x => x.Id == seans.Id).ToList();
            ViewBag.f = db.mBHs.Include(I => I.Branch).ToList();
            db.mBHs.Include(I => I.Hall).ToList();
            db.mBHs.Include(I => I.Movie).ToList();
            return View(models);
        }

        public IActionResult Sales(int id)
        {
            return View();

        }

        [HttpPost]
        public IActionResult Sales(SalesViewModel model)
        {
            if (ModelState.IsValid)
            {
                _salesService.Kaydet(new Sales
                {

                });
                return RedirectToAction("Index", "Branch");
            }
            return View(model);
        }

        
    }
}

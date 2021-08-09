using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SBSSProje.Business.Concrete;
using SBSSProje.Business.Interfaces;
using SBSSProje.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using SBSSProje.Entities.Concrete;
using SBSSProje.Web.Areas.Admin.Models;

namespace SBSSProje.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class MovieController : Controller
    {
        SbssContext db = new SbssContext();
        private readonly IMovieService _movieService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHostingEnvironment _environment;

        public MovieController(IMovieService movieService, UserManager<AppUser> userManager, IHostingEnvironment environment)
        {
            _environment = environment;
            _userManager = userManager;
            _movieService = movieService;
        }
        public IActionResult Index()
        {
            TempData["Active"] = "movies";
            List<Movie> movies = _movieService.GetirHepsi().Where(x => x.Status == true).ToList();
            List<MovieListViewModel> model = new List<MovieListViewModel>();
            foreach (var item in movies)
            {
                MovieListViewModel movieModel = new MovieListViewModel();
                movieModel.MovieId = item.MovieId;
                movieModel.MovieName = item.MovieName;
                movieModel.Director = item.Director;
                movieModel.Cast = item.Cast;
                movieModel.Time = item.Time;
                movieModel.Type = item.Type;
                movieModel.Explanation = item.Explanation;
                movieModel.Picture = item.Picture;
                movieModel.Trailer = item.Trailer;
                movieModel.Date = item.Date;

                model.Add(movieModel);
            }
            return View(model);
        }

        public IActionResult AddMovie()
        {
            TempData["Active"] = "movies";
            return View(new MovieAddViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie(MovieAddViewModel model)
        {
            var resimler = Path.Combine(_environment.WebRootPath, "img");
            if (model.ResimDosyasi.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(resimler, model.ResimDosyasi.FileName),
                    FileMode.Create))
                {
                    await model.ResimDosyasi.CopyToAsync(fileStream);

                }
            }
            model.Picture = model.ResimDosyasi.FileName;
            if (ModelState.IsValid)
            {
                _movieService.Kaydet(new Movie
                {

                    MovieName = model.MovieName,
                    Director = model.Director,
                    Cast = model.Cast,
                    Time = model.Time,
                    Type = model.Type,
                    Explanation = model.Explanation,
                    Picture = model.ResimDosyasi.FileName,
                    Trailer = model.Trailer,
                    Date=model.Date,
                    Status = true
                });

                return RedirectToAction("Index");
            }
            return View(model);
        }



        public IActionResult UpdateMovie(int id)
        {

            TempData["Active"] = "movie";
            var movie = _movieService.GetirIdile(id);
            MovieUpdateViewModel model = new MovieUpdateViewModel
            {
                MovieId = movie.MovieId,
                MovieName = movie.MovieName,
                Director = movie.Director,
                Cast = movie.Cast,
                Time = movie.Time,
                Type = movie.Type,
                Explanation = movie.Explanation,
                Picture = movie.Picture,
                Trailer = movie.Trailer,
                Date= movie.Date
               // Status=true
                
                
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateMovie(MovieUpdateViewModel model, IFormFile resim)
        {
            if (ModelState.IsValid)
            {
                _movieService.Guncelle(new Movie
                {
                    MovieId = model.MovieId,
                    MovieName = model.MovieName,
                    Director = model.Director,
                    Cast = model.Cast,
                    Time = model.Time,
                    Type = model.Type,
                    Explanation = model.Explanation,
                    Picture = model.Picture,
                    Trailer = model.Trailer,
                    Date = model.Date,
                    Status = true

                });
                return RedirectToAction("Index");
            }
            return View(model);

        }

        public IActionResult DeleteMovie(int id)
        {
            var a = db.movies.Find(id);
            a.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

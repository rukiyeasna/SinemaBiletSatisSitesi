using SBSSProje.Business.Interfaces;
using SBSSProje.DataAccess.Interfaces;
using SBSSProje.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBSSProje.Business.Concrete
{
    public class MovieManager : IMovieService
    {
        private readonly IMovieDal _movieDal;
        public MovieManager(IMovieDal movieDal)
        {
            _movieDal = movieDal;
        }
        public List<Movie> GetirHepsi()
        {
            return _movieDal.GetirHepsi();
        }

        public Movie GetirIdile(int id)
        {
            return _movieDal.GetirIdile(id);
        }

        public void Guncelle(Movie tablo)
        {
            _movieDal.Guncelle(tablo);
        }

        public void Kaydet(Movie tablo)
        {
            _movieDal.Kaydet(tablo);
        }

        public void Sil(Movie tablo)
        {
            _movieDal.Sil(tablo);
        }
    }
}

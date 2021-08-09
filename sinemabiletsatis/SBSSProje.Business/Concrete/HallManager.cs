using SBSSProje.Business.Interfaces;
using SBSSProje.DataAccess.Interfaces;
using SBSSProje.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBSSProje.Business.Concrete
{
    public class HallManager : IHallService
    {
        private readonly IHallDal _hallDal;
        public HallManager(IHallDal hallDal)
        {
            _hallDal = hallDal;
        }
        public List<Hall> GetirHepsi()
        {
            return _hallDal.GetirHepsi();
        }

        public Hall GetirIdile(int id)
        {
            return _hallDal.GetirIdile(id);
        }

        public void Guncelle(Hall tablo)
        {
            _hallDal.Guncelle(tablo);
        }

        public void Kaydet(Hall tablo)
        {
            _hallDal.Kaydet(tablo);
        }

        public void Sil(Hall tablo)
        {
            _hallDal.Sil(tablo);
        }
    }
}

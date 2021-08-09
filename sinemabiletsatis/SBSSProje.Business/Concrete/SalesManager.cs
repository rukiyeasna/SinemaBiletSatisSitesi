using SBSSProje.Business.Interfaces;
using SBSSProje.DataAccess.Interfaces;
using SBSSProje.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBSSProje.Business.Concrete
{
    public class SalesManager : ISalesService
    {
        private readonly ISalesDal _salesDal;
        public SalesManager(ISalesDal salesDal)
        {
            _salesDal = salesDal;
        }
        public List<Sales> GetirHepsi()
        {
            return _salesDal.GetirHepsi();
        }

        public Sales GetirIdile(int id)
        {
            return _salesDal.GetirIdile(id);
        }

        public void Guncelle(Sales tablo)
        {
            _salesDal.Guncelle(tablo);
        }

        public void Kaydet(Sales tablo)
        {
            _salesDal.Kaydet(tablo);
        }

        public void Sil(Sales tablo)
        {
            _salesDal.Sil(tablo);
        }
    }
}

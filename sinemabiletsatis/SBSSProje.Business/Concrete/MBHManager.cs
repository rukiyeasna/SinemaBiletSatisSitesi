using SBSSProje.Business.Interfaces;
using SBSSProje.DataAccess.Interfaces;
using SBSSProje.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBSSProje.Business.Concrete
{
    public class MBHManager : IMBHService
    {
        private readonly IMBHDal _mBHDal;
        public MBHManager(IMBHDal mBHDal)
        {
            _mBHDal = mBHDal;
        }
        public List<MBH> GetirHepsi()
        {
            return _mBHDal.GetirHepsi();
        }

        public MBH GetirIdile(int id)
        {
            return _mBHDal.GetirIdile(id);
        }

        public void Guncelle(MBH tablo)
        {
            _mBHDal.Guncelle(tablo);
        }

        public void Kaydet(MBH tablo)
        {
            _mBHDal.Kaydet(tablo);
        }

        public void Sil(MBH tablo)
        {
            _mBHDal.Sil(tablo);
        }
    }
}

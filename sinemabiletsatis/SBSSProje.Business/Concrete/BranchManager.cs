using SBSSProje.Business.Interfaces;
using SBSSProje.DataAccess.Interfaces;
using SBSSProje.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBSSProje.Business.Concrete
{
    public class BranchManager : IBranchService
    {
        private readonly IBranchDal _branchDal;

        public BranchManager(IBranchDal branchDal)
        {
            _branchDal = branchDal;
        }
        public List<Branch> GetirHepsi()
        {
            return _branchDal.GetirHepsi();
        }

        public Branch GetirIdile(int id)
        {
            return _branchDal.GetirIdile(id);
        }

        public void Guncelle(Branch tablo)
        {
            _branchDal.Guncelle(tablo);
        }

        public void Kaydet(Branch tablo)
        {
            _branchDal.Kaydet(tablo);
        }

        public void Sil(Branch tablo)
        {
            _branchDal.Sil(tablo);
        }
    }
}

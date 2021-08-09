using SBSSProje.DataAccess.Interfaces;
using SBSSProje.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBSSProje.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfHallRepository : EfGenericRepository<Hall>, IHallDal
    {
    }
}

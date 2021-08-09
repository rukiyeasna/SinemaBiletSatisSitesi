using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SBSSProje.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBSSProje.DataAccess.Concrete.EntityFrameworkCore.Contexts
{
    public class SbssContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public List<Movie> deger1;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-JRCPL4O\\SQLEXPRESS; database=SBSS; integrated security=true;");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Branch> branches { get; set; }
        public DbSet<Hall> halls { get; set; }
        public DbSet<MBH> mBHs { get; set; }
        public DbSet<Movie> movies { get; set; }
        public DbSet<Sales> sales { get; set; }
    }
}

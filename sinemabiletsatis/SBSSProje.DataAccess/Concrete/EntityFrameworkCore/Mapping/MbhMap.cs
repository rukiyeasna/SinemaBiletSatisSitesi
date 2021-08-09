using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SBSSProje.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBSSProje.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class MbhMap : IEntityTypeConfiguration<MBH>
    {
        public void Configure(EntityTypeBuilder<MBH> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.HasOne<Movie>(f => f.Movie)
                .WithMany(s => s.mBHs)
                .HasForeignKey(f => f.MovieId);

            builder.HasOne<Branch>(f => f.Branch)
                .WithMany(s => s.mBHs)
                .HasForeignKey(f => f.BranchId);

            builder.HasOne<Hall>(f => f.Hall)
                .WithMany(s => s.mBHs)
                .HasForeignKey(f => f.HallId);
        }
    }
}

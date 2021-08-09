using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SBSSProje.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBSSProje.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class HallMap : IEntityTypeConfiguration<Hall>
    {
        public void Configure(EntityTypeBuilder<Hall> builder)
        {
            builder.HasKey(I => I.HallId);
            builder.Property(I => I.HallId).UseIdentityColumn();

            builder.HasOne<Branch>(f => f.Branch)
                .WithMany(s => s.halls)
                .HasForeignKey(f => f.BranchId);
        }
    }
}

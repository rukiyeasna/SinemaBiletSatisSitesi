using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SBSSProje.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBSSProje.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class SalesMap : IEntityTypeConfiguration<Sales>
    {
        public void Configure(EntityTypeBuilder<Sales> builder)
        {
            builder.HasKey(I => I.SalesId);
            builder.Property(I => I.SalesId).UseIdentityColumn();
        }
    }
}

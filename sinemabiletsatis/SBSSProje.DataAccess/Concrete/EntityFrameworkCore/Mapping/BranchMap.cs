using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SBSSProje.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBSSProje.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class BranchMap : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasKey(I => I.BranchId);
            builder.Property(I => I.BranchId).UseIdentityColumn();
        }
    }
}

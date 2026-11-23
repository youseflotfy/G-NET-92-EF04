using EfcoreAssignment4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfcoreAssignment4.Configurations
{
    internal class AccountConfigyration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(a => a.AccountNumber);
            builder.HasOne(a => a.branch).WithMany(c => c.accounts).HasForeignKey(a =>a.branchId);
            builder.Property(a => a.AccountNumber)
              .ValueGeneratedNever();
        }
    }
}

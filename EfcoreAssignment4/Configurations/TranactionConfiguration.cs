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
    internal class TranactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(t => t.TransactionNumber);

            builder.HasOne(t => t.account).WithMany(a => a.transactions).HasForeignKey(t => t.accountID);
        }
    }
}

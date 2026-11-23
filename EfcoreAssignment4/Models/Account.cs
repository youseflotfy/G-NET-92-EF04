using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfcoreAssignment4.Models
{
    internal class Account
    {
        public int AccountNumber { get; set; }
        public decimal CurrentBalance { get; set; }
        public AccountType AccountType { get; set; }
        public DateTime OpeningDate { get; set; }
        public Branch branch { get; set; } = null!;
        public int branchId { get; set; }

        public ICollection<Transaction> transactions { get; set; } = new HashSet<Transaction>();

        public ICollection<CustomerAccount> CustomerAccounts { get; set; } = new HashSet<CustomerAccount>();

    }
}
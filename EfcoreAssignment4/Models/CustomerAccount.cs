using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfcoreAssignment4.Models
{
    internal class CustomerAccount
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public int AccountNumber { get; set; }
        public Account Account { get; set; } = null!;
        public OwnershipType OwnershipType { get; set; }
        public AccountStatus AccountStatus { get; set; }
    }
}

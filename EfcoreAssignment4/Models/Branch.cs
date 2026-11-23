using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfcoreAssignment4.Models
{
    internal class Branch
    {
        public int Code { get; set; }
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        public string PhoneNumber { get; set; } = null!;

        public Manager manager { get; set; } = null!;

        public ICollection<Account> accounts { get; set; } = new HashSet<Account>();
    }
}

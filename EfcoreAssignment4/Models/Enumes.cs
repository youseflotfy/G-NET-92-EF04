using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfcoreAssignment4.Models
{
    internal enum AccountType
    {
        Savings,
        Business,
        Current
    }

    internal enum CustomerType
    {
        Individual,
        Business
    }

    internal enum TransactionType
    {
        Deposit,
        Withdrawal,
        Transfer
    }

    internal enum OwnershipType
    {
        Primary,
        CoHolder
    }

    internal enum AccountStatus
    {
        Active,
        Closed
    }
}

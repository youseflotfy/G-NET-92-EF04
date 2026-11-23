using EfcoreAssignment4.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfcoreAssignment4.Screens
{
    internal class RemoveAccountFromCustomer
    {
        public static void RemoveCustomer(BankContext context)
        {
            Console.WriteLine("\n--- Remove Account from Customer ---");

            Console.Write("Customer Id      : ");
            int customerId = int.Parse(Console.ReadLine()!);

            Console.Write("Account Number   : ");
            int accountNumber = int.Parse(Console.ReadLine()!);

            var customerAccount = context.CustomerAccounts
                .FirstOrDefault(ca => ca.CustomerId == customerId && ca.AccountNumber == accountNumber);

            if (customerAccount == null)
            {
                Console.WriteLine($"No link found between Customer #{customerId} and Account '{accountNumber}'.");
                return;
            }

            context.CustomerAccounts.Remove(customerAccount);
            context.SaveChanges();

            Console.WriteLine($"Account '{accountNumber}' removed from Customer #{customerId}.");
        }
    }
}

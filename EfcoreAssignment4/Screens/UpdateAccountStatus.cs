using EfcoreAssignment4.Contexts;
using EfcoreAssignment4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfcoreAssignment4.Screens
{
    internal class UpdateAccountStatus
    {
        public static void UpdateStatus(BankContext context)
        {
            Console.WriteLine("\n--- Update Account Status ---");

            Console.Write("Account Number   : ");
            int accountNumber = int.Parse(Console.ReadLine()!);

            Console.Write("Customer Id      : ");
            int customerId = int.Parse(Console.ReadLine()!);

            var customerAccount = context.CustomerAccounts
                .FirstOrDefault(ca => ca.AccountNumber == accountNumber && ca.CustomerId == customerId);

            if (customerAccount == null)
            {
                Console.WriteLine($"No account link found for Account '{accountNumber}' and Customer #{customerId}.");
                return;
            }

            Console.WriteLine($"Current Status   : {customerAccount.AccountStatus}");
            Console.WriteLine("New Status:");
            Console.WriteLine("  1) Active");
            Console.WriteLine("  2) Closed");
            Console.Write("Choice: ");
            int statusChoice = int.Parse(Console.ReadLine()!);

            AccountStatus newStatus = statusChoice == 1
                ? AccountStatus.Active
                : AccountStatus.Closed;

            customerAccount.AccountStatus = newStatus;
            context.SaveChanges();

            Console.WriteLine($"Account '{accountNumber}' status updated to {newStatus}.");
        }
    }
}

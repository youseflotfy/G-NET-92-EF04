using EfcoreAssignment4.Contexts;
using EfcoreAssignment4.Models;

namespace EfcoreAssignment4.Screens
{
    internal static class AccountScreen
    {
        public static void OpenAccount(BankContext context)
        {
            Console.WriteLine("\n--- Open New Account ---");

            Console.Write("Account Number   : ");
            int accountNumber = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Account Type:");
            Console.WriteLine("  1) Savings");
            Console.WriteLine("  2) Current");
            Console.WriteLine("  3) Business");
            Console.Write("Choice: ");
            int typeChoice = int.Parse(Console.ReadLine()!);

            AccountType accountType = typeChoice switch
            {
                1 => AccountType.Savings,
                2 => AccountType.Current,
                _ => AccountType.Business
            };

            Console.Write("Branch Code      : ");
            int branchCode = int.Parse(Console.ReadLine()!);

            Console.Write("Customer Id      : ");
            int customerId = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Ownership Role:");
            Console.WriteLine("  1) Primary");
            Console.WriteLine("  2) CoHolder");
            Console.Write("Choice: ");
            int roleChoice = int.Parse(Console.ReadLine()!);

            OwnershipType ownershipType = roleChoice == 1
                ? OwnershipType.Primary
                : OwnershipType.CoHolder;

            Console.WriteLine($"Validating branch '{branchCode}' and customer #{customerId}...");

            bool branchExists = context.Branches.Any(b => b.Code == branchCode);
            var customer = context.Customers.FirstOrDefault(c => c.Id == customerId);

            if (!branchExists || customer == null)
            {
                if (!branchExists)
                    Console.WriteLine($"Branch with code '{branchCode}' was not found.");
                if (customer == null)
                    Console.WriteLine($"Customer with ID #{customerId} was not found.");
             
                return;
            }

            if (context.Accounts.Any(a => a.AccountNumber == accountNumber))
            {
                Console.WriteLine($"Account '{accountNumber}' already exists.");
                return;
            }

            var account = new Account
            {
                AccountNumber = accountNumber,
                AccountType = accountType,
                CurrentBalance = 0m,
                OpeningDate = DateTime.Now,
                branchId = branchCode
            };

            var customerAccount = new CustomerAccount
            {
                CustomerId = customerId,
                AccountNumber = accountNumber,
                OwnershipType = ownershipType,
                AccountStatus = AccountStatus.Active
            };

            context.Accounts.Add(account);
            context.CustomerAccounts.Add(customerAccount);
            context.SaveChanges();

            Console.WriteLine($"Account '{accountNumber}' created and linked to customer {customerId} as {ownershipType} owner.");
        }
    }
}
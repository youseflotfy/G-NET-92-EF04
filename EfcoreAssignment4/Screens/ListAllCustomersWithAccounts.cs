using EfcoreAssignment4.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfcoreAssignment4.Screens
{
    internal class ListAllCustomersWithAccounts
    {
public static void ListAllCustomersAccounts(BankContext context)
    {
        Console.WriteLine("\n--- All Customers (with Accounts) ---");

        var customers = context.Customers
            .Include(c => c.CustomerAccounts)
                .ThenInclude(ca => ca.Account)
            .ToList();

        if (customers.Count == 0)
        {
            Console.WriteLine("No customers found.");
            return;
        }

        foreach (var customer in customers)
        {
            Console.WriteLine($"\nCustomer #{customer.Id} | {customer.FullName} | National ID: {customer.NationalId} | Type: {customer.CustomerType}");
            Console.WriteLine($"  Email: {customer.Email} | Phone: {customer.PhoneNumber} | Address: {customer.Address}");

 

            Console.WriteLine("  Accounts:");
                foreach (var ca in customer.CustomerAccounts)
                {
                    Console.WriteLine($"    - Account #{ca.Account.AccountNumber} | Type: {ca.Account.AccountType} | Balance: {ca.Account.CurrentBalance} | Role: {ca.OwnershipType} | Status: {ca.AccountStatus}");
                }
            }
    }
}
}

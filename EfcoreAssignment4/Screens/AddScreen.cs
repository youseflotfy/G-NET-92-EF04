using EfcoreAssignment4.Contexts;
using EfcoreAssignment4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfcoreAssignment4.Screens
{
    internal static class AddScreen
    {
        public static void AddCustomer(BankContext context) 
        {
            Console.WriteLine("\n--- Add New Customer ---");
            Console.Write("Full Name        : ");
            string fullName = Console.ReadLine()!;

            Console.Write("National ID      : ");
            string nationalId = Console.ReadLine()!;

            Console.Write("Date of Birth    : (yyyy-MM-dd) ");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine()!);

            Console.Write("Email            : ");
            string email = Console.ReadLine()!;

            Console.Write("Phone            : ");
            string phone = Console.ReadLine()!;

            Console.Write("Address          : ");
            string address = Console.ReadLine()!;

            Console.WriteLine("Customer Type:");
            Console.WriteLine("1) Individual");
            Console.WriteLine("2) Business");
            Console.Write("Choice: ");
            int typeChoice = int.Parse(Console.ReadLine()!);

            CustomerType customerType = typeChoice == 1
                ? CustomerType.Individual
                : CustomerType.Business;


            var customer = new Customer
            {
                FullName = fullName,
                NationalId = nationalId,
                DateOfBirth = dateOfBirth,
                Email = email,
                PhoneNumber = phone,
                Address = address,
                CustomerType = customerType
            };

            context.Customers.Add(customer);
            context.SaveChanges();

            Console.WriteLine($"\nCustomer created successfully. CustomerId = {customer.Id}");

        }
    }
}

using EfcoreAssignment4.Contexts;
using EfcoreAssignment4.Models;
using EfcoreAssignment4.Screens;
using System.Diagnostics;

namespace Efcore
{
    internal class MyClass
    {
        static void Main(string[] args)
        {
            using BankContext context = new BankContext();

            if (!context.Branches.Any())
            {
                var cairoBranch = new Branch
                {
                    Name = "Cairo Main Branch",
                    Address = "Tahrir Square, Cairo",
                    PhoneNumber = "0227940001"
                };

                var alexBranch = new Branch
                {
                    Name = "Alexandria Branch",
                    Address = "Stanley, Alexandria",
                    PhoneNumber = "035460002"
                };

                context.Branches.AddRange(cairoBranch, alexBranch);
                context.SaveChanges();
                var manager1 = new Manager
                {
                    FullName = "Ahmed Hassan",
                    Email = "ahmed.hassan@bank.com",
                    PhoneNumber = "01000000001",
                    HireDate = new DateTime(2022, 1, 15),
                    BranchId = cairoBranch.Code
                };

                var manager2 = new Manager
                {
                    FullName = "Mona Adel",
                    Email = "mona.adel@bank.com",
                    PhoneNumber = "01000000002",
                    HireDate = new DateTime(2023, 3, 10),
                    BranchId = alexBranch.Code
                };

                context.Managers.AddRange(manager1, manager2);
                context.SaveChanges();
            }

            while (true)
            {
                InitailScreen.Initail();

                string Choice = Console.ReadLine()!;

                switch(Choice)
                {
                    case "1":
                        AddScreen.AddCustomer(context);
                        break;
                    case "2":
                        AccountScreen.OpenAccount(context);
                        break;
                    case "3":
                        UpdateAccountStatus.UpdateStatus(context);
                        break;
                    case "4":
                        RemoveAccountFromCustomer.RemoveCustomer(context);
                        break;
                    case "5":
                        ListAllCustomersWithAccounts.ListAllCustomersAccounts(context);
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Enter valid number between 0 to 5");
                        break;




                }



            }

           
        }
    }
}
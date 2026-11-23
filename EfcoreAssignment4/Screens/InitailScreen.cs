using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfcoreAssignment4.Screens
{
    internal static class InitailScreen
    {

        public static void Initail() 
        {
            Console.WriteLine("========================================");
            Console.WriteLine("National Bank - Management");
            Console.WriteLine("========================================");
            Console.WriteLine("1) Add a new Customer");
            Console.WriteLine("2) Open a new Account for a Customer");

            Console.WriteLine("3) Update Account Status (Active / Closed)");

            Console.WriteLine("4) Remove an Account from a Customer");

            Console.WriteLine("5) List all Customers (with accounts)");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Enter choice:");

        }
    }
}

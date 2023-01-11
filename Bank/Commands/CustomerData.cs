using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Commands
{
    internal class CustomerData
    {
        public string FirstName { get; }
        public string LastName { get; }
        public long IdNumber { get; }

        public CustomerData(string firstName, string lastName, string idNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            IdNumber = long.Parse(idNumber);
        }

        public static CustomerData ReadCustomerData()
        {
            string firstName, lastName, idNumber;
            Console.WriteLine("Podaj dane klienta:");
            Console.Write("Imię: ");
            firstName = Console.ReadLine();
            Console.Write("Nazwisko: ");
            lastName = Console.ReadLine();
            Console.Write("PESEL: ");
            idNumber = Console.ReadLine();

            return new CustomerData(firstName, lastName, idNumber);
        }
    }
}

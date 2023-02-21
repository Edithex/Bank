using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class Printer : IPrinter
    {
        public void Print(Account account)
        {
            Console.WriteLine("Numer konta: {0}", account.AccountNumber);
            Console.WriteLine("Stan konta: {0} zł", account.GetBalance());
            Console.WriteLine("Typ konta: {0}", account.Type);
            Console.WriteLine("Imię i nazwisko: {0}", account.GetFullName());
            Console.WriteLine("Numer Pesel: {0}", account.IdNumber);
            Console.WriteLine();
        }

        public void Print(IEnumerable<Account> accounts)
        {
            
            foreach (Account account in accounts)
            {
                Console.WriteLine($"Numer konta: {account.AccountNumber} Saldo: {account.Balance} zł Typ: {account.Type}");
            };
        }


        public void PrintAllElements(IEnumerable<Account> accounts)
        {

            foreach (Account account in accounts)
            {
                Console.WriteLine($"Imię i nazwisko: {account.FirstName} {account.LastName} Numer konta: {account.AccountNumber} Saldo: {account.Balance} zł");
            };
        }


    }
}

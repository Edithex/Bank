using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class Printer
    {
        public void Print(SavingsAccount account)
        {
            Console.WriteLine("Numer konta: {0}", account.AccountNumber);
            Console.WriteLine("Stan konta: {0} zł", account.GetBalance());
            Console.WriteLine("Imię i nazwisko: {0}", account.GetFullName());
            Console.WriteLine("Numer Pesel: {0}", account.IdNumber);
            Console.WriteLine();
        }

        public void Print(BillingAccount account)
        {
            Console.WriteLine("Numer konta: {0}", account.AccountNumber);
            Console.WriteLine("Stan konta: {0} zł", account.GetBalance());
            Console.WriteLine("Imię i nazwisko: {0}", account.GetFullName());
            Console.WriteLine("Numer Pesel: {0}", account.IdNumber);
            Console.WriteLine();
        }

    }
}

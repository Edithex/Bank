using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class SmallerPrinter : IPrinter
    {
        public void Print(Account account)
        {
            Console.WriteLine("Numer konta: {0}", account.AccountNumber);
            Console.WriteLine("Imię i nazwisko: {0}", account.GetFullName());
            Console.WriteLine();
        }
    }
}

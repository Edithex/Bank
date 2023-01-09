using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Commands
{
    internal class ListOfAccountsCommand : ICommand
    {
        private AccountManager AccountManager;
        private Printer Printer;

        public ListOfAccountsCommand(AccountManager accountManager, Printer printer)
        {
            AccountManager = accountManager;
            Printer = printer;

        }

        public string GetName()
        {
            return "1";
        }

        public string GetDescription()
        {
            return "Lista kont klienta";
        }


        public void Run()
        {
            Console.Clear();
            //CustomerData data = ReadCustomerData();

            //tu powinna być funkcja
            string firstName, lastName, idNumber;
            Console.WriteLine("Podaj dane klienta:");
            Console.Write("Imię: ");
            Console.ReadLine();
            firstName = Console.ReadLine();
            Console.Write("Nazwisko: ");
            lastName = Console.ReadLine();
            Console.Write("PESEL: ");
            idNumber = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Konta klienta {0} {1} {2}", firstName, lastName, idNumber);
            Console.WriteLine();

            foreach (Account account in AccountManager.GetAllAccountsFor(firstName, lastName, long.Parse(idNumber)))
            {
                Printer.Print(account);
            }
        }
        
}
}

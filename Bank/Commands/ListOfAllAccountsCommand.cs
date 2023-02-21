using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Commands
{
    internal class ListOfAllAccountsCommand : ICommand
    {
        private AccountManager AccountManager;

        public ListOfAllAccountsCommand(AccountManager accountManager)
        {
            AccountManager = accountManager;

        }

        public string GetName()
        {
            return "6";
        }

        public string GetDescription()
        {
            return "Lista wszystkich kont";
        }


        public void Run()
        {
            Console.Clear();
            Console.WriteLine("Lista wszystkich kont:");
            Console.WriteLine();
            Console.WriteLine("KONTA OSZCZĘDNOŚCIOWE:");
            Console.WriteLine();
            foreach (string account in AccountManager.ListOfCustomersAccountSavings())
            {
                Console.WriteLine(account);
            }
            Console.WriteLine();
            Console.WriteLine("KONTA ROZLICZENIOWE:");
            Console.WriteLine();
            foreach (string account in AccountManager.ListOfCustomersAccountBilling())
            {
                Console.WriteLine(account);
            }

            Console.ReadKey();
        }
    }
}

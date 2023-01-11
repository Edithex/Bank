using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Commands
{
    internal class ListOfAllAccounts : ICommand
    {
        private AccountManager AccountManager;
        private Printer Printer;

        public ListOfAllAccounts(AccountManager accountManager)
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
            Console.WriteLine("Lista klientów:");

            foreach (string customer in AccountManager.ListOfCustomers())
            {
                Console.WriteLine(customer);
            }
            Console.ReadKey();
        }
    }
}

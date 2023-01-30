using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Commands
{
    internal class GetAccountsCommand : ICommand
    {
        private AccountManager AccountManager;

        public GetAccountsCommand(AccountManager accountManager)
        {
            AccountManager = accountManager;
        }

        public string GetName()
        {
            return "9";
        }

        public string GetDescription()
        {
            return "Pobierz dane";
        }


        public void Run()
        {
            AccountManager.GetAllAccountsFromDataBase();
            Console.WriteLine("Konta oszczędnościowe:");
            foreach (string customer in AccountManager.ListOfCustomersAccountSavings())
            {
                Console.WriteLine(customer);
            }
            Console.WriteLine("Konta rozliczeniowe:");
            foreach (string customer in AccountManager.ListOfCustomersAccountBilling())
            {
                Console.WriteLine(customer);
            }
            Console.ReadKey();
        }
    }
}

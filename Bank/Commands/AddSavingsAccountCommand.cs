using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Commands
{
    internal class AddSavingsAccountCommand : ICommand
    {
        private AccountManager AccountManager;
        private Printer Printer;
        private CustomerData CustomerData;

        public AddSavingsAccountCommand(AccountManager accountManager, Printer printer)
        {
            AccountManager = accountManager;
            Printer = printer;

        }

        public string GetName()
        {
            return "3";
        }

        public string GetDescription()
        {
            return "Otwarcie konta oszczędnościowego";
        }


        public void Run()
        {
            Console.Clear();
            CustomerData data = CustomerData.ReadCustomerData();
            Account savingsAccount = AccountManager.CreateSavingsAccount(data.FirstName, data.LastName, data.IdNumber);
            AccountManager.SaveToFile(data.FirstName, data.LastName, data.IdNumber);
            Console.Clear();
            Console.WriteLine("Utworzono konto rozliczeniowe:");
            Printer.Print(savingsAccount);
            Console.ReadKey();
        }

    }
}

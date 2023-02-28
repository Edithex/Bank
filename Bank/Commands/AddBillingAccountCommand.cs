using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Commands
{
    internal class AddBillingAccountCommand : ICommand
    {

        private AccountManager AccountManager;
        private Printer Printer;

        public AddBillingAccountCommand(AccountManager accountManager, Printer printer)
        {
            AccountManager = accountManager;
            Printer = printer;
        }

        public int GetName()
        {
            return (int)CommandsName.AddBillingAccounts;
        }

        public string GetDescription()
        {
            return "Otwarcie konta rozliczeniowego";
        }


        public void Run()
        {
            Console.Clear();
            CustomerData data = CustomerData.ReadCustomerData();
            Account billingAccount = AccountManager.CreateBillingAccount(data.FirstName, data.LastName, data.IdNumber);
            Console.Clear();
            Console.WriteLine("Utworzono konto rozliczeniowe:");
            Printer.Print(billingAccount);
            Console.ReadKey();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Commands
{
    internal class AddMoneyCommand : ICommand
    {
        private AccountManager AccountManager;
        private Printer Printer;

        public AddMoneyCommand(AccountManager accountManager, Printer printer)
        {
            AccountManager = accountManager;
            Printer = printer;

        }
        
        public string GetName()
        {
            return "4";
        }

        public string GetDescription()
        {
            return "Wpłata pieniędzy na konto";
        }


        public void Run()
        {
            string accountNumber;
            decimal value;
            Console.Clear();
            Console.WriteLine("Podaj numer konta");
            accountNumber = Console.ReadLine();
            Console.WriteLine("Podaj kwotę do wpłaty");
            value = decimal.Parse(Console.ReadLine());
            AccountManager.AddMoney(accountNumber, value);
            Account account = AccountManager.GetAccount(accountNumber);
            Printer.Print(account);
            Console.ReadKey();
        }
    }
}

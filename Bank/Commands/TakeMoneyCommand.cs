using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Commands
{
    internal class TakeMoneyCommand : ICommand
    {

        private AccountManager AccountManager;
        private Printer Printer;

        public TakeMoneyCommand(AccountManager accountManager, Printer printer)
        {
            AccountManager = accountManager;
            Printer = printer;

        }
        
        public string GetName()
        {
            return "5";
        }

        public string GetDescription()
        {
            return "Wypłata pieniędzy na konto";
        }


        public void Run()
        {

            string accountNumber;
            decimal value;
            Console.Clear();
            Console.WriteLine("Podaj numer konta");
            accountNumber = Console.ReadLine();
            Account account = AccountManager.GetAccount(accountNumber);
            Console.WriteLine("Podaj kwotę do wypłaty");
            value = decimal.Parse(Console.ReadLine());
            AccountManager.TakeMoney(accountNumber, value);
            Printer.Print(account);
            Console.ReadKey();

        }
    }
}

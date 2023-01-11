using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Commands
{
    internal class CloseMonthCommand : ICommand
    {
        private AccountManager AccountManager;
        private Printer Printer;

        public CloseMonthCommand(AccountManager accountManager)
        {
            AccountManager = accountManager;

        }

        public string GetName()
        {
            return "7";
        }

        public string GetDescription()
        {
            return "Zamknięcie miesiąca";
        }


        public void Run()
        {
            Console.Clear();
            AccountManager.CloseMonth();
            Console.WriteLine("Miesiąc zamknięty");
            Console.ReadKey();
        }
    }
}

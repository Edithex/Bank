using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Commands
{
    internal class Menu
    {
        private IEnumerable<ICommand> Commands;

        public Menu(AccountManager accountManager, Printer printer)
        {
            Commands = new ICommand[]
            {
                new ListOfAccountsCommand(accountManager, printer),
                new AddBillingAccountCommand(accountManager, printer),
                new AddSavingsAccountCommand(accountManager, printer),
                new AddMoneyCommand(accountManager, printer),
                new TakeMoneyCommand(accountManager, printer),
                new ListOfAllAccountsCommand(accountManager),
                new CloseMonthCommand(accountManager),
                new SaveCommand(accountManager),
                new GetAccountsCommand(accountManager)
            };
        }
       
        public void Run()
        {
            string action;
            do
            {
                Console.WriteLine("MENU SYSTEMU BANKOWEGO");
                Console.WriteLine();
                foreach (ICommand command in Commands)
                {
                    Console.WriteLine("{0} - {1}", command.GetName(), command.GetDescription());
                    Console.WriteLine();
                }
                    Console.Write("Wpisz nr akcji: ");
                    action = Console.ReadLine();
                    //if (string.IsNullOrEmpty(action))
                    //{
                        RunCommand(action);
                    //}
                
            }
            while (action != "0");

        }

        public void RunCommand(string name) 
        {
            if (name == "0")
                return;

            ICommand selected = null;

            foreach(ICommand command in Commands)
            { 
                if(command.GetName() == name)
                {
                    selected = command;
                    break;
                }
            }

            if(selected!= null) 
            {
                Console.Clear();
                selected.Run();
                Console.Clear();
            }

            else
            {
                Console.WriteLine("!!! Nieznana komenda");
            }
        }

    }
}

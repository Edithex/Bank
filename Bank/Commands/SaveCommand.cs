using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Commands
{
    internal class SaveCommand : ICommand
    {
        private AccountManager AccountManager;

        public SaveCommand(AccountManager accountManager)
        {
            AccountManager = accountManager;
        }

        public string GetName()
        {
            return "8";
        }

        public string GetDescription()
        {
            return "Zapisz dane";
        }


        public void Run()
        {
            Console.Clear();
            using (var sw = new StreamWriter("C:\\Users\\kurow\\source\\repos\\Bank\\Bank\\TextFile\\AccountsDataBase.txt"))
            {
                foreach (string customer in AccountManager.ListOfCustomers())
                {
                    sw.WriteLine(customer);
                }
            }
            Console.Clear();
            Console.WriteLine("Zapisano wprowadzone dane kont do pliku");
            Console.ReadKey();
        }
    }
}

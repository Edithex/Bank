using System;
using System.Collections.Generic;
using System.IO;
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

        public int GetName()
        {
            return (int)CommandsName.SavingToFile;
        }

        public string GetDescription()
        {
            return "Zapisz dane do pliku";
        }


        public void Run()
        {
            Console.Clear();
            string dirname = Directory.GetCurrentDirectory().ToString();
            string parent = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString() + "\\TextFile";

            if (!Directory.Exists(parent))
            {
                Directory.CreateDirectory(parent);
            }

            using (StreamWriter sw = File.AppendText(parent + "\\AccountsDataBase.txt"))
            {
                sw.WriteLine(DateTime.Now);
                sw.WriteLine("Konta oszczędnościowe:");
                foreach (string account in AccountManager.ListOfCustomersAccountSavings())
                {
                    sw.WriteLine(account);
                }
                sw.WriteLine("Konta rozliczeniowe:");
                foreach (string account in AccountManager.ListOfCustomersAccountBilling())
                {
                    sw.WriteLine(account);
                }
                sw.WriteLine();
                sw.Close();
            } 

            Console.WriteLine("Zapisano wprowadzone dane kont do pliku");
            Console.WriteLine($"Ścieżka do pliku: {parent + "\\AccountsDataBase.txt"}");
            Console.ReadKey();
        }
    }
}

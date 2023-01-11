﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Commands
{
    internal class ListOfAccountsCommand : ICommand
    {
        private AccountManager AccountManager;
        private Printer Printer;
        private CustomerData CustomerData;

        public ListOfAccountsCommand(AccountManager accountManager, Printer printer)
        {
            AccountManager = accountManager;
            Printer = printer;

        }

        public string GetName()
        {
            return "1";
        }

        public string GetDescription()
        {
            return "Lista kont klienta";
        }


        public void Run()
        {
            Console.Clear();
            CustomerData data = CustomerData.ReadCustomerData();
            Console.WriteLine("Konta klienta {0} {1} {2}", data.FirstName, data.LastName, data.IdNumber);
            Console.WriteLine();

            foreach (Account account in AccountManager.GetAllAccountsFor(data.FirstName, data.LastName, data.IdNumber))
            {
                Printer.Print(account);
            }
            Console.ReadKey();
        }
        
}
}

using System;
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
            Console.WriteLine("Wyszukaj konto po:");
            Console.WriteLine("1 - Imię i nazwisko");
            Console.WriteLine("2 - Pesel");
            var choice = Console.ReadLine();
            while (choice != "0")
            {
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Podaj imię i nazwisko");
                        var firstName = Console.ReadLine();
                        var lastName = Console.ReadLine();

                        IEnumerable<Account> savingsAccounts = AccountManager.GetSavingsAccountsFor(firstName, lastName);
                        IEnumerable<Account> billingAccounts = AccountManager.GetBillingAccountsFor(firstName, lastName);
                        Console.WriteLine($"Lista kont dla: {firstName} {lastName}");
                        if (savingsAccounts.Any())
                        {
                            Console.Clear();
                            Console.WriteLine($"Konta rozliczeniowe");
                            Printer.Print(savingsAccounts);
                            break;
                        }
                        else if (billingAccounts.Any())
                        {
                            Console.Clear();
                            Console.WriteLine($"Konta rozliczeniowe");
                            Printer.Print(billingAccounts);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Nie znaleziono kont dla podanych danych");
                            break;
                        };
                    case "2":
                        Console.WriteLine("Podaj pesel");
                        var id = Console.ReadLine();
                        long idNumber;
                        if (long.TryParse(id, out idNumber))
                        {
                            savingsAccounts = AccountManager.GetSavingsAccountsFor(idNumber);
                            billingAccounts = AccountManager.GetBillingAccountsFor(idNumber);
                            
                            if (savingsAccounts.Any())
                            {   Console.Clear();
                                Console.WriteLine($"Konta rozliczeniowe");
                                Printer.Print(savingsAccounts);
                                break;
                            }
                            else if (billingAccounts.Any())
                            {   
                                Console.Clear();
                                Console.WriteLine($"Konta rozliczeniowe");
                                Printer.Print(billingAccounts);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Nie znaleziono kont dla podanych danych");
                                break;
                            };
                        }
                        else
                        {
                            Console.WriteLine("Błędny numer pesel!");
                            break;
                        }
                       default:
                            Console.WriteLine("Zła komenda!");
                            break;

                }
                Console.WriteLine();
                Console.WriteLine("Podaj poprawną komendę (Powrót do menu - 0)");
                choice = Console.ReadLine();
                
            }

                Console.ReadKey();
        }
        
}
}

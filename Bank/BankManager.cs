using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class BankManager
    {
        private AccountManager _accountManager;
        private IPrinter _printer;

        public BankManager()
        {
            _accountManager = new AccountManager();
            _printer = new Printer();
        }

        private void PrintMainMenu()
        {
            Console.Clear();
            Console.WriteLine("SYSTEM BANKOWY");
            Console.WriteLine();
            Console.WriteLine("Wybierz akcję:");
            Console.WriteLine("1 - Lista kont klienta");
            Console.WriteLine("2 - Dodaj konto rozliczeniowe");
            Console.WriteLine("3 - Dodaj konto oszczędnościowe");
            Console.WriteLine("4 - Wpłać pieniądze na konto");
            Console.WriteLine("5 - Wypłać pieniądze z konta");
            Console.WriteLine("6 - Lista klientów");
            Console.WriteLine("7 - Wszystkie konta");
            Console.WriteLine("8 - Zakończ miesiąc");
            Console.WriteLine("0 - Zakończ");
        }

        private int SelectedAction()
        {
            Console.WriteLine();
            Console.Write("Wpisz nr akcji: ");
            string action = Console.ReadLine();
            if(string.IsNullOrEmpty(action))
            {
                return -1;
            }
            return int.Parse(action);
        }




        public void Run()
        {
            int action;
            do
            {
                PrintMainMenu();
                action = SelectedAction();

                switch (action)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Wybrano listę kont klienta");
                        Console.Clear();
                        ListOfAccounts();
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Wybrano otwarcie konta rozliczeniowego");
                        Console.Clear();
                        AddBillingAccount();
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Wybrano otwarcie konta oszczędnościowego");
                        AddSavingsAccount();
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Wybrano wpłatę pieniędzy na konto");
                        Console.Clear();
                        AddMoney();
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Wybrano wypłatę pieniędzy z konta");
                        Console.Clear();
                        TakeMoney();
                        Console.ReadKey();
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("Wybrano listę klientów");
                        Console.Clear();
                        ListOfCustomers();
                        Console.ReadKey();
                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine("Wybrano listę wszystkich kont");
                        Console.Clear();
                        ListOfAllAccounts();
                        Console.ReadKey();
                        break;
                    case 8:
                        Console.Clear();
                        Console.WriteLine("Wybrano zamknięcie miesiąca");
                        Console.Clear();
                        CloseMonth();
                        Console.ReadKey();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Nieznane polecenie");
                        Console.ReadKey();
                        break;
                }

            }
            while (action!= 0);
        }
        private void AddBillingAccount()
        {
            Console.Clear();
            CustomerData data = ReadCustomerData();
            Account billingAccount = _accountManager.CreateBillingAccount(data.FirstName, data.LastName, data.IdNumber);
            Console.Clear();
            Console.WriteLine("Utworzono konto rozliczeniowe:");
            _printer.Print(billingAccount);
            Console.ReadKey();
        }

        private void AddSavingsAccount()
        {
            Console.Clear();
            CustomerData data = ReadCustomerData();
            Account savingAccount = _accountManager.CreateSavingsAccount(data.FirstName, data.LastName, data.IdNumber);
            Console.Clear();
            Console.WriteLine("Utworzono konto oszczędnościowe");
            _printer.Print(savingAccount); 
            Console.ReadKey();
        }

        private void ListOfAccounts()
        {
            Console.Clear();
            CustomerData data = ReadCustomerData();
            Console.WriteLine();
            Console.WriteLine("Konta klienta {0} {1} {2}", data.FirstName, data.LastName);
            Console.WriteLine();

            foreach (Account account in _accountManager.GetAllAccountsFor(data.FirstName, data.LastName, data.IdNumber))
            {
                _printer.Print(account);
            }

        }

        private void AddMoney()
        {
            string accountNumber;
            decimal value;
            Console.Clear();
            Console.WriteLine("Podaj numer konta");
            accountNumber = Console.ReadLine();
            Console.WriteLine("Podaj kwotę do wpłaty");
            value = decimal.Parse(Console.ReadLine());
            _accountManager.AddMoney(accountNumber, value);
            Account account = _accountManager.GetAccount(accountNumber);
            _printer.Print(account);
        }

        private void TakeMoney()
        {
            string accountNumber;
            decimal value;
            Console.Clear();
            Console.WriteLine("Podaj numer konta");
            accountNumber = Console.ReadLine();
            Console.WriteLine("Podaj kwotę do wypłaty");
            value = decimal.Parse(Console.ReadLine());
            _accountManager.TakeMoney(accountNumber, value);
            Account account = _accountManager.GetAccount(accountNumber);
            _printer.Print(account);
        }

        private void ListOfCustomers()
        {
            Console.Clear();
            Console.WriteLine("Lista klientów:");
            
            foreach(string customer in _accountManager.ListOfCustomers())
            {
                Console.WriteLine(customer);
            }
            Console.ReadKey();

        }

        private void ListOfAllAccounts()
        {
            Console.Clear();
            Console.WriteLine("Lista kont:");

            foreach (Account account in _accountManager.GetAllAccounts())
            {
                _printer.Print(account);
            }
            Console.ReadKey();

        }

        private void CloseMonth()
        {
            Console.Clear();
            _accountManager.CloseMonth();
            Console.WriteLine("Miesiąc zamknięty");
            Console.ReadKey();
        }

        private CustomerData ReadCustomerData()
        {
            string firstName, lastName, idNumber;
            Console.WriteLine("Podaj dane klienta:");
            Console.Write("Imię: ");
            firstName = Console.ReadLine();
            Console.Write("Nazwisko: ");
            lastName = Console.ReadLine();
            Console.Write("PESEL: ");
            idNumber = Console.ReadLine();

            return new CustomerData(firstName, lastName, idNumber);
        }
    }
    class CustomerData
    {
        public string FirstName { get; }
        public string LastName { get; }
        public long IdNumber { get; }

        public CustomerData(string firstName, string lastName, string idNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            IdNumber = long.Parse(idNumber);
        }
    }
}

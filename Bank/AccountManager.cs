using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class AccountManager
    {
        private IList<Account> _accounts;
 

        public AccountManager()
        {
            _accounts= new List<Account>();
        }


        public IEnumerable<Account> GetAllAccounts()
        {
            return _accounts;
        }

        
        public SavingsAccount CreateSavingsAccount(string firstName, string lastName, long idNumber)
        {
            int id = generateId();

            SavingsAccount account = new SavingsAccount(id, firstName, lastName, idNumber);

            _accounts.Add(account);

            return account;
        }

        public BillingAccount CreateBillingAccount(string firstName, string lastName, long idNumber)
        {
            int id = generateId();

            BillingAccount account = new BillingAccount(id, firstName, lastName, idNumber);

            _accounts.Add(account);

            return account;
        }

        public IEnumerable<Account> GetAllAccountsFor(string firstName, string lastName, long idNumber) 
        {
            /*IList<Account> accounts = new List<Account>();

            foreach (Account account in _accounts) 
            {
                if(account.FirstName == firstName && account.LastName == lastName && account.IdNumber == idNumber)
                {
                    accounts.Add(account);
                }
            }

            return accounts;*/

            return _accounts.Where(x => x.FirstName == firstName && x.LastName == lastName && x.IdNumber == idNumber);

        }

        public Account GetAccount(string accountNumber)
        {
            return _accounts.Single(x => x.AccountNumber == accountNumber);
        }

        public IEnumerable<string> ListOfCustomers()
        {
            /*IList<string> listOfCustomers = new List<string>();

            foreach (Account account in _accounts)

            {
                string customer = account.FirstName + " " + account.LastName + "PESEL: " + Convert.ToString(account.IdNumber);  
                if(!listOfCustomers.Contains(customer))
                {
                    listOfCustomers.Add(customer);
                }
                
            }
            
            return listOfCustomers;*/

            return _accounts.Select(a => string.Format("{0} {1} PESEL: {2}", a.FirstName, a.LastName, a.IdNumber)).Distinct();
        }

        public IEnumerable<string> ListOfCustomersAccountBilling()
        {
            return _accounts.Where(m => m.TypeName() == "Rozliczeniowe").Select(a => string.Format("{0} {1} PESEL: {2} NUMER KONTA: {3} STAN KONTA: {4}", a.FirstName, a.LastName, a.IdNumber, a.AccountNumber, a.Balance)).Distinct();
        }

        public IEnumerable<string> ListOfCustomersAccountSavings()
        {
            return _accounts.Where(m => m.TypeName() == "Oszczędnościowe").Select(a => string.Format("{0} {1} PESEL: {2} NUMER KONTA: {3} STAN KONTA: {4}", a.FirstName, a.LastName, a.IdNumber, a.AccountNumber, a.Balance)).Distinct();
        }

        public void CloseMonth()
        {
            foreach(SavingsAccount account in _accounts.Where(x => x is SavingsAccount))
            {
                account.AddInterest(0.05M); // 5% interest
            }

            foreach(BillingAccount account in _accounts.Where(x => x is BillingAccount))
            {
                account.TakeCharge(2.0M); // 2zł charge
            }
        }

        public void AddMoney(string accountNumber, decimal value)
        {
            Account account = GetAccount(accountNumber);        
            account.ChangeBalance(value);
        }

        public void TakeMoney(string accountNumber, decimal value)
        {
            Account account = GetAccount(accountNumber);
            account.ChangeBalance(-value);
        }



        private int generateId()
        {
            int id = 1;

            if (_accounts.Any())
            {
                id = _accounts.Max(x => x.Id) + 1;
            }

            return id;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
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

        private int generateId()
        {
            int id = 2;

           if (_accounts.Any())
            {
                id = _accounts.Max(x => x.Id) + 1;
               // id = 3;
            }
           
            return id;
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

    }
}

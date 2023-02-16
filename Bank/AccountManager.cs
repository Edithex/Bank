using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class AccountManager
    {
        private IList<Account> _accounts;
        ConnectWithSql connect = new ConnectWithSql();
        


        public AccountManager()
        {
            _accounts= new List<Account>();
            
            //_accounts = _accounts;
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
            connect.ExeQueryAddToDataBase(account);

            return account;
        }

        public BillingAccount CreateBillingAccount(string firstName, string lastName, long idNumber)
        {
            int id = generateId();

            BillingAccount account = new BillingAccount(id, firstName, lastName, idNumber);

            _accounts.Add(account);
            connect.ExeQueryAddToDataBase(account);

            return account;
        }

        public IEnumerable<Account> GetSavingsAccountsFor(string firstName, string lastName) 
        {
            return _accounts.Where(x => x.FirstName == firstName && x.LastName == lastName && x.TypeName() == "Oszczędnościowe");
        }
        public IEnumerable<Account> GetBillingAccountsFor(string firstName, string lastName)
        {
            return _accounts.Where(x => x.FirstName == firstName && x.LastName == lastName && x.TypeName() == "Rozliczeniowe");
        }

        public IEnumerable<Account> GetSavingsAccountsFor(long idNumber)
            {
                if(account.FirstName == firstName && account.LastName == lastName && account.IdNumber == idNumber)
                {
                    accounts.Add(account);
                }
            }

        public IEnumerable<Account> GetBillingAccountsFor(long idNumber)
        {
            return _accounts.Where(x => x.IdNumber == idNumber && x.TypeName() == "Rozliczeniowe");
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
            try
            {
                if (value < 0)
                {
                    throw new Exception("Value must be positive number");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Błąd: {0}", ex.Message);
            }
            account.ChangeBalance(value);
        }

        public void TakeMoney(string accountNumber, decimal value)
        {
            Account account = GetAccount(accountNumber);
            try
            {
                if (value < 0)
                {
                    throw new Exception("Value must be positive number");
                }

                if (value > account.Balance)
                {
                    throw new Exception("Value must be bigger than account balance");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Błąd: {0}", ex.Message);
            }

            if (value < account.Balance)
                account.ChangeBalance(-value);

        }

        public void GetAllAccountsFromDataBase()
        {
            try
            {
                connect.OpenConnection();
                IList<Account> accounts = new List<Account>();
                accounts = GetAccounts();

                foreach (Account account in accounts)
                {
                    _accounts.Add(account);
                }
            }
            catch (SqlException sqlex)
            {
                Console.WriteLine("Błąd" + sqlex.Message);
            }
            finally
            {
                if (connect.StatusConnection())
                {
                    connect.CloseConnection();
                }
            }
        }

        private IList<Account> GetAccounts()
        {
            
            var dane = connect.ExeQuery("SELECT id_account, AccountNumber, Balance, FirstName, LastName, IdNumber, TypeName FROM Accounts");
            List<Account> accounts = new List<Account>();


            foreach (DataRow dr in dane)
            {
                if (dr["TypeName"].ToString() == "Oszczędnościowe")
                {
                    SavingsAccount nsa = new SavingsAccount(int.Parse(dr["id_account"].ToString()), dr["FirstName"].ToString(), dr["LastName"].ToString(), long.Parse(dr["IdNumber"].ToString()));
                    accounts.Add(nsa);
                }
                else
                {
                    BillingAccount nba = new BillingAccount(int.Parse(dr["id_account"].ToString()), dr["FirstName"].ToString(), dr["LastName"].ToString(), long.Parse(dr["IdNumber"].ToString()));
                    accounts.Add(nba);
                }
            }
            return accounts;
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

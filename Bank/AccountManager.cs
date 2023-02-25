using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
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

            SavingsAccount account = new SavingsAccount(id, firstName, lastName, idNumber , GenerateAccountNumber(TypeName.Oszczędnościowe));
            _accounts.Add(account);

            using(connect)
            {
            connect.ExeQueryAddToDataBase(account);
            }

            return account;
        }

        public BillingAccount CreateBillingAccount(string firstName, string lastName, long idNumber)
        {
            int id = generateId();

            BillingAccount account = new BillingAccount(id, firstName, lastName, idNumber, GenerateAccountNumber(TypeName.Rozliczeniowe));

            _accounts.Add(account);
            using(connect)
            {
            connect.ExeQueryAddToDataBase(account);
            }
            

            return account;
        }

        public IEnumerable<Account> GetSavingsAccountsFor(string firstName, string lastName) 
        {
            return _accounts.Where(x => x.FirstName == firstName && x.LastName == lastName && x.Type == TypeName.Oszczędnościowe);
        }
        public IEnumerable<Account> GetBillingAccountsFor(string firstName, string lastName)
        {
            return _accounts.Where(x => x.FirstName == firstName && x.LastName == lastName && x.Type == TypeName.Rozliczeniowe);
        }

        public IEnumerable<Account> GetSavingsAccountsFor(long idNumber)
        {
            return _accounts.Where(x => x.IdNumber == idNumber && x.Type == TypeName.Oszczędnościowe);
        }

        public IEnumerable<Account> GetBillingAccountsFor(long idNumber)
        {
            return _accounts.Where(x => x.IdNumber == idNumber && x.Type == TypeName.Rozliczeniowe);
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
            return _accounts.Where(m => m.Type == TypeName.Rozliczeniowe).Select(a => string.Format("{0} {1} PESEL: {2} NUMER KONTA: {3} STAN KONTA: {4}", a.FirstName, a.LastName, a.IdNumber, a.AccountNumber, a.Balance)).Distinct();
        }

        public IEnumerable<string> ListOfCustomersAccountSavings()
        {
            return _accounts.Where(m => m.Type == TypeName.Oszczędnościowe).Select(a => string.Format("{0} {1} PESEL: {2} NUMER KONTA: {3} STAN KONTA: {4}", a.FirstName, a.LastName, a.IdNumber, a.AccountNumber, a.Balance)).Distinct();
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

            using(connect)
            {
            connect.OpenConnection();
                foreach (Account account in _accounts)
            {
                connect.ExeQueryChangeBalanceInDataBase(account);
            }
            connect.CloseConnection();
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
                else
                {
                    account.ChangeBalance(value);
                    using(connect)
                    {
                        connect.OpenConnection();
                        connect.ExeQueryChangeBalanceInDataBase(account);
            }
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
                else
                {
                    if (value < account.Balance)
                    {
                        GetAccount(accountNumber).ChangeBalance(-value);
                        using(connect)
                        {
                            connect.OpenConnection();
                            connect.ExeQueryChangeBalanceInDataBase(account);
                        } 
            }
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
                using(connect)
                {
                connect.OpenConnection();
                    _accounts = GetAccounts().ToList();
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
            
            var dane = connect.ExeQuery("SELECT id, AccountNumber, Balance, FirstName, LastName, IdNumber, TypeName FROM Accounts");
            List<Account> accounts = new List<Account>();


            foreach (DataRow dr in dane)
            {

                

                if ((TypeName)(Convert.ToInt32(dr["TypeName"].ToString())) == TypeName.Oszczędnościowe)
                {
                    SavingsAccount nsa = new SavingsAccount(Convert.ToInt32(dr["id"].ToString()), dr["FirstName"].ToString(), dr["LastName"].ToString(), Convert.ToInt64(dr["IdNumber"].ToString()),Convert.ToDecimal(dr["Balance"].ToString()), dr["AccountNumber"].ToString());
                    accounts.Add(nsa);
                }
                else if ((TypeName)(Convert.ToInt32(dr["TypeName"].ToString())) == TypeName.Rozliczeniowe)
                {
                    BillingAccount nba = new BillingAccount(Convert.ToInt32(dr["id"].ToString()), dr["FirstName"].ToString(), dr["LastName"].ToString(), Convert.ToInt64(dr["IdNumber"].ToString()), Convert.ToDecimal(dr["Balance"].ToString()), dr["AccountNumber"].ToString());
                    accounts.Add(nba);
                }
                else
                {
                    throw new InvalidOperationException("Unsupported type account");
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

        public int GenerateAccountNumber(TypeName type)
        {
            int value = 0;
            int max = 0;
            if (_accounts.Any())
            {
                IEnumerable<Account> accountNumbers = _accounts.Where(x => x.Type == type);
                foreach (Account account in accountNumbers)
                {
                    value = int.Parse(account.AccountNumber.Remove(0, 2));
                    if (value > max)
                        max = value;
                }
                return max+1;
            }
            else
                return value;

        }
    }
}

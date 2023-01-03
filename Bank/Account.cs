using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    abstract class Account
    {

        public int Id { get; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public string FirstName { get; }
        public string LastName { get; }
        public long IdNumber { get; }

        public Account(int id, string firstName, string lastName, long idNumber)
        {
            Id = id;
            Balance = 0.0M;
            FirstName = firstName;
            LastName = lastName;
            IdNumber = idNumber;
        }

        public abstract string TypeName();

        public string GetFullName()
        {
            string fullName = string.Format("{0} {1}", FirstName, LastName);

            return fullName;
        }

        public string GetBalance()
        {
            string balance = string.Format("{0} zł", Balance);

            return balance;
        }

        public void ChangeBalance(decimal value)
        {
            Balance += value;
        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    abstract class Account
    {

        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long IdNumber { get; set; }

        public Account(int id, string firstName, string lastName, long idNumber)
        {
            Id = id;
            Balance = 0.0M;
            FirstName = firstName;
            LastName = lastName;
            IdNumber = idNumber;
        }

        public Account(int id, string firstName, string lastName, long idNumber, decimal balance, string accountNumber)
        {
            Id = id;
            Balance = balance;
            FirstName = firstName;
            LastName = lastName;
            IdNumber = idNumber;
            AccountNumber = accountNumber;
        }

        public abstract string TypeName();

      /*  public override string ToString()
        {
            return $"Id: {Id} Imię i nazwisko: {FirstName} {LastName} PESEL: {IdNumber} Numer konta: {AccountNumber} Saldo: {Balance}"; 
        }
      */
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

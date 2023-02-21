using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class BillingAccount : Account
    {

        public BillingAccount(int id, string firstName, string lastName, long idNumber, int maxNumber) : base(id, firstName, lastName, idNumber)
        {
            AccountNumber = generateAccountNumber(maxNumber);
            Type = TypeName.Rozliczeniowe;
        }
        public BillingAccount(int id, string firstName, string lastName, long idNumber, decimal balance, string accountNumber) : base(id, firstName, lastName, idNumber, balance, accountNumber)
        {
            Type = TypeName.Rozliczeniowe;
        }

        /*public override void SetType()
        {
            Type = TypeName.Rozliczeniowe;
        }*/

        private string generateAccountNumber(int maxNumber)
        {
            var accountNumber = string.Format("52{0:D8}", maxNumber);

            return accountNumber;
        }

        public void TakeCharge(decimal value)
        {
            if(Balance < value)
            {
                Balance = Balance*(value/100);
            }
            else
            {
                Balance -= value;
            }
        }

    }
}

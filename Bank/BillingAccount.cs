using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class BillingAccount : Account
    {

        public BillingAccount(int id, string firstName, string lastName, long idNumber) : base(id, firstName, lastName, idNumber)
        {
            AccountNumber = generateAccountNumber(id);
        }

        public override string TypeName()
        {
            return "Rozliczeniowe";
        }

        private string generateAccountNumber(int id)
        {
            var accountNumber = string.Format("52{0:D8}", id);

            return accountNumber;
        }

        public void TakeCharge(decimal value)
        {
            Balance -= value;
        }

    }
}

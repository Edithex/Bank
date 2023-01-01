using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class BillingAccount : Account
    {

        public BillingAccount(string accountNumber, decimal balance, string firstName, string lastName, long idNumber) : base(accountNumber,balance,firstName,lastName,idNumber)
        {

        }

    }
}

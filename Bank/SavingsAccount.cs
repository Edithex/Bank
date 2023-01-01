using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class SavingsAccount : Account
    {

        public SavingsAccount(string accountNumber, decimal balance, string firstName, string lastName, long idNumber) : base(accountNumber,balance,firstName,lastName,idNumber)

        {
        }

    }


}

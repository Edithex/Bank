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

        public SavingsAccount(int id, string firstName, string lastName, long idNumber, int maxNumber) : base(id, firstName, lastName, idNumber)
        {
            AccountNumber = generateAccountNumber(maxNumber);
            Type = TypeName.Oszczędnościowe;
        }

        public SavingsAccount(int id, string firstName, string lastName, long idNumber, decimal balance, string accountNumber) : base(id, firstName, lastName, idNumber, balance, accountNumber)
        {
            Type = TypeName.Oszczędnościowe;
        }


        /*public override void SetType()
        {
            Type = TypeName.Oszczędnościowe;
        }*/


        private string generateAccountNumber(int maxNumber)
        {
            var accountNumber = string.Format("43{0:D8}", maxNumber);

            return accountNumber;
        }
        public void AddInterest(decimal interest)
        {
            Balance += Balance * interest;
        }

    }


}

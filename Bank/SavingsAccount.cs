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

        public SavingsAccount(int id, string firstName, string lastName, long idNumber) : base(id, firstName, lastName, idNumber)
        {
            AccountNumber = generateAccountNumber(id);
        }
        
        public override string TypeName()
        {
            return "Oszczędnościowe";
        }

        private string generateAccountNumber(int id)
        {
            var accountNumber = string.Format("43{0:D8}", id);

            return accountNumber;
        }

    }


}

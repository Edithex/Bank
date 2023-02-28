using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Commands
{
    enum CommandsName
    {
        ListOfAccounts = 1,
        AddBillingAccounts = 2,
        AddSavingsAccounts = 3,
        AddMoney = 4,
        TakeMoney = 5,
        ListOfAllAccounts = 6,
        CloseMonth = 7,
        SavingToFile = 8
    }
}

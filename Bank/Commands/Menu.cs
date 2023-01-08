using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Commands
{
    internal class Menu
    {
        private IEnumerable<ICommand> Commands;

        public Menu(AccountManager accountManager)
        {
            Commands = new List<ICommand>();
            

        }
       
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Commands
{
    internal interface ICommand
    {
        public void Run();

        public string GetName();

        public string GetDescription();
    }
}

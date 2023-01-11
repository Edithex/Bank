using Bank.Commands;

namespace Bank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AccountManager accountManager = new AccountManager();
            Printer printer= new Printer(); 

            Menu menu = new Menu(accountManager,printer);
            menu.Run();

            Console.ReadKey();
        }
    }
}
namespace Bank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "Name: Bank";
            string author = "Author: Edith";
            Console.WriteLine(name);
            Console.WriteLine(author);

            /*List <Account> accounts = new List <Account> ();  
            accounts.Add (new SavingsAccount(1, "Michał", "Kowalski", 92012014325));
            accounts.Add(new SavingsAccount(2, "Magdalena", "Wodna", 88053124625));
            accounts.Add(new BillingAccount(3, accounts[0].FirstName, accounts[0].LastName, accounts[0].IdNumber));*/

            AccountManager manager = new AccountManager();

            manager.CreateSavingsAccount("Michał", "Kowalski", 92012014325);
            manager.CreateSavingsAccount("Magdalena", "Wodna", 88053124625);
            manager.CreateBillingAccount("Michał", "Kowalski", 92012014325);

            manager.TakeMoney("4300000001", 50);
            
            //manager.CreateBillingAccount(accounts[0].FirstName, accounts[0].LastName, accounts[0].IdNumber);

            IEnumerable<Account> accounts = manager.GetAllAccounts();

            
            

            IPrinter printer = new Printer();
            //IPrinter printer1= new SmallerPrinter();

            foreach (Account account in accounts)
            {
                printer.Print(account);
            }

            
            //Print List of Customers
            IEnumerable<string> listofcustomers = manager.ListOfCustomers();
            
            foreach(string customer in listofcustomers)
            {
                Console.WriteLine(customer);
            }


            Console.ReadKey();
        }
    }
}
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

            SavingsAccount savingsAccount = new SavingsAccount(1, "Michał", "Kowalski", 92012014325);
            SavingsAccount savingsAccount2 = new SavingsAccount(2, "Magdalena", "Wodna", 88053124625);

            /* Console.WriteLine(savingsAccount.GetFullName());
            Console.WriteLine(savingsAccount2.GetFullName()); */

            Account billingAccount = new BillingAccount(3, savingsAccount.FirstName, savingsAccount.LastName, savingsAccount.IdNumber);
            //Console.WriteLine(billingAccount.GetFullName());

            

            Printer printer = new Printer();
            
            printer.Print(savingsAccount);
            printer.Print(savingsAccount2);

            printer.Print(billingAccount);




            Console.ReadKey();
        }
    }
}
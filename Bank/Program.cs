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

            SavingsAccount savingsAccount = new SavingsAccount("5300000001", 0.0M, "Michał", "Kowalski", 92012014325);
            SavingsAccount savingsAccount2 = new SavingsAccount("5300000002", 10.0M, "Magdalena", "Wodna", 88053124625);

            /* Console.WriteLine(savingsAccount.GetFullName());
            Console.WriteLine(savingsAccount2.GetFullName()); */

            BillingAccount billingAccount = new BillingAccount("6200000001", 0.0M, savingsAccount.FirstName, savingsAccount.LastName, savingsAccount.IdNumber);
            //Console.WriteLine(billingAccount.GetFullName());

            Printer printer = new Printer();
            
            Console.WriteLine();
            Console.WriteLine("KONTA ROZLICZENIOWE");
            Console.WriteLine();
            printer.Print(savingsAccount);
            printer.Print(savingsAccount2);

            Console.WriteLine();
            Console.WriteLine("KONTA OSZCZĘDNOŚCIOWE");
            Console.WriteLine();
            printer.Print(billingAccount);


            Console.ReadKey();
        }
    }
}
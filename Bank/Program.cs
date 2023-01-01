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

            Console.WriteLine();
            Console.WriteLine("KONTA ROZLICZENIOWE");
            Console.WriteLine();

            SavingsAccount savingsAccount = new SavingsAccount();
            savingsAccount.AccountNumber = "5300000001";
            savingsAccount.Balance = 0.0M;
            savingsAccount.FirstName = "Michał";
            savingsAccount.LastName = "Kowalski";
            savingsAccount.IdNumber = 92012014325;
            
            
            Console.WriteLine("Numer konta: {0}", savingsAccount.AccountNumber);
            Console.WriteLine("Stan konta: {0} zł", savingsAccount.Balance);
            Console.WriteLine("Imię i nazwisko: {0} {1}", savingsAccount.FirstName, savingsAccount.LastName);
            Console.WriteLine("Numer Pesel: {0}", savingsAccount.IdNumber);

            SavingsAccount savingsAccount1 = new SavingsAccount();
            savingsAccount1.AccountNumber = "5300000002";
            savingsAccount1.Balance = 10.0M;
            savingsAccount1.FirstName = "Magdalena";
            savingsAccount1.LastName = "Wodna";
            savingsAccount1.IdNumber = 88053124625;
            Console.WriteLine();
            
            Console.WriteLine("Numer konta: {0}", savingsAccount1.AccountNumber);
            Console.WriteLine("Stan konta: {0} zł", savingsAccount1.Balance);
            Console.WriteLine("Imię i nazwisko: {0} {1}", savingsAccount1.FirstName, savingsAccount1.LastName);
            Console.WriteLine("Numer Pesel: {0}", savingsAccount1.IdNumber);

            
            BillingAccount billingAccount = new BillingAccount();
            billingAccount.AccountNumber = "6200000001";
            billingAccount.Balance = 0.0M;
            billingAccount.FirstName = savingsAccount.FirstName;
            billingAccount.LastName = savingsAccount.LastName;
            billingAccount.IdNumber = savingsAccount.IdNumber;

            Console.WriteLine();
            Console.WriteLine("KONTA OSZCZĘDNOŚCIOWE");
            Console.WriteLine();

                       
            Console.WriteLine("Numer konta: {0}", billingAccount.AccountNumber);
            Console.WriteLine("Stan konta: {0} zł", billingAccount.Balance);
            Console.WriteLine("Imię i nazwisko: {0} {1}", billingAccount.FirstName, billingAccount.LastName);
            Console.WriteLine("Numer Pesel: {0}", billingAccount.IdNumber);

            Console.ReadKey();
        }
    }
}
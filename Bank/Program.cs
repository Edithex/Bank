using Bank.Commands;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace Bank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*ConnectWithSql connect= new ConnectWithSql();

                connect.OpenConnection();
                if(connect.StatusConnection())
                {
                    string query = "SELECT FirstName, LastName, AccountNumber, IdNumber FROM Accounts";
                    SqlDataReader reader = connect.DataReader(query);
                    { 
                        while (reader.Read())
                        {

                            Console.WriteLine("Imię i nazwisko: {0} {1} PESEL: {2} Numer konta: {3}", reader["FirstName"], reader["LastName"], reader["IdNumber"], reader["AccountNumber"]);
                        }
                    }
                    reader.Close();
                }
            */

                Console.WriteLine();
                AccountManager accountManager = new AccountManager();
                Printer printer = new Printer();

                Menu menu = new Menu(accountManager, printer);
                menu.Run();

                Console.ReadKey();
            
           
        }
        
    }
}
using Bank.Commands;
using System.Data.SqlClient;
using System.Data;

namespace Bank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connstring = "Data Source = DESKTOP-DKAMI8D;Initial Catalog=Bank;Integrated Security=true";
            SqlConnection con = new SqlConnection(connstring);
            try
            {
                con.Open();
                Console.WriteLine("Nawiązano połączenie z serwerem");
                Console.WriteLine();
                if(con.State == ConnectionState.Open) 
                {
                    string query = "SELECT FirstName, LastName, AccountNumber, IdNumber FROM Accounts";
                    SqlCommand cmd = new SqlCommand(query, con);
                    using (SqlDataReader reader = cmd.ExecuteReader()) 
                    { 
                        while (reader.Read())
                        {
                            Console.WriteLine("Imię i nazwisko: {0} {1} PESEL: {2} Numer konta: {3}", reader["FirstName"], reader["LastName"], reader["IdNumber"], reader["AccountNumber"]);
                        }
                    }
                }


                Console.WriteLine();
                AccountManager accountManager = new AccountManager();
                Printer printer = new Printer();

                Menu menu = new Menu(accountManager, printer);
                menu.Run();

                Console.ReadKey();
            }
            catch (SqlException sqlex)
            {
                Console.WriteLine("Błąd" + sqlex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    Console.WriteLine("Zamknięto połączenie");
                    con.Close();
                }
            } 
        }
    }
}
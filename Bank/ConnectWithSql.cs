using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Security.Principal;

namespace Bank
{
    internal class ConnectWithSql
    {
        SqlConnection con;

        public void OpenConnection()
        {
            con = new SqlConnection("Data Source = DESKTOP-DKAMI8D;Initial Catalog=Bank;Integrated Security=true");
            con.Open();
            Console.WriteLine("Nawiązano połączenie z serwerem");
            Console.WriteLine();
        }

        public void CloseConnection() 
        {
            con.Close();
            Console.WriteLine("Zamknięto połączenie");
        }

        public void ExeQueryAddToDataBase(Account account)
        {
            try
            {
                string query = "INSERT INTO Accounts VALUES (@accountNumber, @balance, @typeName, @firstName, @lastName, @idNumber)";
                OpenConnection();
                Console.WriteLine("Połączono z bazą");
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@accountNumber", account.AccountNumber);
                cmd.Parameters.AddWithValue("@balance", account.Balance);
                cmd.Parameters.AddWithValue("@firstName", account.FirstName);
                cmd.Parameters.AddWithValue("@lastName", account.LastName);
                cmd.Parameters.AddWithValue("@typeName", account.Type);
                cmd.Parameters.AddWithValue("@idNumber", account.IdNumber);
                cmd.ExecuteNonQuery();
                Console.WriteLine("dodano do bazy");
                Console.ReadKey();
            }
            catch (SqlException sqlex)
            {
                Console.WriteLine("Błąd" + sqlex.Message);
            }
            finally
            {
                if (StatusConnection())
                {
                    CloseConnection();
                }
            }
        }

        public void ExeQueryChangeBalanceInDataBase(Account account)
        {

                string query = "UPDATE Accounts SET Balance = @balance WHERE id = @id";
                Console.WriteLine("Połączono z bazą");
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", account.Id);
                cmd.Parameters.AddWithValue("@balance", account.Balance);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Uaktualniono dane salda");

        }


        public DataRowCollection ExeQuery(string Query_)
        {
            DataRowCollection dr;
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.CommandType = CommandType.Text;
            DataSet dataSet = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataSet);
            dr = dataSet.Tables[0].Rows;
            return dr;
        }

        public SqlDataReader DataReader(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        public bool StatusConnection()
        {
            return con.State == ConnectionState.Open;
        }


    }
}

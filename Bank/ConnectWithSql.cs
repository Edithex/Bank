using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Bank
{
    internal class ConnectWithSql
    {
        string connstring = "Data Source = DESKTOP-DKAMI8D;Initial Catalog=Bank;Integrated Security=true";
        SqlConnection con;

        public void OpenConnection()
        {
            con = new SqlConnection(connstring);
            con.Open();
            Console.WriteLine("Nawiązano połączenie z serwerem");
            Console.WriteLine();
        }

        public void CloseConnection() 
        {
            con.Close();
            Console.WriteLine("Zamknięto połączenie");
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

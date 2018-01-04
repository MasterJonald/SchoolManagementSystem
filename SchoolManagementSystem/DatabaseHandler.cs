using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace SchoolManagementSystem
{
    class DatabaseHandler
    {
    }

    public class ConnectToServer
    {
        private SqlConnection sqlconn;
        private string connectionString;

        public ConnectToServer(string _connectionString)
        {
            connectionString = _connectionString;
        }

        public bool OpenConnection()
        {
            try
            {
                sqlconn = new SqlConnection(connectionString);
                sqlconn.Open();
                return true;
            }

            catch(Exception ex)
            {
                //insert error log here
                return false;
            }
        }
    }

    public class UpdateTable
    {
        public void Insert(string query)
        {
            try
            {
                SqlConnection sqlconn = new SqlConnection("");
                
                SqlCommand sqlcomm = new SqlCommand(query);
                sqlcomm.ExecuteNonQuery();
            }
            catch(SqlException ex)
            {
                
            }
        }
    }
}
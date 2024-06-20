using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Data.Sqlite;
using System.Windows;

namespace WpfAppWarmKalt
{
    static class SqlConnect
    {
        public static string sqlConnectString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True";
        public static SqlConnection conn;
            public static SqlCommand cmd;

        public static void getConnection()
        {
            if (conn == null)
            {
                conn = new SqlConnection(sqlConnectString);
                conn.Open();
                MessageBox.Show("Connected with database");
            }
        }

        public static void getData()
        {

        }
        
    }
}

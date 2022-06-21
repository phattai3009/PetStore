using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Connect
    {
        private static string connString = @"Data Source=PHATTAI ;Initial Catalog=QL_PetStore;User ID=sa;Password=123";
        private static SqlConnection conn = null;

        public Connect()
        {
            conn = new SqlConnection(connString);
            conn.Open();
        }

        public static bool OpenConnect()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                return false;
            }
            else
                return true;
        }

        public static void CloseConnect()
        {
            conn.Close();
        }

        public DataTable QuerySQL(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            return dt;
        }

        public void ExecuteSQL(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DBHelper
    {
        private static SqlConnection getConn()
        {
            string strConn = "data source=.;initial catalog=test;uid=sa;password=.";
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            return conn;
        }
        public static DataTable getDT(string strSQL)
        {
            SqlConnection conn = getConn();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
            da.Fill(dt);
            conn.Close();
            return dt;
        }

        public static int cmdSQL(string strSQL)
        {
            SqlConnection conn = getConn();

            SqlCommand cmd = new SqlCommand(strSQL, conn);
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            return i;
        }
    }
}

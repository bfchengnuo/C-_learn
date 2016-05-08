using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DBHelper
    {
        //获得一个链接
        private static SqlConnection getConn()
        {
            string strConn = "data source=.;initial catalog=test;uid=sa;password=awsd123..";
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

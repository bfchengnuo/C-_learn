using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SQL
{
    class SQLTools
    {
        public static DataTable getDT(string strSQL)
        {
            string strConn = "data source=.;initial catalog=Address;uid=sa;password=";
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
            da.Fill(dt);
            conn.Close();
            return dt;
        }

        public static void addBOX(ComboBox combox, DataTable dt, string columnName)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                combox.Items.Add(dt.Rows[i][columnName]);
            }
        }
    }
}

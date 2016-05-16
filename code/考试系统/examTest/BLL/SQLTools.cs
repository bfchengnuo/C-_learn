using DAL;
using System.Data;

namespace BLL
{
    public class SQLTools
    {
        //登陆界面判断账号
        public static bool isLoad(string name,string pwd)
        {
            string strSQL = "select * from students where useName='" + name + "'";
            DataTable dt = DBHelper.getDT(strSQL);
            if (name != "" && pwd != "")
            {
                if (dt.Rows.Count == 0)
                    return false;

                if (dt.Rows[0]["usePWD"].ToString() == pwd)
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }
        //获取数据  取随机数据--->select top 20 * from  Exam order by newid()
        public static DataTable getDT()
        {
            DataTable dt = new DataTable();
            string strSQL = "select top 20 * from  Exam order by newid()";
            //string strSQL = "select * from Exam";
            dt = DBHelper.getDT(strSQL);
            return dt;
        }
        //获取答案表
        public static DataTable getExamDT()
        {
            DataTable dt = new DataTable();
            string strSQL = "select * from kkey";
            dt = DBHelper.getDT(strSQL);
            return dt;
        }

        //将数据提交到数据库
        public static void doInsert(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                //string strSQL = "insert into kkey values('" + dr["ID"] + "','" + dr["EXAM_KEY"] + "')";
                string strSQL = "update kkey set EXAM_KEY='" + dr["EXAM_KEY"] + "' where ID='" + dr["ID"] + "'";
                DBHelper.cmdSQL(strSQL);
            }
        }
    }
}

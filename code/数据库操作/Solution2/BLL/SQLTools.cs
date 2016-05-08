using DAL;
using System.Data;

namespace BLL
{
    public class SQLTools
    {
        //简单查找方法
        public static DataTable findData(string name)
        {
            string strSQL = "select * from stu where stuName='" + name + "'";
            DataTable dt = DBHelper.getDT(strSQL);
            return dt;
        }
        //查找字段，给修改下拉框用
        public static string[] getColumn()
        {
            string strSQL = "select * from stu";
            DataTable dt = DBHelper.getDT(strSQL);

            string[] data = new string[dt.Columns.Count];
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                data[i] = dt.Columns[i].ToString();
            }
            return data;
        }
        //插入数据方法
        public static int setData(string name, string zye, string xbu)
        {
            string strSQL = "insert into stu values('" + name + "','" + zye + "','" + xbu + "')";
            return DBHelper.cmdSQL(strSQL);
        }
        //删除数据方法
        public static int removeData(string name)
        {
            string strSQL = "delete stu where stuName='" + name + "'";
            return DBHelper.cmdSQL(strSQL);
        }
        //更新数据方法
        public static int updateData(string old, string news, string id, string name)
        {
            try
            {
                string strSQL = "update stu set " + name + "='" + news + "' where " + id + "='" + old + "' and stuName='" + name + "'";
                return DBHelper.cmdSQL(strSQL);
            }
            catch (System.Exception)
            {
                return 0;
            }

        }
        //附加查询部分，根据指定内容进行查询
        public static DataTable getDT(string nameZY, string nameXB)
        {
            //复选框全部勾选
            if (nameZY != "" && nameXB != "")
            {
                string strSQL = "select * from stu where stuZY='" + nameZY + "' and stuXB='" + nameXB + "'";
                return DBHelper.getDT(strSQL);
            }
            //只勾选了系部
            else if (nameXB != "")
            {
                string strSQL = "select * from stu where stuXB='" + nameXB + "'";
                return DBHelper.getDT(strSQL);
            }
            //只勾选了专业
            else
            {
                string strSQL = "select * from stu where stuZY='" + nameZY + "'";
                return DBHelper.getDT(strSQL);
            }
        }
        //获取附加查询下拉菜单的数据
        public static DataTable getMenu(int id)
        {
            if (id == 0) //查询系部数据
            {
                string strSQL = "select distinct(stuXB) from stu";
                DataTable dt = DBHelper.getDT(strSQL);
                return dt;
            }
            else //查询专业数据
            {
                string strSQL = "select distinct(stuZY) from stu";
                DataTable dt = DBHelper.getDT(strSQL);
                return dt;
            }

        }
        //重载方法，用于二级联动
        public static DataTable getMenu(string name)
        {
            string strSQL = "select distinct(stuZY) from stu where stuXB='" + name + "'";
            DataTable dt = DBHelper.getDT(strSQL);
            return dt;
        }
    }
}

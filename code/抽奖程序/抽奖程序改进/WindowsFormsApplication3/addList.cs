using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace WindowsFormsApplication3
{
    class addList
    {
        string filepath = @".\src\15软件一班花名册.txt";
        public void Show(List<string> idList,List<string> nameList)
        {
            string[] str = new string[3];
            //判断文件是否存在
            if (File.Exists(filepath))
            {
                //创建读取流读取数据
                StreamReader sr = new StreamReader(filepath, Encoding.Default);
                string len = null;
                while ((len = sr.ReadLine()) != null)
                {
                    //listBox1.Items.Add(len);
                    //分割字符串，将分割后的字串分别装进各自的集合
                    str = len.Split('\t');
                    idList.Add(str[0]);
                    nameList.Add(str[1]);

                }
            }
            else
            {
                MessageBox.Show("文件不存在！");
                //强制所有消息中止，退出所有的窗体
                Application.Exit();
            }


        }
    }
}

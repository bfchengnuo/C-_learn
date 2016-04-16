using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication3
{
    class AddList
    {
        string filepath = @".\src\15软件一班花名册.txt";
        public void Show(List<Student> stuList)
        {
           // string[] str = new string[3];

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
                    string[] str = len.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    if (str.Length == 3)
                    {
                        Student stu = new Student("软件一班");
                        stu.stuID = str[0];
                        stu.stuName = str[1];
                        stuList.Add(stu);
                    }

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

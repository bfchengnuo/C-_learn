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
    public partial class Form1 : Form
    {
        //获取路径
        string filepath = "./src/";
        //string filepath = Application.StartupPath + "\\src\\";
        //定义一个集合来存放文件名，并且提供映射关系
        List<string> namelist = new List<string>();
        //记录取得的随机数
        int i = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(filepath1);
           //获取文件夹中的信息
            DirectoryInfo folder = new DirectoryInfo(filepath);
            //遍历文件夹的内容，筛选出符合规则的文件
            foreach (FileInfo file in folder.GetFiles("*.jpg"))
            {
                //将文件名添加到集合/容器
                //listBox1.Items.Add(file.Name);
                namelist.Add(file.Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 100;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled =false;
            //添加到已选列表控件
            listBox1.Items.Add(namelist[i]);
            //文件名在label标签显示
            label1.Text = namelist[i];
            //删除此次取得的随机数与之对应的文件名，保证下次不在取到
            namelist.RemoveAt(i);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            i = random.Next(0,namelist.Count);
            //i = random.Next(0, listBox1.Items.Count);
            //设置listbox的选择效果 
            //listBox1.SelectedIndex = i;
            pictureBox1.Image = System.Drawing.Bitmap.FromFile(filepath+namelist[i].ToString());
        }
    }
}

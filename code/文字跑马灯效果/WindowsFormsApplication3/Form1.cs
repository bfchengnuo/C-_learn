using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 1000;

        }
        int i = 0;
        int t = 1;
        string temp;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //清除文本框里的内容，会连样式一起清除
            richTextBox1.Clear();
            //将备份的字串还原
            richTextBox1.Text = temp;
            //以上的方法待改进，也许可以用复制到剪切板的方法


            //选中要改变颜色的字符，第一个是开始位置，第二个是长度
            richTextBox1.Select(i, 1);
            //改变选中的字符的颜色
            richTextBox1.SelectionColor = Color.Red;
            i += t;
            if (i == richTextBox1.Text.Length || i == 0)
            {
                t = -t;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //先备份内容，达到每次修改一个的效果
            temp = richTextBox1.Text.ToString();
        }
    }
}

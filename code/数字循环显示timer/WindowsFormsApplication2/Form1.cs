using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        int i = 10;
        //设置标志位
        bool flag = false;
        
        int t = -1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //设置timer的开关和刷新时间
            timer1.Enabled = true;
            timer1.Interval = 888;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //设置timer所运行的代码
            //别人的思路
            i += t;
            label1.Text = i.ToString();
            //判断临界值，如果符合就取反
            if(i==0 || i == 10)
            {
                t = -t;
            }
           /*
           1-10循环显示
            label1.Text = i + "";

            if (flag)
            {

                if (++i == 10)
                {
                    flag = false;
                }

            }
            else
            {
                if (--i == 0)
                {
                    flag = true;
                }
            }
            */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //从10到0停下的时候用
            i = 10;
            timer1.Enabled = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clactext
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //定义一个标志用来判断是否是新的一次计算
        bool flag = false;
        

        //clear键
        private void butc_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }


        //数字键部分
        private void button14_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                flag = false;
                textBox1.Text = "";
            }
            textBox1.Text += "9";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                flag = false;
                textBox1.Text = "";
            }
            textBox1.Text += "8";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                flag = false;
                textBox1.Text = "";
            }
            textBox1.Text += "7";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                flag = false;
                textBox1.Text = "";
            }
            textBox1.Text += "6";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                flag = false;
                textBox1.Text = "";
            }
            textBox1.Text += "5";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                flag = false;
                textBox1.Text = "";
            }
            textBox1.Text += "4";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                flag = false;
                textBox1.Text = "";
            }
            textBox1.Text += "3";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                flag = false;
                textBox1.Text = "";
            }
            textBox1.Text += "2";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                flag = false;
                textBox1.Text = "";
            }
            textBox1.Text += "1";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                flag = false;
                textBox1.Text = "";
            }
            textBox1.Text += "0";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                flag = false;
                textBox1.Text = "";
            }
            textBox1.Text += ".";
        }



        private void butchu_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                flag = false;
                textBox1.Text = "";
            }


            textBox1.Text += " / ";


        }

        private void butcheng_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                flag = false;
                textBox1.Text = "";
            }
            textBox1.Text += " * ";
        }

        private void butjian_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                flag = false;
                textBox1.Text = "";
            }
            textBox1.Text += " - ";
        }

        private void butjia_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                flag = false;
                textBox1.Text = "";
            }

            textBox1.Text += " + ";

        }

        private void butdeng_Click(object sender, EventArgs e) //等号
        {
            //一次运算结束，重置标志
                flag = true;

            //获取字符串中的运算符、第一个数、第二个数
            string st =  textBox1.Text.Substring(textBox1.Text.IndexOf(' ') + 1, 1);
            double a =  double.Parse(textBox1.Text.Substring(0,textBox1.Text.IndexOf(' ')));
            double b =  double.Parse(textBox1.Text.Substring(textBox1.Text.IndexOf(' ')+3));
           
            

            switch (st)
            {
                case "+": textBox1.Text = (a + b) + ""; break;
                case "-": textBox1.Text = (a - b) + ""; break;
                case "*": textBox1.Text = (a * b) + ""; break;
                case "/": textBox1.Text = (a / b) + ""; break;
            }
        }

        //del键设置
        private void butdel_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
        }
    }


}

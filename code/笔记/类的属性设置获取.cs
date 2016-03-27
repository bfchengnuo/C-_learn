using System;
using System.Windows.Forms;

namespace text
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }




        private void Form1_Load(object sender, EventArgs e)
        {
            Demo de = new Demo();
            //设置属性值
            de.show = 2;
            //de.show 这样就是获取属性值
            MessageBox.Show(de.show+"");
        }
    }

    class Demo
    {
        int a;
        //定义属性，不需要传值 和 （），设置和获取写在一个方法中  方法？
        public int show
        {
            //这get 和 set 可以认为是个关键字了吧
            get
            {
                return a;
            }
            set
            {
                //value 就是指传进来的值，固定名称
                a = value;
            }
        }
    }

}

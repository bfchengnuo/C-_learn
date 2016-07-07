using System;
using System.Data;
using System.Windows.Forms;
using BLL;

namespace UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox8_MouseClick(object sender, MouseEventArgs e)
        {
            textBox8.Text = "";
        }
        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_MouseDown(object sender, MouseEventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox3_MouseDown(object sender, MouseEventArgs e)
        {
            textBox3.Text = "";
        }

        private void textBox4_MouseDown(object sender, MouseEventArgs e)
        {
            textBox4.Text = "";
        }
        //普通查找
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = SQLTools.findData(textBox1.Text);
            addGrid(dt);
        }
        //窗口加载事件
        private void Form1_Load(object sender, EventArgs e)
        {
            //设置修改部分的下拉菜单
            string[] data = SQLTools.getColumn();
            foreach (string str in data)
            {
                comboBox1.Items.Add(str);
            }
            comboBox1.SelectedIndex = 0;
            radioButton1.Checked = true;
            comboBox2.Visible = false;
            comboBox3.Visible = false;

        }
        //插入数据
        private void button4_Click(object sender, EventArgs e)
        {
            int flag = SQLTools.setData(textBox5.Text, textBox6.Text, textBox7.Text);
            if (flag != 0)
                label5.Text = "操作成功完成";
            else
                label5.Text = "操作失败！";
        }
        //显示所有数据的按钮
        private void button5_Click(object sender, EventArgs e)
        {
            DataTable dt = SQLTools.findData("' or 1=1;--");
            addGrid(dt);
        }
        //删除数据
        private void button3_Click(object sender, EventArgs e)
        {
            int flag = SQLTools.removeData(textBox4.Text);
            if (flag != 0)
                label5.Text = "操作成功完成";
            else
                label5.Text = "操作失败！";
        }
        //更新数据
        private void button2_Click(object sender, EventArgs e)
        {
            int flag = SQLTools.updateData(textBox2.Text, textBox3.Text, comboBox1.SelectedItem.ToString(),textBox8.Text);
            if (flag != 0)
                label5.Text = "操作成功完成";
            else
                label5.Text = "操作失败！";
        }


        //单选框被点击
        private void radioButton1_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox3.Visible = false;
            comboBox2.Visible = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
        }
        //复选框 系部 被点击
        private void checkBox1_MouseClick(object sender, MouseEventArgs e)
        {
            radioButton1.Checked = false;
            //控制下拉菜单的隐藏显示
            if (checkBox1.Checked)
            {
                comboBox2.Visible = true;
                //给系部添加数据
                addCombo(SQLTools.getMenu(0), comboBox2);
            }
            else
            {
                comboBox2.Visible = false;
            }
        }
        //复选框 专业 被点击
        private void checkBox2_MouseClick(object sender, MouseEventArgs e)
        {
            radioButton1.Checked = false;
            if (checkBox2.Checked)
            {
                comboBox3.Visible = true;
            }
            else
            {
                comboBox3.Visible = false;
            }
            //判断系部是否被选择，不被选择添加所有数据
            if (!checkBox1.Checked)
                addCombo(SQLTools.getMenu(1), comboBox3);
        }
        //系部被下拉选择
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //给专业设置相应数据  形成联动
            addCombo(SQLTools.getMenu(comboBox2.SelectedItem.ToString()), comboBox3);
        }
        //点击附加查询
        private void button6_Click(object sender, EventArgs e)
        {
            //单选框是否被选中
            if (radioButton1.Checked)
            {
                DataTable dt = SQLTools.findData("' or 1=1;--");
                addGrid(dt);
            }
            else if (checkBox1.Checked && checkBox2.Checked)
            {
                DataTable dt = SQLTools.getDT(comboBox3.SelectedItem.ToString(), comboBox2.SelectedItem.ToString());
                addGrid(dt);
            }
            else if (checkBox2.Checked) //只有专业被选中
            {
                DataTable dt = SQLTools.getDT(comboBox3.SelectedItem.ToString(), "");
                addGrid(dt);
            }
            else //系部被选中
            {
                DataTable dt = SQLTools.getDT("", comboBox2.SelectedItem.ToString());
                addGrid(dt);
            }
        }

        //抽取的方法 添加数据到容器
        private void addGrid(DataTable dt)
        {
            //先判断是否为空  不为空先清空数据
            if (dataGridView1.DataSource != null)
            {
                dataGridView1.DataSource = null;
            }
            dataGridView1.DataSource = dt;
        }
        //抽取方法 给下拉列表添加数据
        private void addCombo(DataTable dt, ComboBox com)
        {
            com.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                com.Items.Add(dt.Rows[i][0]);
            }
            com.SelectedIndex = 0;
        }

       
    }
}

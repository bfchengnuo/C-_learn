using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace UI
{
    public partial class MainWindow : Form
    {
        private bool flag = true; //控制窗体加载/隐藏
        private Button[] btn = new Button[20];
        private DataTable dt; //存放题目信息
        private DataTable data = SQLTools.getExamDT(); //存放答案
        private int[] index = new int[20]; //存放选择项
        private Button isBtn; //当前获得焦点的按钮
        private int pointer; //指向当前焦点按钮  上面的可以省略用这个来代替
        private int oldPointer = -1;  //保存上一个点击的按钮
        private int Next; //按顺序下一个按钮

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            Landed load = new Landed();
            load.Owner = this;
            load.Show();

            //动态生成按钮
            for (int i = 0; i < 20; i++)
            {
                btn[i] = new Button();
                btn[i].Width = 75;
                btn[i].Height = 30;
                btn[i].Top = 30 * (i / 10) + 400;
                btn[i].Left = 75 * (i % 10) + 22;
                btn[i].Text = "第" + (i + 1) + "题";
                btn[i].Tag = i.ToString();
                btn[i].Click += btn_Click;
                btn[i].BackColor = Color.Red;
                this.Controls.Add(btn[i]);
            }

            //获取题目
            dt = SQLTools.getDT();
            //默认加载第一题（第一个按钮）
            btn_Click(btn[0], e);
            //题目装载
            for (int i = 0; i < 20; i++)
            {
                DataRow dr = data.NewRow();
                dr["ID"] = dt.Rows[i][0];
                data.Rows.Add(dr);
            }


        }
        //------------------------------
        private void btn_Click(object sender, EventArgs e)
        {
            isBtn = (Button)sender;
            pointer = int.Parse(isBtn.Tag.ToString());

            //如果点击过上个按钮 则设置上个按钮的颜色
            if (oldPointer >= 0)
            {
                doOldCheck(oldPointer);
            }

            //如果当前按钮已经选择过 设置保存的选项，否则清除所有选择
            if (index[pointer] > 0)
                setRead(index[pointer]);
            else
            {
                cleanRead(isBtn);
            }

            doCheck(isBtn, pointer); //显示数据  处于按钮焦点选择状态
            Next = (pointer + 1) % 20; //循环显示
            oldPointer = pointer;
        }

        //设置上一个按钮的颜色
        private void doOldCheck(int oldPointer)
        {
            //判断是否已经选择
            if (index[oldPointer] > 0)
            {
                btn[oldPointer].BackColor = Color.Blue;
            }
            else
                btn[oldPointer].BackColor = Color.Red;
        }


        //添加相应数据，以及设置选中焦点颜色
        private void doCheck(Button btn, int i)
        {
            btn.BackColor = Color.Pink;
            label2.Text = dt.Rows[i][1].ToString();
            radioButton1.Text = dt.Rows[i][2].ToString();
            radioButton2.Text = dt.Rows[i][3].ToString();
            radioButton3.Text = dt.Rows[i][4].ToString();
            radioButton4.Text = dt.Rows[i][5].ToString();
        }
        //保存数据到datatable及int[]
        private void saveData(Button btn, int i)
        {
            //获取选择的答案
            int key = isCheck();
            if (key > 0) //为了防止意外 判断下，可忽略
            {
                //DataRow dr = data.NewRow();
                //dr["ID"] = i+1;
                //dr["EXAM_KEY"] = key;
                //data.Rows.Add(dr); 如果这样插入的话会有重复值，暂未解决
                data.Rows[i]["EXAM_KEY"] = key;
                index[i] = key;
            }
        }
        //判断选择项
        private int isCheck()
        {
            if (radioButton1.Checked)
                return 1;
            else if (radioButton2.Checked)
                return 2;
            else if (radioButton3.Checked)
                return 3;
            else if (radioButton4.Checked)
                return 4;
            else
                return -1;
        }
        //清空单选
        private void cleanRead(Button btn)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }
        //显示保存的选项 如果查看已经选择的按钮
        private void setRead(int index)
        {
            if (index == 1)
                radioButton1.Checked = true;
            else if (index == 2)
                radioButton2.Checked = true;
            else if (index == 3)
                radioButton3.Checked = true;
            else if (index == 4)
                radioButton4.Checked = true;
        }

        //如果点击了单选按钮就保存答案  单选框已捆绑
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            saveData(isBtn, pointer);
        }

        private void MainWindow_Activated(object sender, EventArgs e)
        {
            if (flag)
            {
                Hide(); //窗体加载完毕 激活状态
                flag = false;
            }
        }

        //下一题
        private void button2_Click(object sender, EventArgs e)
        {
            btn_Click(btn[Next], e);
        }
        //上一题  此处有个bug 未修复
        private void button1_Click(object sender, EventArgs e)
        {
            btn_Click(btn[Next - 2], e);
        }

        //交卷按钮
        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否提交？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SQLTools.doInsert(data);
                MessageBox.Show("提交成功！");
                this.Close();
            }
        }
    }
}

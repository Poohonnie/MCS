using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_2
{
    public partial class 计算器 : Form
    {
        string line = ""; //显示值
        double M = 0.0; //储存值
        int oprt = 0; //运算符号; 1 3 4 分别代表 + * / ; 0 代表未读入运算符。
        int minus = 0; //记录输入'-'运算符的次数，正数 True 0 False。
        public 计算器()
        {
            InitializeComponent();
        }

        private void buttonMr_Click(object sender, EventArgs e)   //取出储存值
        {
            switch(oprt)
            {
                case 0:line = Convert.ToString(M);break;   //将显示值设置为M
                default:line += Convert.ToString(M); break;
            }
            DisplayBox.Text = line;  //输出
        }

        private void buttonMc_Click(object sender, EventArgs e)    
        {
            M = 0.0;  //M清零
        }

        private void buttonMPlus_Click(object sender, EventArgs e)
        {
            this.buttonEqual_Click(sender, e);   //调用"="方法输出当前屏幕显示的式子的值
            M += double.Parse(line);    //更新储存值
            line = Convert.ToString(M);
            DisplayBox.Text = line;
        }

        private void buttonMMinus_Click(object sender, EventArgs e)    //同 M+
        {
            this.buttonEqual_Click(sender, e);
            M -= double.Parse(line);
            line = Convert.ToString(M);
            DisplayBox.Text = line;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (line == "0")  //消除前导0的影响
                line = "1";
            else
                line += '1'; DisplayBox.Text = line;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (line == "0")
                line = "2";
            else
                line += '2'; DisplayBox.Text = line;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (line == "0")
                line = "3";
            else
                line += '3'; DisplayBox.Text = line;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (line == "0")
                line = "4";
            else
                line += '4';
            DisplayBox.Text = line;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (line == "0")
                line = "5";
            else
                line += '5';
            DisplayBox.Text = line;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (line == "0")
                line = "6";
            else
                line += '6';
            DisplayBox.Text = line;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (line == "0")
                line = "7";
            else
                line += '7'; DisplayBox.Text = line;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (line == "0")
                line = "8";
            else
                line += '8';
            DisplayBox.Text = line;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (line == "0")
                line = "9";
            else 
                line += '9';
            DisplayBox.Text = line;
        }
        private void button0_Click(object sender, EventArgs e)
        {
            if (line != "0") 
                line += 0;  // 消除前导0的影响
            DisplayBox.Text = line;
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            switch(oprt)
            {
                case 0: line += '+';break;
                case 1: break;
                case 3: line = line.Replace("*", "+"); break;
                case 4: line = line.Replace("/", "+"); break;
            }    //更正运算符为+
            oprt = 1;  //记录运算符状态
            DisplayBox.Text = line;
        }

        private void buttonMinus_Click(object sender, EventArgs e) //仅表示负号，减法算法不在此方法内
        {
            line += '-';
            minus++;
            DisplayBox.Text = line;
        }

        private void buttonMultiply_Click(object sender, EventArgs e)  //同+
        {
            switch (oprt)
            {
                case 0: line += '*'; break;
                case 1: line = line.Replace("+", "*"); break;
                case 3: break;
                case 4: line = line.Replace("/", "*"); break;
            }
            oprt = 3;
            DisplayBox.Text = line;
        }

        private void buttonDivide_Click(object sender, EventArgs e)  //同+
        {
            switch (oprt)
            {
                case 0: line += '/'; break;
                case 1: line = line.Replace("+", "/"); break;
                case 3: line = line.Replace("*", "/"); break;
                case 4: break;
            }
            oprt = 4;
            DisplayBox.Text = line;
        }

        private void buttonPoint_Click(object sender, EventArgs e)  //添加'.'
        {
            line += ".";
            DisplayBox.Text = line;
        }

        private void buttonC_Click(object sender, EventArgs e)  //清屏
        {
            line = "";
            oprt = 0; //使运算状态恢复初始状态
            DisplayBox.Text = line;
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            string[] val; //用于存储line表达式中的数据
            switch (oprt)
            {
                case 0:
                    {
                        // 出现过至少两次'-'号，第一个数为负数的减法运算
                        if (minus > 1)
                        {
                            val = line.Split('-');
                            line = Convert.ToString( - double.Parse(val[1]) - double.Parse(val[2]));
                            DisplayBox.Text = line;
                        }
                        // 出现一次负号，要么是都为正数的减法运算，要么为单个负数
                        if (minus == 1)
                        {
                            if (line.Substring(0, 1) == "-")  // 单个负数
                                DisplayBox.Text = line;
                            else  // 两个正数的减法
                            {
                                val = line.Split('-');
                                line = Convert.ToString(double.Parse(val[0]) - double.Parse(val[1]));
                                DisplayBox.Text = line;
                            }
                        }
                        break;
                    }
                case 1:
                    {
                        //加法
                        val = line.Split('+'); //读取并存储数据
                        line = Convert.ToString(double.Parse(val[0]) + double.Parse(val[1]));  //计算结果
                        DisplayBox.Text = line;    //将结果显示出来
                        break;
                    }
                case 3:
                    {
                        //乘法
                        val = line.Split('*');
                        line = Convert.ToString(double.Parse(val[0]) * double.Parse(val[1]));
                        DisplayBox.Text = line;
                        break;
                    }
                case 4:
                    {
                        //除法
                        val = line.Split('/');
                        line = Convert.ToString(double.Parse(val[0]) / double.Parse(val[1]));
                        DisplayBox.Text = line;
                        break;
                    }
            }
            oprt = 0;
            if (double.Parse(line) > 0)
                minus = 0;
            else minus = 1;
            //标记负号出现情况
        }
    }
}

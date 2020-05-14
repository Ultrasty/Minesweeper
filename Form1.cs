using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public bool cai = true;
        int n = 11;
        Label[,] x=new Label[11,11];
        bool[,] bomb = new bool[11, 11];
        int[,] num = new int[13, 13];//指示周围雷的数量的数组
        private void Form1_Load(object sender, EventArgs e)
        {
            int xWidth = SystemInformation.PrimaryMonitorSize.Width;
            int yHeight = SystemInformation.PrimaryMonitorSize.Height; 
            this.Location=new Point (0,yHeight/2-this.Height/2);
      
        }
        private void lab_Click(object sender, System.EventArgs e)
        {

        }
        private void box_MouseDown(object sender, MouseEventArgs e)
        {
            int win=0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (x[i,j].Text != "" || x[i,j].BackColor != SystemColors.Control)
                        win++;
                }
            }
            if (win == n * n-1) MessageBox.Show("你真六","温馨提示");
            if (e.Button == MouseButtons.Left)
            {
                int w = (((Label)sender).Left - 20) / 32;
                int h = (((Label)sender).Top - 20) / 32;
                if (bomb[w, h])
                {
                    
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if (bomb[i, j]) x[i, j].BackColor = Color.Red;
                        }
                    }
                    Form2 frm2 = new Form2();
                    while (cai)
                    { 
                        frm2.ShowDialog(this);
                    }
                }
                else
                {
                    ((Label)sender).Text = num[w + 1, h + 1].ToString();
                    ((Label)sender).Font = new Font("方正清刻本悦宋", 20);
                    ((Label)sender).ForeColor = Color.Blue;
                }
                for (int o = 1; o <= 18;o++ )
                    for (int i = 0; i < n ; i++)
                    {
                        for (int j = 0; j < n ; j++)
                        {
                            if (x[i, j].Text == "0")
                                for (int g = i - 1; g <= i + 1; g++)
                                {
                                    for (int q = j - 1; q <= j + 1; q++)
                                    {
                                        try
                                        {
                                            x[g, q].Text = num[g + 1, q + 1].ToString();
                                        }
                                        catch
                                        {
                                            
                                        }
                                    }
                                }

                        }
                    }

                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if (x[i, j].Text != "")
                            {
                                x[i, j].Font = new Font("方正清刻本悦宋", 20);
                                x[i, j].ForeColor = Color.Blue;
                            }
                        }
                    }
            }
            
            
            if (e.Button == MouseButtons.Right)
            {
             if (((Label)sender).BackColor == SystemColors.Control)
                {
                    int w = (((Label)sender).Left - 20) / 32;
                    int h = (((Label)sender).Top - 20) / 32;
                    x[w, h].BackColor = Color.Green;
                }
                else
                {
                    ((Label)sender).BackColor =SystemColors.Control;
                }
            }
        }
        int y;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            cai = true;
            try 
            {
                int d = int.Parse(textBox1.Text);
            }
            catch
            {
                return;
            }
            if (int.Parse(textBox1.Text) > 121 || int.Parse(textBox1.Text) < 1) return;
            if (y == 0)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        x[i, j] = new Label();
                        x[i, j].Size = new Size(30, 30);
                        x[i, j].Location = new Point(20 + 32 * i, 20 + 32 * j);
                        x[i, j].AutoSize = false;
                        x[i, j].BorderStyle = BorderStyle.Fixed3D;
                        this.Controls.Add(x[i, j]);
                        x[i, j].Click += new EventHandler(this.lab_Click);
                        x[i, j].MouseDown += new MouseEventHandler(this.box_MouseDown);
                    }
                }
                y = 1;
            }
            
            for (int i = 0; i < n; i++)                        //初始化
            {
                for (int j = 0; j < n; j++)
                {
                    bomb[i, j] = false;
                    x[i, j].Text = "";
                    x[i, j].BackColor = SystemColors.Control;
                }
            }
            for (int i = 0; i < 13; i++)                       
            {
                for (int j = 0; j < 13; j++)
                {

                    num[i, j] = 0;
                }
            }
            
            int a, b;
            Random r = new Random();//产生雷的random对象
            int bombmax = 1;

            while (bombmax <= int.Parse(textBox1.Text))//获取设定的雷的总数
            {
                a = r.Next(0, n);
                b = r.Next(0, n);
                if (bomb[a, b] == false)
                {
                    bombmax++;
                    bomb[a, b] = true;
                    for (int i = a; i <= a + 2; i++)
                    {
                        for (int j = b; j <= b + 2; j++)
                        {
                            num[i, j]++;
                        }
                    }
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cai = true;
            for (int i = 0; i < n; i++)                        //初始化
            {
                for (int j = 0; j < n; j++)
                {
                    
                    x[i, j].Text = "";
                    x[i, j].BackColor = SystemColors.Control;
                }
            }
        }
    }
}

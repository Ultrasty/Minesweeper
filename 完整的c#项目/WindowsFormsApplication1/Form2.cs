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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("你真菜", "温馨提示");
            this.Close();
            Form1 frm1 = (Form1)this.Owner;
            frm1.cai = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int x = r.Next(0, this.Width - button2.Width - 10);
            int y = r.Next(0, this.Height - button2.Height - 10);
            button2.Location = new Point(x, y);
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            
            
            
        }
        
        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
           
            int a = button2.Left;
            int b = button2.Left+button2.Width;
            int c = button2.Top;
            int d = button2.Top + button2.Height;



            if (e.X < a && e.X > a - 20 && e.Y < d && e.Y > c)
            {
                button2.Left = e.X + 20;
                if (b + 14 > this.Width)
                    move();
            }
            if (e.X > b && e.X < b + 20 && e.Y < d && e.Y > c)
            {
                button2.Left = e.X - 20 -button2.Width;
                if (a < 0)
                    move();
            }
            if (e.X > a && e.X < b  && e.Y < d+20 && e.Y > d)
            {
                button2.Top  = e.Y - 20 - button2.Height;
                if (c < 0)
                    move();
            }
            if (e.X > a && e.X < b && e.Y < c && e.Y > c-20)
            {
                button2.Top = e.Y + 20 ;
                if (d+37>this.Height)
                    move();
            }


                //if (e.X > button2.Left+button2.Width)
                //{
                //    button2.Left = e.X - 12-button2.Width;
                //    if (button2.Left< 0)
                //        move();
                //}
                //if (e.Y < button2.Top)
                //{
                //    button2.Top = e.Y + 12;
                //    if (button2.Top + button2.Height - 20 > this.Height)
                //        move();
                //}
                //if (e.Y > button2.Top+button2.Height)
                //{
                //    button2.Top = e.Y - 12-button2.Height;
                //    if (button2.Top<0)
                //        move();
                //}

                

            
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            move();
        }

        private void Form2_MouseHover(object sender, EventArgs e)
        {
            
        }
        private void move()
        {
        re: Random r = new Random();
            int x = r.Next(0, this.Width - button2.Width - 20);
            int y = r.Next(0, this.Height - button2.Height - 20);
            if (x >= button2.Left && x <= button2.Left + button2.Width && y >= button2.Top && y <= button2.Top + button2.Height)
                goto re;
            button2.Location = new Point(x, y);
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {                 
            Form1 frm1 = (Form1)this.Owner;

            int xWidth = SystemInformation.PrimaryMonitorSize.Width;
            int yHeight = SystemInformation.PrimaryMonitorSize.Height;
            this.Location = new Point(frm1.Width,yHeight/2-this.Height/2);

            

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            int a = button2.Left;
            int b = button2.Left + button2.Width;
            int c = button2.Top;
            int d = button2.Top + button2.Height;



            if (e.X+pictureBox1.Left < a && e.X+pictureBox1.Left > a - 20 && e.Y+pictureBox1.Top < d && e.Y+pictureBox1.Top > c)
            {
                button2.Left = e.X+pictureBox1.Left + 20;
                if (b + 14 > this.Width)
                    move();
            }
            if (e.X+pictureBox1.Left > b && e.X+pictureBox1.Left < b + 20 && e.Y+pictureBox1.Top < d && e.Y+pictureBox1.Top > c)
            {
                button2.Left = e.X+pictureBox1.Left - 20 - button2.Width;
                if (a < 0)
                    move();
            }
            if (e.X+pictureBox1.Left > a && e.X+pictureBox1.Left < b && e.Y+pictureBox1.Top < d + 20 && e.Y+pictureBox1.Top > d)
            {
                button2.Top = e.Y+pictureBox1.Top - 20 - button2.Height;
                if (c < 0)
                    move();
            }
            if (e.X+pictureBox1.Left > a && e.X+pictureBox1.Left < b && e.Y+pictureBox1.Top < c && e.Y+pictureBox1.Top > c - 20)
            {
                button2.Top = e.Y+pictureBox1.Top + 20;
                if (d + 37 > this.Height)
                    move();
            }
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            int a = button2.Left;
            int b = button2.Left + button2.Width;
            int c = button2.Top;
            int d = button2.Top + button2.Height;



            if (e.X+button1.Left < a && e.X+button1.Left > a - 20 && e.Y+button1.Top < d && e.Y+button1.Top > c)
            {
                button2.Left = e.X+button1.Left + 20;
                if (b + 14 > this.Width)
                    move();
            }
            if (e.X+button1.Left > b && e.X+button1.Left < b + 20 && e.Y+button1.Top < d && e.Y+button1.Top > c)
            {
                button2.Left = e.X+button1.Left - 20 - button2.Width;
                if (a < 0)
                    move();
            }
            if (e.X+button1.Left > a && e.X+button1.Left < b && e.Y+button1.Top < d + 20 && e.Y+button1.Top > d)
            {
                button2.Top = e.Y+button1.Top - 20 - button2.Height;
                if (c < 0)
                    move();
            }
            if (e.X+button1.Left > a && e.X+button1.Left < b && e.Y+button1.Top < c && e.Y+button1.Top > c - 20)
            {
                button2.Top = e.Y+button1.Top + 20;
                if (d + 37 > this.Height)
                    move();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lb0804
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void double_recursion(int n)
        {
            textBox2.Clear();
            int k = Count(n);
            Record(k-1, n);


        }

        private void Record(int k, int n)
        {
            if (k>=0)
            {
                textBox2.Text += ((int)(n / (Math.Pow(10,k))) % 10).ToString() + " "; Record(k - 1, n);

            }
        }

        public  int k = 0;
        private int Count(int n)
        {
            if (n != 0)
            { k++; return Count(n / 10); }
            else return k;

        }
    
        public int flag = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (flag == 0)
            {
                k = 0;
                flag++;
                double_recursion(Convert.ToInt32(textBox1.Text));
            }
            else
            {
                panel1.Visible = true;
                button1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            flag = 0;
            panel1.Visible = false;
            button1.Enabled = true;
            textBox1.Clear();
            textBox2.Clear();
            k = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

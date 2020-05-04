using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lb1304
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Panel picture = new Panel();
        private void button1_Click(object sender, EventArgs e)
        {
            int k = Convert.ToInt32(numericUpDown1.Value);
            picture.Size = new Size(k*10, k*10);
            picture.Location = new Point(12, 56);
            picture.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Remove(picture);
            this.Controls.Add(picture);


            Graphics g =picture.CreateGraphics();

            for (int i = (k - 1); i > 0; i--)
            {
                g.DrawLine(new Pen(Color.Blue), 10, i * 10, k * 10 - 10, i * 10);
                if (i % 2 != 0)
                {
                    g.DrawLine(new Pen(Color.Blue), 10, i * 10, 13, i * 10+3);
                    g.DrawLine(new Pen(Color.Blue), 10, i * 10, 13, i * 10-3);
                    if (i != 1)
                    {
                        g.DrawLine(new Pen(Color.Blue), 10, i * 10, 10, (i-1) * 10 );
                       g.DrawLine(new Pen(Color.Blue), 10, (i-1) * 10, 13, (i-1) * 10 + 3);
                        g.DrawLine(new Pen(Color.Blue), 10, (i - 1) * 10, 7, (i - 1) * 10 + 3);
                    }

                }
                else
                {
                    g.DrawLine(new Pen(Color.Blue), k * 10 - 13, i * 10+3, k * 10 - 10, i * 10);
                    g.DrawLine(new Pen(Color.Blue), k * 10 - 13, i * 10-3, k * 10 - 10, i * 10);


                    g.DrawLine(new Pen(Color.Blue), k * 10-10, i * 10, k * 10-10, (i - 1) * 10);
                    g.DrawLine(new Pen(Color.Blue), k * 10 - 10, (i - 1) * 10, k * 10 - 13, (i - 1) * 10 + 3);
                    g.DrawLine(new Pen(Color.Blue), k * 10 - 10, (i - 1) * 10, k * 10 -7, (i - 1) * 10 + 3);

                }
            }

           

        }

    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lb1504
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
        public void FillPolygonPoint(PaintEventArgs e)
        {

            // Create solid brush.
            SolidBrush blueBrush = new SolidBrush(Color.Blue);
            Pen pen = new Pen(Color.Red);
            // Create points that define polygon.
            Point point1 = new Point(50, 50);
            Point point2 = new Point(100, 25);
            Point point3 = new Point(200, 5);
            Point point4 = new Point(250, 50);
            Point point5 = new Point(300, 100);
            Point point6 = new Point(350, 200);
            Point point7 = new Point(250, 250);
            Point[] curvePoints = { point1, point2, point3, point4, point5, point6, point7 };
            PointF[] curvePoints2 = { point1, point2, point3, point4, point5, point6, point7 };

            // Draw polygon to screen.
            e.Graphics.FillPolygon(blueBrush, curvePoints);
            e.Graphics.DrawPolygon(pen, curvePoints2);
         
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            this.FillPolygonPoint(e);
        }
    }
}

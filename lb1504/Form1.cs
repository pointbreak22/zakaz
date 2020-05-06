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
            Paint();
        }
        public void Paint()
        {
            zed.GraphPane.CurveList.Clear();
            zed.GraphPane.GraphObjList.Clear();
            zed.GraphPane.AddCurve("Line", new[] { 0.0, 0.0 }, new[] { 0.0, 4.0 }, Color.Red);
            zed.GraphPane.AddCurve("Line", new[] { 0.0, 2.0 }, new[] { 4.0, 4.0 }, Color.Red);
            zed.GraphPane.AddCurve("Line", new[] { 2.0, 2.0 }, new[] { 0.0, 4.0 }, Color.Red);
            zed.GraphPane.AddCurve("Line", new[] { 2.0, 0.0 }, new[] { 0.0, 0.0 }, Color.Red);

            zed.GraphPane.AddCurve("Line", new[] { 1.0, 4.0 }, new[] { 1.0, 1.0 }, Color.Red);
            zed.GraphPane.AddCurve("Line", new[] { 1.0, 1.0 }, new[] { 1.0, 3.0 }, Color.Red);
            zed.GraphPane.AddCurve("Line", new[] { 1.0, 4.0 }, new[] { 3.0, 3.0 }, Color.Red);
            zed.GraphPane.AddCurve("Line", new[] { 4.0, 4.0 }, new[] { 1.0, 3.0 }, Color.Red);
            zed.AxisChange();
            zed.Invalidate();

        }





        private void button1_Click(object sender, EventArgs e)
        {
            flag1 = 0;
            flag2 = 0;
            flag3 = 0;




            Paint();
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
        int flag1 = 0; int flag2 = 0; int flag3 = 0;
        private void zed_MouseMove(object sender, MouseEventArgs e)
        {
            // Сюда будут записаны координаты в системе координат графика
            double x, y;

            // Пересчитываем пиксели в координаты на графике
            // У ZedGraph есть несколько перегруженных методов ReverseTransform.
            zed.GraphPane.ReverseTransform(e.Location, out x, out y);

            // Выводим результат
            string text = string.Format("X: {0};    Y: {1}", x, y);
            //textBox1.Text = text;
           
            if ((x > 0 && x < 2 && y < 4 && y > 3) || (x > 0 && x < 1 && y < 3 && y > 1) || (x > 0 && x < 2 && y < 1 && y > 0))
            {
                if (flag1 == 0)
                { 
                var poly = new ZedGraph.PolyObj
                {
                    Points = new[]
                      {
                          new ZedGraph.PointD(0, 0),
                          new ZedGraph.PointD(0, 4),
                          new ZedGraph.PointD(2, 4),
                          new ZedGraph.PointD(2, 3),
                          new ZedGraph.PointD(1, 3),
                          new ZedGraph.PointD(1, 1),
                          new ZedGraph.PointD(2, 1),
                          new ZedGraph.PointD(2, 0)
                },

                    Fill = new ZedGraph.Fill(Color.Green),
                    ZOrder = ZedGraph.ZOrder.E_BehindCurves
                };
                zed.GraphPane.GraphObjList.Add(poly);
                zed.AxisChange();
                zed.Invalidate();
                flag1++;

               }


            }
            if (x > 1 && x < 2 && y < 3 && y > 1)
            {
                if (flag2 == 0)
                {
                    var poly2 = new ZedGraph.PolyObj
                {
                    Points = new[]
                  {
                          new ZedGraph.PointD(1, 1),
                          new ZedGraph.PointD(1, 3),
                          new ZedGraph.PointD(2, 3),
                          new ZedGraph.PointD(2, 1)
                       
                },

                    Fill = new ZedGraph.Fill(Color.Green),
                    ZOrder = ZedGraph.ZOrder.E_BehindCurves
                };
                zed.GraphPane.GraphObjList.Add(poly2);
                zed.AxisChange();
                zed.Invalidate();
                flag2++;

                }



            }
            if (x <4 && x > 2 && y < 3 && y > 1)
            {
                if (flag3 == 0)
                {
                    var poly2 = new ZedGraph.PolyObj
                {
                    Points = new[]
                  {                     
                           new ZedGraph.PointD(2, 1),
                           new ZedGraph.PointD(2, 3),
                           new ZedGraph.PointD(4, 3),
                           new ZedGraph.PointD(4, 1),
                },

                    Fill = new ZedGraph.Fill(Color.Green),
                    ZOrder = ZedGraph.ZOrder.E_BehindCurves
                };
                zed.GraphPane.GraphObjList.Add(poly2);
                zed.AxisChange();
                zed.Invalidate();
                flag3++;

                }



            }



        }


    }
}

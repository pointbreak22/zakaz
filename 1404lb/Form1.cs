using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace _1404lb
{
    public partial class Form1 : Form
    {
        GraphPane pane;
        public Form1()
        {
            InitializeComponent();
            pane = zedGraph.GraphPane;
            pane.Title.Text = "y=x^2/A";
            pane.XAxis.Title.Text = "Ось X";
            pane.YAxis.Title.Text = "Ось Y";
          

        }
        private double f(double x, double a)
        {

            return Math.Pow(x,2)/a;
        }
        private void button1_Click(object sender, EventArgs e)
        {
    

            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            pane.CurveList.Clear();
          
            // Создадим список точек
            PointPairList list = new PointPairList();
          
            int a = Convert.ToInt32(numericUpDown1.Value);
            double xmin = -500;
            double xmax = 500;

            // Заполняем список точек
            for (double x = xmin; x <= xmax; x += 0.01)
            {
                // добавим в список точку
                list.Add(x, f(x,a));
            }

            // Создадим кривую с названием "Sinc",
            // которая будет рисоваться голубым цветом (Color.Blue),
            // Опорные точки выделяться не будут (SymbolType.None)
            LineItem myCurve = pane.AddCurve("Парабола", list, Color.Blue, SymbolType.None);

            // Вызываем метод AxisChange (), чтобы обновить данные об осях.
            // В противном случае на рисунке будет показана только часть графика,
            // которая умещается в интервалы по осям, установленные по умолчанию
            zedGraph.AxisChange();

            // Обновляем график
            zedGraph.Invalidate();
        }
    }
}

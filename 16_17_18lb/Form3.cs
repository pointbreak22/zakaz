using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _16_17_18lb
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            
            // richTextBox1.Text = form1.numericUpDown1.Value.ToString() + " " +Form1.peoples.Count;
            switch (comboBox1.Text)
            {
                case "Имя": Form1.peoples[Form1.numer].Imya = textBox1.Text; break;
                case "Рост": Form1.peoples[Form1.numer].Rost = Convert.ToInt32(textBox1.Text); break;
                case "Вес": Form1.peoples[Form1.numer].Ves = Convert.ToInt32(textBox1.Text); ; break;
                case "Возраст": Form1.peoples[Form1.numer].Vozrast = Convert.ToInt32(textBox1.Text); break;
                case "Пол": Form1.peoples[Form1.numer].Pol = textBox1.Text; break;
                case "Лицо": Form1.peoples[Form1.numer].Litco = textBox1.Text; break;
                case "Губы": Form1.peoples[Form1.numer].Gubi = textBox1.Text; break;
                case "Нос": Form1.peoples[Form1.numer].Nos = textBox1.Text; break;
                case "Глаза": Form1.peoples[Form1.numer].Glaza = textBox1.Text; break;
                case "Волосы": Form1.peoples[Form1.numer].Volosi = textBox1.Text; break;
                case "Страна": Form1.peoples[Form1.numer].mestopolozhenie.Strana = textBox1.Text; break;
                case "Город": Form1.peoples[Form1.numer].mestopolozhenie.Gorod = textBox1.Text; break;
                case "Училище": Form1.peoples[Form1.numer].obrazovanie.Uchilishe = textBox1.Text; break;
                case "Специальность": Form1.peoples[Form1.numer].obrazovanie.Spetcialnost = textBox1.Text; break;
                case "Место работы": Form1.peoples[Form1.numer].rabota.Imenovaniye = textBox1.Text; break;
                case "Должность": Form1.peoples[Form1.numer].rabota.Dolzhnost = textBox1.Text; break;

            }
            this.Close();
        }
    }
}

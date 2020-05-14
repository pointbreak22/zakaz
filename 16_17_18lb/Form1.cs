using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace _16_17_18lb
{

    public partial class Form1 : Form
    {
        Person person = new Person();
     static  public List<Person> peoples = new List<Person>();
        public List<string> stImya= new List<string>() { "Даша", "Петя", "Надя", "Дима"};
        public List<string> stPol = new List<string>() { "мужской", "женский" };
        public List<string> stLitco = new List<string>() { "круглое", "овальное", "узкое", "скуластое" };
        public List<string> stGubi = new List<string>() { "яркие", "бледные", "бесцветные", "алые" };
        public List<string> stNos = new List<string>() { "прямой", "острый", "греческий", "орлиный" };
        public List<string> stGlaza = new List<string>() { "голубые ", "зелёные", "синие", "чёрные" };
        public List<string> stVolosi = new List<string>() { "светлые", "тёмные", "русые", "каштановые" };
        public List<string> stStrana = new List<string>() { "Россия", "Украина", "Молдова", "ПМР" };
        public List<string> stGorod = new List<string>() { "Москва", "Одесса", "Кишинев", "Тирасполь" };
        public List<string> stSpetcialnos = new List<string>() { "инженер", "медик", "экономист", "химик" };
        public List<string> stUchilishe = new List<string>() { "инженерное", "медицинское", "экономическое", "химическое" };
        public List<string> stDolzhnost = new List<string>() { "мастер", "стажер","мененжер","начальник"};
        public List<string> stImenovaniye = new List<string>() { "Завод", "Поликлинника", "бугалтерия", "лаболатория" };
        public string [] Svoistva = { "Imya", "Rost"," Ves"," Vozrast"," Pol"," Litso ","Gubi"," Nos"," Glaza"," Volosi"," Strana ","Gorod"," Spetcialnost"," Uchilishe"," Dolzhnost"," Imenovaniye" };

        public Form1()
        {
            InitializeComponent();
            button16.ContextMenuStrip = contextMenuStrip1;
            XmlSerializer formatter = new XmlSerializer(typeof(List<Person>));

            using (Stream fStream = File.OpenRead("save.xml"))
            {
                peoples= (List<Person>)formatter.Deserialize(fStream);
                MessageBox.Show("C файла пришла информация об обьектов");
                if (peoples.Count>0)
                {
                    numericUpDown1.Maximum = peoples.Count;
                    numericUpDown1.Minimum = 1;
                    numericUpDown3.Maximum = peoples.Count;
                    numericUpDown3.Minimum = 1;
                    AutoComp();
                }
               

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            person.method1(textImya.Text);
        }

       
      
        private void button9_Click(object sender, EventArgs e)
        {

            Person p = new Person()
            {
                Imya = textImya.Text,
                Rost = Convert.ToInt32(textRost.Text),
                Ves = Convert.ToInt32(textVes.Text),
                Vozrast = Convert.ToInt32(textVozrast.Text),
                Pol = textPol.Text,
                Litco = textLitso.Text,
                Gubi = textGubi.Text,
                Nos = textNos.Text,
                Glaza = textGlaza.Text,
                Volosi = textVolosi.Text,
                mestopolozhenie = new Mestopolozhenie() { Strana = textStrana.Text, Gorod = textGorod.Text },
                obrazovanie = new Obrazovanie() { Spetcialnost = textSpetcialnost.Text, Uchilishe = textUchilishe.Text },
                rabota = new Rabota() { Dolzhnost = textDolzhnost.Text, Imenovaniye = textImenovaniye.Text }


            };

            peoples.Add(p);
            numericUpDown1.Maximum = peoples.Count;
            numericUpDown1.Minimum = 1;
            numericUpDown3.Maximum = peoples.Count;
            numericUpDown3.Minimum = 1;
            AutoComp();



        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            person.method2(textRost.Text);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            person.method3(textVes.Text);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            person.method4(textVozrast.Text);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            person.method5(textPol.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            person.mestopolozhenie = new Mestopolozhenie();
            person.mestopolozhenie.method6(textStrana.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            person.obrazovanie = new Obrazovanie();
            person.obrazovanie.method7(textSpetcialnost.Text);
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            person.rabota = new Rabota();
            person.rabota.method8(textDolzhnost.Text);
        }

        private void AutoComplete(TextBox textBox, string str)
        {
            
                AutoCompleteStringCollection source = new AutoCompleteStringCollection();
                foreach (Person p in peoples)
                {
                    switch (str)
                    {
                        case "Imya": source.Add(p.Imya); break;
                        case "Rost": source.Add(p.Rost.ToString()); break;
                        case "Ves": source.Add(p.Ves.ToString()); break;
                        case "Vozrast": source.Add(p.Vozrast.ToString()); break;
                        case "Pol": source.Add(p.Pol); break;
                        case "Litco": source.Add(p.Litco); break;
                        case "Gubi": source.Add(p.Gubi); break;
                        case "Nos": source.Add(p.Nos); break;
                        case "Glaza": source.Add(p.Glaza); break;
                        case "Volosi": source.Add(p.Volosi); break;
                        case "Strana": source.Add(p.mestopolozhenie.Strana); break;
                        case "Gorod": source.Add(p.mestopolozhenie.Gorod); break;
                        case "Spetcialnos": source.Add(p.obrazovanie.Spetcialnost); break;
                        case "Uchilishe": source.Add(p.obrazovanie.Uchilishe); break;
                        case "Dolzhnost": source.Add(p.rabota.Dolzhnost); break;
                        case "Imenovaniye": source.Add(p.rabota.Imenovaniye); break;
                    }
                }
                textBox.AutoCompleteCustomSource = source;
                textBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            
        }
        private void AutoComp()
        {
            AutoComplete(textImya, "Imya");
            AutoComplete(textRost, "Rost");
            AutoComplete(textVes, "Ves");
            AutoComplete(textVozrast, "Vozrast");
            AutoComplete(textPol, "Pol");
            AutoComplete(textLitso, "Litso");
            AutoComplete(textGubi, "Gubi");
            AutoComplete(textNos, "Nos");
            AutoComplete(textGlaza, "Glaza");
            AutoComplete(textVolosi, "Volosi");
            AutoComplete(textStrana, "Strana");
            AutoComplete(textGorod, "Gorod");
            AutoComplete(textUchilishe, "Uchilishe");
            AutoComplete(textSpetcialnost, "Spetcialnost");
            AutoComplete(textImenovaniye, "Imenovaniye");
            AutoComplete(textDolzhnost, "Dolzhnost");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            textImya.Text = stImya[random.Next(stImya.Count)];
            textRost.Text = random.Next(100, 200).ToString();
            textVes.Text = random.Next(50, 120).ToString();
            textVozrast.Text = random.Next(20, 60).ToString();
            textPol.Text = stPol[random.Next(stPol.Count)];
            textLitso.Text = stLitco[random.Next(stLitco.Count)];
            textGubi.Text = stGubi[random.Next(stGubi.Count)];
            textNos.Text = stNos[random.Next(stNos.Count)];
            textGlaza.Text = stGlaza[random.Next(stGlaza.Count)];
            textVolosi.Text = stVolosi[random.Next(stVolosi.Count)];
            textStrana.Text = stStrana[random.Next(stStrana.Count)];
            textGorod.Text = stGorod[random.Next(stGorod.Count)];
            textSpetcialnost.Text = stSpetcialnos[random.Next(stSpetcialnos.Count)];
            textUchilishe.Text = stUchilishe[random.Next(stUchilishe.Count)];
            textDolzhnost.Text = stDolzhnost[random.Next(stDolzhnost.Count)];
            textImenovaniye.Text = stImenovaniye[random.Next(stImenovaniye.Count)];
        }

        public  void datagreed_reloard()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            for (int i = 0; i < 4; i++)
            {
                var column1 = new DataGridViewColumn();
                column1.HeaderText = Svoistva[i]; //текст в шапке
                column1.Width = 100; //ширина колонки
                column1.ReadOnly = true; //значение в этой колонке нельзя править
                column1.Name = "name"+i.ToString(); //текстовое имя колонки, его можно использовать вместо обращений по индексу
                column1.Frozen = true; //флаг, что данная колонка всегда отображается на своем месте
                column1.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки
                dataGridView1.Columns.Add(column1);
            }
            foreach (Person p in peoples)
             dataGridView1.Rows.Add(p.Imya,p.Rost,p.Ves,p.Vozrast);


        }



        private void button12_Click(object sender, EventArgs e)
        {
            datagreed_reloard();

        }

        private void alllab_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            form2.richTextBox1.Clear();
            form2.richTextBox1.SelectedText = "Имя - " + peoples[Convert.ToInt32(numericUpDown1.Value-1)].Imya+"\n";
            form2.richTextBox1.SelectedText = "Рост - " + peoples[Convert.ToInt32(numericUpDown1.Value-1)].Rost.ToString()+"\n";
            form2.richTextBox1.SelectedText = "Вес - " + peoples[Convert.ToInt32(numericUpDown1.Value-1)].Ves.ToString()+"\n";
            form2.richTextBox1.SelectedText = "Возраст - " + peoples[Convert.ToInt32(numericUpDown1.Value-1)].Vozrast.ToString()+"\n";
            form2.richTextBox1.SelectedText = "Пол - " + peoples[Convert.ToInt32(numericUpDown1.Value-1)].Pol.ToString() + "\n";
            form2.richTextBox1.SelectedText = "Лицо - " + peoples[Convert.ToInt32(numericUpDown1.Value-1)].Litco+"\n";
            form2.richTextBox1.SelectedText = "Губы - " + peoples[Convert.ToInt32(numericUpDown1.Value-1)].Gubi+"\n";
            form2.richTextBox1.SelectedText = "Нос - " + peoples[Convert.ToInt32(numericUpDown1.Value-1)].Nos+"\n";
            form2.richTextBox1.SelectedText = "Глаза - " + peoples[Convert.ToInt32(numericUpDown1.Value-1)].Glaza+"\n";
            form2.richTextBox1.SelectedText = "Волосы - " + peoples[Convert.ToInt32(numericUpDown1.Value-1)].Volosi+"\n";
            form2.richTextBox1.SelectedText = "Страна - " + peoples[Convert.ToInt32(numericUpDown1.Value-1)].mestopolozhenie.Strana+"\n";
            form2.richTextBox1.SelectedText = "Город - " + peoples[Convert.ToInt32(numericUpDown1.Value-1)].mestopolozhenie.Gorod+"\n";
            form2.richTextBox1.SelectedText = "Специальность - " + peoples[Convert.ToInt32(numericUpDown1.Value-1)].obrazovanie.Spetcialnost+"\n";
            form2.richTextBox1.SelectedText = "Училище- " + peoples[Convert.ToInt32(numericUpDown1.Value-1)].obrazovanie.Uchilishe+"\n";
            form2.richTextBox1.SelectedText = "Место работы - " + peoples[Convert.ToInt32(numericUpDown1.Value-1)].rabota.Imenovaniye+"\n";
            form2.richTextBox1.SelectedText = "Должность - " + peoples[Convert.ToInt32(numericUpDown1.Value-1)].rabota.Dolzhnost+"\n";
            
        
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (peoples.Count > 0)
            {
                peoples.RemoveAt(Convert.ToInt32(numericUpDown1.Value-1));
                datagreed_reloard();              
                    numericUpDown1.Maximum = peoples.Count;
                    numericUpDown1.Minimum = 1;
                    numericUpDown3.Maximum = peoples.Count;
                    numericUpDown3.Minimum = 1;

               
            }
        }
        static public int numer=0;
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numer = Convert.ToInt32(numericUpDown1.Value);
        }

     

        private void button16_Click(object sender, EventArgs e)
        {
     
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

            person.method1(textImya.Text);
          
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            person.method2(textRost.Text);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            person.method3(textVes.Text);
        }

        private void метод5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            person.method5(textPol.Text);
        }

        private void метод6эToolStripMenuItem_Click(object sender, EventArgs e)
        {
            person.mestopolozhenie = new Mestopolozhenie();
            person.mestopolozhenie.method6(textStrana.Text);
        }

        private void метод7ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            person.obrazovanie = new Obrazovanie();
            person.obrazovanie.method7(textSpetcialnost.Text);
        }

        private void метод8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            person.rabota = new Rabota();
            person.rabota.method8(textDolzhnost.Text);
        }

        private void метод4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            person.method4(textVozrast.Text);
        }
        public List<Person> carFromDisk=new List<Person>();
        private void button18_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog.FileName;
            XmlSerializer formatter = new XmlSerializer(typeof(List<Person>));

            using (Stream fStream = File.OpenRead(filename))
            {
                carFromDisk = (List<Person>)formatter.Deserialize(fStream);
                MessageBox.Show("Загружены объекты из файла ");

            }
            if (carFromDisk.Count ==0)
                MessageBox.Show("Нет объектов");
            numericUpDown2.Maximum = carFromDisk.Count;
            numericUpDown2.Minimum =1;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog.FileName;

            XmlSerializer formatter = new XmlSerializer(typeof(List<Person>));
         
            using (Stream fStream = new FileStream(filename+".xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(fStream, peoples);
            }
            MessageBox.Show("--> Сохранение объекта в Binary format");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Person>));

            using (Stream fStream = new FileStream("save.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(fStream, peoples);
            }
            MessageBox.Show("--> Сохранение объектов в фаил save.xml через Сериализацию xml");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (carFromDisk.Count > 0)
            {
                peoples.Add(carFromDisk[Convert.ToInt32(numericUpDown2.Value - 1)]);
                AutoComp();
            }
            else MessageBox.Show("Нет информации из файла");
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.SelectedText = "Имя - " + carFromDisk[Convert.ToInt32(numericUpDown2.Value-1)].Imya + "\n";
            richTextBox1.SelectedText = "Рост - " + carFromDisk[Convert.ToInt32(numericUpDown2.Value-1)].Rost.ToString() + "\n";
            richTextBox1.SelectedText = "Вес - " + carFromDisk[Convert.ToInt32(numericUpDown2.Value-1)].Ves.ToString() + "\n";
            richTextBox1.SelectedText = "Возраст - " + carFromDisk[Convert.ToInt32(numericUpDown2.Value-1)].Vozrast.ToString() + "\n";
            richTextBox1.SelectedText = "Пол - " + carFromDisk[Convert.ToInt32(numericUpDown2.Value-1)].Pol.ToString() + "\n";
            richTextBox1.SelectedText = "Лицо - " + carFromDisk[Convert.ToInt32(numericUpDown2.Value-1)].Litco + "\n";
            richTextBox1.SelectedText = "Губы - " + carFromDisk[Convert.ToInt32(numericUpDown2.Value-1)].Gubi + "\n";
            richTextBox1.SelectedText = "Нос - " + carFromDisk[Convert.ToInt32(numericUpDown2.Value-1)].Nos + "\n";
            richTextBox1.SelectedText = "Глаза - " + carFromDisk[Convert.ToInt32(numericUpDown2.Value-1)].Glaza + "\n";
            richTextBox1.SelectedText = "Волосы - " + carFromDisk[Convert.ToInt32(numericUpDown2.Value-1)].Volosi + "\n";
            richTextBox1.SelectedText = "Страна - " + carFromDisk[Convert.ToInt32(numericUpDown2.Value-1)].mestopolozhenie.Strana + "\n";
            richTextBox1.SelectedText = "Город - " + carFromDisk[Convert.ToInt32(numericUpDown2.Value-1)].mestopolozhenie.Gorod + "\n";
            richTextBox1.SelectedText = "Специальность - " + carFromDisk[Convert.ToInt32(numericUpDown2.Value-1)].obrazovanie.Spetcialnost + "\n";
            richTextBox1.SelectedText = "Училище- " + carFromDisk[Convert.ToInt32(numericUpDown2.Value-1)].obrazovanie.Uchilishe + "\n";
            richTextBox1.SelectedText = "Место работы - " + carFromDisk[Convert.ToInt32(numericUpDown2.Value-1)].rabota.Imenovaniye + "\n";
            richTextBox1.SelectedText = "Должность - " + carFromDisk[Convert.ToInt32(numericUpDown2.Value-1)].rabota.Dolzhnost + "\n";

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            richTextBox2.SelectedText = "Имя - " + peoples[Convert.ToInt32(numericUpDown3.Value - 1)].Imya + "\n";
            richTextBox2.SelectedText = "Рост - " + peoples[Convert.ToInt32(numericUpDown3.Value - 1)].Rost.ToString() + "\n";
            richTextBox2.SelectedText = "Вес - " + peoples[Convert.ToInt32(numericUpDown3.Value - 1)].Ves.ToString() + "\n";
            richTextBox2.SelectedText = "Возраст - " + peoples[Convert.ToInt32(numericUpDown3.Value - 1)].Vozrast.ToString() + "\n";
            richTextBox2.SelectedText = "Пол - " + peoples[Convert.ToInt32(numericUpDown3.Value - 1)].Pol.ToString() + "\n";
            richTextBox2.SelectedText = "Лицо - " + peoples[Convert.ToInt32(numericUpDown3.Value - 1)].Litco + "\n";
            richTextBox2.SelectedText = "Губы - " + peoples[Convert.ToInt32(numericUpDown3.Value - 1)].Gubi + "\n";
            richTextBox2.SelectedText = "Нос - " + peoples[Convert.ToInt32(numericUpDown3.Value - 1)].Nos + "\n";
            richTextBox2.SelectedText = "Глаза - " + peoples[Convert.ToInt32(numericUpDown3.Value - 1)].Glaza + "\n";
            richTextBox2.SelectedText = "Волосы - " + peoples[Convert.ToInt32(numericUpDown3.Value - 1)].Volosi + "\n";
            richTextBox2.SelectedText = "Страна - " + peoples[Convert.ToInt32(numericUpDown3.Value - 1)].mestopolozhenie.Strana + "\n";
            richTextBox2.SelectedText = "Город - " + peoples[Convert.ToInt32(numericUpDown3.Value - 1)].mestopolozhenie.Gorod + "\n";
            richTextBox2.SelectedText = "Специальность - " + peoples[Convert.ToInt32(numericUpDown3.Value - 1)].obrazovanie.Spetcialnost + "\n";
            richTextBox2.SelectedText = "Училище- " + peoples[Convert.ToInt32(numericUpDown3.Value - 1)].obrazovanie.Uchilishe + "\n";
            richTextBox2.SelectedText = "Место работы - " + peoples[Convert.ToInt32(numericUpDown3.Value - 1)].rabota.Imenovaniye + "\n";
            richTextBox2.SelectedText = "Должность - " + peoples[Convert.ToInt32(numericUpDown3.Value - 1)].rabota.Dolzhnost + "\n";

        }

        private void button20_Click(object sender, EventArgs e)
        {
            peoples[Convert.ToInt32(numericUpDown3.Value - 1)] = carFromDisk[Convert.ToInt32(numericUpDown2.Value - 1)];
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textImya.Clear();
            textRost.Clear();
            textVes.Clear();
            textVozrast.Clear();
            textPol.Clear();
            textLitso.Clear();
            textGubi.Clear();
            textNos.Clear();
            textGlaza.Clear();
            textVolosi.Clear();
            textStrana.Clear();
            textGorod.Clear();
            textSpetcialnost.Clear();
            textUchilishe.Clear();
            textDolzhnost.Clear();
            textImenovaniye.Clear();
        }
    }
    [Serializable]
    public class Person
    {
        public string Imya { get; set; }
        public int Rost { get; set; }
        public int Ves { get; set; }
        public int Vozrast { get; set; }
        public string Pol { get; set; }
        public string Litco { get; set; }
        public string Gubi { get; set; }
        public string Nos { get; set; }
        public string Glaza { get; set; }
        public string Volosi { get; set; }


        public Mestopolozhenie mestopolozhenie { get; set; }
        public Obrazovanie obrazovanie { get; set; }
        public Rabota rabota { get; set; }


        public void method1(string name)
        {
            Imya = name;
            MessageBox.Show("На свойство Imya повлияла строка -" + Imya);


        }

        internal void method2(string text)
        {
            if (int.TryParse(text, out int num))
            {
                Rost = num;
                MessageBox.Show("На свойство Rost повлияло значение -" + Rost);
            }
            else MessageBox.Show("Введите число");
        }

        internal void method3(string text)
        {
            if (int.TryParse(text, out int num))
            {
                Ves = num;
                MessageBox.Show("На свойство  Ves повлияла строка -" + Ves);
            }
            else MessageBox.Show("Введите число");
        }

        internal void method4(string text)
        {
            if (int.TryParse(text, out int num))
            {
                Vozrast = num;
                MessageBox.Show("На свойство  Vozrast повлияла строка -" + Vozrast.ToString());
            }
            else MessageBox.Show("Введите число");
        }

        internal void method5(string text)
        {

            Pol = text;
            MessageBox.Show("На свойство  Pol повлияла строка -" + Pol);

        }
    }
    [Serializable]
    public class Mestopolozhenie
    {

        public string Strana { get; set; }
        public string Gorod { get; set; }
        internal void method6(string text)
        {

            Strana = text;
            MessageBox.Show("На свойство Strana повлияла строка -" + Strana);

        }
    }
    [Serializable]
    public class Obrazovanie
    {

        public string Uchilishe { get; set; }
        public string Spetcialnost { get; set; }

        internal void method7(string text)
        {

            Spetcialnost = text;
            MessageBox.Show("На свойство  Spetcialnost повлияла строка -" + Spetcialnost);

        }
    }
    [Serializable]
    public class Rabota
    {

        public string Imenovaniye { get; set; }
        public string Dolzhnost { get; set; }

        internal void method8(string text)
        {

            Dolzhnost = text;
            MessageBox.Show("На свойство Dolzhnost повлияла строка -" + Dolzhnost);

        }
    }
}

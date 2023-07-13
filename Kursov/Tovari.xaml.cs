using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.IO;
using ClassLibrary1;

namespace Kursov
{
    /// <summary>
    /// Логика взаимодействия для Tovari.xaml
    /// </summary>
    public partial class Tovari : Window
    {
        public Tovar[] tov = new Tovar[] { };
        public int q = 0;
        public Tovari()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            for (int i = 0; i < tov.Length; i++)
            {
                if (tov[i].nalichie == "нет" || tov[i].nalichie == "Нет")
                {
                    System.Windows.Forms.MessageBox.Show("Рекомендуем к закупке " + tov[i].nazvanie);
                }
            }

            MainWindow gl = new MainWindow();
            gl.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DobTov tovar = new DobTov();
            tovar.ShowDialog();
            Array.Resize(ref tov, tov.Length + 1);
            tov[q] = tovar.tov1;
            string[] rows = { tov[q].nazvanie, tov[q].srok, tov[q].otdel, tov[q].cena.ToString(), tov[q].kolvo.ToString(), tov[q].nalichie };
            grid.Items.Add(rows);
            q++;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int index = grid.SelectedIndex;
            DobTov dobtov = new DobTov();
            dobtov.Text1.Text = tov[index].nazvanie;
            dobtov.Text2.Text = tov[index].srok;
            dobtov.Text3.Text = tov[index].otdel;
            dobtov.Text4.Text = tov[index].cena.ToString();
            dobtov.Text5.Text = tov[index].kolvo.ToString();
            dobtov.Text6.Text = tov[index].nalichie;
            dobtov.ShowDialog();
            tov[index].nazvanie = dobtov.Text1.Text;
            tov[index].srok = dobtov.Text2.Text;
            tov[index].otdel = dobtov.Text3.Text;
            tov[index].cena = Convert.ToDouble(dobtov.Text4.Text);
            tov[index].kolvo = Int32.Parse(dobtov.Text5.Text);
            tov[index].nalichie = dobtov.Text6.Text;
            string[] str = { tov[index].nazvanie, tov[index].srok, tov[index].otdel, tov[index].cena.ToString(), tov[index].kolvo.ToString(), tov[index].nalichie };
            grid.Items[index] = str;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int index = grid.SelectedIndex;
            grid.Items.RemoveAt(index);
            for (int i = index; i < tov.Length - 1; i++)
            {
                tov[i] = tov[i + 1];
            }
            Array.Resize(ref tov, tov.Length - 1);
            q--;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < tov.Length; i++)
            {
                if (tov[i].nalichie == "нет" || tov[i].nalichie == "Нет")
                {
                    System.Windows.Forms.MessageBox.Show("Рекомендуем к закупке " + tov[i].nazvanie);
                }
            }
            grid.Items.Clear();
            Array.Resize(ref tov, 0);
            q = 0;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    string filename = openFileDialog1.FileName;
                    string stroka;
                    StreamReader sr = new StreamReader(filename);
                    System.Windows.Forms.MessageBox.Show("Файл успешно открыт");
                    while (!sr.EndOfStream)
                    {
                        stroka = sr.ReadLine();
                        string[] slova = stroka.Split(';');
                        Array.Resize(ref tov, tov.Length + 1);
                        tov[q] = new Tovar("", "", "", 0, 0, "");
                        tov[q].nazvanie = slova[0];
                        tov[q].srok = slova[1];
                        tov[q].otdel = slova[2];
                        tov[q].cena = Convert.ToDouble(slova[3]);
                        tov[q].kolvo = Int32.Parse(slova[4]);
                        tov[q].nalichie = slova[5];
                        grid.Items.Add(slova);
                        q++;
                    }
                    sr.Close();
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Ошибка");
                }
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    string filename = saveFileDialog1.FileName;
                    FileStream fs = new FileStream(filename, FileMode.Create);
                    StreamWriter sw = new StreamWriter(fs);
                    for (int i = 0; i < tov.Length; i++)
                    {
                        string stroka1 = tov[i].ToString();
                        sw.WriteLine(stroka1);
                    }
                    System.Windows.Forms.MessageBox.Show("Файл сохранён");
                    sw.Close();
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Ошибка");
                }
            }
        }
    }
}

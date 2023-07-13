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
using System.Text;
using ClassLibrary1;
using System.IO;
using System.Windows.Forms;

namespace Kursov
{
    /// <summary>
    /// Логика взаимодействия для Spzak.xaml
    /// </summary>
    public partial class Spzak : Window
    {
        public ZakupkaSp[] zakupkaSps = new ZakupkaSp[] { };
        public int q = 0;
        public Spzak()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MainWindow gl = new MainWindow();
            gl.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Dobspzak dobspzak = new Dobspzak();
            dobspzak.ShowDialog();
            Array.Resize(ref zakupkaSps, zakupkaSps.Length + 1);
            zakupkaSps[q] = dobspzak.zaksp;
            string[] rows = { zakupkaSps[q].nazvanie, zakupkaSps[q].cena.ToString(), zakupkaSps[q].kolvo.ToString() };
            grid.Items.Add(rows);
            q++;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Dobspzak dobtov = new Dobspzak();
            int index = grid.SelectedIndex;
            dobtov.Text1.Text = zakupkaSps[index].nazvanie;
            dobtov.Text2.Text = zakupkaSps[index].cena.ToString();
            dobtov.Text3.Text = zakupkaSps[index].kolvo.ToString();
            dobtov.ShowDialog();
            zakupkaSps[index].nazvanie = dobtov.Text1.Text;
            zakupkaSps[index].cena = Convert.ToDouble(dobtov.Text2.Text);
            zakupkaSps[index].kolvo = Int32.Parse(dobtov.Text3.Text);
            string[] str = { zakupkaSps[index].nazvanie, zakupkaSps[index].cena.ToString(), zakupkaSps[index].kolvo.ToString() };
            grid.Items[index] = str;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int index = grid.SelectedIndex;
            grid.Items.RemoveAt(index);
            for (int i = index; i < zakupkaSps.Length - 1; i++)
            {
                zakupkaSps[i] = zakupkaSps[i + 1];
            }
            Array.Resize(ref zakupkaSps, zakupkaSps.Length - 1);
            q--;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            grid.Items.Clear();
            Array.Resize(ref zakupkaSps, 0);
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
                    StreamReader sr = new StreamReader(filename, Encoding.Default);
                    System.Windows.Forms.MessageBox.Show("Файл успешно открыт");
                    while (!sr.EndOfStream)
                    {
                        stroka = sr.ReadLine();
                        string[] slova = stroka.Split(';');
                        Array.Resize(ref zakupkaSps, zakupkaSps.Length + 1);
                        zakupkaSps[q].nazvanie = slova[0];
                        zakupkaSps[q].cena = Convert.ToDouble(slova[1]);
                        zakupkaSps[q].kolvo = Int32.Parse(slova[2]);
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
                    StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                    for (int i = 0; i < zakupkaSps.Length; i++)
                    {
                        string stroka1 = zakupkaSps[i].ToString();
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

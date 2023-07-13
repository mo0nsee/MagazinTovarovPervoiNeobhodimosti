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
using System.IO;
using System.Windows.Forms;
using System.IO;
using ClassLibrary1;

namespace Kursov
{
    /// <summary>
    /// Логика взаимодействия для Grzak.xaml
    /// </summary>
    public partial class Grzak : Window
    {
        public ZakupkaGr[] zakupkas = new ZakupkaGr[] { };
        public int q = 0;
        public Grzak()
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
            DobGrzak grzakyp = new DobGrzak();
            grzakyp.ShowDialog();
            Array.Resize(ref zakupkas, zakupkas.Length + 1);
            zakupkas[q] = grzakyp.zak;
            string[] rows = {zakupkas[q].data};
            grid.Items.Add(rows);
            q++;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int index = grid.SelectedIndex;
            DobGrzak dobgrz = new DobGrzak();
            dobgrz.Text1.Text = zakupkas[index].data.ToString();
            dobgrz.ShowDialog();
            zakupkas[index].data = dobgrz.Text1.Text;
            string[] str = { zakupkas[index].data.ToString() };
            grid.Items[index] = str;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int index = grid.SelectedIndex;
            grid.Items.RemoveAt(index);
            for (int i = index; i < zakupkas.Length - 1; i++)
            {
                zakupkas[i] = zakupkas[i + 1];
            }
            Array.Resize(ref zakupkas, zakupkas.Length - 1);
            q--;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            grid.Items.Clear();
            Array.Resize(ref zakupkas, 0);
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
                        Array.Resize(ref zakupkas, zakupkas.Length + 1);
                        zakupkas[q].data = stroka;
                        string[] rows = { zakupkas[q].data };
                        grid.Items.Add(rows);
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
                    for (int i = 0; i < zakupkas.Length; i++)
                    {
                        string stroka1 = zakupkas[i].ToString();
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

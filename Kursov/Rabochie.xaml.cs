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
using ClassLibrary1;
using System.Windows.Forms;

namespace Kursov
{
    /// <summary>
    /// Логика взаимодействия для Rabochie.xaml
    /// </summary>
    public partial class Rabochie : Window
    {
        public Rabotniki[] rabotniks = new Rabotniki[] { };
        public int q = 0;
        public Rabochie()
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
            Dobrab rabpl = new Dobrab();
            rabpl.ShowDialog();
            Array.Resize(ref rabotniks, rabotniks.Length + 1);
            rabotniks[q] = rabpl.rab1;
            string[] rows = { rabotniks[q].fio, rabotniks[q].dols, rabotniks[q].Godprin.ToString(), rabotniks[q].zarp.ToString(), rabotniks[q].staj.ToString() };
            grid.Items.Add(rows);
            q++;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int index = grid.SelectedIndex;
            Dobrab dobrab = new Dobrab();
            dobrab.Text1.Text = rabotniks[index].fio;
            dobrab.Text2.Text = rabotniks[index].dols;
            dobrab.Text3.Text = rabotniks[index].Godprin.ToString();
            dobrab.Text4.Text = rabotniks[index].zarp.ToString();
            dobrab.Text5.Text = rabotniks[index].staj.ToString();
            dobrab.ShowDialog();
            rabotniks[index].fio = dobrab.Text1.Text;
            rabotniks[index].dols = dobrab.Text2.Text;
            rabotniks[index].Godprin = Int32.Parse(dobrab.Text3.Text);
            rabotniks[index].zarp = Int32.Parse(dobrab.Text4.Text);
            rabotniks[index].staj = Int32.Parse(dobrab.Text5.Text);
            string[] str = { rabotniks[index].fio, rabotniks[index].dols, rabotniks[index].Godprin.ToString(), rabotniks[index].zarp.ToString(), rabotniks[index].staj.ToString() };
            grid.Items[index] = str;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int index = grid.SelectedIndex;
            grid.Items.RemoveAt(index);
            for (int i = index; i < rabotniks.Length - 1; i++)
            {
                rabotniks[i] = rabotniks[i + 1];
            }
            Array.Resize(ref rabotniks, rabotniks.Length - 1);
            q--;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            grid.Items.Clear();
            Array.Resize(ref rabotniks, 0);
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
                        Array.Resize(ref rabotniks, rabotniks.Length + 1);
                        rabotniks[q] = new Rabotniki("", "", 0, 0, 0);
                        rabotniks[q].fio = slova[0];
                        rabotniks[q].dols = slova[1];
                        rabotniks[q].Godprin = Int32.Parse(slova[2]);
                        rabotniks[q].zarp = Int32.Parse(slova[3]);
                        rabotniks[q].staj = Int32.Parse(slova[4]);
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
                    for (int i = 0; i < rabotniks.Length; i++)
                    {
                        string stroka1 = rabotniks[i].ToString();
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

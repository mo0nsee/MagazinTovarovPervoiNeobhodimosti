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

namespace Kursov
{
    /// <summary>
    /// Логика взаимодействия для Vhod.xaml
    /// </summary>
    public partial class Vhod : Window
    {
        public Vhod()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StreamReader f = new StreamReader("F:\\4312\\Kursov\\File\\parol.txt");
            string parol1 = f.ReadLine();
            string parol = Password.Password;
            if (parol == parol1)
            {
                MainWindow gl = new MainWindow();
                gl.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Неверный пароль");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Parol izm = new Parol();
            izm.Show();
        }
    }
}

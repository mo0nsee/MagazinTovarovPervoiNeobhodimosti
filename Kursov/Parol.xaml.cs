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

namespace Kursov
{
    /// <summary>
    /// Логика взаимодействия для Parol.xaml
    /// </summary>
    public partial class Parol : Window
    {
        public Parol()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText(@"F:\\4312\\Kursov\\File\\parol.txt", string.Empty);
            string parol1 = Ip.Text;
            Director dir = new Director(parol1);
            File.AppendAllText(@"F:\\4312\\Kursov\\File\\parol.txt", dir.ToString());
            this.Close();
        }
    }
}

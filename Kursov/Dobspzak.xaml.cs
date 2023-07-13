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
using ClassLibrary1;

namespace Kursov
{
    /// <summary>
    /// Логика взаимодействия для Dobspzak.xaml
    /// </summary>
    public partial class Dobspzak : Window
    {
        public ZakupkaSp zaksp = new ZakupkaSp();
        public Dobspzak()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            zaksp.nazvanie = Text1.Text;
            zaksp.cena = Convert.ToDouble(Text2.Text);
            zaksp.kolvo = Int32.Parse(Text3.Text);
            this.Close();
        }
    }
}

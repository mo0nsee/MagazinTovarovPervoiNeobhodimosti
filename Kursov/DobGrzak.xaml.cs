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
    /// Логика взаимодействия для DobGrzak.xaml
    /// </summary>
    public partial class DobGrzak : Window
    {
        public ZakupkaGr zak = new ZakupkaGr();
        public DobGrzak()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            zak.data = Text1.Text;
            this.Close();
        }
    }
}

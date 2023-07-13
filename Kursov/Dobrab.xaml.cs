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
    /// Логика взаимодействия для Dobrab.xaml
    /// </summary>
    public partial class Dobrab : Window
    {
        public Rabotniki rab1 = new Rabotniki("", "", 0, 0, 0);
        public Dobrab()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            rab1.fio = Text1.Text;
            rab1.dols = Text2.Text;
            rab1.Godprin = Int32.Parse(Text3.Text);
            rab1.zarp = Int32.Parse(Text4.Text);
            rab1.staj = Int32.Parse(Text5.Text);
            this.Close();
        }
    }
}

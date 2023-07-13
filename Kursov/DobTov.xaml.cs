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
using ClassLibrary1;

namespace Kursov
{
    /// <summary>
    /// Логика взаимодействия для DobTov.xaml
    /// </summary>
    public partial class DobTov : Window
    {
        public Tovar tov1 = new Tovar("", "", "", 0, 0, "");
        public DobTov()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tov1.nazvanie = Text1.Text;
            tov1.srok = Text2.Text;
            tov1.otdel = Text3.Text;
            tov1.cena = Convert.ToDouble(Text4.Text);
            tov1.kolvo = Int32.Parse(Text5.Text);
            tov1.nalichie = Text6.Text;
            this.Close();
        }
    }
}

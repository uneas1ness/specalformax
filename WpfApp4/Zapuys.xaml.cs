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

namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для Zapuys.xaml
    /// </summary>
    public partial class Zapuys : Window
    {
        public Buyers Buyers { get; set; }
        public Zapuys(Buyers buyers)
        {
            Buyers = buyers;
            DataContext = Buyers;
            InitializeComponent();
        }
        void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}

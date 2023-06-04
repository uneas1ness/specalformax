using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        ApplicationContext db = new ApplicationContext();
        public ClientWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // гарантируем, что база данных создана
            db.Database.EnsureCreated();
            // загружаем данные из БД
            db.Services.Load();
            // и устанавливаем данные в качестве контекста
            DataContext = db.Services.Local.ToObservableCollection();
        }
        ApplicationContext2 db1 = new ApplicationContext2();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Zapuys zap = new Zapuys(new Buyers());
            if (zap.ShowDialog() == true)
            {
                Buyers bayers = zap.Buyers;
                db1.Buyers.Add(bayers);
                db1.SaveChanges();
            }

        }
    }
}

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db = new ApplicationContext();
        public MainWindow()
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
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            UserWindow UserWindow = new UserWindow(new Services());
            if (UserWindow.ShowDialog() == true)
            {
                Services services = UserWindow.Services;
                db.Services.Add(services);
                db.SaveChanges();
            }
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            Services? user = usersList.SelectedItem as Services;
            // если ни одного объекта не выделено, выходим
            if (user is null) return;

            UserWindow UserWindow = new UserWindow(new Services
            {
                Price = user.Price,
                Name = user.Name
            });

            if (UserWindow.ShowDialog() == true)
            {
                // получаем измененный объект
                user = db.Services.Find(UserWindow.Services.Price);
                if (user != null)
                {
                    user.Price = UserWindow.Services.Price;
                    user.Name = UserWindow.Services.Name;
                    db.SaveChanges();
                    usersList.Items.Refresh();
                }
            }

        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            Services? user = usersList.SelectedItem as Services;
            // если ни одного объекта не выделено, выходим
            if (user is null) return;
            db.Services.Remove(user);
            db.SaveChanges();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Registration window2 = new Registration();
            window2.ShowDialog();

           

        }
    }
}

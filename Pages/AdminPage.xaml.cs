using Praktika4Kurs.Entities;
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

namespace Praktika4Kurs.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        private User curUser;
        public AdminPage(User user)
        {
            curUser = user;
            InitializeComponent();
        }

        private void LoadUsers(object sender, RoutedEventArgs e)
        {
            var users = Navigator.db.Users.Include("Role").ToList();
            UsersDG.ItemsSource = users;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            Navigator.db.SaveChanges();
        }
    }
}

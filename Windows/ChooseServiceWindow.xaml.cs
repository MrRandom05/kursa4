using Praktika4Kurs.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace Praktika4Kurs.Windows
{
    /// <summary>
    /// Логика взаимодействия для ChooseServiceWindow.xaml
    /// </summary>
    public partial class ChooseServiceWindow : Window
    {
        private User curUser;
        private ServiceList curService;
        public ChooseServiceWindow(User user, ServiceList service)
        {
            this.curUser = user;
            this.curService = service;
            InitializeComponent();
        }

        private void LoadMyCars(object sender, RoutedEventArgs e)
        {
            try
            {
                Navigator.db.Cars.Load();
                var cars = Navigator.db.Cars.Where(x => x.OwnerUserId == curUser.UserId).ToList();
                UserCarsCB.ItemsSource = cars;
            }
            catch { }
        }

        private void ChooseCar(object sender, RoutedEventArgs e)
        {

            try
            {
                if (UserCarsCB.SelectedIndex != -1)
                {
                    var car = UserCarsCB.SelectedItem as Car;
                    Navigator.db.clientsServices.Add(ClientsService.Of(curService, car, ServiceStatus.Ordered));
                    Navigator.db.SaveChanges();
                    MessageBox.Show("Ok");
                }
                else
                {
                    MessageBox.Show("Выбкрите машину для оказания услуги");
                }
            }
            catch { }
        }
    }
}

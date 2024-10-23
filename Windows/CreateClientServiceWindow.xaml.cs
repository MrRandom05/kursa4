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
    /// Логика взаимодействия для CreateClientServiceWindow.xaml
    /// </summary>
    public partial class CreateClientServiceWindow : Window
    {
        private User curUser;
        public CreateClientServiceWindow(User user)
        {
            InitializeComponent();
            curUser = user;
        }

        private void LoadCars(object sender, RoutedEventArgs e)
        {
            try
            {
                Navigator.db.Cars.Load();
                var cars = Navigator.db.Cars.ToList();
                CarsCB.ItemsSource = cars;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void LoadServiceList(object sender, RoutedEventArgs e)
        {
            try
            {
                Navigator.db.ServiceList.Load();
                var serviceList = Navigator.db.ServiceList.ToList();
                ServicesCB.ItemsSource = serviceList;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void CreateService(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ServicesCB.SelectedIndex == -1 || CarsCB.SelectedIndex == -1)
                {
                    MessageBox.Show("Выберите услугу и машину");
                }
                else
                {
                    var service = ServicesCB.SelectedItem as ServiceList;
                    var car = CarsCB.SelectedItem as Car;

                    var clientService = ClientsService.Of(service, car, ServiceStatus.Ordered);
                    Navigator.db.clientsServices.Add(clientService);
                    Navigator.db.SaveChanges();
                    MessageBox.Show("Услуга заказана");
                    this.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}

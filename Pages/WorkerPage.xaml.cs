using Praktika4Kurs.Entities;
using Praktika4Kurs.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Praktika4Kurs.Pages
{
    /// <summary>
    /// Логика взаимодействия для WorkerPage.xaml
    /// </summary>
    public partial class WorkerPage : Page
    {
        private User curUser;
        public WorkerPage(User user)
        {
            curUser = user;
            InitializeComponent();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            Navigator.db.SaveChanges();
        }

        private void LoadServices(object sender, RoutedEventArgs e)
        {
            try
            {
                Navigator.db.ServiceList.Load();
                var res = Navigator.db.ServiceList.Local.ToBindingList();
                ServiceDG.ItemsSource = res;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void OnServiceDGColumnsGenerating(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            PropertyDescriptor propertyDescriptor = (PropertyDescriptor)e.PropertyDescriptor;
            e.Column.Header = propertyDescriptor.DisplayName;
            if (propertyDescriptor.DisplayName == "ServiceListId")
            {
                e.Cancel = true;
            }
        }
        private void RemoveServices()
        {
            try
            {
                if (ServiceDG.SelectedItems.Count > 0)
                {
                    while (0 < ServiceDG.SelectedItems.Count)
                    {
                        Navigator.db.ServiceList.Remove(ServiceDG.SelectedItems[0] as ServiceList);
                    }
                    Navigator.db.SaveChanges();
                    MessageBox.Show("Записи успешно удалены");
                }
                else
                {
                    MessageBox.Show("Выберете записи для удаления");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteServices(object sender, RoutedEventArgs e)
        {
            RemoveServices();
        }

        private void LoadOrders(object sender, RoutedEventArgs e)
        {

            try
            {
                Navigator.db.DetailsOrders.Load();
                var res = Navigator.db.DetailsOrders.Local.ToBindingList();
                OrdersDG.ItemsSource = res;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void OnOrdersDGColumnsGenerating(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            PropertyDescriptor propertyDescriptor = (PropertyDescriptor)e.PropertyDescriptor;
            e.Column.Header = propertyDescriptor.DisplayName;
            if (propertyDescriptor.DisplayName == "DetailsOrderId" || propertyDescriptor.DisplayName == "Creator" || propertyDescriptor.DisplayName == "OrderDetails")
            {
                e.Cancel = true;
            }
        }

        private void RemoveOrders()
        {
            try
            {
                if (OrdersDG.SelectedIndex != -1)
                {
                    Navigator.db.DetailsFromOrders.RemoveRange((OrdersDG.SelectedItems[0] as DetailsOrder).OrderDetails);
                    Navigator.db.DetailsOrders.Remove(OrdersDG.SelectedItems[0] as DetailsOrder);
                    Navigator.db.SaveChanges();
                    MessageBox.Show("Записи успешно удалены");
                }
                else
                {
                    MessageBox.Show("Выберете записи для удаления");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteOrders(object sender, RoutedEventArgs e)
        {
            RemoveOrders();
        }

        private void LoadClientService(object sender, RoutedEventArgs e)
        {
            try
            {
                Navigator.db.clientsServices.Load();
                var res = Navigator.db.clientsServices.Local.ToBindingList();
                ClientServiceDG.ItemsSource = res;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void OnClientServiceDGColumnsGenerating(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            PropertyDescriptor propertyDescriptor = (PropertyDescriptor)e.PropertyDescriptor;
            e.Column.Header = propertyDescriptor.DisplayName;
            if (propertyDescriptor.DisplayName == "ClientsServiceId" || propertyDescriptor.DisplayName == "ClientCar" || propertyDescriptor.DisplayName == "Service")
            {
                e.Cancel = true;
            }
            if (propertyDescriptor.DisplayName == "ClientCarCarId" || propertyDescriptor.DisplayName == "ServiceServiceListId")
            {
                e.Column.IsReadOnly = true;
            }
        }

        private void AddOrder(object sender, RoutedEventArgs e)
        {
            try
            {
                var win = new CreateOrderWindow(curUser);
                win.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void AddClientService(object sender, RoutedEventArgs e)
        {
            try
            {
                var win = new CreateClientServiceWindow(curUser);
                win.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}

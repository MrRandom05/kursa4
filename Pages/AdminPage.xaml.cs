﻿using Praktika4Kurs.Entities;
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
            try
            {
                Navigator.db.Users.Load();
                var users = Navigator.db.Users.Local.ToBindingList();
                UsersDG.ItemsSource = users;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            try
            {
                Navigator.db.SaveChanges();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void OnUsersDGColumnsGenerating(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            PropertyDescriptor propertyDescriptor = (PropertyDescriptor)e.PropertyDescriptor;
            e.Column.Header = propertyDescriptor.DisplayName;
            if (propertyDescriptor.DisplayName == "UserId")
            {
                e.Cancel = true;
            }
        }

        private void RemoveUsers()
        {
            try
            {
                if (UsersDG.SelectedItems.Count > 0)
                {
                    while(0 < UsersDG.SelectedItems.Count)
                    {
                        Navigator.db.Users.Remove(UsersDG.SelectedItems[0] as User);
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

        private void DeleteUsers(object sender, RoutedEventArgs e)
        {
            RemoveUsers();
        }

        private void OnDetailsDGColumnsGenerating(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            PropertyDescriptor propertyDescriptor = (PropertyDescriptor)e.PropertyDescriptor;
            e.Column.Header = propertyDescriptor.DisplayName;
            if (propertyDescriptor.DisplayName == "DetailId")
            {
                e.Cancel = true;
            }
        }

        private void LoadDetails(object sender, RoutedEventArgs e)
        {
            try
            {
                Navigator.db.Details.Load();
                var res = Navigator.db.Details.Local.ToBindingList();
                DetailsDG.ItemsSource = res;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void RemoveDetails()
        {
            try
            {
                if (DetailsDG.SelectedItems.Count > 0)
                {
                    while (0 < DetailsDG.SelectedItems.Count)
                    {
                        Navigator.db.Details.Remove(DetailsDG.SelectedItems[0] as Detail);
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

        private void DeleteDetails(object sender, RoutedEventArgs e)
        {
            RemoveDetails();
        }

        private void LoadCars(object sender, RoutedEventArgs e)
        {

            try
            {
                Navigator.db.Cars.Load();
                var res = Navigator.db.Cars.Local.ToBindingList();
                CarsDG.ItemsSource = res;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void OnCarsDGColumnsGenerating(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            PropertyDescriptor propertyDescriptor = (PropertyDescriptor)e.PropertyDescriptor;
            e.Column.Header = propertyDescriptor.DisplayName;
            if (propertyDescriptor.DisplayName == "CarId" || propertyDescriptor.DisplayName == "Owner")
            {
                e.Cancel = true;
            }

        }
        private void RemoveCars()
        {
            try
            {
                if (CarsDG.SelectedItems.Count > 0)
                {
                    while (0 < CarsDG.SelectedItems.Count)
                    {
                        Navigator.db.Cars.Remove(CarsDG.SelectedItems[0] as Car);
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

        private void DeleteCars(object sender, RoutedEventArgs e)
        {
            RemoveCars();
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
        }

        private void DeleteClientService(object sender, RoutedEventArgs e)
        {

        }
        private void RemoveClientServices()
        {
            try
            {
                if (OrdersDG.SelectedIndex != -1)
                {
                    Navigator.db.clientsServices.Remove(ClientServiceDG.SelectedItems[0] as ClientsService);
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
    }
}

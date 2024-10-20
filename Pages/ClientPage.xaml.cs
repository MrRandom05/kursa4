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
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        private User curUser;
        public ClientPage(User user)
        {
            curUser = user;
            InitializeComponent();
        }
        
        private void LoadCars(object sender, RoutedEventArgs e)
        {

            try
            {
                Navigator.db.Cars.Load();
                var res = Navigator.db.Cars.Where(x => x.OwnerUserId == curUser.UserId).ToList();

                CarsDG.ItemsSource = res;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void OnCarsDGColumnsGenerating(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            PropertyDescriptor propertyDescriptor = (PropertyDescriptor)e.PropertyDescriptor;
            e.Column.Header = propertyDescriptor.DisplayName;
            if (propertyDescriptor.DisplayName == "CarId" || propertyDescriptor.DisplayName == "Owner" || propertyDescriptor.DisplayName == "OwnerUserId")
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
                        var car = Navigator.db.Cars.First(x => x.CarId == (CarsDG.SelectedItems[0] as Car).CarId);
                        Navigator.db.Cars.Remove(car);
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
                var res = Navigator.db.ServiceList.ToList();
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

        private void AddCars(object sender, RoutedEventArgs e)
        {
            try
            {
                var win = new CreateCarWindow(curUser);
                win.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ChooseService(object sender, RoutedEventArgs e)
        {

            try
            {
                if (ServiceDG.SelectedIndex != -1)
                {
                    var win = new ChooseServiceWindow(curUser, (ServiceDG.SelectedItem as ServiceList));
                    win.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Выберите услугу из списка");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}

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
    /// Логика взаимодействия для CreateOrderWindow.xaml
    /// </summary>
    public partial class CreateOrderWindow : Window
    {
        private User curUser;
        public CreateOrderWindow(User user)
        {
            InitializeComponent();
            curUser = user;
        }

        private void LoadDetails(object sender, RoutedEventArgs e)
        {
            Navigator.db.Details.Load();
            var details = Navigator.db.Details.ToList();
            AvailibleDetailsLV.ItemsSource = details;
        }

        private void CreateOrder(object sender, RoutedEventArgs e)
        {
            try
            {
                var title = Titletxt.Text;
                var details = AvailibleDetailsLV.ItemsSource as List<Detail>;
                if (string.IsNullOrEmpty(title) || details == null || details.Count() == 0)
                {
                    MessageBox.Show("Введите название и выберите детали для заказа");
                }
                else
                {
                    details = details.Where(x => x.Count > 0 ).ToList();
                    if (details.Count() > 0)
                    {
                        var order = new DetailsOrder() { Creator = curUser, OrderTitle = title };
                        var detailFromOrder = new List<DetailsFromOrder>();
                        foreach (Detail detail in details)
                        {
                            detailFromOrder.Add(new DetailsFromOrder() { Count = detail.Count, Detail = detail });
                        }
                        order.OrderDetails = detailFromOrder;
                        Navigator.db.DetailsOrders.Add(order);
                        Navigator.db.SaveChanges();
                        MessageBox.Show("Заказ создан");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Введите название и выберите детали для заказа");
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}

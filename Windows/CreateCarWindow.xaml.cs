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
using System.Windows.Shapes;

namespace Praktika4Kurs.Windows
{
    /// <summary>
    /// Логика взаимодействия для CreateCarWindow.xaml
    /// </summary>
    public partial class CreateCarWindow : Window
    {
        private User curUser;
        public CreateCarWindow(User user)
        {
            curUser = user;
            InitializeComponent();
        }

        private void AddCar(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Numtxt.Text))
                {
                    Navigator.db.Cars.Add(Car.Of(Numtxt.Text, curUser.UserId));
                    Navigator.db.SaveChanges();
                    MessageBox.Show("Машина добавлена");
                }
                else
                {
                    MessageBox.Show("Введите номер машины");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}

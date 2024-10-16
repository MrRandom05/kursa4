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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void TryRegistrate(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Logintxt.Text) || string.IsNullOrEmpty(Passwordtxt.Password) || string.IsNullOrEmpty(PasswordRepeattxt.Password))
                {
                    MessageBox.Show("Все поля должны быть заполнены");
                }
                else
                {
                    if (PasswordRepeattxt.Password != Passwordtxt.Password)
                    {
                        MessageBox.Show("Пароли должны совпадать");
                    }
                    else
                    {
                        if (Navigator.db.Users.Where(x => x.Login == Logintxt.Text).Any())
                        {
                            MessageBox.Show("Логин занят");
                        }
                        else
                        {
                            Navigator.db.Users.Add(User.Of(Logintxt.Text, Passwordtxt.Password, Role.Client));
                            Navigator.db.SaveChanges();
                            MessageBox.Show("Пользователь зарегестрирован");
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}

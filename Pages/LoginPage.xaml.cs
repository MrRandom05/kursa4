using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Praktika4Kurs.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void NavAccountCreationPage(object sender, RoutedEventArgs e)
        {
            Navigator.Push(new RegistrationPage());
        }

        private void TrySignIn(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Logintxt.Text) ||  string.IsNullOrEmpty(Passwordtxt.Password))
                {
                    MessageBox.Show("Все поля должны быть заполнены");
                }
                else
                {
                    var user = Navigator.db.Users.Include("Role").First(x => x.Login == Logintxt.Text);
                    if (user != null)
                    {
                        if (user.Password == Passwordtxt.Password)
                        {
                            switch (user.Role.RoleName)
                            {
                                case "админ":
                                    Navigator.Push(new AdminPage(user));
                                    break;
                                case "клиент":
                                    Navigator.Push(new ClientPage(user));
                                    break;
                                case "работник":
                                    Navigator.Push(new WorkerPage(user));
                                    break;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Логин или пароль указаны неверно");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пользователя с таким логином не существует");
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}

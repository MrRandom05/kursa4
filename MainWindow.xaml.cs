using Praktika4Kurs.Entities;
using Praktika4Kurs.Pages;
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

namespace Praktika4Kurs
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Navigator.db = new AppContext();
            MainFrame.Navigate(new LoginPage());
            Navigator.NavFrame = MainFrame;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Navigator.Pop();
        }

        private void SaveDB(object sender, EventArgs e)
        {
            Navigator.db.Dispose();
        }
    }
}

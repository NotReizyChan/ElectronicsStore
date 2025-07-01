using ElectronicsStore.Models;
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
using System.IO;


namespace ElectronicsStore.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private List<User> _users = new List<User>
        {
            new User { Username = "1", Password = "1" },
            new User { Username = "2", Password = "2" },
            new User { Username = "3", Password = "3" }
        };

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            foreach (var user in _users)
            {
                if (user.Username == username && user.Password == password)
                {
                    var mainWindow = new MainStoreWindow(username);
                    mainWindow.Show();
                    this.Close();
                    return;
                }
            }

            MessageBox.Show("Вы ввели неправильный пароль. Пожалуйста, введите правильный :)", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}

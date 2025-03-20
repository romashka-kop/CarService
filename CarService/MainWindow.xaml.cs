using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CarService.Data;
using CarService.Models;
using Microsoft.IdentityModel.Tokens;

namespace CarService
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (Authorization.GetInstance().isAuthorized)
            {
                SetWorking();
            } else
            {
                SetLogin();
            }
        }
        private void SetLogin()
        {
            LoginPanel.Visibility = Visibility.Visible;
            MainPanel.Visibility = Visibility.Collapsed;
        }

        private void SetWorking()
        {
            LoginPanel.Visibility = Visibility.Collapsed;
            MainPanel.Visibility = Visibility.Visible;
        }

        private void SetProfile()
        {
            var a = Authorization.GetInstance();
            if (a.isAuthorized && a.CurrentUser != null)
            {
                Username.Text = a.CurrentUser.Family + " " + a.CurrentUser.Name;

                UserType type = a.CurrentUser.Type;

                switch (type) { 
                    case UserType.Manager:
                        BillsBtn.Visibility = Visibility.Visible;
                        break;
                    case UserType.Mechanic:
                        break;
                    case UserType.Operator:
                        break;
                    case UserType.Client:
                        break;
                }
            }
        }

        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            SetLogin();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = Login.Text;
            string pass = Pass.Password;

            if (login.IsNullOrEmpty() || pass.IsNullOrEmpty())
            {
                MessageBox.Show("Введите данные!");
                return;
            }

            if (Authorization.GetInstance().Login(login, pass))
            {
                SetWorking();
                SetProfile();
            } else
            {
                MessageBox.Show("Пользователь с указанными данными не найден!");
            }
        }

        private void RequestsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BillsBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
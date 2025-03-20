using CarService.Models;
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

namespace CarService.Pages
{
    /// <summary>
    /// Логика взаимодействия для USersPage.xaml
    /// </summary>
    public partial class USersPage : Page
    {
        public USersPage()
        {
            InitializeComponent();

            using var context = new CarServiceContext();

            var user = context.Users.FirstOrDefault();
            user.Phone = "sfaf";

            context.Update(user);

            context.SaveChanges();


            UsersList.ItemsSource =  context.Users.ToList();
        }
    }
}

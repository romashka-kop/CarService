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
using CarService.Models;
using Microsoft.IdentityModel.Tokens;

namespace CarService.Pages
{
    /// <summary>
    /// Логика взаимодействия для RequestCreatePage.xaml
    /// </summary>
    public partial class RequestCreatePage : Page
    {
        public RequestCreatePage()
        {
            InitializeComponent();
            LoadCars();
            LoadManufacturers();
        }

        private void LoadManufacturers(string search = "")
        {
            using var context = new CarServiceContext();

            ManBox.ItemsSource = context.Manufacturers.Where(u => u.Name.Contains(search)).ToArray();
        }

        private void LoadCars(string search = "", int? manId = null)
        {
            using var context = new CarServiceContext();

            CarBox.ItemsSource = context.Cars
                .Where(u => u.Model.Contains(search) && (manId == null ? true : u.ManufacturerID == manId))
                .ToArray();
        }

        private void CarAddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CarName.Text.IsNullOrEmpty())
            {
                MessageBox.Show("не заполнено название");
                return;
            }

            int? manid = ManBox.SelectedItem != null ? ((Manufacturer)ManBox.SelectedItem).Id : null;

            if (manid == null) {
                MessageBox.Show("не заполнен производитель");
                return;
            }

            using var context = new CarServiceContext();
            context.Add(new Car { ManufacturerID = manid ?? 0, Model = CarName.Text, Year = 2000});
            context.SaveChanges();
            LoadManufacturers(ManName.Text);
        }

        private void ManAdBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ManName.Text.IsNullOrEmpty())
            {
                MessageBox.Show("не заполнено название");

            }
            using var context = new CarServiceContext();
            context.Add(new Manufacturer { Name = ManName.Text });
            context.SaveChanges();
            LoadManufacturers(ManName.Text);
        }

        private void ManName_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadManufacturers(ManName.Text);
        }

        private void CarName_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = CarName.Text;
            int? manid = ManBox.SelectedItem != null ? ((Manufacturer)ManBox.SelectedItem).Id : null;
            
            LoadCars(search, manid);
        }

        private void ManBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string search = CarName.Text;
            int? manid = ManBox.SelectedItem != null ? ((Manufacturer)ManBox.SelectedItem).Id : null;

            LoadCars(search, manid);
        }
    }
}

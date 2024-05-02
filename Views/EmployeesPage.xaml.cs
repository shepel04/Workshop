using Microsoft.EntityFrameworkCore;
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
using Workshop.Data;
using Workshop.Models;

namespace Workshop.Views
{
    /// <summary>
    /// Логика взаимодействия для EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesPage : Page
    {
        private AppDbContext _dbContext;
        public EmployeesPage()
        {
            InitializeComponent();
            _dbContext = new AppDbContext();
            LoadAllData();
        }

        private void LoadAllData()
        {
            using (var context = new AppDbContext())
            {
                var employees = context.employees.Select(emp => new {
                    emp.FirstName,
                    emp.LastName,
                    emp.Position,
                    emp.Salary,
                    emp.PhoneNumber
                }).ToList();

                EmployeesDataGrid.ItemsSource = employees;

            }
        }

        private void EmployeesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            var addEmployeeWindow = new AddEmployeeWindow();

            addEmployeeWindow.Show();
        }

        private void DeleteEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            Employee selectedEmployee = (Employee)EmployeesDataGrid.SelectedItem;

            if (selectedEmployee == null)
            {
                MessageBox.Show("Please select an employee to delete.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this employee?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                using (var context = new AppDbContext())
                {
                    context.employees.Remove(selectedEmployee);
                    context.SaveChanges();
                }

                LoadAllData();
            }
        }

        private void FindEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string searchText = EmployeeSearchTextBox.Text.Trim();

                var employees = _dbContext.employees.Where(emp => emp.FirstName.Contains(searchText) || emp.LastName.Contains(searchText) || emp.PhoneNumber.Contains(searchText)).ToList();

                EmployeesDataGrid.ItemsSource = employees;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка під час пошуку: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RefreshEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            LoadAllData();
        }
    }
}

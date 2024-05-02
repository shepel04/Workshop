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
using System.Windows.Shapes;
using Workshop.Data;
using Workshop.Models;

namespace Workshop.Views
{
    /// <summary>
    /// Логика взаимодействия для AddEmployeeWindow.xaml
    /// </summary>
    public partial class AddEmployeeWindow : Window
    {
        private readonly AppDbContext dbContext;

        public AddEmployeeWindow()
        {
            InitializeComponent();
            dbContext = new AppDbContext();
        }
             
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> emptyFields = new List<string>();

            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
                emptyFields.Add("First Name");
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
                emptyFields.Add("Last Name");
            if (string.IsNullOrWhiteSpace(txtPosition.Text))
                emptyFields.Add("Position");
            if (string.IsNullOrWhiteSpace(txtSalary.Text))
                emptyFields.Add("Salary");
            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
                emptyFields.Add("Phone Number");

            if (emptyFields.Any())
            {
                MessageBox.Show("The following fields are required:\n" + string.Join("\n", emptyFields), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Employee newEmployee = new Employee
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Position = txtPosition.Text,
                Salary = decimal.Parse(txtSalary.Text),
                PhoneNumber = txtPhoneNumber.Text
            };

            using (var context = new AppDbContext())
            {
                context.employees.Add(newEmployee);
                context.SaveChanges();
            }

            this.Close();
        }
    }
}

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
    /// Логика взаимодействия для ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        private readonly AppDbContext dbContext;

        public ClientsPage()
        {
            InitializeComponent();
            dbContext = new AppDbContext(); 
            LoadClients();
        }

        private void LoadClients()
        {
            ClientsDataGrid.ItemsSource = dbContext.clients.ToList();
        }

        private void ApplyFilterButton_Click(object sender, RoutedEventArgs e)
        {           
            string filterName = NameFilterTextBox.Text;
            string filterPhone = PhoneFilterTextBox.Text;

            var filteredClients = dbContext.clients.AsQueryable();
                        
            if (!string.IsNullOrEmpty(filterName))
            {
                filteredClients = filteredClients.Where(c => c.FirstName.Contains(filterName) || c.LastName.Contains(filterName));
            }
            if (!string.IsNullOrEmpty(filterPhone))
            {
                filteredClients = filteredClients.Where(c => c.PhoneNumber.Contains(filterPhone));
            }

            ClientsDataGrid.ItemsSource = filteredClients.ToList();
        }

        private void RefreshTableButton_Click(object sender, RoutedEventArgs e)
        {
            LoadClients();
        }

        private void ResetFilterButton_Click(object sender, RoutedEventArgs e)
        {
            NameFilterTextBox.Text = "";
            PhoneFilterTextBox.Text = "";

            LoadClients();
        }

        private void AddClientButton_Click(object sender, RoutedEventArgs e)
        {
            var addClientWindow = new AddClientWindow();
            addClientWindow.ShowDialog();
        }

        private void DeleteClientButton_Click(object sender, RoutedEventArgs e)
        {
            Client selectedClient = (Client)ClientsDataGrid.SelectedItem;

            if (selectedClient != null)
            {
                MessageBoxResult result = MessageBox.Show("Ви впевнені, що хочете видалити цього клієнта?", "Підтвердження видалення", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        dbContext.clients.Remove(selectedClient);
                        dbContext.SaveChanges();

                        LoadClients();
                        MessageBox.Show("Клієнт видалено успішно.", "Успішно", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Під час видалення клієнта сталася помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть клієнта для видалення.", "Клієнт не вибрано", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ShowClientOrdersButton_Click(object sender, RoutedEventArgs e)
        {
            Client selectedClient = (Client)ClientsDataGrid.SelectedItem;
            if (selectedClient != null)
            {
                ClientOrdersWindow clientOrdersWindow = new ClientOrdersWindow(selectedClient.Id);
                clientOrdersWindow.Show();
            }
            else
            {
                MessageBox.Show("Виберіть клієнта для перегляду його замовлень.");
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

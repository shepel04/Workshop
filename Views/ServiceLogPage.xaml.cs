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

namespace Workshop.Views
{
    /// <summary>
    /// Логика взаимодействия для ServiceLogPage.xaml
    /// </summary>
    public partial class ServiceLogPage : Page
    {
        private AppDbContext _dbContext; 

        public ServiceLogPage()
        {
            InitializeComponent();
            _dbContext = new AppDbContext();  
            LoadServiceLogs();  
        }

        private void LoadServiceLogs()
        {
            try
            {
                var serviceLogs = (from log in _dbContext.serviceLogs
                                   join client in _dbContext.clients on log.ClientId equals client.Id
                                   select new
                                   {
                                       log.Id,
                                       ClientName = client.FirstName + " " + client.LastName,
                                       ClientPhone = client.PhoneNumber,
                                       log.ServiceDate,
                                       log.ServiceDescription,
                                       log.ServiceCost
                                   }).ToList();

                ServiceJournalDataGrid.ItemsSource = serviceLogs;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження журналу обслуговування: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RefreshServiceJournalButton_Click(object sender, RoutedEventArgs e)
        {
            LoadServiceLogs(); 
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string searchText = SearchTextBox.Text.Trim();

                var serviceLogs = (from log in _dbContext.serviceLogs
                                   join client in _dbContext.clients on log.ClientId equals client.Id
                                   where client.FirstName.Contains(searchText) || client.LastName.Contains(searchText) || client.PhoneNumber.Contains(searchText)
                                   select new
                                   {
                                       log.Id,
                                       ClientName = client.FirstName + " " + client.LastName,
                                       ClientPhone = client.PhoneNumber,
                                       log.ServiceDate,
                                       log.ServiceDescription,
                                       log.ServiceCost
                                   }).ToList();

                ServiceJournalDataGrid.ItemsSource = serviceLogs;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка під час пошуку: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

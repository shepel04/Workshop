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
    /// Логика взаимодействия для AddOrderToClientWindow.xaml
    /// </summary>
    public partial class AddOrderToClientWindow : Window
    {
        private AppDbContext dbContext;

        public AddOrderToClientWindow()
        {
            InitializeComponent();
            dbContext = new AppDbContext();
        }

        private void ClientComboBox_DropDownOpened(object sender, EventArgs e)
        {
            string searchText = ClientComboBox.Text.ToLower();

            List<Client> allClients = dbContext.clients.ToList();

            List<Client> filteredClients = allClients
                .Where(client => client.LastName.ToLower().Contains(searchText) || client.FirstName.ToLower().Contains(searchText))
                .ToList();

            ClientComboBox.ItemsSource = filteredClients
                .Select(client => $"{client.LastName} {client.FirstName}")
                .Where(name => name.ToLower().Contains(searchText))
                .ToList();
        }
        private void AddOrderButton_Click(object sender, RoutedEventArgs e)
        {
            if (ClientComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Будь ласка, виберіть клієнта.");
                return;
            }

            string selectedClientName = ClientComboBox.SelectedItem.ToString();
            string[] parts = selectedClientName.Split(' ');
            string lastName = parts[0];
            string firstName = parts[1];

            Client selectedClient = dbContext.clients
                .FirstOrDefault(client => client.LastName == lastName && client.FirstName == firstName);

            if (selectedClient == null)
            {
                MessageBox.Show("Не вдалося знайти обраного клієнта.");
                return;
            }

            Order newOrder = new Order
            {
                ClientId = selectedClient.Id,
                OrderDate = DateTime.Now.ToUniversalTime(),
                OrderStatus = StatusTextBox.Text,
            };

            dbContext.orders.Add(newOrder);
            dbContext.SaveChanges(); 

            OrderDetail newOrderDetail = new OrderDetail
            {
                OrderId = newOrder.Id,      
                Description = DescriptionTextBox.Text,
                UnitPrice = Decimal.Parse(PriceTextBox.Text),
            };

            dbContext.orderDetails.Add(newOrderDetail);
            dbContext.SaveChanges(); 

            MessageBox.Show("Замовлення успішно додано для клієнта.");

            this.Close();
        }
    }
}

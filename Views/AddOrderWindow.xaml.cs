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
    public partial class AddOrderWindow : Window
    {
        private AppDbContext dbContext;

        public AddOrderWindow()
        {
            InitializeComponent();
            dbContext = new AppDbContext();
        }
              
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CreateOrderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var clientName = ClientNameTextBox.Text;
                var clientLastName = ClientLastNameTextBox.Text;
                var phoneNumber = PhoneNumberTextBox.Text;
                var orderDate = OrderDatePicker.SelectedDate.Value.ToUniversalTime();
                var orderStatus = OrderStatusTextBox.Text;
                var description = DescriptionTextBox.Text;
                var unitPrice = decimal.Parse(UnitPriceTextBox.Text);

                if (string.IsNullOrWhiteSpace(clientName) || string.IsNullOrWhiteSpace(clientLastName) || string.IsNullOrWhiteSpace(phoneNumber) || orderDate == default(DateTime) || string.IsNullOrWhiteSpace(orderStatus) || string.IsNullOrWhiteSpace(description))
                {
                    MessageBox.Show("Будь ласка, заповніть всі обов'язкові поля!");
                    return;
                }

                using (var dbContext = new AppDbContext())
                {
                    // Check if the client with the entered phone number already exists
                    var existingClient = dbContext.clients.FirstOrDefault(c => c.PhoneNumber == phoneNumber);

                    if (existingClient == null)
                    {
                        // If the client does not exist, create a new one
                        var client = new Client
                        {
                            FirstName = clientName,
                            LastName = clientLastName,
                            PhoneNumber = phoneNumber
                        };

                        dbContext.clients.Add(client);
                        dbContext.SaveChanges();

                        // Create a new order for the client
                        Order newOrder = new Order
                        {
                            ClientId = client.Id,
                            OrderDate = DateTime.Now.ToUniversalTime(),
                            OrderStatus = orderStatus,
                        };

                        dbContext.orders.Add(newOrder);
                        dbContext.SaveChanges();

                        // Add order detail
                        OrderDetail newOrderDetail = new OrderDetail
                        {
                            OrderId = newOrder.Id,
                            Description = description,
                            UnitPrice = unitPrice,
                        };

                        dbContext.orderDetails.Add(newOrderDetail);
                        dbContext.SaveChanges();

                        this.Close();

                        MessageBox.Show("Замовлення успішно додано для клієнта.");
                    }
                    else
                    {
                        MessageBox.Show("Клієнт з введеним номером телефону вже існує.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при додаванні замовлення: " + ex.Message);
            }
        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            AddOrderToClientWindow window = new AddOrderToClientWindow();

            window.Show();
            this.Close();
        }
    }
}

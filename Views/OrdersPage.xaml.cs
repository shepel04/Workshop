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
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        private AppDbContext dbContext;
        public OrdersPage()
        {
            InitializeComponent();
            dbContext = new AppDbContext();
            LoadData(); 
        }

        private async void LoadData()
        {
            using (var dbContext = new AppDbContext())
            {
                var orders = await dbContext.orders
                    .Include(order => order.Client)
                    .Include(order => order.OrderDetails)
                    .ToListAsync();

                var data = orders.Select(order => new
                {
                    Id = order.Id,
                    ClientName = $"{order.Client.FirstName} {order.Client.LastName}",
                    OrderDate = order.OrderDate,
                    OrderStatus = order.OrderStatus,
                    Description = order.OrderDetails.Description,
                    UnitPrice = order.OrderDetails.UnitPrice
                }).ToList();

                OrdersDataGrid.ItemsSource = data;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var addOrderWindow = new AddOrderWindow();

            addOrderWindow.Show();
        }

        private async void CompleteOrderButton_Click(object sender, RoutedEventArgs e)
        {
            if (OrdersDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, виберіть замовлення для завершення!");
                return;
            }

            var selectedOrder = ((dynamic)OrdersDataGrid.SelectedItem)?.Id;
            if (selectedOrder == null)
            {
                MessageBox.Show("Не вдалося отримати Id обраного замовлення!");
                return;
            }

            using (var dbContext = new AppDbContext())
            {
                var order = await dbContext.orders.FindAsync(selectedOrder);

                if (order == null)
                {
                    MessageBox.Show("Замовлення не знайдено!");
                    return;
                }

                order.OrderStatus = "Виконано";

                OrderDetail orderDetail = await dbContext.orderDetails.FindAsync(order.Id + 7);  

                if (orderDetail == null)
                {
                    MessageBox.Show("Деталі замовлення не знайдено!");
                    return;
                }

                var serviceLog = new ServiceLog
                {
                    ClientId = order.ClientId,
                    ServiceDate = DateTime.UtcNow,
                    ServiceDescription = orderDetail.Description,
                    ServiceCost = orderDetail.UnitPrice
                };

                dbContext.serviceLogs.Add(serviceLog);

                 
                

                var financeRecord = new Finance
                {
                    OrderId = order.Id,
                    Amount = orderDetail.UnitPrice,
                };

                dbContext.finances.Add(financeRecord);
                dbContext.orders.Remove(order);

                try
                {
                    await dbContext.SaveChangesAsync();   
                    MessageBox.Show("Замовлення успішно завершено!");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка при завершенні замовлення: " + ex.Message);
                }
            }
        }

        private async void DeleteOrderButton_Click(object sender, RoutedEventArgs e)
        {
            if (OrdersDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, виберіть замовлення для видалення!");
                return;
            }

            var selectedOrder = ((dynamic)OrdersDataGrid.SelectedItem)?.Id;
            if (selectedOrder == null)
            {
                MessageBox.Show("Не вдалося отримати Id обраного замовлення!");
                return;
            }

            using (var dbContext = new AppDbContext())
            {
                var order = await dbContext.orders.FindAsync(selectedOrder);

                if (order == null)
                {
                    MessageBox.Show("Замовлення не знайдено!");
                    return;
                }

                try
                {
                    dbContext.orders.Remove(order);
                    await dbContext.SaveChangesAsync();
                    MessageBox.Show("Замовлення успішно видалено!");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка при видаленні замовлення: " + ex.Message);
                }
            }
        }

        private void ApplyFilterButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime? filterDate = DateFilterPicker.SelectedDate;
            decimal? minPrice = null;
            decimal? maxPrice = null;
            int? orderId = null;

            if (!string.IsNullOrEmpty(PriceFilterLowerTextBox.Text))
            {
                minPrice = decimal.Parse(PriceFilterLowerTextBox.Text);
            }
            if (!string.IsNullOrEmpty(PriceFilterHigherTextBox.Text))
            {
                maxPrice = decimal.Parse(PriceFilterHigherTextBox.Text);
            }
            string filterCustomerName = CustomerNameFilterTextBox.Text;

            if (!string.IsNullOrEmpty(OrderIdTextBox.Text))
            {
                orderId = int.Parse(OrderIdTextBox.Text);
            }

            var filteredOrders = dbContext.orders
                .Include(o => o.Client)
                .Include(o => o.OrderDetails)
                .AsQueryable();
            if (filterDate.HasValue)
            {
                DateTime startOfDay = filterDate.Value.Date.ToUniversalTime();
                DateTime endOfDay = filterDate.Value.Date.AddDays(1).AddTicks(-1).ToUniversalTime();
                filteredOrders = filteredOrders.Where(o => o.OrderDate.ToUniversalTime() >= startOfDay && o.OrderDate.ToUniversalTime() <= endOfDay);
            }
            if (minPrice.HasValue && maxPrice.HasValue)
            {
                filteredOrders = filteredOrders.Where(order => order.OrderDetails != null && order.OrderDetails.UnitPrice >= minPrice && order.OrderDetails.UnitPrice <= maxPrice);
            }
            else if (minPrice.HasValue && !maxPrice.HasValue)
            {
                filteredOrders = filteredOrders.Where(order => order.OrderDetails != null && order.OrderDetails.UnitPrice >= minPrice);
            }
            else if (maxPrice.HasValue && !minPrice.HasValue)
            {
                filteredOrders = filteredOrders.Where(order => order.OrderDetails != null && order.OrderDetails.UnitPrice <= maxPrice);
            }

            if (orderId.HasValue)
            {
                filteredOrders = filteredOrders.Where(order => order.Id == orderId);
            }

            if (!string.IsNullOrEmpty(filterCustomerName))
            {
                filteredOrders = filteredOrders.Where(o => o.Client.FirstName.Contains(filterCustomerName) || o.Client.LastName.Contains(filterCustomerName));
            }

            OrdersDataGrid.ItemsSource = filteredOrders.Select(o => new
            {
                OrderId = o.Id,
                OrderDate = o.OrderDate,
                ClientName = o.Client.FirstName + " " + o.Client.LastName,
                Description = o.OrderDetails != null ? o.OrderDetails.Description : "", 
                TotalPrice = o.OrderDetails != null ? o.OrderDetails.UnitPrice : 0
            }).ToList();
        }

        private void ResetFilterButton_Click(object sender, RoutedEventArgs e)
        {
            DateFilterPicker.SelectedDate = null;
            PriceFilterLowerTextBox.Text = "";
            PriceFilterHigherTextBox.Text = "";
            CustomerNameFilterTextBox.Text = "";
            OrderIdTextBox.Text = "";

            LoadData();
        }

        private void RefreshTableButton_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
    }
}

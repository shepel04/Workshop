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
using Workshop.Models;
using Workshop.Data;


namespace Workshop.Views
{
    /// <summary>
    /// Логика взаимодействия для ClientOrdersWindow.xaml
    /// </summary>
    /// 

    public class OrderViewModel
    {
        public string OrderDescription { get; set; }
        public decimal OrderPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
    }

    public partial class ClientOrdersWindow : Window
    {
        private readonly int clientId;

        public ClientOrdersWindow(int clientId)
        {
            InitializeComponent();

            using (var dbContext = new AppDbContext())
            {
                var client = dbContext.clients.FirstOrDefault(c => c.Id == clientId);
                if (client != null)
                {
                    Title = $"{client.FirstName} {client.LastName} - Замовлення";
                }
            }

            this.clientId = clientId;
            LoadOrders();
        }

        private void LoadOrders()
        {
            using (var dbContext = new AppDbContext())
            {
                var ordersFromOrdersTable = dbContext.orders
                    .Where(o => o.ClientId == clientId)
                    .Select(o => new OrderViewModel
                    {
                        OrderDescription = o.OrderDetails.Description,
                        OrderPrice = o.OrderDetails.UnitPrice,
                        OrderDate = o.OrderDate,
                        OrderStatus = o.OrderStatus
                    })
                    .ToList();

                var ordersFromServiceLogTable = dbContext.serviceLogs
                    .Where(sl => sl.ClientId == clientId)
                    .Select(sl => new OrderViewModel
                    {
                        OrderDescription = sl.ServiceDescription,
                        OrderPrice = sl.ServiceCost,
                        OrderDate = sl.ServiceDate,
                        OrderStatus = "Архівне"  
                    })
                    .ToList();

                var allOrders = ordersFromOrdersTable.Union(ordersFromServiceLogTable).ToList();

                OrdersDataGrid.ItemsSource = allOrders;
            }
        }
    }
}

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
using Workshop.Models;
using Workshop.Data;
using Microsoft.EntityFrameworkCore;

namespace Workshop.Views
{
    /// <summary>
    /// Логика взаимодействия для FinancePage.xaml
    /// </summary>
    public partial class FinancePage : Page
    {
        public FinancePage()
        {
            InitializeComponent();
            LoadFinancesAndServiceLogs();
        }

        private async void LoadFinancesAndServiceLogs()
        {
            using (var dbContext = new AppDbContext())
            {
                var finances = await dbContext.finances.ToListAsync();

                var serviceLogs = await dbContext.serviceLogs.ToListAsync();

                var data = from finance in finances
                           join serviceLog in serviceLogs
                           on finance.OrderId equals serviceLog.ClientId
                           select new
                           {
                               finance.Amount,
                               serviceLog.ServiceDate
                           };

                FinancesDataGrid.ItemsSource = data;
            }
        }

        
    }
}

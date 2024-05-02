using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Workshop.Views;


namespace Workshop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OrdersPage_Checked(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new OrdersPage();
        }

        private void ClientsPage_Checked(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ClientsPage();
        }

        private void EmployeesPage_Checked(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new EmployeesPage();
        }

        private void ServicesPage_Checked(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ServicesPage();
        }

        private void StoragePage_Checked(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new StoragePage();
        }

        private void FinancePage_Checked(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new FinancePage();
        }

        private void InventoryPage_Checked(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new InventoryPage();
        }

        private void ServiceLogPage_Checked(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ServiceLogPage();
        }

    }
}
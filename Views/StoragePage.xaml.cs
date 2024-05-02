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


namespace Workshop.Views
{
    /// <summary>
    /// Логика взаимодействия для StoragePage.xaml
    /// </summary>
    public partial class StoragePage : Page
    {
        public StoragePage()
        {
            InitializeComponent();
            RefreshInventory();
        }
        private void RefreshInventory()
        {
            using (var dbContext = new AppDbContext())
            {
                List<Product> products = dbContext.products.ToList();
                InventoryDataGrid.ItemsSource = products;
            }
        }


        private void AddItemButton_Click(object sender, RoutedEventArgs e)
        {
            AddToStorageWindow storageWindow = new AddToStorageWindow();

            storageWindow.Show();
        }

        private void DeleteItemButton_Click(object sender, RoutedEventArgs e)
        {
            if (InventoryDataGrid.SelectedItems.Count > 0)
            {
                MessageBoxResult result = MessageBox.Show("Ви впевнені, що хочете видалити вибрані елементи?", "Підтвердження видалення", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    using (var dbContext = new AppDbContext())
                    {
                        foreach (var selectedItem in InventoryDataGrid.SelectedItems)
                        {
                            Product productToDelete = selectedItem as Product;
                            if (productToDelete != null)
                            {
                                dbContext.products.Remove(productToDelete);
                            }
                        }

                        dbContext.SaveChanges();
                    }

                    RefreshInventory();  
                }
            }
            else
            {
                MessageBox.Show("Спочатку оберіть елементи для видалення.", "Попередження", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = SearchTextBox.Text;
            using (var dbContext = new AppDbContext())
            {
                List<Product> products = dbContext.products
                    .Where(p => p.Name.Contains(searchTerm) || p.Description.Contains(searchTerm) || p.Category.Contains(searchTerm))
                    .ToList();
                InventoryDataGrid.ItemsSource = products;
            }
        }

        private void RefreshInventoryButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshInventory();            
        }
    }
}

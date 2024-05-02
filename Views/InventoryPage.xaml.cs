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
using Microsoft.EntityFrameworkCore;
using Workshop.Models;
using Workshop.Data;
using System.Diagnostics;
using System.Xml.Linq;

namespace Workshop.Views
{
    /// <summary>
    /// Логика взаимодействия для InventoryPage.xaml
    /// </summary>
    public partial class InventoryPage : Page
    {
        private List<Inventory> inventoryList;
        private AppDbContext dbContext;

        public InventoryPage()
        {
            InitializeComponent();
            dbContext = new AppDbContext();
            LoadInventoryDataGrid();
        }

        private void RefreshInventoryButton_Click(object sender, RoutedEventArgs e)
        {
            LoadInventoryDataGrid();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();
            LoadInventoryDataGrid(searchText);
        }

        private void LoadInventoryDataGrid()
        {
            using (var dbContext = new AppDbContext())
            {
                var inventoryList = dbContext.inventoryItems
                    .Include(inv => inv.Product)
                    .Select(inv => new InventoryDisplayItem
                    {
                        Id = inv.Id,
                        ProductName = inv.Product.Name,
                        ProductDescription = inv.Product.Description,
                        Quantity = inv.QuantityInStock,
                    })
                    .ToList();

                InventoryDataGrid.ItemsSource = inventoryList;
            }
        }
        private void LoadInventoryDataGrid(string nameFilter = "")
        {
            using (var dbContext = new AppDbContext())
            {
                IQueryable<InventoryDisplayItem> query = dbContext.inventoryItems
                    .Include(inv => inv.Product)
                    .Select(inv => new InventoryDisplayItem
                    {
                        Id = inv.Id,
                        ProductName = inv.Product.Name,
                        ProductDescription = inv.Product.Description,
                        Price = inv.Product.Price,
                        Quantity = inv.QuantityInStock,
                    });

                if (!string.IsNullOrEmpty(nameFilter))
                {
                    query = query.Where(item => item.ProductName.ToLower().Contains(nameFilter.ToLower()));
                }

                var inventoryList = query.ToList();
                InventoryDataGrid.ItemsSource = inventoryList;
            }
        }


        private void AddItemButton_Click(object sender, RoutedEventArgs e)
        {
            AddInventoryItemWindow addItemWindow = new AddInventoryItemWindow();

            if (addItemWindow.ShowDialog() == true)
            {
                if (string.IsNullOrWhiteSpace(addItemWindow.NameTextBox.Text) ||
                    string.IsNullOrWhiteSpace(addItemWindow.DescriptionTextBox.Text) ||
                    string.IsNullOrWhiteSpace(addItemWindow.PriceTextBox.Text) ||
                    string.IsNullOrWhiteSpace(addItemWindow.CategoryTextBox.Text) ||
                    string.IsNullOrWhiteSpace(addItemWindow.QuantityInStockTextBox.Text))
                {
                    MessageBox.Show("Будь ласка, заповніть всі поля.");
                    return;
                }

                string name = addItemWindow.NameTextBox.Text;
                string description = addItemWindow.DescriptionTextBox.Text;
                decimal price = decimal.Parse(addItemWindow.PriceTextBox.Text);
                string category = addItemWindow.CategoryTextBox.Text;
                int quantityInStock = int.Parse(addItemWindow.QuantityInStockTextBox.Text);

                var newItem = new Inventory
                {
                    Product = new Product
                    {
                        Name = name,
                        Description = description,
                        Price = price,
                        Category = category,
                        QuantityInStock = quantityInStock
                    },

                    QuantityInStock = quantityInStock
                };

                dbContext.inventoryItems.Add(newItem);
                dbContext.SaveChanges();
                LoadInventoryDataGrid();

                MessageBox.Show("Предмет інвентарю успішно додано до бази даних.");
            }
        }


        private void DeleteItemButton_Click(object sender, RoutedEventArgs e)
        {
            if (InventoryDataGrid.SelectedItem != null)
            {
                InventoryDisplayItem selectedItem = (InventoryDisplayItem)InventoryDataGrid.SelectedItem;

                int itemIdToDelete = selectedItem.Id;

                using (var dbContext = new AppDbContext())
                {
                    Inventory inventoryToDelete = dbContext.inventoryItems.FirstOrDefault(inv => inv.Id == itemIdToDelete);

                    if (inventoryToDelete != null)
                    {
                        dbContext.inventoryItems.Remove(inventoryToDelete);

                        Product productToDelete = dbContext.products.FirstOrDefault(p => p.Id == inventoryToDelete.ProductId);
                        if (productToDelete != null)
                        {
                            dbContext.products.Remove(productToDelete);
                        }

                        dbContext.SaveChanges();

                        LoadInventoryDataGrid();
                    }
                    else
                    {
                        MessageBox.Show("Предмет із зазначеним Id не знайдено в базі даних.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть предмет для видалення.");
            }
        }

        //private void EditItemButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (InventoryDataGrid.SelectedItem != null)
        //    {
        //        InventoryDisplayItem selectedItem = (InventoryDisplayItem)InventoryDataGrid.SelectedItem;

        //        AddInventoryItemWindow editItemWindow = new AddInventoryItemWindow();

        //        if (editItemWindow.ShowDialog() == true)
        //        {
        //            string name = editItemWindow.NameTextBox.Text;
        //            string description = editItemWindow.DescriptionTextBox.Text;
        //            decimal price = decimal.Parse(editItemWindow.PriceTextBox.Text);
        //            string category = editItemWindow.CategoryTextBox.Text;
        //            int quantityInStock = int.Parse(editItemWindow.QuantityInStockTextBox.Text);

        //            Inventory inventoryToUpdate = dbContext.inventoryItems.FirstOrDefault(inv => inv.Id == selectedItem.Id);

        //            if (inventoryToUpdate != null)
        //            {
        //                inventoryToUpdate.Product.Name = name;
        //                inventoryToUpdate.Product.Description = description;
        //                inventoryToUpdate.Product.Price = price;
        //                inventoryToUpdate.Product.Category = category;
        //                inventoryToUpdate.QuantityInStock = quantityInStock;

        //                dbContext.SaveChanges();

        //                LoadInventoryDataGrid();

        //                MessageBox.Show("Предмет інвентарю успішно відредаговано.");
        //            }
        //            else
        //            {
        //                MessageBox.Show("Помилка: предмет із зазначеним Id не знайдено в базі даних.");
        //            }
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Будь ласка, виберіть предмет для редагування.");
        //    }
        //}
    }

    public class InventoryDisplayItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}

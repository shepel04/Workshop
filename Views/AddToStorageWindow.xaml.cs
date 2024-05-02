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
    /// Логика взаимодействия для AddToStorageWindow.xaml
    /// </summary>
    public partial class AddToStorageWindow : Window
    {
        public AddToStorageWindow()
        {
            InitializeComponent();
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            using (var dbContext = new AppDbContext())
            {
                var newProduct = new Product
                {
                    Name = productNameTextBox.Text,
                    Description = productDescriptionTextBox.Text,
                    Price = decimal.Parse(productPriceTextBox.Text),
                    Category = productCategoryTextBox.Text,
                    QuantityInStock = int.Parse(productQuantityTextBox.Text)
                };

                dbContext.products.Add(newProduct);
                dbContext.SaveChanges();
            }

            MessageBox.Show("Product added successfully.");
            this.Close();
        }
    }
}

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

namespace Workshop.Views
{
    /// <summary>
    /// Логика взаимодействия для AddInventoryItemWindow.xaml
    /// </summary>
    public partial class AddInventoryItemWindow : Window
    {
        public AddInventoryItemWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}

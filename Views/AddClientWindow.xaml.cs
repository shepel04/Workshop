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
using System.ComponentModel.DataAnnotations;

namespace Workshop.Views
{
    /// <summary>
    /// Логика взаимодействия для AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        private AppDbContext _context;

        public ClientViewModel Client { get; set; }

        public AddClientWindow()
        {
            InitializeComponent();
            _context = new AppDbContext();
            Client = new ClientViewModel();
            DataContext = Client;
        }

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            if (IsValid(Client))
            {
                var newClient = new Client
                {
                    FirstName = Client.FirstName,
                    LastName = Client.LastName,
                    PhoneNumber = Client.PhoneNumber
                };

                _context.clients.Add(newClient);
                _context.SaveChanges();

                MessageBox.Show("Client added successfully!");
                Close();
            }
        }

        private bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj, null, null);
            var validationResults = new System.Collections.Generic.List<System.ComponentModel.DataAnnotations.ValidationResult>();

            return System.ComponentModel.DataAnnotations.Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
    public class ClientViewModel
    {
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; }
    }

}

using System.Configuration;
using System.Data;
using System.Windows;

namespace Workshop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=1111;Database=workshop;";
            Current.Properties["PostgresConnectionString"] = connectionString;
        }
    }

}

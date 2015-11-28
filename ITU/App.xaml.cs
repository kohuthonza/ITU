using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ITU
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {


        private void Application_Startup(object sender, StartupEventArgs e)
        {

            Users.Initialize();

            Users.users.Add(new User("Honza", "kolomaz"));
            Users.users.Add(new User("Jurka", "volomaz"));

            MainWindow wnd = new MainWindow();
            wnd.Show();
        }
    }
}

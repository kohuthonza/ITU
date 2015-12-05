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
            Users.deserialize();

            Plants.Initialize();
            Plants.deserialize();

            try
            {
                Users.Admin = Users.users.First(var => (var.Login == "admin"));
                Users.users.Remove(Users.Admin);
            }
            catch (InvalidOperationException)
            {
                User tmp = new User();
                tmp.Login = "admin";
                tmp.Passwd = "admin";
                Users.Admin = tmp;
            }

            MainWindow wnd = new MainWindow();
            wnd.Show();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            Users.serialize();
            Plants.serialize();
        }
    }
}

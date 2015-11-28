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

namespace ITU
{
    /// <summary>
    /// Interaction logic for AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public AddUserWindow()
        {
            InitializeComponent();
        }

        private void addUserBtn_Click(object sender, RoutedEventArgs e)
        {
            if (loginBox.Text != "" && passwdBox.Password != "")
            {
               

                try
                {
                    Users.users.First(var => (var.Name == loginBox.Text));
                    MessageBox.Show("Uživatel již existuje!");
                }
                catch (InvalidOperationException)
                {
                    Users.users.Add(new User(loginBox.Text, passwdBox.Password));
                    MessageBox.Show("Uživatel přidán!");
                    open_MainWindow();
                    this.Close();

                }

            }
                
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            open_MainWindow();
            this.Close();
        }

        private void endBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void open_MainWindow()
        {
            MainWindow wnd = new MainWindow();
            wnd.Show();
        }
    }
}

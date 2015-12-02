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

namespace ITU
{
    /// <summary>
    /// Interaction logic for ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        private User user;

        public ProfilePage(User user)
        {
            this.user = user;
            InitializeComponent();
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new EditUserPage(user));
        }

        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {
            
            MainWindow wnd = new MainWindow();
            wnd.Show();
            Application.Current.MainWindow.Close();

        }

        private void endBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }
    }
}

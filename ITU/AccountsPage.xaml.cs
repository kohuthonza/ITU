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
    /// Interaction logic for AccountsPage.xaml
    /// </summary>
    public partial class AccountsPage : Page
    {
        public AccountsPage()
        {
            InitializeComponent();
            accList.ItemsSource = Users.users;
            accList.DisplayMemberPath = "Login";
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (accList.SelectedItem == null)
            {
                MessageBox.Show("Vyberte účet!");
            }
            else
            {
                User tmp = accList.SelectedItem as User;
                PasswordWindow wnd = new PasswordWindow(tmp, "Zadejte heslo");
                wnd.ShowDialog();

                if (wnd.success)
                {
                    wnd.Close();
                    this.NavigationService.Navigate(new ProfilePage(tmp));
                }
                else
                {
                    wnd.Close();
                }
            }
        }

        private void endBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }
    }
}

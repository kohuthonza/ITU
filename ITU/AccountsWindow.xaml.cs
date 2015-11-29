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
    /// Interaction logic for AccountsWindow.xaml
    /// </summary>
    public partial class AccountsWindow : Window
    {
        public AccountsWindow()
        {
            InitializeComponent();
            accList.ItemsSource = Users.users;
            accList.DisplayMemberPath = "Name";
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {

            if(accList.SelectedItem == null)
            {
                MessageBox.Show("Vyberte účet!");
            }
            else
            {
                User tmp = accList.SelectedItem as User;
                PasswordWindow wnd = new PasswordWindow(tmp);
                wnd.ShowDialog();

                if (wnd.success)
                {
                    wnd.Close();
                    ProfileWindow pwnd = new ProfileWindow(tmp);
                    pwnd.Show();
                    this.Close();
                }
                else
                {
                    wnd.Close();
                }
            }
                
        }

        private void endBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow wnd = new MainWindow();
            wnd.Show();
            this.Close();
        }
    }
}

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
    /// Interaction logic for UsersListUserControl.xaml
    /// </summary>
    public partial class UsersListUserControl : UserControl
    {

        private MainWindow mwnd;

        public UsersListUserControl()
        {
            InitializeComponent();
            accList.ItemsSource = Users.users;
            accList.DisplayMemberPath = "Login";
            this.mwnd = Application.Current.MainWindow as MainWindow;
        }
        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            mwnd.MainGrid.Children.Clear();
            mwnd.MainGrid.Children.Add(new AdminUserControl());
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
                Users.ActiveUser = tmp;
                mwnd.MainGrid.Children.Clear();
                mwnd.MainGrid.Children.Add(new EditUserUserControl());
                
            }
        }


        private void adminBtn_Click(object sender, RoutedEventArgs e)
        {
            PasswordWindow wnd = new PasswordWindow(Users.Admin, "Zadejte heslo");
            wnd.ShowDialog();
            if (wnd.success)
            {
                wnd.Close();
                mwnd.MainGrid.Children.Clear();
                Users.ActiveUser = Users.Admin;
                mwnd.MainGrid.Children.Add(new AdminUserControl());
            }
            else
            {
                wnd.Close();
            }
        }

    }
}

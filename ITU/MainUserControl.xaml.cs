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
    /// Interaction logic for MainUserControl.xaml
    /// </summary>
    public partial class MainUserControl : UserControl
    {

        private MainWindow mwnd;

        public MainUserControl()
        {
            InitializeComponent();

            this.mwnd = Application.Current.MainWindow as MainWindow;
        }

        private void startBtn_Click(object sender, RoutedEventArgs e)
        {
            mwnd.MainGrid.Children.Clear();
            mwnd.MainGrid.Children.Add (new WelcomeUserControl());
        }

        private void accBtn_Click(object sender, RoutedEventArgs e)
        {
            mwnd.MainGrid.Children.Clear();
            mwnd.MainGrid.Children.Add(new AccountsUserControl());
        }

        private void endBtn_Click(object sender, RoutedEventArgs e)
        {
            mwnd.Close();
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

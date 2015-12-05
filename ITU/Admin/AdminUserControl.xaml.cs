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
    /// Interaction logic for AdminUserControl.xaml
    /// </summary>
    public partial class AdminUserControl : UserControl
    {

        private MainWindow mwnd;

        public AdminUserControl()
        {
            InitializeComponent();
            this.mwnd = Application.Current.MainWindow as MainWindow;
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {

            mwnd.MainGrid.Children.Clear();
            mwnd.MainGrid.Children.Add(new ChangePasswdUserControl());

        }

        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {

            mwnd.MainGrid.Children.Clear();
            mwnd.MainGrid.Children.Add(new MainUserControl());
        }

        private void endBtn_Click(object sender, RoutedEventArgs e)
        {
            mwnd.Close();
        }

        private void plantBtn_Click(object sender, RoutedEventArgs e)
        {
            Plants.ActualIndex = 0;
            mwnd.MainGrid.Children.Clear();
            mwnd.MainGrid.Children.Add(new PlantsUserControl());
        }
    


        private void userBtn_Click(object sender, RoutedEventArgs e)
        {
            mwnd.MainGrid.Children.Clear();
            mwnd.MainGrid.Children.Add(new UsersListUserControl());
        }
    }
}

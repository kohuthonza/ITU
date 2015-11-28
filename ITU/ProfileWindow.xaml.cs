using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        public User user { get; set; }

        public ProfileWindow(User user)
        {
            InitializeComponent();
            this.user = user;
            loginBlock.Text = user.Name;
            passwdBlock.Text = user.passwd;
        }

        private void open_MainWindow()
        {
            MainWindow wnd = new MainWindow();
            wnd.Show();
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

    }
}

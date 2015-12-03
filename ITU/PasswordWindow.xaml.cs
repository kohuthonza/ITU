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
    /// Interaction logic for PasswordWindow.xaml
    /// </summary>
    public partial class PasswordWindow : System.Windows.Window
    {

        private User user;
        public bool success { get; set; }

        public PasswordWindow(User user, string alert)
        {
            InitializeComponent();
            this.user = user;
            alertBlock.Text = alert;
            this.success = false;

        }

        private void subBtn_Click(object sender, RoutedEventArgs e)
        {
            if (passwdBox.Password == user.Passwd)
            {
                success = true;
                this.Hide();
            }
            else
            {
                MessageBox.Show("Nesprávné heslo!");
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            success = false;
        }
    }
}

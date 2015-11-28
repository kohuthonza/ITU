using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
     

        public MainWindow()
        {
            InitializeComponent();

        }

       

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {



            if (loginBox.Text != "" && passwdBox.Password != "")

             

            {
                try
                {
                    
                    ProfileWindow wnd = new ProfileWindow(Users.users.First(var => (var.Name == loginBox.Text) && (var.passwd == passwdBox.Password)));
                    wnd.Show();
                    this.Close();
                    
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Neznám tě!");
                }
   
            }
         
        }

        private void addUserBtn_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow wnd = new AddUserWindow();
            wnd.Show();
            this.Close();
        }


    }
}

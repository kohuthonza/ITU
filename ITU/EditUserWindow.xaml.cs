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
    /// Interaction logic for EditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : Window
    {
        private ProfileWindow prownd;
        private User user;
        

        public EditUserWindow(User user, ProfileWindow prownd)
        {
            InitializeComponent();

            this.prownd = prownd;
            this.user = user;
            prownd.Hide();

            loginBox.Text = user.Name;


        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            prownd.Show();
            this.Close();
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {

            
            PasswordWindow wnd = new PasswordWindow(user);
            wnd.ShowDialog();
            if (wnd.success)
            {
                wnd.Close();
                if (string.IsNullOrWhiteSpace(loginBox.Text))
                {
                    MessageBox.Show("Přihlašovací jméno je prázdné!");

                }
                else
                {
                    if (loginBox.Text != user.Name)
                    {
                        try
                        {
                            Users.users.First(var => (var.Name == loginBox.Text));
                            MessageBox.Show("Uživatel již existuje!");
                        }
                        catch (InvalidOperationException)
                        {
                            user.Name = loginBox.Text;
                            MessageBox.Show("Přihlašovací jméno změněno!");
                        }
                    }
                }
            
                if (!(string.IsNullOrWhiteSpace(newpasswdBox.Password) && string.IsNullOrWhiteSpace(new2passwdBox.Password)))
                {
                    if (newpasswdBox.Password == new2passwdBox.Password)
                    {
                        user.passwd = newpasswdBox.Password;
                        MessageBox.Show("Heslo změněno!");
                    }
                    else
                    {
                        MessageBox.Show("Hesla se neshodují!");
                    }
                }
            }
            else
            {
                wnd.Close();
            }
            loginBox.Text = user.Name;
            newpasswdBox.Password = "";
            new2passwdBox.Password = "";

            

        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            PasswordWindow wnd = new PasswordWindow(user);
            wnd.ShowDialog();
            if (wnd.success)
            {
                wnd.Close();
                Users.users.Remove(user);
                MainWindow mwnd = new MainWindow();
                mwnd.Show();
                prownd.Close();
                this.Close();
            }
            else
            {
                wnd.Close();
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            prownd.Show(); ;
        }
    }
}

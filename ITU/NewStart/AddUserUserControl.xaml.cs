using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ITU
{
    /// <summary>
    /// Interaction logic for AddUserUserControl.xaml
    /// </summary>
    public partial class AddUserUserControl : System.Windows.Controls.UserControl
    {

        private MainWindow mwnd;

        public AddUserUserControl()
        {
            InitializeComponent();
            this.mwnd = System.Windows.Application.Current.MainWindow as MainWindow;
            var timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 200;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            SolidColorBrush redColor = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            SolidColorBrush greenColor = new SolidColorBrush(Color.FromRgb(0, 190, 0));
            SolidColorBrush defaultColor = new SolidColorBrush(Color.FromRgb(171, 173, 179));
            bool enable = true;

            if (string.IsNullOrWhiteSpace(loginBox.Text))
            {
                loginBox.BorderBrush = redColor;
                enable = false;
                loginAlert.Text = "Kolonka je prázdná";
            }
            else
            {

                try
                {
                    Users.users.First(var => (var.Login == loginBox.Text));
                    loginBox.BorderBrush = redColor;
                    enable = false;
                    loginAlert.Text = "Uživatel již existuje";
                }
                catch (InvalidOperationException)
                {
                    loginBox.BorderBrush = greenColor;
                    loginAlert.Text = "";
                }


            }
            if (nameBox.Text != "")
            {
                nameBox.BorderBrush = greenColor;
            }
            else
            {
                nameBox.BorderBrush = defaultColor;
            }
            if (snameBox.Text != "")
            {
                snameBox.BorderBrush = greenColor;
            }
            else
            {
                snameBox.BorderBrush = defaultColor;
            }
            if (emailBox.Text != "")
            {
                emailBox.BorderBrush = greenColor;
            }
            else
            {
                emailBox.BorderBrush = defaultColor;
            }

            if (!(string.IsNullOrWhiteSpace(passwdBox.Password) && string.IsNullOrWhiteSpace(passwd2Box.Password)))
            {

                if (string.IsNullOrWhiteSpace(passwdBox.Password))
                {
                    passwdBox.BorderBrush = redColor;
                    passwd2Box.BorderBrush = defaultColor;
                    enable = false;
                    passwordAlert.Text = "Kolonka je prázdná";
                    password2Alert.Text = "";
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(passwd2Box.Password))
                    {
                        passwd2Box.BorderBrush = redColor;
                        passwdBox.BorderBrush = defaultColor;
                        enable = false;
                        password2Alert.Text = "Kolonka je prázdná";
                        passwordAlert.Text = "";
                    }
                    else
                    {
                        if (passwdBox.Password != passwd2Box.Password)
                        {
                            passwdBox.BorderBrush = redColor;
                            passwd2Box.BorderBrush = redColor;
                            enable = false;
                            passwordAlert.Text = "Hesla se neshodují";
                            password2Alert.Text = "Hesla se neshodují";

                        }
                        else
                        {
                            passwdBox.BorderBrush = greenColor;
                            passwd2Box.BorderBrush = greenColor;
                            passwordAlert.Text = "";
                            password2Alert.Text = "";
                        }
                    }
                }


            }
            else
            {
                passwdBox.BorderBrush = redColor;
                passwd2Box.BorderBrush = redColor;
                passwordAlert.Text = "Kolonka je prázdná";
                password2Alert.Text = "Kolonka je prázdná";
                enable = false;
            }

            if (enable)
            {
                addUserBtn.IsEnabled = true;
            }
            else
            {
                addUserBtn.IsEnabled = false;
            }
        }

        private void addUserBtn_Click(object sender, RoutedEventArgs e)
        {
            if (loginBox.Text != "" && passwdBox.Password != "")
            {
                try
                {
                    Users.users.First(var => (var.Login == loginBox.Text));
                    System.Windows.MessageBox.Show("Uživatel již existuje!");
                }
                catch (InvalidOperationException)
                {
                    User tmp = new User();
                    tmp.Login = loginBox.Text;
                    tmp.Passwd = passwdBox.Password;
                    tmp.Name = nameBox.Text;
                    tmp.Sname = snameBox.Text;
                    tmp.Email = emailBox.Text;
                    Users.users.Add(tmp);
                    Users.ActiveUser = tmp;

                    mwnd.MainGrid.Children.Clear();
                    mwnd.MainGrid.Children.Add(new ProfileUserControl());


                }

            }
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            mwnd.MainGrid.Children.Clear();
            mwnd.MainGrid.Children.Add(new WelcomeUserControl());
        }

        private void endBtn_Click(object sender, RoutedEventArgs e)
        {
            mwnd.Close();
        }

    }
}

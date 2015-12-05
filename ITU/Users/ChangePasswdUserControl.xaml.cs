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
    /// Interaction logic for ChangePasswdUserControl.xaml
    /// </summary>
    public partial class ChangePasswdUserControl : System.Windows.Controls.UserControl
    {

        private MainWindow mwnd;

        public ChangePasswdUserControl()
        {
            InitializeComponent();
            this.mwnd = System.Windows.Application.Current.MainWindow as MainWindow;
            var timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 200;
            timer.Start();


            editBtn.IsEnabled = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {

            SolidColorBrush redColor = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            SolidColorBrush greenColor = new SolidColorBrush(Color.FromRgb(0, 190, 0));
            SolidColorBrush defaultColor = new SolidColorBrush(Color.FromRgb(171, 173, 179));
            bool enable = true;

            if (string.IsNullOrWhiteSpace(newpasswdBox.Password) &&
                string.IsNullOrWhiteSpace(new2passwdBox.Password))
            {
               
                newpasswdBox.BorderBrush = defaultColor;
                new2passwdBox.BorderBrush = defaultColor;
                newpasswordAlert.Text = "";
                new2passwordAlert.Text = "";
                enable = false;
            }
            else
            {

                if (!(string.IsNullOrWhiteSpace(newpasswdBox.Password) && string.IsNullOrWhiteSpace(new2passwdBox.Password)))
                {

                    if (string.IsNullOrWhiteSpace(newpasswdBox.Password))
                    {
                        newpasswdBox.BorderBrush = redColor;
                        new2passwdBox.BorderBrush = defaultColor;
                        enable = false;
                        newpasswordAlert.Text = "Kolonka je prázdná";
                        new2passwordAlert.Text = "";
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(new2passwdBox.Password))
                        {
                            new2passwdBox.BorderBrush = redColor;
                            newpasswdBox.BorderBrush = defaultColor;
                            enable = false;
                            new2passwordAlert.Text = "Kolonka je prázdná";
                            newpasswordAlert.Text = "";
                        }
                        else
                        {
                            if (newpasswdBox.Password != new2passwdBox.Password)
                            {
                                newpasswdBox.BorderBrush = redColor;
                                new2passwdBox.BorderBrush = redColor;
                                enable = false;
                                newpasswordAlert.Text = "Hesla se neshodují";
                                new2passwordAlert.Text = "Hesla se neshodují";

                            }
                            else
                            {
                                newpasswdBox.BorderBrush = greenColor;
                                new2passwdBox.BorderBrush = greenColor;
                                newpasswordAlert.Text = "";
                                new2passwordAlert.Text = "";
                            }
                        }
                    }



                }
                else
                {
                    newpasswdBox.BorderBrush = defaultColor;
                    new2passwdBox.BorderBrush = defaultColor;
                    newpasswordAlert.Text = "";
                    new2passwordAlert.Text = "";
                }
            }

            if (enable)
            {
                editBtn.IsEnabled = true;
            }
            else
            {
                editBtn.IsEnabled = false;
            }

        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            
            mwnd.MainGrid.Children.Clear();
            if (Users.ActiveUser.Login == "admin")
            {
                mwnd.MainGrid.Children.Add(new AdminUserControl());
            }
            else
            {
                mwnd.MainGrid.Children.Add(new ProfileUserControl());
            }
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            bool change = false;
            PasswordWindow wnd = new PasswordWindow(Users.ActiveUser, "Zadejte aktuální heslo");
            wnd.ShowDialog();
            if (wnd.success)
            {
                wnd.Close();

                if (!(string.IsNullOrWhiteSpace(newpasswdBox.Password) && string.IsNullOrWhiteSpace(new2passwdBox.Password)))
                {
                    if (newpasswdBox.Password == new2passwdBox.Password)
                    {
                        Users.ActiveUser.Passwd = newpasswdBox.Password;
                        change = true;
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Hesla se neshodují!");
                    }
                }
            }
            else
            {
                wnd.Close();
            }
            newpasswdBox.Password = "";
            new2passwdBox.Password = "";

            if (change)
            {
                System.Windows.MessageBox.Show("Heslo bylo změněno");
                mwnd.MainGrid.Children.Clear();
                if(Users.ActiveUser.Login == "admin")
                {
                    mwnd.MainGrid.Children.Add(new AdminUserControl());
                }
                else
                {
                    mwnd.MainGrid.Children.Add(new ProfileUserControl());
                }
            }
        }

    }
}

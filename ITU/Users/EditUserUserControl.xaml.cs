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
    /// Interaction logic for EditUserUserControl.xaml
    /// </summary>
    public partial class EditUserUserControl : System.Windows.Controls.UserControl
    {

        private MainWindow mwnd;

        public EditUserUserControl()
        {
            InitializeComponent();
            this.mwnd = System.Windows.Application.Current.MainWindow as MainWindow;
            loginBox.Text = Users.ActiveUser.Login;
            nameBox.Text = Users.ActiveUser.Name;
            snameBox.Text = Users.ActiveUser.Sname;
            emailBox.Text = Users.ActiveUser.Email;
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

            if (loginBox.Text == Users.ActiveUser.Login &&
               nameBox.Text == Users.ActiveUser.Name &&
               snameBox.Text == Users.ActiveUser.Sname &&
               emailBox.Text == Users.ActiveUser.Email &&
               string.IsNullOrWhiteSpace(newpasswdBox.Password) &&
               string.IsNullOrWhiteSpace(new2passwdBox.Password))
            {
                nameBox.BorderBrush = defaultColor;
                snameBox.BorderBrush = defaultColor;
                emailBox.BorderBrush = defaultColor;
                newpasswdBox.BorderBrush = defaultColor;
                new2passwdBox.BorderBrush = defaultColor;
                loginBox.BorderBrush = defaultColor;
                loginAlert.Text = "";
                newpasswordAlert.Text = "";
                new2passwordAlert.Text = "";
                enable = false;
            }
            else
            {

                if (string.IsNullOrWhiteSpace(loginBox.Text))
                {
                    loginBox.BorderBrush = redColor;
                    enable = false;
                    loginAlert.Text = "Kolonka je prázdná";
                }
                else
                {

                    if (loginBox.Text != Users.ActiveUser.Login)
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
                    else
                    {
                        loginBox.BorderBrush = defaultColor;
                        loginAlert.Text = "";
                    }
                }
                if (nameBox.Text != Users.ActiveUser.Name)
                {
                    nameBox.BorderBrush = greenColor;
                }
                else
                {
                    nameBox.BorderBrush = defaultColor;
                }
                if (snameBox.Text != Users.ActiveUser.Sname)
                {
                    snameBox.BorderBrush = greenColor;
                }
                else
                {
                    snameBox.BorderBrush = defaultColor;
                }
                if (emailBox.Text != Users.ActiveUser.Email)
                {
                    emailBox.BorderBrush = greenColor;
                }
                else
                {
                    emailBox.BorderBrush = defaultColor;
                }

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
            Users.ActiveUser = Users.Admin;
            mwnd.MainGrid.Children.Add(new UsersListUserControl());
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            bool change = false;

            
            if (string.IsNullOrWhiteSpace(loginBox.Text))
            {
                 System.Windows.MessageBox.Show("Přihlašovací jméno je prázdné!");

            }
            else
            {
                if (loginBox.Text != Users.ActiveUser.Login)
                {
                    try
                    {
                        Users.users.First(var => (var.Login == loginBox.Text));
                        System.Windows.MessageBox.Show("Uživatel již existuje!");
                    }
                    catch (InvalidOperationException)
                    {
                        Users.ActiveUser.Login = loginBox.Text;
                        change = true;
                     }
                }
                if (nameBox.Text != Users.ActiveUser.Name)
                {
                    Users.ActiveUser.Name = nameBox.Text;
                    change = true;
                }
                if (snameBox.Text != Users.ActiveUser.Sname)
                {
                    Users.ActiveUser.Sname = snameBox.Text;
                    change = true;
                }
                if (emailBox.Text != Users.ActiveUser.Email)
                {
                    Users.ActiveUser.Email = emailBox.Text;
                    change = true;
                }
            }

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
            
           
            newpasswdBox.Password = "";
            new2passwdBox.Password = "";

            if (change)
            {
                System.Windows.MessageBox.Show("Účet byl upraven");
                mwnd.MainGrid.Children.Clear();
                Users.ActiveUser = Users.Admin;
                mwnd.MainGrid.Children.Add(new UsersListUserControl());
            }
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
           

            Users.users.Remove(Users.ActiveUser);
            mwnd.MainGrid.Children.Clear();
            Users.ActiveUser = Users.Admin;
            mwnd.MainGrid.Children.Add(new UsersListUserControl());

            
        }

    }
}

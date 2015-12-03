using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;

namespace ITU
{
    /// <summary>
    /// Interaction logic for EditUserPage.xaml
    /// </summary>
    public partial class EditUserPage : Page
    {
        private User user;

        public EditUserPage(User user)
        {
            InitializeComponent();
            this.user = user;
            loginBox.Text = user.Login;
            nameBox.Text = user.Name;
            snameBox.Text = user.Sname;
            emailBox.Text = user.Email;
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

            if (loginBox.Text == user.Login &&
               nameBox.Text == user.Name &&
               snameBox.Text == user.Sname &&
               emailBox.Text == user.Email && 
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
            else { 

                if (string.IsNullOrWhiteSpace(loginBox.Text))
                {
                    loginBox.BorderBrush = redColor;
                    enable = false;
                    loginAlert.Text = "Kolonka je prázdná";
                }
                else
                {

                    if (loginBox.Text != user.Login)
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
                if (nameBox.Text != user.Name)
                {
                    nameBox.BorderBrush = greenColor;
                }
                else
                {
                    nameBox.BorderBrush = defaultColor;
                }
                if (snameBox.Text != user.Sname)
                {
                    snameBox.BorderBrush = greenColor;    
                }
                else
                {
                    snameBox.BorderBrush = defaultColor;
                }
                if (emailBox.Text != user.Email)
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
            loginBox.Text = user.Login;
            nameBox.Text = user.Name;
            snameBox.Text = user.Sname;
            emailBox.Text = user.Email;

            this.NavigationService.GoBack();
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            bool change = false;
            PasswordWindow wnd = new PasswordWindow(user, "Zadejte aktuální heslo");
            wnd.ShowDialog();
            if (wnd.success)
            {
                wnd.Close();
                if (string.IsNullOrWhiteSpace(loginBox.Text))
                {
                    System.Windows.MessageBox.Show("Přihlašovací jméno je prázdné!");

                }
                else
                {
                    if (loginBox.Text != user.Login)
                    {
                        try
                        {
                            Users.users.First(var => (var.Login == loginBox.Text));
                            System.Windows.MessageBox.Show("Uživatel již existuje!");
                        }
                        catch (InvalidOperationException)
                        {
                            user.Login = loginBox.Text;
                            change = true;
                        }
                    }
                    if (nameBox.Text != user.Name)
                    {
                        user.Name = nameBox.Text;
                        change = true;
                    }
                    if (snameBox.Text != user.Sname)
                    {
                        user.Sname = snameBox.Text;
                        change = true;
                    }
                    if (emailBox.Text != user.Email)
                    {
                        user.Email = emailBox.Text;
                        change = true;
                    }
                }

                if (!(string.IsNullOrWhiteSpace(newpasswdBox.Password) && string.IsNullOrWhiteSpace(new2passwdBox.Password)))
                {
                    if (newpasswdBox.Password == new2passwdBox.Password)
                    {
                        user.Passwd = newpasswdBox.Password;
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
                System.Windows.MessageBox.Show("Účet byl upraven");
            }
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            PasswordWindow wnd = new PasswordWindow(user, "Pro smazání účtu zadejte heslo");
            wnd.ShowDialog();
            if (wnd.success)
            {
                wnd.Close();

                Users.users.Remove(user);
                MainWindow mwnd = new MainWindow();
                mwnd.Show();
                System.Windows.Application.Current.MainWindow.Close();
                System.Windows.Application.Current.MainWindow = mwnd;
                
            }
            else
            {
                wnd.Close();
            }
        }
    }
}

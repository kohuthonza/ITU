﻿using System;
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
    /// Interaction logic for AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public AddUserWindow()
        {
            InitializeComponent();
        }

        private void addUserBtn_Click(object sender, RoutedEventArgs e)
        {
            if (loginBox.Text != "" && passwdBox.Password != "")
            {
               

                try
                {
                    Users.users.First(var => (var.Name == loginBox.Text));
                    MessageBox.Show("Uživatel již existuje!");
                }
                catch (InvalidOperationException)
                {
                    User tmp = new User();
                    tmp.Name = loginBox.Text;
                    tmp.passwd = passwdBox.Password;
                    Users.users.Add(tmp);
                
                    MessageBox.Show("Uživatel přidán!");

                    ProfileWindow wnd = new ProfileWindow(tmp);
                    wnd.Show();
                    this.Close();

                }

            }
                
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            WelcomeWindow wnd = new WelcomeWindow();
            wnd.Show();
            this.Close();
        }

        private void endBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        

    }
}

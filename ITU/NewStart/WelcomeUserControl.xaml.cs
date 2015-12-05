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
    /// Interaction logic for WelcomeUserControl.xaml
    /// </summary>
    public partial class WelcomeUserControl : UserControl
    {

        private MainWindow mwnd;

        public WelcomeUserControl()
        {
            InitializeComponent();
            this.mwnd = Application.Current.MainWindow as MainWindow;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            mwnd.MainGrid.Children.Clear();
            mwnd.MainGrid.Children.Add(new MainUserControl());
        }

        private void nextBtn_Click(object sender, RoutedEventArgs e)
        {
            mwnd.MainGrid.Children.Clear();
            mwnd.MainGrid.Children.Add(new AddUserUserControl());
        }
    }
}

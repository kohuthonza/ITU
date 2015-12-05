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
    /// Interaction logic for ShowPlantUserControl.xaml
    /// </summary>
    public partial class ShowPlantUserControl : UserControl
    {

        private MainWindow mwnd;

        public ShowPlantUserControl()
        {
            InitializeComponent();
            this.mwnd = Application.Current.MainWindow as MainWindow;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            mwnd.MainGrid.Children.Clear();
            mwnd.MainGrid.Children.Add(new PlantsUserControl());
        }

        private void addPlantBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void endBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void imageBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void descriptionBox_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            mwnd.MainGrid.Children.Clear();
            mwnd.MainGrid.Children.Add(new EditPlantUserControl());
        }
    }
}

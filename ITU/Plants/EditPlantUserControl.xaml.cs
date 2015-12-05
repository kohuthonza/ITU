using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for EditPlantUserControl.xaml
    /// </summary>
    public partial class EditPlantUserControl : UserControl
    {

        private MainWindow mwnd;

        public EditPlantUserControl()
        {
            InitializeComponent();
            this.mwnd = Application.Current.MainWindow as MainWindow;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void addPlantBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void endBtn_Click(object sender, RoutedEventArgs e)
        {
                Plants.plants.Remove(Plants.ActivePlant);
                File.Delete(Plants.ActivePlant.Image);
                mwnd.MainGrid.Children.Clear();
                Plants.ActivePlant = null;
                mwnd.MainGrid.Children.Add(new PlantsUserControl());
        }

        private void imageBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void descriptionBox_GotFocus(object sender, RoutedEventArgs e)
        {

        }
    }
}

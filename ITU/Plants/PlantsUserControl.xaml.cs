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
    /// Interaction logic for FlowersUserControl.xaml
    /// </summary>
    public partial class PlantsUserControl : UserControl
    {
        private MainWindow mwnd;

        public PlantsUserControl()
        {
            InitializeComponent();
            if (Users.ActiveUser.Login != "admin")
            {
                addBtn.Visibility = Visibility.Hidden;
            }


            if ((Plants.ActualIndex == Plants.plants.Count) && (Plants.ActualIndex  != 0))
            {
                Plants.ActualIndex -= 6;
            }


            this.mwnd = Application.Current.MainWindow as MainWindow;
            
            if ((Plants.plants.Count - Plants.ActualIndex) > 6)
            {
                showImages(Plants.ActualIndex, 6);
            }
            else
            {
                showImages(Plants.ActualIndex, Plants.plants.Count - Plants.ActualIndex);
            }

            if (Plants.ActualIndex == 0)
                prevBtn.Visibility = Visibility.Hidden;
            if (!((Plants.plants.Count - Plants.ActualIndex) > 6))
            {
                nextBtn.Visibility = Visibility.Hidden;
            }

        }

        private void showImages(int startIndex, int nImages)
        {

            BitmapImage bitmap;

            ImageBrush brush0;
            ImageBrush brush1;
            ImageBrush brush2;
            ImageBrush brush3;
            ImageBrush brush4;
            ImageBrush brush5;

            plant0Block.Text = "";
            plant1Block.Text = "";
            plant2Block.Text = "";
            plant3Block.Text = "";
            plant4Block.Text = "";
            plant5Block.Text = "";

            plant0Button.Background = Brushes.Transparent;
            plant1Button.Background = Brushes.Transparent;
            plant2Button.Background = Brushes.Transparent;
            plant3Button.Background = Brushes.Transparent;
            plant4Button.Background = Brushes.Transparent;
            plant5Button.Background = Brushes.Transparent;

            for (int i = startIndex; i < startIndex + nImages; i++)
            {
                bitmap = loadImage(Plants.plants[i].Image);

                switch (i - startIndex)
                {
                    case 0:
                        brush0 = new ImageBrush();
                        brush0.ImageSource = bitmap;
                        plant0Button.Background = brush0;
                        plant0Block.Text = Plants.plants[i].Name;
                        break;
                    case 1:
                        brush1 = new ImageBrush();
                        brush1.ImageSource = bitmap;
                        plant1Button.Background = brush1;
                        plant1Block.Text = Plants.plants[i].Name;
                        break;
                    case 2:
                        brush2 = new ImageBrush();
                        brush2.ImageSource = bitmap;
                        plant2Button.Background = brush2;
                        plant2Block.Text = Plants.plants[i].Name;
                        break;
                    case 3:
                        brush3 = new ImageBrush();
                        brush3.ImageSource = bitmap;
                        plant3Button.Background = brush3;
                        plant3Block.Text = Plants.plants[i].Name;
                        break;
                    case 4:
                        brush4 = new ImageBrush();
                        brush4.ImageSource = bitmap;
                        plant4Button.Background = brush4;
                        plant4Block.Text = Plants.plants[i].Name;
                        break;
                    case 5:
                        brush5 = new ImageBrush();
                        brush5.ImageSource = bitmap;
                        plant5Button.Background = brush5;
                        plant5Block.Text = Plants.plants[i].Name;
                        break;
                    default:
                        break;
                }
            }

        }

        private BitmapImage loadImage(string Image)
        {
            try
            {
                using (var stream = new FileStream(Image, FileMode.Open))
                {
                    var bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.StreamSource = stream;
                    bitmapImage.EndInit();
                    bitmapImage.Freeze();
                    return bitmapImage;
                }
            }
            catch (NotSupportedException)
            {
                return null;
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


        private void endBtn_Click(object sender, RoutedEventArgs e)
        {
            mwnd.Close();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            mwnd.MainGrid.Children.Clear();
            mwnd.MainGrid.Children.Add(new AddPlantUserControl());
        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Left)
            {
                plant0Block.Text = "hoj";
            }
            if (e.Key == Key.Right)
            {
                plant0Block.Text = "troj";
            }
           
        }

        private void nextBtn_Click(object sender, RoutedEventArgs e)
        {
            Plants.ActualIndex += 6;

            if ((Plants.plants.Count - Plants.ActualIndex) > 6)
            {
                showImages(Plants.ActualIndex, 6);
            }
            else
            {
                showImages(Plants.ActualIndex, Plants.plants.Count - Plants.ActualIndex);
            }

            if (!((Plants.plants.Count - Plants.ActualIndex) > 6))
            {
                nextBtn.Visibility = Visibility.Hidden;
            }

            prevBtn.Visibility = Visibility.Visible;
        }

        private void prevBtn_Click(object sender, RoutedEventArgs e)
        {
            Plants.ActualIndex -= 6;

            if ((Plants.plants.Count - Plants.ActualIndex) > 6)
            {
                showImages(Plants.ActualIndex, 6);
            }
            else
            {
                showImages(Plants.ActualIndex, Plants.plants.Count - Plants.ActualIndex);
            }

            if (!((Plants.ActualIndex) > 0))
            {
                prevBtn.Visibility = Visibility.Hidden;
            }


            nextBtn.Visibility = Visibility.Visible;

        }

        private void plant0Button_Click(object sender, RoutedEventArgs e)
        {
            Plants.ActivePlant = Plants.plants[Plants.ActualIndex];
            mwnd.MainGrid.Children.Clear();
            mwnd.MainGrid.Children.Add(new ShowPlantUserControl());
        }

        private void plant1Button_Click(object sender, RoutedEventArgs e)
        {
            Plants.ActivePlant = Plants.plants[Plants.ActualIndex + 1];
            mwnd.MainGrid.Children.Clear();
            mwnd.MainGrid.Children.Add(new ShowPlantUserControl());
        }

        private void plant2Button_Click(object sender, RoutedEventArgs e)
        {
            Plants.ActivePlant = Plants.plants[Plants.ActualIndex + 2];
            mwnd.MainGrid.Children.Clear();
            mwnd.MainGrid.Children.Add(new ShowPlantUserControl());
        }

        private void plant3Button_Click(object sender, RoutedEventArgs e)
        {
            Plants.ActivePlant = Plants.plants[Plants.ActualIndex + 3];
            mwnd.MainGrid.Children.Clear();
            mwnd.MainGrid.Children.Add(new ShowPlantUserControl());
        }

        private void plant4Button_Click(object sender, RoutedEventArgs e)
        {
            Plants.ActivePlant = Plants.plants[Plants.ActualIndex + 4];
            mwnd.MainGrid.Children.Clear();
            mwnd.MainGrid.Children.Add(new ShowPlantUserControl());
        }

        private void plant5Button_Click(object sender, RoutedEventArgs e)
        {
            Plants.ActivePlant = Plants.plants[Plants.ActualIndex + 5];
            mwnd.MainGrid.Children.Clear();
            mwnd.MainGrid.Children.Add(new ShowPlantUserControl());
        }
    }
}

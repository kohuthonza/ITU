using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AddFlowerUserControl.xaml
    /// </summary>
    public partial class AddPlantUserControl : System.Windows.Controls.UserControl
    {

        private MainWindow mwnd;
        private bool setImage;
        private string srcImage;

        public AddPlantUserControl()
        {
            InitializeComponent();
            SolidColorBrush grayColor = new SolidColorBrush(Color.FromRgb(200, 200, 200));

            this.mwnd = System.Windows.Application.Current.MainWindow as MainWindow;
            descriptionBox.Text = "Popis rostliny";
            descriptionBox.Foreground = grayColor;
            this.setImage = false;


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

            if (!setImage)
            {
                imageAlert.Text = "Přidejte obrázek";
                imageAlert.Foreground = redColor;
                enable = false;
            }
            else
            {
                imageAlert.Text = "Obrázek";
                imageAlert.Foreground = greenColor;
            }

            if (string.IsNullOrWhiteSpace(nameBox.Text))
            {
                nameBox.BorderBrush = redColor;
                enable = false;
                nameAlert.Text = "Kolonka je prázdná";
            }
            else
            {

                try
                {
                    Plants.plants.First(var => (var.Name == nameBox.Text));
                    nameBox.BorderBrush = redColor;
                    enable = false;
                    nameAlert.Text = "Rostlina již existuje";
                }
                catch (InvalidOperationException)
                {
                    nameBox.BorderBrush = greenColor;
                    nameAlert.Text = "";
                }


            }

            if (enable)
            {
                addPlantBtn.IsEnabled = true;
            }
            else
            {
                addPlantBtn.IsEnabled = false;
            }
        }

        private void addPlantBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameBox.Text) && setImage)
            {
                try
                {
                    Plants.plants.First(var => (var.Name == nameBox.Text));
                    System.Windows.MessageBox.Show("Rostlina již existuje!");
                }
                catch (InvalidOperationException)
                {
                    Plant tmp = new Plant();
                    tmp.Name = nameBox.Text;
                    tmp.Podrise = podriseBox.Text;
                    tmp.Oddeleni = oddeleniBox.Text;
                    tmp.Trida = tridaBox.Text;
                    tmp.Rad = radBox.Text;
                    tmp.Celed = celedBox.Text;
                    tmp.Description = descriptionBox.Text;

                    string Folder = "Images";
                    string imageName = Regex.Replace(tmp.Name, @"\s+", "_");
                    imageName = imageName + ".jpg";

                    tmp.Image = Folder + "/" + imageName;

                    
                    Directory.CreateDirectory(Folder);
                    File.Delete(Folder + "/" + imageName);
                    File.Copy(srcImage, Folder + "/" + imageName);

                    Plants.plants.Add(tmp);


                    if((Plants.plants.Count - Plants.ActualIndex) > 6)
                    {
                        Plants.ActualIndex = (Plants.plants.Count / 6)*6;
                    }

                    mwnd.MainGrid.Children.Clear();
                    mwnd.MainGrid.Children.Add(new PlantsUserControl());

                    System.Windows.MessageBox.Show("Rostlina byla přidána");


                }

            }
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            mwnd.MainGrid.Children.Clear();
            mwnd.MainGrid.Children.Add(new PlantsUserControl());
        }

        private void endBtn_Click(object sender, RoutedEventArgs e)
        {
            mwnd.Close();
        }

        private void descriptionBox_GotFocus(object sender, RoutedEventArgs e)
        {
            SolidColorBrush blackColor = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            descriptionBox.Text = "";
            descriptionBox.Foreground = blackColor;
            descriptionBox.GotFocus -= descriptionBox_GotFocus;
        }

        private BitmapImage loadImage(string Image)
        {
            try {
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

        private void imageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog FileDialog = new OpenFileDialog();
            if (FileDialog.ShowDialog() == DialogResult.OK)
            {

                srcImage = FileDialog.FileName;
                BitmapImage bitmap = loadImage(FileDialog.FileName);
                if (bitmap != null)
                {
                    setImage = true;
                    ImageBrush imgbrush = new ImageBrush();
                    imgbrush.ImageSource = bitmap;
                    imageBtn.Background = imgbrush;
                }
                else
                {
                    System.Windows.MessageBox.Show("Obrázek se nepodařilo nahrát");
                }

                


                
            }

        }
    }
}

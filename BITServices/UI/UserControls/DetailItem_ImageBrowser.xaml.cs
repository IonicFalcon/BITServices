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
using BITServices.Control;

namespace BITServices.UI.UserControls
{
    /// <summary>
    /// Interaction logic for DetailItem_ImageBrowser.xaml
    /// </summary>
    public partial class DetailItem_ImageBrowser : System.Windows.Controls.UserControl
    {
        public DetailItem_ImageBrowser()
        {
            InitializeComponent();
            LayoutRoot.DataContext = this;
        }

        public string ImagePath
        {
            get { return (string)GetValue(ImagePathProperty); }
            set { SetValue(ImagePathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImagePath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImagePathProperty =
            DependencyProperty.Register("ImagePath", typeof(string), typeof(DetailItem_ImageBrowser), new PropertyMetadata(string.Empty));

        public Commander ValueChangedCommand
        {
            get { return (Commander)GetValue(ValueChangedCommandProperty); }
            set { SetValue(ValueChangedCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DetailValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueChangedCommandProperty =
            DependencyProperty.Register("ValueChangedCommand", typeof(Commander), typeof(DetailItem_ImageBrowser), new PropertyMetadata(null));

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog imageBrowser = new OpenFileDialog();
            imageBrowser.Title = "Select Profile Picture";
            imageBrowser.Filter = "Images|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (imageBrowser.ShowDialog() == DialogResult.OK)
            {
                ImagePath = imageBrowser.FileName;
            }
        }
    }
}

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

namespace BITServices.UI.UserControls
{
    /// <summary>
    /// Interaction logic for ProfilePic.xaml
    /// </summary>
    public partial class ProfilePic : System.Windows.Controls.UserControl
    {
        
        public ProfilePic()
        {
            InitializeComponent();
            btnProfilePic.DataContext = this;
        }


        public string ProfilePicImagePath
        {
            get { return (string)GetValue(ProfilePicImagePathProperty); }
            set { SetValue(ProfilePicImagePathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProfilePicImage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProfilePicImagePathProperty =
            DependencyProperty.Register("ProfilePicImagePath", typeof(string), typeof(ProfilePic), new PropertyMetadata(string.Empty));

        private void btnProfilePic_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog imageBrowser = new OpenFileDialog();
            imageBrowser.Title = "Select Profile Picture";
            imageBrowser.Filter = "Images|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (imageBrowser.ShowDialog() == DialogResult.OK)
            {
                ProfilePicImagePath = imageBrowser.FileName;
            }
        }
    }
}

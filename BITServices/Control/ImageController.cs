using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace BITServices.Control
{
    class ImageController
    {
        public static byte[] ImagePathToByteArray(string imagePath)
        {
            Image image = Image.FromFile(imagePath);

            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        public static BitmapImage UriToBitmap(string uri)
        {
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(uri, UriKind.Relative);
            bitmapImage.DecodePixelWidth = 50;

            bitmapImage.EndInit();

            return bitmapImage;
        }

        public static BitmapImage ImageArrayToBitmap(byte[] imageData)
        {
            using (MemoryStream memoryStream = new MemoryStream(imageData))
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = memoryStream;
                image.EndInit();
                return image;
            }
        }
    }
}

using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ImageViewer
{
    public class Image
    {
        public string FilePath { get; }
        public BitmapImage BitmapImage { get; } 
        
        public Image(string filePath)
        {
            FilePath = filePath;
            BitmapImage = new BitmapImage();
            BitmapImage.BeginInit();
            BitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            BitmapImage.UriSource = new Uri(filePath);
            BitmapImage.EndInit();
        }
    }
}
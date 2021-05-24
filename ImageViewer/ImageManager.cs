using System.Windows;

namespace ImageViewer
{
    public static class ImageManager
    {
        public static void RenderImage(Image image, MainWindow mainWindow)
        {
            mainWindow.Image.Source = image.BitmapImage;
            mainWindow.SizeToContent = SizeToContent.WidthAndHeight;
            mainWindow.ResizeMode = ResizeMode.NoResize;
            mainWindow.Show();
            mainWindow.UpdateUi();
        }
        
    }
}
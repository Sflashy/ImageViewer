using System.Windows;

namespace ImageViewer
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var image = new Image(e.Args[0]);
            ImageManager.RenderImage(image, new MainWindow(image));
        }
    }
}
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ImageViewer
{

    public partial class MainWindow
    {
        private readonly Image _image;
        public MainWindow(Image image)
        {
            _image = image;
            InitializeComponent();
        }

        #region KeyEvents
        
        private void RemoveFile(object sender, RoutedEventArgs e)
        {
            File.Delete(_image.FilePath);
            ExitApp(null,null);
        }
        private void CopyImage(object sender, RoutedEventArgs e)
        { 
            Clipboard.SetImage(_image.BitmapImage);
        }
        private void UploadFile(object sender, RoutedEventArgs e)
        {
            Process.Start("C:\\Program Files\\ShareX\\ShareX.exe", _image.FilePath);
        }
        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void ExitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void KeyEvents(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Delete) RemoveFile(null,null);
            if(e.Key == Key.Escape) Application.Current.Shutdown();
        }
        public void UpdateUi()
        {
            Application.Current.Dispatcher.Invoke((Action) async delegate
            {
                for (int i = 0; i < 10; i++)
                {
                    Top = (SystemParameters.PrimaryScreenHeight / 2) - (Height / 2);
                    Left = (SystemParameters.PrimaryScreenWidth / 2) - (Width / 2);
                    await Task.Delay(1);
                }

            });
        }
        
        #endregion
    }
}
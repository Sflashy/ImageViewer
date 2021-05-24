using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

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

        private void ShowFileDetails(object sender, MouseEventArgs e)
        {
            var tooltip = new ToolTip();
            tooltip.Placement = PlacementMode.MousePoint;
            tooltip.Opacity = 0.9;
            tooltip.Background = new SolidColorBrush(Color.FromRgb(33, 33, 33));
            tooltip.Foreground = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            tooltip.Content = $"{Path.GetFileName(_image.FilePath)} ({_image.BitmapImage.PixelWidth} x {_image.BitmapImage.PixelHeight}) {BytesToString(new FileInfo(_image.FilePath).Length)}";
            FileDetails.ToolTip = tooltip;
        }
        
        private static string BytesToString(long byteCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" };
            if (byteCount == 0)
                return "0" + suf[0];
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num).ToString() + suf[place];
        }
    }
}
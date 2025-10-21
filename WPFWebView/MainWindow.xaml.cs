using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Web.WebView2.Wpf;

namespace WPFWebView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly WebView2? _webView;
        public MainWindow()
        {
            InitializeComponent();
        }



        private void OnMenuClick(object sender, RoutedEventArgs e)
        {
            if (sender is not Button button)
            {
                return;
            }

            var menu = button.ContextMenu;
            if (menu == null)
            {
                return;
            }

            menu.PlacementTarget = button;
            menu.Placement = PlacementMode.Bottom;
            menu.IsOpen = true;
        }


        private void OnRefresh(object sender, RoutedEventArgs e)
        {
            _webView?.Reload();
        }

        private void OnShowUrl(object sender, RoutedEventArgs e)
        {
            var owner = Window.GetWindow(this);
            var url = _webView?.Source?.AbsoluteUri ?? string.Empty;
            MessageBox.Show(owner ?? Application.Current.MainWindow, url, "當前網址", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void OnDeveloperTools(object sender, RoutedEventArgs e)
        {
            _webView?.CoreWebView2?.OpenDevToolsWindow();
        }

    }
}
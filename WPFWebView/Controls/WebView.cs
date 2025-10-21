using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
using WPFWebView.Scripts;

namespace WPFWebView.Controls
{
    public class WebView : WebView2
    {
        private static readonly Lazy<string?> UserAgent = new Lazy<string?>(LoadUserAgent);

        public WebView()
        {
            CoreWebView2InitializationCompleted += OnCoreWebView2InitializationCompleted;
            Loaded += OnLoaded;
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (CoreWebView2 != null)
            {
                return;
            }

            try
            {
                await EnsureCoreWebView2Async();
            }
            catch
            {
                // Ignore initialization failures here, event handler will handle them.
            }
        }

        private void OnCoreWebView2InitializationCompleted(object? sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            if (!e.IsSuccess || CoreWebView2 == null)
            {
                return;
            }

            var userAgent = UserAgent.Value;
            if (!string.IsNullOrWhiteSpace(userAgent))
            {
                CoreWebView2.Settings.UserAgent = userAgent;
            }

            CoreWebView2.AddScriptToExecuteOnDocumentCreated(CivetMobileScript.Source);
        }

        private static string? LoadUserAgent()
        {
            try
            {
                var basePath = AppContext.BaseDirectory;
                var configPath = Path.Combine(basePath, "appsettings.json");

                if (!File.Exists(configPath))
                {
                    return null;
                }

                using var stream = File.OpenRead(configPath);
                using var document = JsonDocument.Parse(stream);

                if (!document.RootElement.TryGetProperty("WebView", out var webViewElement))
                {
                    return null;
                }

                if (!webViewElement.TryGetProperty("UserAgent", out var userAgentElement))
                {
                    return null;
                }

                var value = userAgentElement.GetString();
                return string.IsNullOrWhiteSpace(value) ? null : value;
            }
            catch
            {
                return null;
            }
        }
    }
}

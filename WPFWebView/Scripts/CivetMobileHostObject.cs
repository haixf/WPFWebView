using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace WPFWebView.Scripts
{
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class CivetMobileHostObject
    {
        private static void Trace(string name, params object?[] args)
        {
            var formattedArgs = string.Join(", ", args.Select(FormatArgument));
            Debug.WriteLine($"civetmobile.{name}({formattedArgs})");
        }

        private static string FormatArgument(object? value)
        {
            return value switch
            {
                null => "null",
                string s => $"\"{s}\"",
                _ => value.ToString() ?? string.Empty
            };
        }

        public void civet_js_alert(object? str) => Trace(nameof(civet_js_alert), str);

        public bool civet_js_confirm(object? str)
        {
            Trace(nameof(civet_js_confirm), str);
            return false;
        }

        public string civet_js_prompt(object? str)
        {
            Trace(nameof(civet_js_prompt), str);
            return string.Empty;
        }

        public void selectMedia(object? type, object? maxCount) => Trace(nameof(selectMedia), type, maxCount);

        public void view_picture(object? urlsStr, object? index) => Trace(nameof(view_picture), urlsStr, index);

        public void showWebGif(object? url) => Trace(nameof(showWebGif), url);

        public void view_video(object? url) => Trace(nameof(view_video), url);

        public void view_public_no_info(object? no, object? type) => Trace(nameof(view_public_no_info), no, type);

        public void activity_intent(object? confName, object? xmlString, object? confId, object? creator, object? peoples) =>
            Trace(nameof(activity_intent), confName, xmlString, confId, creator, peoples);

        public void activity_intent2(object? confName, object? xmlString, object? confId, object? creator, object? peoples) =>
            Trace(nameof(activity_intent2), confName, xmlString, confId, creator, peoples);

        public void show_calendar(object? defDate) => Trace(nameof(show_calendar), defDate);

        public void show_location(object? imgUrl, object? name, object? x, object? y) => Trace(nameof(show_location), imgUrl, name, x, y);

        public void navigation(object? imgUrl, object? name, object? x, object? y) => Trace(nameof(navigation), imgUrl, name, x, y);

        public void find_location() => Trace(nameof(find_location));

        public void scan_qrcode() => Trace(nameof(scan_qrcode));

        public void scan_pcode() => Trace(nameof(scan_pcode));

        public void open_file(object? type, object? url) => Trace(nameof(open_file), type, url);

        public void hideOptionMenu() => Trace(nameof(hideOptionMenu));

        public void showOptionMenu() => Trace(nameof(showOptionMenu));

        public void hideMenuItems(object? str) => Trace(nameof(hideMenuItems), str);

        public void showMenuItems(object? str) => Trace(nameof(showMenuItems), str);

        public void setScreenDirection(object? str) => Trace(nameof(setScreenDirection), str);

        public void closeWindow() => Trace(nameof(closeWindow));

        public void chat(object? strJson) => Trace(nameof(chat), strJson);

        public object? getCurrentUser()
        {
            Trace(nameof(getCurrentUser));
            return null;
        }

        public object? getFriendsInfo()
        {
            Trace(nameof(getFriendsInfo));
            return null;
        }

        public object? getUserInfo(object? strJson)
        {
            Trace(nameof(getUserInfo), strJson);
            return null;
        }

        public object? get_location()
        {
            Trace(nameof(get_location));
            return null;
        }

        public object? getDeviceId()
        {
            Trace(nameof(getDeviceId));
            return null;
        }

        public object? authorizationStatus(object? type)
        {
            Trace(nameof(authorizationStatus), type);
            return null;
        }

        public void shareNews(object? strJson) => Trace(nameof(shareNews), strJson);

        public void open_webview(object? url) => Trace(nameof(open_webview), url);

        public void open_webview2(object? url) => Trace(nameof(open_webview2), url);

        public void open_webview_and_CloseCurrentWindow(object? url) => Trace(nameof(open_webview_and_CloseCurrentWindow), url);

        public void hideNav() => Trace(nameof(hideNav));

        public void hideNavAndStatusBar() => Trace(nameof(hideNavAndStatusBar));

        public void showNav() => Trace(nameof(showNav));

        public void cleanCache() => Trace(nameof(cleanCache));

        public void actionURI(object? actionUri) => Trace(nameof(actionURI), actionUri);

        public void secretPage(object? isSecret) => Trace(nameof(secretPage), isSecret);

        public object? readNFC()
        {
            Trace(nameof(readNFC));
            return null;
        }

        public void watermarkSlanted(object? strJson) => Trace(nameof(watermarkSlanted), strJson);

        public void openAPP(object? urlScheme, object? downloads, object? androidPackageName) =>
            Trace(nameof(openAPP), urlScheme, downloads, androidPackageName);

        public void telSipPhone(object? numbers) => Trace(nameof(telSipPhone), numbers);

        public object? getLanguage()
        {
            Trace(nameof(getLanguage));
            return null;
        }

        public object? getDarkMode()
        {
            Trace(nameof(getDarkMode));
            return null;
        }

        public object? getDeviceinfo()
        {
            Trace(nameof(getDeviceinfo));
            return null;
        }

        public void allowLongPress(object? array) => Trace(nameof(allowLongPress), array);

        public void open_webview_half_screen(object? url) => Trace(nameof(open_webview_half_screen), url);

        public void open_webview_full_blur(object? url) => Trace(nameof(open_webview_full_blur), url);

        public void webview_will_show_alert() => Trace(nameof(webview_will_show_alert));

        public void webview_will_close_alert() => Trace(nameof(webview_will_close_alert));

        public void watermark(object? strJson) => Trace(nameof(watermark), strJson);

        public void screenshotMonitor(object? options) => Trace(nameof(screenshotMonitor), options);

        public object? globalSearch(object? type)
        {
            Trace(nameof(globalSearch), type);
            return null;
        }
    }
}

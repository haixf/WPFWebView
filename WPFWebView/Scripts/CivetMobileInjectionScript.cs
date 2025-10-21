namespace WPFWebView.Scripts
{
    internal static class CivetMobileInjectionScript
    {
        public const string Source = """
(() => {
    if (window.civetmobile) {
        return;
    }

    const host = window.chrome?.webview?.hostObjects?.sync?.civetmobile;
    if (!host) {
        console.warn("civetmobile host object is not available.");
        return;
    }

    window.civetmobile = host;
})();
""";
    }
}

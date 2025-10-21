namespace WPFWebView.Scripts
{
    internal static class CivetMobileScript
    {
        public const string Source = """
(() => {
    if (window.civetmobile) {
        return;
    }

    const warn = (name) => console.warn(`civetmobile.${name} fallback is not available.`);
    const call = (fn, args, name) => {
        if (typeof fn === "function") {
            return fn(...args);
        }

        warn(name);
        return undefined;
    };

    const callFeedback = (actionId, value) => {
        let payload;
        try {
            payload = JSON.stringify({ actionId, value });
        } catch (error) {
            payload = JSON.stringify({ actionId });
        }

        return call(window.feedback, [payload], `${actionId}#feedback`);
    };

    const civetmobile = {
        civet_js_alert: (str) => call(window.alert, [str], "civet_js_alert"),
        civet_js_confirm: (str) => call(window.confirm, [str], "civet_js_confirm"),
        civet_js_prompt: (str) => call(window.prompt, [str], "civet_js_prompt"),
        selectMedia: (type, maxCount) => {
            const isVideo = typeof type === "string" && type.toLowerCase().includes("video");
            return call(window.showMedia, [[], isVideo], "selectMedia");
        },
        view_picture: (urlsStr, index) => warn(`view_picture(${urlsStr}, ${index})`),
        showWebGif: (url) => warn(`showWebGif(${url})`),
        view_video: (url) => callFeedback("view_video", { url }),
        view_public_no_info: (no, type) => warn(`view_public_no_info(${no}, ${type})`),
        activity_intent: (confName, xmlString, confId, creator, peoples) => warn("activity_intent"),
        activity_intent2: (confName, xmlString, confId, creator, peoples) => warn("activity_intent2"),
        show_calendar: (defDate) => call(window.civetSelectedDate, [defDate ?? ""], "show_calendar"),
        show_location: (imgUrl, name, x, y) => warn("show_location"),
        navigation: (imgUrl, name, x, y) => warn("navigation"),
        find_location: () => call(window.civetUploadLocation, ["", "", 0, 0], "find_location"),
        scan_qrcode: () => call(window.show_qrcode, [""], "scan_qrcode"),
        scan_pcode: () => call(window.show_pcode, [""], "scan_pcode"),
        open_file: (type, url) => warn("open_file"),
        hideOptionMenu: () => warn("hideOptionMenu"),
        showOptionMenu: () => warn("showOptionMenu"),
        hideMenuItems: (str) => warn(`hideMenuItems(${str})`),
        showMenuItems: (str) => warn(`showMenuItems(${str})`),
        setScreenDirection: (str) => warn(`setScreenDirection(${str})`),
        closeWindow: () => window.close(),
        chat: (strJson) => warn(`chat(${strJson})`),
        getCurrentUser: () => callFeedback("getCurrentUser", null),
        getFriendsInfo: () => callFeedback("getFriendsInfo", null),
        getUserInfo: (strJson) => callFeedback("getUserInfo", strJson),
        get_location: () => callFeedback("get_location", null),
        getDeviceId: () => callFeedback("getDeviceId", null),
        authorizationStatus: (type) => callFeedback("authorizationStatus", type),
        shareNews: (strJson) => warn(`shareNews(${strJson})`),
        open_webview: (url) => { if (url) { window.open(url, "_blank"); } },
        open_webview2: (url) => { if (url) { window.open(url, "_blank"); } },
        open_webview_and_CloseCurrentWindow: (url) => { if (url) { window.location.href = url; } },
        hideNav: () => warn("hideNav"),
        hideNavAndStatusBar: () => warn("hideNavAndStatusBar"),
        showNav: () => warn("showNav"),
        cleanCache: () => warn("cleanCache"),
        actionURI: (actionUri) => warn(`actionURI(${actionUri})`),
        secretPage: (isSecret) => warn(`secretPage(${isSecret})`),
        readNFC: () => callFeedback("readNFC", null),
        watermarkSlanted: (strJson) => warn(`watermarkSlanted(${strJson})`),
        openAPP: (urlScheme, downloads, androidPackageName) => warn("openAPP"),
        telSipPhone: (numbers) => warn(`telSipPhone(${numbers})`),
        getLanguage: () => callFeedback("getLanguage", null),
        getDarkMode: () => callFeedback("getDarkMode", null),
        getDeviceinfo: () => callFeedback("getDeviceinfo", null),
        allowLongPress: (array) => warn(`allowLongPress(${array})`),
        open_webview_half_screen: (url) => { if (url) { window.open(url, "_blank"); } },
        open_webview_full_blur: (url) => { if (url) { window.open(url, "_blank"); } },
        webview_will_show_alert: () => warn("webview_will_show_alert"),
        webview_will_close_alert: () => warn("webview_will_close_alert"),
        watermark: (strJson) => call(window.cmJs?.watermark, [strJson], "watermark"),
        screenshotMonitor: (options) => callFeedback("registerDetectScreenShot", options ?? null),
        globalSearch: (type) => callFeedback("globalSearch", { type: type ?? "user" })
    };

    window.civetmobile = civetmobile;

    const cm = window.cm || {};
    cm.chooseImage = (obj = {}) => civetmobile.selectMedia(obj.type, obj.maxCount);
    cm.previewImage = (obj = {}) => {
        const url = obj.url ?? (Array.isArray(obj.urls) ? obj.urls[0] : undefined) ?? obj.urlsStr;
        if (typeof url === "string" && url.toLowerCase().endsWith(".gif")) {
            civetmobile.showWebGif(url);
            return;
        }

        civetmobile.view_picture(obj.urlsStr ?? obj.urls ?? "", obj.index ?? 0);
    };
    cm.previewVideo = (obj = {}) => civetmobile.view_video(obj.url ?? "");
    cm.showPublicNoInfo = (obj = {}) => civetmobile.view_public_no_info(obj.no ?? "", obj.type ?? "");
    cm.conference = (obj = {}) => civetmobile.activity_intent(obj.confName, obj.xmlString, obj.confId, obj.creator, obj.peoples);
    cm.calender = (obj = {}) => civetmobile.show_calendar(obj.defDate ?? "");
    cm.showLocation = (obj = {}) => civetmobile.show_location(obj.imgUrl, obj.name, obj.x, obj.y);
    cm.navigation = (obj = {}) => civetmobile.navigation(obj.imgUrl, obj.name, obj.x, obj.y);
    cm.getLocation = () => civetmobile.find_location();
    cm.scanQRCode = () => civetmobile.scan_qrcode();
    cm.scanPCode = () => civetmobile.scan_pcode();
    cm.openFile = (obj = {}) => civetmobile.open_file(obj.type, obj.url);
    cm.hideOptionMenu = () => civetmobile.hideOptionMenu();
    cm.showOptionMenu = () => civetmobile.showOptionMenu();
    cm.hideMenuItems = (obj = {}) => civetmobile.hideMenuItems(obj.str ?? obj.items);
    cm.showMenuItems = (obj = {}) => civetmobile.showMenuItems(obj.str ?? obj.items);
    cm.setScreen = (obj = {}) => civetmobile.setScreenDirection(obj.direction ?? obj.str);
    cm.closeWindow = () => civetmobile.closeWindow();
    cm.chat = (obj = {}) => civetmobile.chat(JSON.stringify(obj));
    cm.getCurrentUser = () => civetmobile.getCurrentUser();
    cm.getFriendsInfo = () => civetmobile.getFriendsInfo();
    cm.getUserInfo = (obj = {}) => civetmobile.getUserInfo(JSON.stringify(obj));
    cm.getGPS = () => civetmobile.get_location();
    cm.getDeviceId = () => civetmobile.getDeviceId();
    cm.appPower = (obj = {}) => civetmobile.authorizationStatus(obj.type);
    cm.shareNews = (obj = {}) => civetmobile.shareNews(JSON.stringify(obj));
    cm.open_webview = (url) => civetmobile.open_webview(typeof url === "string" ? url : url?.url);
    cm.open_webview2 = (url) => civetmobile.open_webview2(typeof url === "string" ? url : url?.url);
    cm.open_webview_and_CloseCurrentWindow = (url) => civetmobile.open_webview_and_CloseCurrentWindow(typeof url === "string" ? url : url?.url);
    cm.hideNav = () => civetmobile.hideNav();
    cm.hideNavAndStatusBar = () => civetmobile.hideNavAndStatusBar();
    cm.showNav = () => civetmobile.showNav();
    cm.cleanCache = () => civetmobile.cleanCache();
    cm.actionURI = (actionUri) => civetmobile.actionURI(actionUri?.actionUri ?? actionUri);
    cm.secretPage = (isSecret) => civetmobile.secretPage(isSecret?.isSecret ?? isSecret);
    cm.readNFC = () => civetmobile.readNFC();
    cm.watermark = (obj = {}) => civetmobile.watermark(JSON.stringify(obj));
    cm.openAPP = (json = {}) => civetmobile.openAPP(json.urlScheme, [json.download_ios, json.download_android, json.download_androidMarket], json.androidPackageName);
    cm.telSipPhone = (arr) => civetmobile.telSipPhone(arr);
    cm.getLanguage = () => civetmobile.getLanguage();
    cm.getDarkMode = () => civetmobile.getDarkMode();
    cm.getDeviceinfo = () => civetmobile.getDeviceinfo();
    cm.allowLongPress = (arr) => civetmobile.allowLongPress(arr);
    cm.open_webview_half_screen = (url) => civetmobile.open_webview_half_screen(typeof url === "string" ? url : url?.url);
    cm.open_webview_full_blur = (url) => civetmobile.open_webview_full_blur(typeof url === "string" ? url : url?.url);
    cm.webview_will_show_alert = () => civetmobile.webview_will_show_alert();
    cm.webview_will_close_alert = () => civetmobile.webview_will_close_alert();
    cm.watermarkSlanted = (show, density, angle, withHorizontal) => civetmobile.watermarkSlanted(JSON.stringify({ show, density, angle, withHorizontal }));
    cm.screenshotMonitor = (obj = {}) => civetmobile.screenshotMonitor(obj);
    cm.globalSearch = (obj = {}) => civetmobile.globalSearch(obj.type);

    window.cm = cm;
})();
""";
    }
}

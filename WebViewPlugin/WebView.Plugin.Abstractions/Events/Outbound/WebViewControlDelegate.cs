﻿using WebView.Plugin.Abstractions.Enumerations;
using Xamarin.Forms;

namespace WebView.Plugin.Abstractions.Events.Outbound
{
    public class WebViewControlDelegate
    {

        public static string InjectedFunction
        {
            get
            {
                switch (Device.OS)
                {
                    case TargetPlatform.Android:
                        return "function csharp(data){bridge.invokeAction(data);}";
                    case TargetPlatform.iOS:
                        return "function csharp(data){window.webkit.messageHandlers.invokeAction.postMessage(data);}";
                    default:
                        return "function csharp(data){window.external.notify(data);}";
                }
            }
        }

        public delegate void PerformNavigationDelegate(FormsWebView sender, string uri, WebViewContentType contentType, string baseUri = "");
        public static event PerformNavigationDelegate OnNavigationRequestedFromUser;

        public delegate string ObtainUriDelegate(FormsWebView sender);
        public static event ObtainUriDelegate ObtainUri;

        public delegate void InjectJavascriptDelegate(FormsWebView sender, string js);
        public static event InjectJavascriptDelegate OnInjectJavascriptRequest;

        public void PerformNavigation(FormsWebView sender, string uri, WebViewContentType contentType, string baseUri = "")
        {
            OnNavigationRequestedFromUser?.Invoke(sender, uri, contentType, baseUri);
        }

        internal string GetUri(FormsWebView sender)
        {
            return ObtainUri != null ? ObtainUri(sender) : "";
        }

        internal void InjectJavascript(FormsWebView sender, string js)
        {
            OnInjectJavascriptRequest?.Invoke(sender, js);
        }
    }
}
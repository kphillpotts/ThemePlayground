using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThemePlayground.Styles;
using Foundation;
using UIKit;
using Xamarin.Forms;
using ThemePlayground.iOS.Themes;

[assembly: Dependency(typeof(IOSThemeManager))]
namespace ThemePlayground.iOS.Themes
{
    public class IOSThemeManager : IPlatformThemeManager
    {
        public void ChangeTheme(string themeName)
        {
            switch (themeName.ToLower())
            {
                case "light":
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.Default, false);
                        UIApplication.SharedApplication.StatusBarHidden = false;
                        GetCurrentViewController().SetNeedsStatusBarAppearanceUpdate();
                    });
                    break;
                case "dark":
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.BlackTranslucent, false);
                        UIApplication.SharedApplication.StatusBarHidden = true;
                        GetCurrentViewController().SetNeedsStatusBarAppearanceUpdate();
                    });
                    break;
                case "rose":
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, false);
                        UIApplication.SharedApplication.StatusBarHidden = false;
                        GetCurrentViewController().SetNeedsStatusBarAppearanceUpdate();
                    });
                    break;
                default:
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.Default, false);
                        UIApplication.SharedApplication.StatusBarHidden = false;
                        GetCurrentViewController().SetNeedsStatusBarAppearanceUpdate();
                    });
                    break;
            }
        }

        UIViewController GetCurrentViewController()
        {
            var window = UIApplication.SharedApplication.KeyWindow;
            var vc = window.RootViewController;
            while (vc.PresentedViewController != null)
                vc = vc.PresentedViewController;
            return vc;
        }
    }
}
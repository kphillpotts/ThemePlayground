using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ThemePlayground.Styles;
using Xamarin.Forms;
using ThemePlayground.Droid.Themes;
using Plugin.CurrentActivity;

[assembly: Dependency(typeof(AndroidThemeManager))]
namespace ThemePlayground.Droid.Themes
{
    public class AndroidThemeManager : IPlatformThemeManager
    {
        public void ChangeTheme(string themeName)
        {
            switch (themeName.ToLower())
            {
                case "light":
                    if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            var currentWindow = GetCurrentWindow();
                            currentWindow.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.LightStatusBar;
                            currentWindow.SetStatusBarColor(Android.Graphics.Color.LightGreen);
                        });
                    }
                    break;
                case "dark":
                    if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            var currentWindow = GetCurrentWindow();
                            currentWindow.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.Fullscreen;
                            //currentWindow.SetStatusBarColor(Android.Graphics.Color.DarkCyan);
                            //..ActionBar.
                            
                        });
                    }
                    break;
                case "rose":
                    if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            var currentWindow = GetCurrentWindow();
                            currentWindow.DecorView.SystemUiVisibility = 0;
                            currentWindow.SetStatusBarColor(Android.Graphics.Color.DarkCyan);
                        });
                    }
                    break;
                default:
                    //Device.BeginInvokeOnMainThread(() =>
                    //{
                    //    UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.Default, false);
                    //    UIApplication.SharedApplication.StatusBarHidden = false;
                    //    GetCurrentViewController().SetNeedsStatusBarAppearanceUpdate();
                    //});
                    break;
            }
        }

        Window GetCurrentWindow()
        {
            var window = CrossCurrentActivity.Current.Activity.Window;

            // clear FLAG_TRANSLUCENT_STATUS flag:
            window.ClearFlags(WindowManagerFlags.TranslucentStatus);

            // add FLAG_DRAWS_SYSTEM_BAR_BACKGROUNDS flag to the window
            window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);

            return window;
        }
    }
}
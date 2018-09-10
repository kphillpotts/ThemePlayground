using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ThemePlayground
{
    public static class Settings
    {
        public static string Theme
        {
            get
            {
                if (Application.Current.Properties.ContainsKey("Theme"))
                {
                    string theme = Application.Current.Properties["Theme"].ToString();
                    return theme;
                }
                return "Base";
            }
            set
            {
                Application.Current.Properties["Theme"] = value.ToString();
                Application.Current.SavePropertiesAsync();
            }
        }
    }
}

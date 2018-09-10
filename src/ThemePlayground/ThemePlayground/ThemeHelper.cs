using System;
using ThemePlayground.Styles;
using Xamarin.Forms;

namespace ThemePlayground
{
    public static class ThemeHelper
    {
        public static string CurrentTheme;

        public static void ChangeTheme(string theme)
        {
            // don't change to the same theme
            if (theme == CurrentTheme) return;

            // clear all the resources
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.Clear();
            ResourceDictionary applicationResourceDictionary = Application.Current.Resources;
            ResourceDictionary newTheme = null;


            switch (theme.ToLowerInvariant())
            {
                case "light":
                    newTheme = new LightTheme();
                    break;
                case "dark":
                    newTheme = new DarkTheme();
                    break;
                case "rose":
                    newTheme = new RoseTheme();
                    break;
                default:
                    newTheme = new BaseStyleResources();
                    break;
            }

            foreach (var merged in newTheme.MergedDictionaries)
            {
                applicationResourceDictionary.MergedDictionaries.Add(merged);
            }

            ManuallyCopyThemes(newTheme, applicationResourceDictionary);

            CurrentTheme = theme;
        }

        private static void ManuallyCopyThemes(ResourceDictionary fromResource, ResourceDictionary toResource)
        {
            foreach (var item in fromResource.Keys)
            {
                toResource[item] = fromResource[item];
            }
        }
    }
}
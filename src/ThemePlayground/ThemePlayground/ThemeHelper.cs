using System;
using ThemePlayground.Styles;
using Xamarin.Forms;

namespace ThemePlayground
{
    internal static class ThemeHelper
    {
        internal static void ChangeTheme(string themeName)
        {
            // clear all the resources
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.Clear();
            ResourceDictionary applicationResourceDictionary = Application.Current.Resources;
            ResourceDictionary newTheme = null;


            switch (themeName.ToLowerInvariant())
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
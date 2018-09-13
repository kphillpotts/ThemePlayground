using System;
using System.Collections.Generic;
using System.Text;

namespace ThemePlayground.Styles
{
    public interface IPlatformThemeManager
    {
        void ChangeTheme(string themeName);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThemePlayground.Styles
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RoseTheme : ResourceDictionary
    {
		public RoseTheme()
		{
			InitializeComponent ();
		}
	}
}
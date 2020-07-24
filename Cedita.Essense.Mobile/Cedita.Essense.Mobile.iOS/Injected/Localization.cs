using System.Diagnostics;
using System.Globalization;
using Cedita.Essense.Mobile.Interfaces;
using Cedita.Essense.Mobile.UWP.Injected;
using Xamarin.Forms;

[assembly: Dependency(typeof(Localize))]
namespace Cedita.Essense.Mobile.UWP.Injected
{
    public class Localize : ILocalize
    {
        public void SetLocale()
        {
            Debug.WriteLine("culture: " + CultureInfo.CurrentCulture.Name);
            Debug.WriteLine("ui:      " + CultureInfo.CurrentUICulture.Name);
        }

        public string GetCurrent() =>  CultureInfo.CurrentUICulture.Name;
        
    }
}


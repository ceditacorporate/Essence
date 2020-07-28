using Xamarin.Forms;
using Cedita.Essense.Mobile.Xamarin.UWP.Injected;
using Cedita.Essense.Mobile.Xamarin.Interfaces;

[assembly: Dependency(typeof(Localize))]
namespace Cedita.Essense.Mobile.Xamarin.UWP.Injected
{
    public class Localize : ILocalize
    {
        public void SetLocale()
        {
        }

        public string GetCurrent() => Windows.System.UserProfile.GlobalizationPreferences.Languages[0];
    }
}


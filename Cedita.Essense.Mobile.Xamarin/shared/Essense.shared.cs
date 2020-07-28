using System.Globalization;
using Cedita.Essense.Mobile.Xamarin.Converters;
using Cedita.Essense.Mobile.Xamarin.Interfaces;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Cedita.Essense.Mobile
{
    public class Essense : Application
    {
        public static Size ScreenSize { get; private set; }
        public void Init()
        {
            Application.Current.Resources = new ResourceDictionary();
            Application.Current.Resources.Add("ColorConverter", new ColorConverter());
            Application.Current.Resources.Add("DateToStringConverter ", new DateToStringConverter());
            Application.Current.Resources.Add("DoubleToStringConverter ", new DoubleToStringConverter());
            Application.Current.Resources.Add("IntToStringConverter ", new IntToStringConverter());
            Application.Current.Resources.Add("LanguageConverter ", new LanguageConverter());
            Application.Current.Resources.Add("NegateBooleanConverter ", new NegateBooleanConverter());
            Application.Current.Resources.Add("WidthSizeConverter ", new WidthSizeConverter());
            Application.Current.Resources.Add("HeightSizeConverter ", new HeightSizeConverter());
            Application.Current.Resources.Add("ValueProgressBarConverter ", new VisibleConverter());
            Application.Current.Resources.Add("VisibleImageConverter ", new VisibleImageConverter());

            ScreenSize = new Size(DeviceDisplay.MainDisplayInfo.Width, DeviceDisplay.MainDisplayInfo.Height);

            var netLanguage = DependencyService.Get<ILocalize>().GetCurrent();
            Plugin.Cedita.Essense.Mobile.Xamarin.shared.Langs.Culture = new CultureInfo(netLanguage);
            DependencyService.Get<ILocalize>().SetLocale();

            DependencyService.Register<IUserSettings>();
            DependencyService.Register<IFileservice>();
        }
    }
}

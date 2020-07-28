using System;
using System.Globalization;
using Xamarin.Forms;

namespace Cedita.Essense.Mobile.Xamarin.Converters
{
    public class LanguageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var prop = (string)parameter;
            if (string.IsNullOrEmpty(prop))
                return string.Empty;

            var rv = Plugin.Cedita.Essense.Mobile.Xamarin.shared.Langs.ResourceManager.GetString(prop);

            return rv;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

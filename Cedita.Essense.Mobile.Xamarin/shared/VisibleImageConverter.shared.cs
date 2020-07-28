using System;
using System.Globalization;
using Xamarin.Forms;

namespace Cedita.Essense.Mobile.Xamarin.Converters
{
    public class VisibleImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var prop = (string)value;
            var param = (string)parameter;

            return string.IsNullOrEmpty(prop) ? param : prop;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Globalization;
using Xamarin.Forms;

namespace Cedita.Essense.Mobile.Converters
{
    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var prop = (bool)value;

            return prop ? Color.LightGreen : Color.PaleVioletRed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

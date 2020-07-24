using System;
using Xamarin.Forms;

namespace Cedita.Essense.Mobile.Converters
{
    public class DoubleToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var val = (double)value;
            return val.ToString("C");
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (string)value;
        }
    }
}

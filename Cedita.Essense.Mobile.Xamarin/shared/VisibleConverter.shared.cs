using System;
using System.Globalization;
using Xamarin.Forms;

namespace Cedita.Essense.Mobile.Xamarin.Converters
{
    public class VisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var prop = (string)parameter;
            return string.IsNullOrEmpty(prop) ? false : true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

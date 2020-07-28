using System;
using Xamarin.Forms;

namespace Cedita.Essense.Mobile.Xamarin.Converters
{
    public class DateToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            
            var dt = DateTime.Parse((string)parameter);
            return dt.ToString("dd MMM yyyy");
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Globalization;
using Xamarin.Forms;

namespace SqliteTest.UI.Converters
{
    public class SearchColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string)) return value;
            var text = (string)value;
            return (string.IsNullOrEmpty(text) || (text.Length < 3)) ? Color.Red : Color.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}

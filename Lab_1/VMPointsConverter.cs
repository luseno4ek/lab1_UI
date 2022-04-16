using System;
using System.Windows;
using System.Windows.Data;
using System.Globalization;

namespace Lab_1
{
    public class VMPointsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                string val = value as string;
                float result = float.Parse(val);
                return result;
            }
            catch (Exception error)
            {
                MessageBox.Show($"Unexpected error: {error.Message}.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return "Point: ERROR";
            }
        }
    }
}

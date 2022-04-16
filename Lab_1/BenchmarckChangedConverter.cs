using System;
using System.Windows;
using System.Windows.Data;
using System.Globalization;

namespace Lab_1
{
    public class BenchmarckChangedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                bool val = (bool)value;
                if (val)
                {
                    return "Current benchmark has been changed! \nPlease, save it before closing the app.";
                }
                else
                {
                    return "";
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"Unexpected error: {error.Message}.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return "ERROR";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return false;
        }
    }
}

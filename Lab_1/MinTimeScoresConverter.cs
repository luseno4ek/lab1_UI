using System;
using System.Windows;
using System.Windows.Data;
using System.Globalization;

namespace Lab_1
{
    public class MinTimeScoresConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                string result = "VMTime statistics:\n\n";
                double[] val = (double[])value;
                if (val[0] == -1)
                {
                    return result + "Benchmark is empty!";
                }
                return result + $"Min VML_HA relative time: {val[0]:0.00000000} \n" +
                    $"Min VML_EP relative time: {val[1]:0.00000000}";
            }
            catch (Exception error)
            {
                MessageBox.Show($"Unexpected error: {error.Message}.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return "Max WML_HA Coef: ERROR";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return 0;
        }
    }
}

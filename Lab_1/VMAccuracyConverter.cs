using System;
using System.Windows;
using System.Windows.Data;
using System.Globalization;
using Class_Library;

namespace Lab_1
{
    public class VMAccuracyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value != null)
                {
                    VMAccuracy val = (VMAccuracy)value;
                    return $"Information about selected VMAccuracy:\nMax difference point: {val.MaxDiffPoint:0.00},\n Max difference value: {val.MaxDifference:0.000000000}," +
                        $"\n VML_HA value: {val.ValuesInMaxDiffPoint[0]:0.000000000}, \n VML_EP value: {val.ValuesInMaxDiffPoint[1]:0.000000000}";
                }
                return "";
            }
            catch (Exception error)
            {
                MessageBox.Show($"Unexpected error: {error.Message}.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return "VML_HA value: ERROR, VML_EP value: ERROR";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new VMTime();
        }
    }
}

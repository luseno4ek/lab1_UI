using System;
using System.Windows;
using System.Windows.Data;
using System.Globalization;
using Class_Library;

namespace Lab_1
{
    public class VMfunctionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value != null)
                {
                    switch(value)
                    {
                        case 0:
                            return VMf.vmdExp;
                        case 1:
                            return VMf.vmsExp;
                        case 2:
                            return VMf.vmdErf;
                        case 3:
                            return VMf.vmsErf;
                    }
                }
                return "";
            }
            catch (Exception error)
            {
                MessageBox.Show($"Unexpected error: {error.Message}.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return "Function: ERROR";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value != null)
                {
                    switch (value)
                    {
                        case 0:
                            return VMf.vmdExp;
                        case 1:
                            return VMf.vmsExp;
                        case 2:
                            return VMf.vmdErf;
                        case 3:
                            return VMf.vmsErf;
                    }
                }
                return "";
            }
            catch (Exception error)
            {
                MessageBox.Show($"Unexpected error: {error.Message}.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return "Function: ERROR";
            }
        }
    }
}

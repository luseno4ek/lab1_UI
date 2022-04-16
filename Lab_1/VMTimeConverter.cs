﻿using System;
using System.Windows;
using System.Windows.Data;
using System.Globalization;
using Class_Library;

namespace Lab_1
{
    public class VMTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if(value != null)
                {
                    VMTime val = (VMTime)value;
                    return $"Information about selected VMTime: \n VML_HA relative time: {val.TimeScore[0]:0.0000},\n " +
                        $"VML_EP relative time: {val.TimeScore[1]:0.0000}";
                }
                return "";
            }
            catch (Exception error)
            {
                MessageBox.Show($"Unexpected error: {error.Message}.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return "WML_HA Coef: ERROR, WML_EP Coef: ERROR";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new VMTime();
        }
    }
}

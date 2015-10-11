﻿namespace BattleField2.WpfGUI.Converter
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    public class GridMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int result = (10 - (int.Parse(value.ToString()))) * 25;
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null; // Not needed
        }
    }
}
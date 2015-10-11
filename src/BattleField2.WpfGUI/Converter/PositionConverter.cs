namespace BattleField2.WpfGUI.Converter
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    public class PositionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int result = (int.Parse(value.ToString())) * 50;
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null; // Not needed at the moment
        }
    }
}
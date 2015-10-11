namespace BattleField2.WpfGUI.Converter
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    /// <summary>
    /// This is an converter, passing values for positioning Cells in the XAML Canvas of the View.
    /// </summary>
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
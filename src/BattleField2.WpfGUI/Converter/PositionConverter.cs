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
        /// <summary>
        /// Convertion method thaking info prom the current cell 
        /// and transforming it in input for positioning the cell template in the XAML view canvas
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int result = (int.Parse(value.ToString())) * 50;
            return result;
        }

        /// <summary>
        /// Convertion back method thaking info prom the XAML view canvas
        /// and returning it to the cell.
        /// Not used at the moment, but implemented as part of IValueConverter interface
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null; // Not needed at the moment
        }
    }
}
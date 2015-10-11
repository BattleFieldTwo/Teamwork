namespace BattleField2.WpfGUI.Converter
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    /// <summary>
    /// This is an converter, passing values for defining the margin of the Grid element
    /// in which all the Cells are placed in the XAML View.
    /// </summary>
    public class GridMarginConverter : IValueConverter
    {
        /// <summary>
        /// Convertion method taking info prom the current cells collection
        /// and transforming it in input for positioning the whole cell field in the XAML view canvas
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int result = (11 - (int.Parse(value.ToString()))) * 30;
            return result;
        }

        /// <summary>
        /// Convertion back method taking info prom the XAML view canvas
        /// and returning it the number of cells.
        /// Not used at the moment, but implemented as part of IValueConverter interface
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null; // Not needed at the moment
        }
    }
}

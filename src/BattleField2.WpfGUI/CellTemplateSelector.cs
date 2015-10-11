namespace BattleField2.WpfGUI
{
    using System.Windows;
    using System.Windows.Controls;

    using BattleField2.WpfGUI.CellDecorator;
    /// <summary>
    /// Namespace that holds the WPF GUI Logic and classes.
    /// </summary>
    [System.Runtime.CompilerServices.CompilerGenerated]
    class NamespaceDoc
    {

    }

    /// <summary>
    /// This is template selector class, determing which specific Cell template
    /// is passed to the XAML Canvas of the View.
    /// </summary>
    class CellTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Data template for representing Mine one in XAML view
        /// </summary>
        public DataTemplate SelectorMineOneTemplate { get; set; }

        /// <summary>
        /// Data template for representing Mine two in XAML view
        /// </summary>
        public DataTemplate SelectorMineTwoTemplate { get; set; }

        /// <summary>
        /// Data template for representing Mine three in XAML view
        /// </summary>
        public DataTemplate SelectorMineThreeTemplate { get; set; }

        /// <summary>
        /// Data template for representing Mine four in XAML view
        /// </summary>
        public DataTemplate SelectorMineFourTemplate { get; set; }

        /// <summary>
        /// Data template for representing Mine five in XAML view
        /// </summary>
        public DataTemplate SelectorMineFiveTemplate { get; set; }

        /// <summary>
        /// Data template for representing Empty cell in XAML view
        /// </summary>
        public DataTemplate SelectorEmptyCellTemplate { get; set; }

        /// <summary>
        /// Data template for representing Detonated cell in XAML view
        /// </summary>
        public DataTemplate SelectorDetonatedCellTemplate { get; set; }

        /// <summary>
        /// Data template method, based on the type of the input cell
        /// </summary>
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            ObservableCellDecorator o = item as ObservableCellDecorator;
            switch (o.CellToBeDecorated.GetType().Name)
            {
                case "MineLevelOneUpgrade":
                    return SelectorMineOneTemplate;
                case "MineLevelTwoUpgrade":
                    return SelectorMineTwoTemplate;
                case "MineLevelThreeUpgrade":
                    return SelectorMineThreeTemplate;
                case "MineLevelFourUpgrade":
                    return SelectorMineFourTemplate;
                case "MineLevelFiveUpgrade":
                    return SelectorMineFiveTemplate;
                case "EmptyCell":
                    return SelectorEmptyCellTemplate;
                case "DetonatedCell":
                    return SelectorDetonatedCellTemplate;
                default: return null;
            }
        }
    }
}


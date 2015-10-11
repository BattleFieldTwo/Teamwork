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
        public DataTemplate SelectorMineOneTemplate { get; set; }

        public DataTemplate SelectorMineTwoTemplate { get; set; }

        public DataTemplate SelectorMineThreeTemplate { get; set; }

        public DataTemplate SelectorMineFourTemplate { get; set; }

        public DataTemplate SelectorMineFiveTemplate { get; set; }

        public DataTemplate SelectorEmptyCellTemplate { get; set; }

        public DataTemplate SelectorDetonatedCellTemplate { get; set; }

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


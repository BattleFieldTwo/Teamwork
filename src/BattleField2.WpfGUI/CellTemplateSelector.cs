namespace BattleField2.WpfGUI
{
    using System.Windows;
    using System.Windows.Controls;

    using BattleField2.WpfGUI.CellDecorator;

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


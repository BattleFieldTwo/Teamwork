
using System.Windows;
using System.Windows.Controls;
using BattleField2.Models.Cells;

namespace BattleField2.WpfGUI
{
    class CellTemplateSelector : DataTemplateSelector
    {
        public DataTemplate MineFiveTemplate { get; set; }

        public DataTemplate MineFourTemplate { get; set; }

        public DataTemplate MineThreeTemplate { get; set; }

        public DataTemplate MineTwoTemplate { get; set; }

        public DataTemplate MineOneTemplate { get; set; }

        public DataTemplate EmptyCellTemplate { get; set; }

        public DataTemplate DetonatedCellTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            Cell o = item as Cell;
            switch (o.GetType().Name)
            {
                case "MineLevelOneUpgrade":
                    return MineOneTemplate;
                case "MineLevelTwoUpgrade":
                    return MineTwoTemplate;
                case "MineLevelThreeUpgrade":
                    return MineThreeTemplate;
                case "MineLevelFourUpgrade":
                    return MineFourTemplate;
                case "MineLevelFiveUpgrade":
                    return MineFiveTemplate;
                case "EmptyCell":
                    return EmptyCellTemplate;
                case "DetonatedCell":
                    return DetonatedCellTemplate;
                default: return null;
            }
        }
    }
}


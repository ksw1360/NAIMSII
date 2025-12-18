using System.Windows;

namespace NAIMS2.Common.ViewModels
{
    internal class CollectList : UIElement
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public System.Windows.HorizontalAlignment HorizontalAlignment { get; set; }
        public VerticalAlignment VerticalAlignment { get; set; }
        public Thickness Margin { get; set; }
        public CollectListContentViewModel DataContext { get; internal set; }
    }
}
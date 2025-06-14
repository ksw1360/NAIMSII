using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Label = System.Windows.Controls.Label;

namespace NAIMS2.Common.Views
{
    /// <summary>
    /// CollectDataPopup.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CollectDataPopup : Window
    {
        public CollectDataPopup()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LabelAlignment(this);
        }

        private void LabelAlignment(DependencyObject parent)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is Label label)
                {
                    label.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
                    label.VerticalContentAlignment = VerticalAlignment.Center;
                    label.FontFamily = new System.Windows.Media.FontFamily("pretendard");
                    label.FontSize = 14;
                }
                LabelAlignment(child);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}

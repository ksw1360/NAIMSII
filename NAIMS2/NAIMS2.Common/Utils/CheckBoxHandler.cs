using System.Windows.Controls;
using System.Windows.Media;
using CheckBox = System.Windows.Controls.CheckBox;
using Color = System.Windows.Media.Color;

namespace NAIMS2.Common.Utils
{
    public static class CheckBoxHandler
    {
        public static void UpdateCheckBox(CheckBox checkBox)
        {
            if (checkBox.IsChecked == true)
            {
                checkBox.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255)); // 흰색
            }
            else
            {
                checkBox.IsEnabled = false;
                checkBox.IsChecked = false;
            }
        }
    }
}

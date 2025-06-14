using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TextBox = System.Windows.Controls.TextBox;

namespace NAIMS2.Common
{
    public static class PlaceholderBehavior
    {
        public static readonly DependencyProperty PlaceholderTextProperty =
            DependencyProperty.RegisterAttached(
                "PlaceholderText",
                typeof(string),
                typeof(PlaceholderBehavior),
                new PropertyMetadata(string.Empty, OnPlaceholderTextChanged));

        public static string GetPlaceholderText(DependencyObject obj)
        {
            return (string)obj.GetValue(PlaceholderTextProperty);
        }

        public static void SetPlaceholderText(DependencyObject obj, string value)
        {
            obj.SetValue(PlaceholderTextProperty, value);
        }

        private static void OnPlaceholderTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBox textBox)
            {
                // 초기 플레이스홀더 설정
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    textBox.Text = GetPlaceholderText(textBox);
                    textBox.Foreground = new SolidColorBrush(Colors.Gray);
                }

                // 이벤트 핸들러 추가
                textBox.GotFocus += (s, _) =>
                {
                    if (textBox.Text == GetPlaceholderText(textBox))
                    {
                        textBox.Text = string.Empty;
                        textBox.Foreground = new SolidColorBrush(Colors.Black);
                    }
                };

                textBox.LostFocus += (s, _) =>
                {
                    if (string.IsNullOrEmpty(textBox.Text))
                    {
                        textBox.Text = GetPlaceholderText(textBox);
                        textBox.Foreground = new SolidColorBrush(Colors.Gray);
                    }
                };
            }
        }
    }
}
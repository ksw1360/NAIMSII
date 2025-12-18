using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace NAIMS2.Common.Views
{
    /// <summary>
    /// MediaPopup.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MediaPopup : Window
    {
        public MediaPopup()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (CollectDataRadioButton.IsChecked == true)
            {
                DeviceFileList deviceFileList = new DeviceFileList();
                deviceFileList.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                deviceFileList.ShowDialog();
            }
            else if (AnalysisResultRadioButton.IsChecked == true)
            {
                CollectDataPopup collectDataPopup = new CollectDataPopup();
                collectDataPopup.WindowStartupLocation= WindowStartupLocation.CenterScreen;
                collectDataPopup.ShowDialog();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CollectDataRadioButton.IsChecked = true;
        }

        private void CollectDataStackPanel_Click(object sender, MouseButtonEventArgs e)
        {
            CollectDataRadioButton.IsChecked = true;
        }

        private void CollectDataLabel_Click(object sender, MouseButtonEventArgs e)
        {
            CollectDataRadioButton.IsChecked = true;
        }

        private void AnalysisResultStackPanel_Click(object sender, MouseButtonEventArgs e)
        {
            AnalysisResultRadioButton.IsChecked = true;
        }

        private void AnalysisResultLabel_Click(object sender, MouseButtonEventArgs e)
        {
            AnalysisResultRadioButton.IsChecked = true;
        }
    }

    public class BooleanToOpacityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (bool)value ? 1.0 : 0.0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

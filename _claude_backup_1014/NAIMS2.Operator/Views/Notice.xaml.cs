using NAIMS2.Common.Models;
using NAIMS2.Operator.ViewModels;
using System.Windows.Controls;
using System.Windows;
using UserControl = System.Windows.Controls.UserControl;

namespace NAIMS2.Common.Views
{
    public partial class Notice : UserControl
    {
        public Notice()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this)?.Close();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = new NoticeModelViewModel();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //저장

        }
    }
}
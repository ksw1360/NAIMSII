using NAIMS2.Operator.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserControl = System.Windows.Controls.UserControl;

namespace NAIMS2.Common.Views
{
    /// <summary>
    /// MissionMngtWave.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MissionMngtWave : UserControl
    {
        public MissionMngtWave()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = new WavAnalMngtViewModel();
        }

        private void OneWeekButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OneMonthButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

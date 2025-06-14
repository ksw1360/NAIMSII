using NAIMS2.Common.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Threading;
using NAIMS2.Operator.ViewModels;
using NAIMS2.Common.Utils;
using System;

namespace NAIMS2.Common.Views
{
    public partial class MissionMngDashboard : System.Windows.Controls.UserControl
    {
        private DispatcherTimer timer;
        public MissionMngDashboard()
        {
            InitializeComponent();
            this.DataContext = new MissionMngDashboardViewModel();

            // 시간 업데이트 타이머
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
            //NAIMS2.Common.Utils.LabelAlignmentProcessor.ApplyLabelAlignmentLeft(this);
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            tb_time.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}

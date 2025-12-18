// NAIMS2.Common.Views 프로젝트 내 MainWindows.xaml.cs
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using NAIMS2.Common.Utils;
using NAIMS2.Common.ViewModels;

namespace NAIMS2.Common.Views
{
    public partial class MainWindows : Window
    {
        protected DispatcherTimer timer;

        public MainWindows()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel(); // ViewModel 설정
            this.WindowState = WindowState.Maximized;

            // 시간 업데이트 타이머
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();

            DateTimeTextBlock.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            // CheckBox 핸들러 (UI 로직이므로 코드 비하인드에 유지 가능)
            CheckBoxHandler.UpdateCheckBox(cb_network);
            CheckBoxHandler.UpdateCheckBox(cb_drive);
            CheckBoxHandler.UpdateCheckBox(cb_direct);

            btn_alarm.Click += Button_Click_1;
            btn_chat.Click += Button_Click;
        }

        protected virtual void Timer_Tick(object sender, EventArgs e)
        {
            DateTimeTextBlock.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        protected virtual void MainTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        protected virtual void BodyTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        protected virtual void Button_Click_1(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("공지사항 창을 여는 기능은 아직 구현되지 않았습니다.", "공지사항");
        }

        protected virtual void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void cb_drive_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MediaPopup popup = new MediaPopup();
                popup.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                popup.ShowDialog();
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
            }
        }
    }
}

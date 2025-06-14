// NAIMS2.Common.Views 프로젝트 내 MainWindows.xaml.cs
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using NAIMS2.Common.Utils;
using NAIMS2.Operator.ViewModels;
using Button = System.Windows.Controls.Button;
using Orientation = System.Windows.Controls.Orientation;

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
            // Window 객체 동적 생성
            Window popupWindow = new Window
            {
                Title = "공지사항",
                Width = 800,
                Height = 800,
                WindowStyle = WindowStyle.ToolWindow, // 최소화/최대화 버튼 제거
                ResizeMode = ResizeMode.NoResize, // 크기 조정 비활성화
                WindowStartupLocation = WindowStartupLocation.CenterOwner, // 부모 창 중앙
                Owner = this // 메인 윈도우를 부모로 설정
            };

            // StackPanel 생성 (Notice와 버튼을 수직으로 배치)
            StackPanel panel = new StackPanel
            {
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Stretch
            };

            // Notice UserControl 인스턴스 생성
            var noticeControl = new Notice();
            panel.Children.Add(noticeControl); // StackPanel에 Notice 추가

            // 닫기 버튼 생성
            Button closeButton = new Button
            {
                Content = "닫기",
                Width = 80,
                Height = 30,
                Margin = new Thickness(10),
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center
            };

            closeButton.Click += (s, e) =>
            {
                popupWindow.DialogResult = true; // DialogResult 설정
                popupWindow.Close(); // 창 닫기
            };

            // 추가 버튼 생성 (예: "확인" 버튼)
            Button confirmButton = new Button
            {
                Content = "확인",
                Width = 80,
                Height = 30,
                Margin = new Thickness(10),
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center
            };

            confirmButton.Click += (s, e) =>
            {
                popupWindow.DialogResult = true; // DialogResult 설정 (필요에 따라 false로 변경 가능)
                popupWindow.Close(); // 창 닫기
            };

            // 버튼들을 StackPanel에 추가
            StackPanel buttonPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal, // 버튼을 수평으로 배치
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                Margin = new Thickness(0, 10, 0, 10)
            };

            buttonPanel.Children.Add(confirmButton);
            buttonPanel.Children.Add(closeButton);

            panel.Children.Add(buttonPanel); // 버튼 패널을 StackPanel에 추가

            // Window의 Content로 StackPanel 설정
            popupWindow.Content = panel;

            // 팝업창 띄우기 (모달)
            popupWindow.ShowDialog();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected virtual void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("메신저 창을 여는 기능은 아직 구현되지 않았습니다.", "메신저");
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

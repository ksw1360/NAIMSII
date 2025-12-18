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
using System.Windows.Threading;
using DevExpress.Xpf.Core.Native;
using NAIMS2.Common.Utils;
using MessageBox = System.Windows.MessageBox;

namespace NAIMS2.Common.Views
{
    public partial class MainInherited : Window
    {
        protected DispatcherTimer timer;
        protected TextBlock DateTimeTextBlockProperty;
        protected TabControl DateTimeTextBlockproperty;
        protected Button btn_alarmProperty;
        protected Button btn_chatProperty;
        protected TabControl BodyTabControlProperty;

        private CollectList collectList;

        public MainInherited()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();

            DateTimeTextBlock.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            UpdateBodyTabControl(0);

            btn_alarm.Click += Button_Click_1;
            btn_chat.Click += Button_Click;

            CheckBoxHandler.UpdateCheckBox(cb_network);
            CheckBoxHandler.UpdateCheckBox(cb_drive);
            CheckBoxHandler.UpdateCheckBox(cb_direct);
        }

        protected virtual void Timer_Tick(object sender, EventArgs e)
        {
            DateTimeTextBlock.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        protected virtual void MainTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HandleTabSelection(MainTabControl, UpdateBodyTabControl);
        }

        protected virtual void BodyTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HandleTabSelection(BodyTabControl, UpdateSubTabControl);
        }

        private void HandleTabSelection(TabControl tabControl, Action<int> updateAction)
        {
            if (tabControl.SelectedIndex >= 0)
            {
                updateAction(tabControl.SelectedIndex);
            }
        }

        private void SetCommonControlProperties(Control control, string name, double width, HorizontalAlignment horizontalAlignment)
        {
            control.Name = name;
            control.Width = width;
            control.Height = double.NaN;
            control.HorizontalAlignment = horizontalAlignment;
            control.VerticalAlignment = VerticalAlignment.Stretch;
            control.Margin = new Thickness(0, 0, 0, 0);
            control.Visibility = Visibility.Visible;
        }

        private void UpdateSubTabControl(int selectedIndex)
        {
            try
            {
                var tabItem = BodyTabControl.SelectedItem as TabItem;
                if (tabItem == null)
                {
                    Logger.Warn("TabItem이 null입니다. BodyTabControl의 선택된 탭을 확인하세요.");
                    return;
                }

                switch (selectedIndex)
                {
                    case 0:
                        tabItem.Content = null;
                        tabItem.IsEnabled = true;
                        tabItem.Visibility = Visibility.Visible;

                        var userControl = new UserControl();
                        SetCommonControlProperties(userControl, "ReceiveSendDataControl", double.NaN, HorizontalAlignment.Stretch);
                        userControl.Content = "Test";
                        tabItem.Content = userControl;

                        Logger.Info($"동적 UserControl이 탭 {selectedIndex}에 성공적으로 추가되었습니다.");
                        break;

                    case 1:
                        if (tabItem.Content != null)
                            return;
                        tabItem.Content = null;

                        collectList ??= new CollectList();
                        SetCommonControlProperties(collectList, "CollectList", 1500, HorizontalAlignment.Left);
                        tabItem.Content = collectList;

                        Logger.Info($"CollectList UserControl이 탭 {selectedIndex}에 성공적으로 추가되었습니다.");
                        break;

                    default:
                        Logger.Warn($"지원되지 않는 탭 인덱스: {selectedIndex}");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"하단 탭 업데이트 중 오류 발생: {ex.Message}\nStackTrace: {ex.StackTrace}", "오류", MessageBoxButton.OK, MessageBoxImage.Error);
                Logger.Error($"하단 탭 업데이트 중 오류: {ex.Message}\nStackTrace: {ex.StackTrace}");
            }
        }

        private TabItem CreateTabItem(string name, string header, System.Drawing.Brush background = null)
        {
            return new TabItem
            {
                Name = name,
                Header = header,
                Background = background ?? new SolidColorBrush(System.Drawing.Color.FromArgb(60, 60, 60, 60))
            };
        }

        protected virtual void UpdateBodyTabControl(int tabIndex)
        {
            BodyTabControl.Items.Clear();

            if (tabIndex == 0)
            {
                BodyTabControl.Items.Add(CreateTabItem("TabItem1" + tabIndex, "송수신 자료"));
                BodyTabControl.Items.Add(CreateTabItem("TabItem2" + tabIndex, "수집/배포 자료"));
            }
            else if (tabIndex == 1)
            {
                BodyTabControl.Items.Add(CreateTabItem("TabItem3" + tabIndex, "음향정보 관리/분석"));
            }
        }

        protected virtual void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("알람 창을 여는 기능은 아직 구현되지 않았습니다.", "알람");
        }

        protected virtual void Button_Click(object sender, RoutedEventArgs e)
        {
            //About about = new About();
            //about.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //about.ShowDialog();
            System.Windows.Application.Current.Shutdown();
        }


        private void cb_drive_Click(object sender, RoutedEventArgs e)
        {
            DeviceFileList list = new DeviceFileList();
            list.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            list.ShowDialog();
        }
    }
}

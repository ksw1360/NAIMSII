using NAIMS2.Common.Views;
using NAIMS2.Operator.Models;
using System.Collections.ObjectModel; // ObservableCollection을 위해
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel;       // INotifyPropertyChanged를 위해
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media; // ToList() 사용을 위해


namespace NAIMS2.Common.ViewModels
{
    // 각 탭 아이템에 대한 ViewModel (헤더와 콘텐츠를 포함)
    public class TabItemViewModel : INotifyPropertyChanged
    {
        private string _header;
        public string Header // 탭 헤더에 바인딩될 속성
        {
            get => _header;
            set
            {
                if (_header != value)
                {
                    _header = value;
                    OnPropertyChanged(nameof(Header));
                }
            }
        }

        private object _contentViewModel;
        public object ContentViewModel // 탭 콘텐츠에 바인딩될 ViewModel (다양한 타입 가능)
        {
            get => _contentViewModel;
            set
            {
                if (_contentViewModel != value)
                {
                    _contentViewModel = value;
                    OnPropertyChanged(nameof(ContentViewModel));
                }
            }
        }

        public TabItemViewModel(string header, object contentViewModel)
        {
            Header = header;
            ContentViewModel = contentViewModel;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // 탭 콘텐츠에 들어갈 내용의 예시 ViewModel (필요에 따라 더 많이 정의 가능)
    public partial class DashboardContentViewModel : INotifyPropertyChanged
    {
        private string _dashboardData = string.Empty;
        public string DashboardData
        {
            get => _dashboardData;
            set
            {
                if (_dashboardData != value)
                {
                    _dashboardData = value;
                    OnPropertyChanged(nameof(DashboardData));
                }
            }
        }

        public DashboardContentViewModel(string data)
        {
            DashboardData = data;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public partial class SettingsContentViewModel : INotifyPropertyChanged
    {
        private string _settingName;
        public string SettingName
        {
            get => _settingName;
            set
            {
                if (_settingName != value)
                {
                    _settingName = value;
                    OnPropertyChanged(nameof(SettingName));
                }
            }
        }

        public SettingsContentViewModel(string name)
        {
            SettingName = name;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


    // 메인 화면 전체의 ViewModel
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<TabItemViewModel> _topTabItems;
        public ObservableCollection<TabItemViewModel> TopTabItems
        {
            get => _topTabItems;
            set
            {
                if (_topTabItems != value)
                {
                    _topTabItems = value;
                    OnPropertyChanged(nameof(TopTabItems));
                }
            }
        }

        private ObservableCollection<TabItemViewModel> _bodyTabItems;
        public ObservableCollection<TabItemViewModel> BodyTabItems // 하단 탭을 위한 컬렉션
        {
            get => _bodyTabItems;
            set
            {
                if (_bodyTabItems != value)
                {
                    _bodyTabItems = value;
                    OnPropertyChanged(nameof(BodyTabItems));
                }
            }
        }

        private int _selectedTopTabIndex;
        public int SelectedTopTabIndex // 상단 탭의 선택된 인덱스
        {
            get => _selectedTopTabIndex;
            set
            {
                if (_selectedTopTabIndex != value)
                {
                    _selectedTopTabIndex = value;
                    OnPropertyChanged(nameof(SelectedTopTabIndex));
                    UpdateBodyTabs(value); // 선택된 상단 탭에 따라 하단 탭 업데이트
                }
            }
        }

        private ObservableCollection<Dummy> _tempData;
        public ObservableCollection<Dummy> TempData
        {
            get => _tempData;
            set
            {
                _tempData = value;
                OnPropertyChanged(nameof(TempData));
            }
        }

        public MainViewModel()
        {
            TopTabItems = new ObservableCollection<TabItemViewModel>();
            BodyTabItems = new ObservableCollection<TabItemViewModel>(); // 초기화

            // 상단 탭 아이템을 추가합니다.
            TopTabItems.Add(new TabItemViewModel("자료통제 관리/분석", null));
            TopTabItems.Add(new TabItemViewModel("음향정보 관리/분석", null));

            UpdateBodyTabs(0);
        }

        private void UpdateBodyTabs(int topTabIndex)
        {
            BodyTabItems.Clear();

            switch (topTabIndex)
            {
                case 0:
                    // 새로운 Grid 인스턴스 생성
                    var grid = new Grid();
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.7, GridUnitType.Star) });
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(5, GridUnitType.Pixel) });
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(300) });

                    // 새로운 SideBar 인스턴스 생성
                    var sideBar = new SideBar
                    {
                        Width = double.NaN,
                        Height = double.NaN,
                        HorizontalAlignment = System.Windows.HorizontalAlignment.Right,
                        VerticalAlignment = VerticalAlignment.Stretch,
                        Margin = new Thickness(5)
                    };
                    Grid.SetColumn(sideBar, 2);
                    grid.Children.Add(sideBar);

                    // 새로운 GridSplitter 인스턴스 생성
                    var gridSplitter = new GridSplitter
                    {
                        Width = 5,
                        Background = System.Windows.Media.Brushes.Gray,
                        HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch,
                        VerticalAlignment = VerticalAlignment.Stretch
                    };
                    Grid.SetColumn(gridSplitter, 1);
                    grid.Children.Add(gridSplitter);

                    // 새로운 CollectList 인스턴스 생성
                    var collectList = new CollectList
                    {
                        Width = double.NaN,
                        Height = double.NaN,
                        HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Stretch,
                        Margin = new Thickness(5)
                    };
                    // CollectList의 DataContext를 CollectListContentViewModel로 설정
                    collectList.DataContext = new CollectListContentViewModel();
                    Grid.SetColumn(collectList, 0);
                    grid.Children.Add(collectList);

                    // 새로운 TabItemViewModel 추가
                    BodyTabItems.Add(new TabItemViewModel("수집/배포 자료", grid));
                    break;
                case 1:
                    BodyTabItems.Add(new TabItemViewModel("음향정보 관리", new SettingsContentViewModel("음향정보 관리 설정")));
                    BodyTabItems.Add(new TabItemViewModel("음향정보 분석", new SettingsContentViewModel("음향정보 분석 설정")));
                    break;
                default:
                    break;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    internal class SideBar : UIElement
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public object HorizontalAlignment { get; set; }
        public VerticalAlignment VerticalAlignment { get; set; }
        public Thickness Margin { get; set; }
    }
};
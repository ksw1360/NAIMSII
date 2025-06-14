using DevExpress.Xpf.Docking;
using NAIMS2.Common.Views;
using NAIMS2.Common.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
//using NAIMS2.Operator.Views; // ToList() 사용을 위해


namespace NAIMS2.Operator.ViewModels
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
    public class DashboardContentViewModel : INotifyPropertyChanged
    {
        private string _dashboardData;
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class SettingsContentViewModel : INotifyPropertyChanged
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

        private ObservableCollection<cbsignalDummy> _CbsignalDummies;
        public ObservableCollection<cbsignalDummy> CbsignalDummies
        {
            get => _CbsignalDummies;
            set
            {
                _CbsignalDummies = value;
                OnPropertyChanged(nameof(CbsignalDummies));
            }
        }

        ObservableCollection<cbcollectDummy> _CbcollectDummies;
        public ObservableCollection<cbcollectDummy> CbcollectDummies
        {
            get => _CbcollectDummies;
            set
            {
                _CbcollectDummies = value;
                OnPropertyChanged(nameof(CbcollectDummies));
            }
        }

        ObservableCollection<WavAnalMngtDummy> _WavAnalMngtDummy;
        public ObservableCollection<WavAnalMngtDummy> WavAnalMngtDummy
        {
            get => _WavAnalMngtDummy;
            set
            {
                _WavAnalMngtDummy = value;
                OnPropertyChanged(nameof(WavAnalMngtDummy));
            }
        }

        ObservableCollection<NoticeModel> _NoticeModel;
        public ObservableCollection<NoticeModel> NoticeModel
        {
            get => _NoticeModel;
            set
            {
                _NoticeModel = value;
                OnPropertyChanged(nameof(NoticeModel));
            }
        }

        public MainViewModel()
        {
            TopTabItems = new ObservableCollection<TabItemViewModel>();
            BodyTabItems = new ObservableCollection<TabItemViewModel>(); // 초기화

            // 상단 탭 아이템을 추가합니다.
            TopTabItems.Add(new TabItemViewModel("원음분석", null));
            TopTabItems.Add(new TabItemViewModel("정밀분석", null));
            
            TopTabItems.Add(new TabItemViewModel("임무관리", null));
            TopTabItems.Add(new TabItemViewModel("자료/DB 관리", null));
            TopTabItems.Add(new TabItemViewModel("시스템관리", null));

            UpdateBodyTabs(0);
        }

        private void UpdateBodyTabs(int topTabIndex)
        {
            BodyTabItems.Clear();

            switch (topTabIndex)
            {
                case 0:
                    // 새로운 Grid 인스턴스 생성
                    /*
                    var grid = new Grid();
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.7, GridUnitType.Star) });
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(5, GridUnitType.Pixel) });
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(300) });

                    // 새로운 SideBar 인스턴스 생성
                    var sideBar = new SideBar
                    {
                        Width = double.NaN,
                        Height = double.NaN,
                        HorizontalAlignment = HorizontalAlignment.Right,
                        VerticalAlignment = VerticalAlignment.Stretch,
                        Margin = new Thickness(5)
                    };
                    Grid.SetColumn(sideBar, 2);
                    grid.Children.Add(sideBar);

                    // 새로운 GridSplitter 인스턴스 생성
                    var gridSplitter = new GridSplitter
                    {
                        Width = 5,
                        Background = Brushes.Gray,
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        VerticalAlignment = VerticalAlignment.Stretch
                    };
                    Grid.SetColumn(gridSplitter, 1);
                    grid.Children.Add(gridSplitter);

                    // 새로운 CollectList 인스턴스 생성
                    var collectList = new CollectList
                    {
                        Width = double.NaN,
                        Height = double.NaN,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Stretch,
                        Margin = new Thickness(5)
                    };
                    // CollectList의 DataContext를 CollectListContentViewModel로 설정
                    collectList.DataContext = new CollectListContentViewModel();
                    Grid.SetColumn(collectList, 0);
                    grid.Children.Add(collectList);
                    */
                    // 새로운 TabItemViewModel 추가
                    BodyTabItems.Add(new TabItemViewModel("수동소나 원음분석", null));
                    BodyTabItems.Add(new TabItemViewModel("능동소나 원음분석", null));
                    break;
                case 1:
                    break;
                case 2:
                    var missionMngDashboard = new MissionMngDashboard();

                    // 새로운 Grid 인스턴스 생성
                    var grid2 = new Grid();
                    grid2.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.7, GridUnitType.Star) });
                    grid2.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(5, GridUnitType.Pixel) });
                    grid2.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(300) });

                    // 새로운 SideBar 인스턴스 생성
                    var sideBar2 = new SideBar
                    {
                        Width = double.NaN,
                        Height = double.NaN,
                        HorizontalAlignment = HorizontalAlignment.Right,
                        VerticalAlignment = VerticalAlignment.Stretch,
                        Margin = new Thickness(5)
                    };
                    Grid.SetColumn(sideBar2, 2);
                    grid2.Children.Add(sideBar2);

                    // 새로운 GridSplitter 인스턴스 생성
                    var gridSplitter2 = new GridSplitter
                    {
                        Width = 5,
                        Background = Brushes.Gray,
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        VerticalAlignment = VerticalAlignment.Stretch
                    };
                    Grid.SetColumn(gridSplitter2, 1);
                    grid2.Children.Add(gridSplitter2);
                    
                    var missionMngtWave = new MissionMngtWave
                    {
                        Width= double.NaN,
                        Height= double.NaN,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,
                        Margin= new Thickness(5)
                    };
                    grid2.Children.Add(missionMngtWave);
                    BodyTabItems.Add(new TabItemViewModel("임무관리(보조모니터)", missionMngDashboard));
                    BodyTabItems.Add(new TabItemViewModel("임무관리(주모니터)", grid2));
                    break;
                case 3:
                    BodyTabItems.Add(new TabItemViewModel("표적식별DB관리", new SettingsContentViewModel("자료/DB 관리")));
                    BodyTabItems.Add(new TabItemViewModel("기준식별DB관리", new SettingsContentViewModel("자료/DB 관리")));
                    BodyTabItems.Add(new TabItemViewModel("기준식별DB적용", new SettingsContentViewModel("자료/DB 관리")));
                    BodyTabItems.Add(new TabItemViewModel("기준식별DB배포", new SettingsContentViewModel("자료/DB 관리")));
                    break;
                case 4:
                    BodyTabItems.Add(new TabItemViewModel("자체고장진단", new SettingsContentViewModel("시스템관리")));
                    BodyTabItems.Add(new TabItemViewModel("녹화저장관리", new SettingsContentViewModel("시스템관리")));
                    BodyTabItems.Add(new TabItemViewModel("녹음저정관리", new SettingsContentViewModel("시스템관리")));
                    BodyTabItems.Add(new TabItemViewModel("운용이력관리", new SettingsContentViewModel("시스템관리")));
                    BodyTabItems.Add(new TabItemViewModel("운용계정관리", new SettingsContentViewModel("시스템관리")));
                    BodyTabItems.Add(new TabItemViewModel("오디오 제어", new SettingsContentViewModel("시스템관리")));
                    BodyTabItems.Add(new TabItemViewModel("환경설정", new SettingsContentViewModel("시스템관리")));
                    BodyTabItems.Add(new TabItemViewModel("도움말", new SettingsContentViewModel("시스템관리")));
                    BodyTabItems.Add(new TabItemViewModel("로그아웃", new SettingsContentViewModel("시스템관리")));
                    
                    var exit = new Exit()
                    {
                        Width = 80,
                        Height = 45,
                        Background = Brushes.Gray,
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        VerticalAlignment = VerticalAlignment.Stretch
                    };                    
                    BodyTabItems.Add(new TabItemViewModel("시스템 종료", exit));
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
};
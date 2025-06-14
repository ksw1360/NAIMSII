1. 네임스페이스 NAIMS2.Operator.ViewModels 의 MainViewModel.cs Class File 확인
2. 상단 TabControl TabItem 추가 구문
   public MainViewModel()
{
    TopTabItems = new ObservableCollection<TabItemViewModel>();
    BodyTabItems = new ObservableCollection<TabItemViewModel>(); // 초기화

    // 상단 탭 아이템을 추가합니다.
    TopTabItems.Add(new TabItemViewModel("자료통제 관리/분석", null));
    TopTabItems.Add(new TabItemViewModel("음향정보 관리/분석", null));
    
    UpdateBodyTabs(0);
}

상단 Tab 추가 구문
TopTabItems.Add(new TabItemViewModel("송수신 자료", null));

3. 하단 BodyControl TabItem 추가 구문
private void UpdateBodyTabs(int topTabIndex)
{
    // 기존 하단 탭을 모두 지웁니다.
    BodyTabItems.Clear();

    // 선택된 상단 탭에 따라 다른 하단 탭을 추가합니다.
    switch (topTabIndex)
    {
        case 0:
            UserControl userControl = new UserControl()
            {
                Content = "송수신자료.",
                Width = 500,
                Height = 500,
                Background = System.Windows.Media.Brushes.LightGray,
                VerticalAlignment = System.Windows.VerticalAlignment.Stretch,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch
            };
            BodyTabItems.Add(new TabItemViewModel("송수신자료", userControl));          <= 동적 UserControl 추가
            BodyTabItems.Add(new TabItemViewModel("수집/배포 자료", new CollectList()   <== 사용자가 만든 UserControl 추가
            {
                Width = double.NaN,
                Height = double.NaN,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch,
                VerticalAlignment = System.Windows.VerticalAlignment.Stretch
            }));
            break;
        case 1:
            BodyTabItems.Add(new TabItemViewModel("음향정보 관리", null));
            BodyTabItems.Add(new TabItemViewModel("음향정보 분석", null));
            break;
        default:
            // 정의되지 않은 탭 인덱스 처리
            break;
    }
}
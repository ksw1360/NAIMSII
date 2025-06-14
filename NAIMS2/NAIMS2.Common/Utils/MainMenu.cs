using System;
using System.Windows.Controls;
using System.Windows.Media;
using Brushes = System.Windows.Media.Brushes;
using Color = System.Windows.Media.Color;
using FontFamily = System.Windows.Media.FontFamily;

namespace NAIMS2.Common.Utils
{
    internal class MainMenu
    {
        private readonly Menu menu = new Menu();

        public MainMenu(string[][] List)
        {
            if (List == null || List.Length == 0 || List.Any(item => item == null || item.Length == 0))
            {
                throw new ArgumentException("Menu items list cannot be null, empty, or contain null/empty sub-arrays.", nameof(List));
            }

            // 메뉴 항목 생성
            foreach (string[] menuData in List)
            {
                // 첫 번째 요소는 메뉴명
                string menuName = menuData[0];
                MenuItem menuItem = new MenuItem { Header = menuName };

                // 입력 배열에 하위 메뉴가 있으면 추가 (DB 로드 전 임시 처리)
                for (int i = 1; i < menuData.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(menuData[i]))
                    {
                        menuItem.Items.Add(new MenuItem { Header = menuData[i] });
                    }
                }

                menu.Items.Add(menuItem);
            }

            // 메뉴 스타일 설정
            menu.Background = new SolidColorBrush(Color.FromArgb(61, 61, 61, 61));
            menu.Foreground = Brushes.White;

            // 메뉴 항목 및 하위 항목 스타일 설정
            ApplyMenuItemStyles(menu.Items);
        }

        private void ApplyMenuItemStyles(ItemCollection items)
        {
            foreach (MenuItem item in items)
            {
                item.Background = new SolidColorBrush(Color.FromArgb(61, 61, 61, 61));
                item.Foreground = Brushes.White;
                item.BorderThickness = new System.Windows.Thickness(0);
                item.Padding = new System.Windows.Thickness(5);
                item.FontSize = 14;
                item.FontFamily = new FontFamily("Pretendard");

                // 하위 메뉴 항목에도 스타일 적용
                if (item.Items.Count > 0)
                {
                    ApplyMenuItemStyles(item.Items);
                }
            }
        }

        public Menu GetMenu()
        {
            return menu;
        }

        // DB에서 메뉴 항목 로드 시 사용할 메서드 (예시)
        public void LoadMenuFromDatabase(/* DB 연결 매개변수 */)
        {
            // DB에서 메뉴 데이터를 가져오는 로직 (예: SQL 쿼리)
            // 예시: List<string[]> menuData = FetchMenuFromDB();
            // foreach (var menuData in menuData)
            // {
            //     MenuItem menuItem = new MenuItem { Header = menuData[0] };
            //     for (int i = 1; i < menuData.Length; i++)
            //     {
            //         menuItem.Items.Add(new MenuItem { Header = menuData[i] });
            //     }
            //     menu.Items.Add(menuItem);
            // }
            // ApplyMenuItemStyles(menu.Items);
        }
    }
}
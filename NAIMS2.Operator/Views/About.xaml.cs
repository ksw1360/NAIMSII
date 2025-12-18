using System;
using System.IO;
using System.Windows;

namespace NAIMS2.Common.Views
{
    /// <summary>
    /// About.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class About : Window
    {
        public About()
        {
            InitializeComponent();
            LoadHelpContent();
        }

        private void LoadHelpContent()
        {
            // 방법 1: 프로젝트에 포함된 HTML 파일 로드
            // HTML 파일을 프로젝트에 추가하고 '빌드 작업'을 '콘텐츠(Content)'로,
            // '출력 디렉터리로 복사'를 '항상 복사' 또는 '변경된 내용만 복사'로 설정하세요.
            try
            {
                // 실행 파일이 있는 폴더를 기준으로 help.html 파일의 경로를 설정합니다.
                // 예를 들어, help.html 파일이 실행 파일과 같은 폴더에 있다면 아래와 같이 사용합니다.
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string helpFilePath = Path.Combine(baseDirectory, "help.html"); // 또는 "HtmlHelp/help.html" 등 상대 경로

                if (File.Exists(helpFilePath))
                {
                    HelpWebBrowser.Navigate(new Uri(helpFilePath));
                }
                else
                {
                    HelpWebBrowser.NavigateToString("<html><body><h1>도움말 파일을 찾을 수 없습니다.</h1></body></html>");
                }
            }
            catch (Exception ex)
            {
                HelpWebBrowser.NavigateToString($"<html><body><h1>오류 발생:</h1><p>{ex.Message}</p></body></html>");
            }
        }

        private void SimpleButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}

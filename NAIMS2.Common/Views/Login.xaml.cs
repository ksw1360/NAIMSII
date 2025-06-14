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
using TextBox = System.Windows.Controls.TextBox;
using UserControl = System.Windows.Controls.UserControl;

namespace NAIMS2.Common.Views
{
    /// <summary>
    /// Login.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Login : Window
    {
        private const string IdPlaceholder = "사용자 ID를 입력하세요";
        private const string pwPlaceholder = "사용자 PW를 입력하세요";
        public Login()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void tb_id_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tb_id.Text = string.Empty;
            //common:PlaceholderBehavior.PlaceholderText="사용자 ID를 입력하세요"
        }

        private void IdTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text == IdPlaceholder)
            {
                textBox.Text = string.Empty;
                textBox.Foreground = new SolidColorBrush(Colors.Black); // 입력 텍스트는 검정색
            }
        }

        private void IdTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = IdPlaceholder;
                textBox.Foreground = new SolidColorBrush(Colors.Gray); // 플레이스홀더 회색
            }
        }

        private void pwTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text == pwPlaceholder)
            {
                textBox.Text = string.Empty;
                textBox.Foreground = new SolidColorBrush(Colors.Black); // 입력 텍스트는 검정색
            }
        }

        private void pwTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = pwPlaceholder;
                textBox.Foreground = new SolidColorBrush(Colors.Gray); // 플레이스홀더 회색
            }
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            //로그인작업 계정이 안나와서 임시로 로그인
            if (tb_id.Text=="Admin" && tb_pw.Text=="1234")
            {
                MainWindows mainWindows = new MainWindows();
                mainWindows.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                mainWindows.ShowDialog();
            }
        }
    }
}

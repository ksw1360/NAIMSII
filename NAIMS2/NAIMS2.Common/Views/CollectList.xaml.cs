using log4net.Repository.Hierarchy;
using NAIMS2.Common.Utils;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Color = System.Windows.Media.Color;
using Logger = NAIMS2.Common.Utils.Logger;
using UserControl = System.Windows.Controls.UserControl;

namespace NAIMS2.Common.Views
{
    /// <summary>
    /// CollectList.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CollectList : UserControl
    {
        public CollectList()
        {
            InitializeComponent();

            Loaded += async (s, e) => await InitalizeDataAsync();
        }

        private async Task InitalizeDataAsync()
        {
            try
            {
                // DataGrid 가상화 활성화 (코드로 확인)
                CollectionDataGrid.EnableRowVirtualization = true;
                DistributionDataGrid.EnableRowVirtualization = true;
                CollectionDataGrid.EnableColumnVirtualization = true;
                DistributionDataGrid.EnableColumnVirtualization = true;

                // 초기 날짜 설정
                EndDatePicker.SelectedDate = DateTime.Today;
                StartDatePicker.SelectedDate = DateTime.Today.AddDays(-7); // 기본 1주일

                //DataGrid 설정
                DataGridInit();
            }
            catch (Exception ex)
            {
                Logger.Error("Error", ex);
            }
        }

        private void DataGridInit()
        {
            int rowCount = DistributionDataGrid.Items.Count;
            int colCount = DistributionDataGrid.Columns.Count;

            var columns = DistributionDataGrid.Columns.FirstOrDefault(c => c.Header.ToString() == "컬럼명");

            if (rowCount > 0 && colCount > 0)
            {
                columns.CellStyle = new Style(typeof(DataGridCell))
                {
                    Setters =
                    {
                        new Setter(DataGridCell.BackgroundProperty, new SolidColorBrush(Color.FromArgb(51,51,51,51))),
                        new Setter(DataGridCell.ForegroundProperty, new SolidColorBrush(Color.FromArgb(255, 255, 255, 255))),
                        new Setter(DataGridCell.HorizontalContentAlignmentProperty, true),
                    }
                };
            }
        }

        private void OneWeekButton_Click(object sender, RoutedEventArgs e)
        {
            EndDatePicker.SelectedDate = DateTime.Today;
            StartDatePicker.SelectedDate = DateTime.Today.AddDays(-7);
        }

        private void OneMonthButton_Click(object sender, RoutedEventArgs e)
        {
            EndDatePicker.SelectedDate = DateTime.Today;
            StartDatePicker.SelectedDate = DateTime.Today.AddMonths(-1);
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            // 검색 로직 (예: 키워드와 날짜를 사용해 데이터 필터링)
            System.Windows.MessageBox.Show("검색 버튼 클릭됨!");
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            KeywordTextBox.Text = string.Empty;
            StartDatePicker.SelectedDate = DateTime.Today.AddDays(-7);
            EndDatePicker.SelectedDate = DateTime.Today;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DeviceFileList driveList = new DeviceFileList();
            driveList.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            driveList.ShowDialog();
        }
    }
}

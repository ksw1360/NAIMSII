using DevExpress.Xpf.Core.FilteringUI;
using NAIMS2.Common.Utils;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using Brushes = System.Windows.Media.Brushes;
using MessageBox = System.Windows.MessageBox;

namespace NAIMS2.Common.Views
{
    public partial class DeviceFileList : Window
    {
        //private UsbWatch usbWatch;
        private bool bFine = false;
        private DispatcherTimer _timer;
        public ObservableCollection<FileItem> FileList { get; set; } // 데이터 컬렉션

        public DeviceFileList()
        {
            InitializeComponent();
            FileList = new ObservableCollection<FileItem>();
            datagrid1.ItemsSource = FileList; // DataGrid의 ItemSource 설정

            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(1);
            _timer.Tick += _timer_Tick;
            _timer.Start();
        }

        private void _timer_Tick(object? sender, EventArgs e)
        {
            try
            {
                DriveInfo[] diArray = DriveInfo.GetDrives();
                DriveInfo selectedDrive = null;
                bool bFine = false;

                foreach (DriveInfo di in diArray)
                {
                    Logger.Info($"Drive: {di.Name}, Type: {di.DriveType}, Ready: {di.IsReady}");
                    if (di.IsReady && di.DriveType == DriveType.Removable && !di.Name.StartsWith("C:\\", StringComparison.OrdinalIgnoreCase))
                    {
                        bFine = true;
                        selectedDrive = di;
                        break;
                    }
                }

                StatusTextBlock.Content = bFine ? selectedDrive.Name + "연결되었습니다." : "연결된 USB가 없습니다.";
                if (bFine)
                    _timer.Stop();
                if (bFine && selectedDrive != null)
                {
                    LoadFolderContents(selectedDrive);
                    // Set foreground color for tr_fList items
                    foreach (object item in tr_fList.Items)
                    {
                        if (tr_fList.ItemContainerGenerator.ContainerFromItem(item) is ListBoxItem listBoxItem)
                        {
                            listBoxItem.Foreground = Brushes.White;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, ex);
            }
        }

        // Implementation of LoadFolderContents to list folders
        private void LoadFolderContents(DriveInfo drive)
        {
            try
            {
                // Clear existing items in tr_fList
                tr_fList.Items.Clear();

                // Get the root directory of the drive
                DirectoryInfo rootDir = drive.RootDirectory;

                // Get all directories in the root
                DirectoryInfo[] folders = rootDir.GetDirectories();

                // Add each folder name to tr_fList
                string[] folderlist = new string[folders.Length];
                int i = 0;
                foreach (DirectoryInfo folder in folders)
                {
                    if (folder.Name.Contains("System")) continue;
                    var filename = Directory.GetFiles(drive + folder.Name);
                    for (int k = 0; k < filename.Length; k++)
                    {
                        tr_fList.Items.Add(filename[k]);
                    }
                    i++;
                }

                //LoadFiles(drive, folderlist);
                Logger.Info($"Loaded {folders.Length} folders from drive {drive.Name}");
            }
            catch (UnauthorizedAccessException ex)
            {
                Logger.Error($"Access denied to {drive.Name}: {ex.Message}", ex);
                StatusTextBlock.Content = "폴더에 접근할 수 없습니다.";
            }
            catch (IOException ex)
            {
                Logger.Error($"IO error accessing {drive.Name}: {ex.Message}", ex);
                StatusTextBlock.Content = "폴더를 읽는 중 오류가 발생했습니다.";
            }
        }


        private void LoadFiles(DriveInfo selectedDrive, string[] path)
        {
            string[] files = new string[path.Length];
            for (int i = 0; i < path.Length; i++)
            {
                string filename = selectedDrive + path[i];
                files = Directory.GetFiles(filename);
                //datagrid1 값 설정 예정
            }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // 저장 루틴 추가 예정
            // DialogResult = true;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void tr_fList_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

        }

        private void CancelButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void tr_fList_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void tr_fList_SelectedItemChanged_1(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

        }

        private void tr_fList_Selected(object sender, RoutedEventArgs e)
        {
            object selectedValue = tr_fList.SelectedItem;

            if (selectedValue != null)
            {
                string newFileName = selectedValue.ToString(); // TreeView에서 선택된 값

                // 기존 컬럼을 모두 지우고 새 컬럼을 추가합니다.
                datagrid1.Columns.Clear();

                DataGridTextColumn fileColumn = new DataGridTextColumn();
                fileColumn.Header = "파일명"; // 컬럼 헤더 설정

                // FileItem 클래스의 "FileName" 속성에 바인딩
                fileColumn.Binding = new System.Windows.Data.Binding("FileName");

                datagrid1.Columns.Add(fileColumn);

                // 중요: 이제 FileList 컬렉션에 새 데이터를 추가하면 DataGrid에 나타납니다.
                FileList.Add(new FileItem { FileName = newFileName });

                // (선택 사항) 만약 여러 항목을 추가하고 싶다면
                // FileList.Add(new FileItem { FileName = "또 다른 파일.doc" });
            }
        }
    }

    public class FileItem : INotifyPropertyChanged
    {
        private string _fileName;
        public string FileName // 이 속성 이름이 Binding에 사용됩니다.
        {
            get { return _fileName; }
            set
            {
                if (_fileName != value)
                {
                    _fileName = value;
                    OnPropertyChanged(nameof(FileName));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

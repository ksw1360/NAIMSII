using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
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
using System.IO;
using NAIMS2.Common.Utils;

namespace NAIMS2.Operator.Views
{
    public partial class DeviceFileList : Window
    {
        private UsbWatch usbWatch;

        public DeviceFileList()
        {
            InitializeComponent();
            InitAsync();
        }

        private async void InitAsync()
        {
            tr_fList.Items.Clear();
            datagrid1.ItemsSource = null;
            usbWatch = new UsbWatch();

            // 이벤트 핸들러 등록
            usbWatch.StatusChanged += async status =>
            {
                await Dispatcher.InvokeAsync(() =>
                {
                    StatusTextBlock.Content = status; // 상태 메시지 업데이트
                });
            };

            usbWatch.DrivesUpdated += async driveInfos =>
            {
                await Dispatcher.InvokeAsync(() =>
                {
                    tr_fList.Items.Clear(); // 기존 폴더 항목 지우기
                    datagrid1.ItemsSource = null; // 기존 파일 항목 지우기

                    if (driveInfos == null || !driveInfos.Any())
                    {
                        StatusTextBlock.Content = "USB 상태: 드라이브 없음";
                        SaveButton.IsEnabled = false;
                        CancelButton.IsEnabled = true;
                        return;
                    }

                    // 폴더와 파일 분리
                    var folderNodes = new List<FolderNode>();
                    var fileItems = new List<FileItem>();

                    foreach (var drive in driveInfos)
                    {
                        var rootNode = new FolderNode(drive.Name, drive.Name);
                        folderNodes.Add(rootNode);
                        LoadFolderContents(rootNode, drive.Name);

                        // 파일 목록 추가
                        fileItems.AddRange(GetFilesInDirectory(drive.Name));
                    }

                    // TreeView에 폴더 표시
                    foreach (var node in folderNodes)
                    {
                        tr_fList.Items.Add(node);
                    }

                    // DataGrid에 파일 표시
                    datagrid1.ItemsSource = fileItems;

                    StatusTextBlock.Content = "USB 상태: 드라이브 감지됨";
                    SaveButton.IsEnabled = true;
                    CancelButton.IsEnabled = false;
                });
            };

            // 비동기 초기 로드
            await Task.Run(() => usbWatch.LoadUSBDrives());
        }

        private void LoadFolderContents(FolderNode parentNode, string path)
        {
            try
            {
                var directories = Directory.GetDirectories(path);
                foreach (var dir in directories)
                {
                    var dirInfo = new DirectoryInfo(dir);
                    var childNode = new FolderNode(dirInfo.Name, dir);
                    parentNode.Children.Add(childNode);
                    LoadFolderContents(childNode, dir); // 재귀적으로 하위 폴더 로드
                }
            }
            catch (Exception ex)
            {
                Dispatcher.Invoke(() =>
                {
                    MessageBox.Show($"폴더 로드 중 오류: {ex.Message}", "오류", MessageBoxButton.OK, MessageBoxImage.Error);
                    Logger.Error($"폴더 로드 중 오류", ex);
                });
            }
        }

        private List<FileItem> GetFilesInDirectory(string path)
        {
            var fileItems = new List<FileItem>();
            try
            {
                var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    var fileInfo = new FileInfo(file);
                    fileItems.Add(new FileItem
                    {
                        Name = fileInfo.Name,
                        Extension = fileInfo.Extension,
                        Size = $"{fileInfo.Length / 1024} KB"
                    });
                }
            }
            catch (Exception ex)
            {
                Dispatcher.Invoke(() =>
                {
                    MessageBox.Show($"파일 로드 중 오류: {ex.Message}", "오류", MessageBoxButton.OK, MessageBoxImage.Error);
                    Logger.Error($"파일 로드 중 오류", ex);
                });
            }
            return fileItems;
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
            DialogResult = true;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }

    // 폴더 노드 클래스 (TreeView용)
    public class FolderNode
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public List<FolderNode> Children { get; set; }

        public FolderNode(string name, string path)
        {
            Name = name;
            Path = path;
            Children = new List<FolderNode>();
        }
    }

    // 파일 항목 클래스 (DataGrid용)
    public class FileItem
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public string Size { get; set; }
    }
}
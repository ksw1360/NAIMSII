using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Threading.Tasks;

namespace NAIMS2.Common.Views
{
    public class UsbWatch
    {
        public event Action<string> StatusChanged;
        public event Action<List<DriveInfo>> DrivesUpdated;

        public async Task LoadUSBDrivesAsync()
        {
            try
            {
                var drives = await Task.Run(() => DriveInfo.GetDrives()
                    .Where(d => d.IsReady && d.DriveType == DriveType.Removable)
                    .ToList());

                if (drives.Any())
                {
                    StatusChanged?.Invoke("USB 상태: 드라이브 감지됨");
                    DrivesUpdated?.Invoke(drives);
                }
                else
                {
                    StatusChanged?.Invoke("USB 상태: 드라이브 없음");
                    DrivesUpdated?.Invoke(new List<DriveInfo>());
                }
            }
            catch (Exception ex)
            {
                StatusChanged?.Invoke($"USB 감지 오류: {ex.Message}");
                DrivesUpdated?.Invoke(new List<DriveInfo>());
            }
        }

        // 기존 동기 메서드 (호환성을 위해 유지)
        public void LoadUSBDrives()
        {
            _ = LoadUSBDrivesAsync(); // 비동기 호출
        }
    }
}
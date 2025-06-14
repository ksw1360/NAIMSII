using NAIMS2.Common.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAIMS2.Operator.ViewModels
{
    public class CollectListContentViewModel
    {
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

        public CollectListContentViewModel()
        {
            TempData = new ObservableCollection<Dummy>
        {
            new Dummy { IsSelected = false, Title = 01, Email = "수집자료명", Duration = "해정단", TakeTime="00:00:00", Progress=45, AddedTime = "진행중", CompletedTime = "2025-06-04", protectdate = "2025-11-30", FileSize = 2048 },
            new Dummy { IsSelected = true, Title = 02, Email = "수집자료명", Duration = "해정단", TakeTime="00:00:00",Progress = 70, AddedTime = "진행중", CompletedTime = "2025-06-04", protectdate = "2025-11-30", FileSize = 2048 },
            new Dummy { IsSelected = false, Title = 03, Email = "수집자료명", Duration = "해정단", TakeTime="00:00:00",Progress = 33, AddedTime = "대기", CompletedTime = "2025-06-03", protectdate = "2025-10-31", FileSize = 512 }
        };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

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
    public class WavAnalMngtViewModel
    {
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

        public WavAnalMngtViewModel()
        {
            _WavAnalMngtDummy = new ObservableCollection<WavAnalMngtDummy>
            {
                new WavAnalMngtDummy { MissionName = "임무폴더명텍스트", Collect = "WSD200K", CollectBox = "ㅇㅇㅇ함", CollectDate = DateTime.Now, RecvDate = DateTime.Now, WavSignalCnt = 1, ChannelCnt = 2, CellectMove = "파일명.확장자", JobStatus = "임무중", WorkName = "박OO중사" },
                new WavAnalMngtDummy { MissionName = "임무폴더명텍스트", Collect = "WSD200K", CollectBox = "ㅇㅇㅇ함", CollectDate = DateTime.Now, RecvDate = DateTime.Now, WavSignalCnt = 4, ChannelCnt = 12, CellectMove = "파일명.확장자", JobStatus = "미할당", WorkName = "" },
                new WavAnalMngtDummy { MissionName = "임무폴더명텍스트", Collect = "WSD200K", CollectBox = "ㅇㅇㅇ함", CollectDate = DateTime.Now, RecvDate = DateTime.Now, WavSignalCnt = 4, ChannelCnt = 12, CellectMove = "파일명.확장자", JobStatus = "임무 완료", WorkName = "김OO 주무관" }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

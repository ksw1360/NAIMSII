using NAIMS2.Common.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAIMS2.Common.ViewModels
{
    public class NoticeModelViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<NoticeModel> _NoticeModel;
        public ObservableCollection<NoticeModel> NoticeModel
        {
            get => _NoticeModel;
            set
            {
                _NoticeModel = value;
                OnPropertyChanged(nameof(NoticeModel));
            }
        }

        private NoticeModel _selectedNotice;
        public NoticeModel SelectedNotice
        {
            get => _selectedNotice;
            set
            {
                _selectedNotice = value;
                OnPropertyChanged(nameof(SelectedNotice));
            }
        }

        public NoticeModelViewModel()
        {
            _NoticeModel = new ObservableCollection<NoticeModel>
            {
                new NoticeModel
                {
                    No = 1,
                    List = "테스트테스트테스트1",
                    Writer = "김상우",
                    WriteDate = DateTime.Now,
                    ExpiryDate = DateTime.Now,
                    isStatus = true,
                    MemoLines = new ObservableCollection<string> { "공지사항 테스트중입니다.!" + Environment.NewLine + "첫번째 테스트" }
                },
                new NoticeModel
                {
                    No = 2,
                    List = "테스트테스트테스트2",
                    Writer = "김상우",
                    WriteDate = DateTime.Now,
                    ExpiryDate = DateTime.Now,
                    isStatus = true,
                    MemoLines = new ObservableCollection<string> { "공지사항 테스트중입니다.!" + Environment.NewLine + "두번째 테스트" }
                }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
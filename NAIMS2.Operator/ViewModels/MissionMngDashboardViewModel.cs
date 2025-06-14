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
    public class MissionMngDashboardViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<PersonMissionData> _personData;
        public ObservableCollection<PersonMissionData> PersonData
        {
            get { return _personData; }
            set
            {
                _personData = value;
                OnPropertyChanged(nameof(PersonData));
            }
        }

        public MissionMngDashboardViewModel()
        {
            // Sample Data - you would replace this with actual data loaded from a service/database
            PersonData = new ObservableCollection<PersonMissionData>
            {
                new PersonMissionData { Name = "김OO 중사", PreCompletion = 4, InCompletion = 1, PreDetailed = 4, InDetailed = 2 },
                new PersonMissionData { Name = "이OO 중사", PreCompletion = 2, InCompletion = 1, PreDetailed = 3, InDetailed = 0 },
                new PersonMissionData { Name = "박OO 중사", PreCompletion = 1, InCompletion = 1, PreDetailed = 2, InDetailed = 6 },
                new PersonMissionData { Name = "김OO 소령", PreCompletion = 2, InCompletion = 3, PreDetailed = 3, InDetailed = 1 },
                new PersonMissionData { Name = "백OO 소령", PreCompletion = 6, InCompletion = 0, PreDetailed = 1, InDetailed = 0 },
                new PersonMissionData { Name = "최OO 소령", PreCompletion = 1, InCompletion = 4, PreDetailed = 2, InDetailed = 7 },
                new PersonMissionData { Name = "김OO 주무관", PreCompletion = 0, InCompletion = 4, PreDetailed = 6, InDetailed = 2 },
                new PersonMissionData { Name = "이OO 주무관", PreCompletion = 1, InCompletion = 1, PreDetailed = 2, InDetailed = 6 },
                new PersonMissionData { Name = "박OO 주무관", PreCompletion = 2, InCompletion = 3, PreDetailed = 5, InDetailed = 0 },
                new PersonMissionData { Name = "최OO 주무관", PreCompletion = 2, InCompletion = 4, PreDetailed = 6, InDetailed = 0 },
                new PersonMissionData { Name = "김OO 과장", PreCompletion = 3, InCompletion = 1, PreDetailed = 4, InDetailed = 0 }
            };
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAIMS2.Common.Models
{
    // Data Model for a single person's mission data for the bar chart
    public class PersonMissionData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; set; }
        public int PreCompletion { get; set; } // 완료분석 전
        public int InCompletion { get; set; }  // 완료분석 중
        public int PreDetailed { get; set; }   // 정밀분석 전
        public int InDetailed { get; set; }    // 정밀분석 중

        public int TotalCount => PreCompletion + InCompletion + PreDetailed + InDetailed;
        private const double MaxBarWidth = 100;
        private const double ScaleFactor = 20;

        public string PreCompletionWidth => $"{PreCompletion * ScaleFactor}";
        public string InCompletionWidth => $"{InCompletion * ScaleFactor}";
        public string PreDetailedWidth => $"{PreDetailed * ScaleFactor}";
        public string InDetailedWidth => $"{InDetailed * ScaleFactor}";

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

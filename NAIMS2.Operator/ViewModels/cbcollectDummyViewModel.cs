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
    public class cbcollectDummyViewModel
    {
        ObservableCollection<cbcollectDummy> _CbcollectDummies;
        public ObservableCollection<cbcollectDummy> CbcollectDummies
        {
            get => _CbcollectDummies;
            set
            {
                _CbcollectDummies = value;
                OnPropertyChanged(nameof(CbcollectDummies));
            }
        }

        public cbcollectDummyViewModel()
        {
            _CbcollectDummies = new ObservableCollection<cbcollectDummy>
            {
                new cbcollectDummy {key="1", value="수동 단일채널"},
                new cbcollectDummy {key="2", value="자동 단일채널"}
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

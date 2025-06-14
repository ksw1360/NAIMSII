using DevExpress.Mvvm.Native;
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
    public class cbsignalDummyViewModel
    {
        private ObservableCollection<cbsignalDummy> _CbsignalDummies;
        public ObservableCollection<cbsignalDummy> CbsignalDummies
        {
            get => _CbsignalDummies;
            set
            {
                _CbsignalDummies = value;
                OnPropertyChanged(nameof(CbsignalDummies));
            }
        }

        public cbsignalDummyViewModel()
        {
            _CbsignalDummies = new ObservableCollection<cbsignalDummy>
            {
                new cbsignalDummy {key="1", value="WSD-000K"},
                new cbsignalDummy {key="2", value="WSD-001K"}
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

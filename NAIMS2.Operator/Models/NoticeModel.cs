using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAIMS2.Common.Models
{
    public class NoticeModel
    {
        public int No { get; set; }
        public string List { get; set; }
        public string Writer { get; set; }
        public DateTime WriteDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool isStatus { get; set; }
        public ObservableCollection<string> MemoLines { get; set; }
    }
}

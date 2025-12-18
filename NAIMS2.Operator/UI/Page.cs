using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAIMS2.Common;

namespace NAIMS2.Common.UI
{
    public class Page : System.Windows.Controls.Page // IUIBase 제거
    {
        public Hashtable? BaseInfo { get; set; }

        public virtual void Init(Hashtable info)
        {
            this.BaseInfo = info;
        }
    }
}

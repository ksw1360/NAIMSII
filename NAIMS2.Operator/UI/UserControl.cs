using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAIMS2.Common;

namespace NAIMS2.Operator.UI
{
    public class UserControl: System.Windows.Controls.UserControl//, IUIBase
    {
        public Hashtable? BaseInfo { get; set; }
        public virtual void Init(Hashtable info)
        {
            this.BaseInfo = info;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpf.Core;
using NAIMS2.Common.Interfaces;

namespace NAIMS2.Common.UI
{
    public class Window : ThemedWindow, IUIBase
    {
        public Hashtable? BaseInfo { get; set; }
        public virtual void Init(Hashtable info)
        {
            this.BaseInfo = info;
        }
    }
}

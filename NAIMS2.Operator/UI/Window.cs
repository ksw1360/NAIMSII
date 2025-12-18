using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpf.Core;
//using NAIMS2.Common.Interfaces;

namespace NAIMS2.Operator.UI
{
    public class Window : ThemedWindow
    {
        public Hashtable? BaseInfo { get; set; }
        public virtual void Init(Hashtable info)
        {
            this.BaseInfo = info;
        }
    }
}
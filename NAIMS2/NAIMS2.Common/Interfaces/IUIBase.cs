using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAIMS2.Common.Interfaces
{
    internal interface IUIBase
    {
        Hashtable? BaseInfo { get; set; }
        void Init(Hashtable info);
    }
}

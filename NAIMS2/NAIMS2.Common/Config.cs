using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAIMS2.Common
{
    public static class Config
    {
        public static string DBFile { get; set; }
        static Config()
        {
            DBFile = Constants.DB_FILE;
        }
    }
}

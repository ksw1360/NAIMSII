using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NAIMS2.Common
{
    internal static class Initializer
    {
        static Initializer()
        {
            Console.WriteLine("Start up {0}", Assembly.GetExecutingAssembly().Location);
        }
    }
}

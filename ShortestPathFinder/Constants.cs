using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeTransportationLimited.Graphs
{
    static class Constants
    {
        public const int MAX_NODES = 512;
        
        public static double MAX_CONNECTIONS
        {
            get { return Math.Pow(MAX_NODES, 2); }
        }
    }
}

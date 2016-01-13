using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeTransportationLimited.Graphs
{
    class Path
    {
        public Stack<Connection> ConnectionStack = new Stack<Connection>(262144);
    }
}

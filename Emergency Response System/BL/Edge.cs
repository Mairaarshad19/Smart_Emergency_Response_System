using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergency_Response_System.BL
{
    public class Edge
    {
        public int To;
        public double Minutes;
        public double TrafficFactor;
        public string Status; // "Open" or "Closed"
        public string Name;
        public double DistanceKm;
        public Edge Next;
    }

}

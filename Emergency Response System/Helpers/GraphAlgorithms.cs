using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emergency_Response_System.BL;

namespace Emergency_Response_System.Helpers
{
    public class GraphAlgorithms
    {
        public static double FindFastestRoute(CityGraph graph, int ambulanceIntersection, int emergencyIntersection)
        {
            double[] dist = Dijkstra.Run(graph, ambulanceIntersection);
            return dist[emergencyIntersection]; // shortest travel time
        }
    }
}

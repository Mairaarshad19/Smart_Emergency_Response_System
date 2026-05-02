using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergency_Response_System.BL
{
    public class RouteBL
    {
        public int RouteId { get; set; }
        public int DispatchId { get; set; }
        public string Path { get; set; } // JSON or text list of intersections
        public double TotalDistance { get; set; }
        public int TotalTime { get; set; }

        public RouteBL(int routeId, int dispatchId, string path, double totalDistance, int totalTime)
        {
            RouteId = routeId;
            DispatchId = dispatchId;
            Path = path;
            TotalDistance = totalDistance;
            TotalTime = totalTime;
        }
    }

}

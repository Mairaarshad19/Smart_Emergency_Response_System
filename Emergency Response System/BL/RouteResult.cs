using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergency_Response_System.BL
{
    public class RouteStep
    {
        public int From;
        public int To;
        public string RoadName;
        public double DistanceKm;
        public double SegmentMinutes;
    }

    public class RouteResult
    {
        public RouteStep[] Steps;
        public int TotalMinutes;
        public double TotalDistanceKm;
        public string PathText;
    }
}

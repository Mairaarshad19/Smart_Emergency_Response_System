using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using global::Emergency_Response_System.BL;

namespace Emergency_Response_System.Helpers
{
    public static class MapHelper
    {
        // Haversine distance (kilometers) using decimals cast to double
        private static double DistanceKm(double lat1, double lon1, double lat2, double lon2)
        {
            double R = 6371.0;
            double dLat = ((double)lat2 - (double)lat1) * Math.PI / 180.0;
            double dLon = ((double)lon2 - (double)lon1) * Math.PI / 180.0;
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                        Math.Cos((double)lat1 * Math.PI / 180.0) *
                        Math.Cos((double)lat2 * Math.PI / 180.0) *
                        Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c;
        }

        // Requires intersections with Latitude/Longitude populated
        public static int FindNearestIntersection(CityGraph graph, double lat, double lng)
        {
            int bestId = -1;
            double bestDist = double.MaxValue;

            var node = graph.Intersections.First;
            while (node != null)
            {
                var it = node.Value;
                if (it.Latitude != 0 || it.Longitude != 0)
                {
                    double d = DistanceKm(lat, lng, it.Latitude, it.Longitude);
                    if (d < bestDist) { bestDist = d; bestId = it.Id; }
                }
                node = node.Next;
            }

            return bestId; // -1 if none have coordinates
        }
    }
}

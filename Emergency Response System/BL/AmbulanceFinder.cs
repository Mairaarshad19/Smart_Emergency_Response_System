using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emergency_Response_System.BL.Emergency_Response_System.BL;
using Emergency_Response_System.DL;
using Microsoft.EntityFrameworkCore.Internal;
using Emergency_Response_System.Managers;
using Emergency_Response_System.Helpers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace Emergency_Response_System.BL
{
    public static class AmbulanceFinder
    {
        public static double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            double R = 6371; // Earth radius in km
            double dLat = (lat2 - lat1) * Math.PI / 180.0;
            double dLon = (lon2 - lon1) * Math.PI / 180.0;

            lat1 = lat1 * Math.PI / 180.0;
            lat2 = lat2 * Math.PI / 180.0;

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat1) * Math.Cos(lat2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c; // distance in km
        }

        public static AmbulanceBL FindNearestAmbulance(AmbulanceLinkedList list, double emergencyLat, double emergencyLon)
        {
            if (list == null || list.head == null)
                return null;

            AmbulancePriorityQueue pq = new AmbulancePriorityQueue();
            AmbulanceNode temp = list.head;

            while (temp != null)
            {
                var amb = temp.data;
                if (amb != null && amb.status == "Available")
                {
                    double dist = GeoHelper.Distance(emergencyLat, emergencyLon, amb.current_latitude, amb.current_longitude);
                    pq.Enqueue(amb, dist);
                }
                temp = temp.next;
            }

            if (!pq.IsEmpty())
            {
                var nearest = pq.Dequeue();
                return nearest.amb;
            }
            return null;
        }

        public static AmbulanceBL PickFastestAmbulance(
                CityGraph cityGraph,
                AmbulanceLinkedList list,
                int emergencyIntersection,
                EmergencyBL emergency)
            {
            if (list == null || list.head == null)
                return null;

            AmbulancePriorityQueue pq = new AmbulancePriorityQueue();
            AmbulanceNode temp = list.head;

            while (temp != null)
            {
                var amb = temp.data;
                if (amb != null && amb.status == "Available")
                {
                    // Get the station intersection for this ambulance
                    int startIntersection = StationDL.GetIntersectionIdByStation(amb.station_id);

                    // Run Dijkstra to calculate travel time from ambulance station to emergency intersection
                    double routeTime = GraphAlgorithms.FindFastestRoute(
                        cityGraph,
                        cityGraph.GetIndexById(startIntersection),
                        cityGraph.GetIndexById(emergencyIntersection)
                    );

                    // Only enqueue if route is valid
                    if (routeTime > 0 && !double.IsInfinity(routeTime))
                    {
                        pq.Enqueue(amb, routeTime); // priority = travel time
                    }
                }
                temp = temp.next;
            }

            if (!pq.IsEmpty())
            {
                var fastest = pq.Dequeue(); // ambulance with lowest travel time
                return fastest.amb;
            }
            return null;
        }

    }
}


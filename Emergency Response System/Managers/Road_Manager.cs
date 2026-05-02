using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emergency_Response_System.BL;
using Emergency_Response_System.DL;

namespace Emergency_Response_System.Managers
{
    public static class RoadManager
    {
        public static LinkedList<RoadBL> Roads = new LinkedList<RoadBL>();

        public static void LoadRoads()
        {
            Roads.Clear();
            foreach (var road in RoadDL.GetAllRoads())
            {
                Roads.AddLast(road);
            }
        }

        // Build CityGraph from Roads
        public static CityGraph BuildGraph()
        {
            CityGraph graph = new CityGraph();

            // Add intersections
            foreach (var intersection in IntersectionManager.Intersections)
            {
                graph.AddIntersection(intersection.Id, intersection.Name);
            }

            foreach (var road in Roads)
            {
                if (graph.HasIntersection(road.FromIntersectionId) && graph.HasIntersection(road.ToIntersectionId))
                {
                    // Add both directions
                    graph.AddRoad(road.FromIntersectionId, road.ToIntersectionId, road.TravelTimeMinutes);
                    graph.AddRoad(road.ToIntersectionId, road.FromIntersectionId, road.TravelTimeMinutes);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine(
                        $"Road {road.RoadId} skipped: invalid intersection IDs {road.FromIntersectionId} -> {road.ToIntersectionId}");
                }
            }
            foreach (var road in Roads)
            {
                // Safety check: only add if both intersections exist in graph
                if (graph.HasIntersection(road.FromIntersectionId) && graph.HasIntersection(road.ToIntersectionId))
                {
                    graph.AddRoad(road.FromIntersectionId, road.ToIntersectionId, road.TravelTimeMinutes);
                }
                else
                {
                    // Optional: log or warn if road references missing intersection
                    System.Diagnostics.Debug.WriteLine(
                        $"Road {road.RoadId} skipped: invalid intersection IDs {road.FromIntersectionId} -> {road.ToIntersectionId}");
                }
            }

            return graph;
        }

    }

}

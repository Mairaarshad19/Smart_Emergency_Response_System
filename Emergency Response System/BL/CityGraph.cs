using System;
using System.Collections.Generic;
using Emergency_Response_System.DL;

namespace Emergency_Response_System.BL
{
        public class CityGraph
        {
            public LinkedList<IntersectionBL> Intersections = new LinkedList<IntersectionBL>();
            public int Count => Intersections.Count;

            // Add intersection
            public void AddIntersection(int id, string name)
            {
                Intersections.AddLast(new IntersectionBL(id, name)); // FIX: AddLast
            }

            // Add road (directed edge)
            public void AddRoad(int fromId, int toId, double time)
            {
                IntersectionBL from = FindIntersection(fromId);
                if (from == null) return;

                RoadNode road = new RoadNode(toId, time);

                if (from.RoadsHead == null)
                    from.RoadsHead = road;
                else
                {
                    RoadNode temp = from.RoadsHead;
                    while (temp.Next != null) temp = temp.Next;
                    temp.Next = road;
                }
            }

            // Add bidirectional road (two-way)
            public void AddBidirectionalRoad(int id1, int id2, double time)
            {
                AddRoad(id1, id2, time);
                AddRoad(id2, id1, time);
            }

            // Find intersection by DB ID (manual traversal)
            public IntersectionBL FindIntersection(int id)
            {
                foreach (var intersection in Intersections)
                {
                    if (intersection.Id == id)
                        return intersection;
                }
                return null;
            }

            // Check if intersection exists (manual traversal)
            public bool HasIntersection(int id)
            {
                foreach (var intersection in Intersections)
                {
                    if (intersection.Id == id)
                        return true;
                }
                return false;
            }

        public IntersectionBL GetIntersectionByIndex(int index)
        {
            int i = 0;
            var node = Intersections.First;
            while (node != null)
            {
                if (i == index) return node.Value;
                i++;
                node = node.Next;
            }
            return null;
        }


        // Map DB ID → index (for Dijkstra arrays)
        public int GetIndexById(int intersectionId)
            {
                int i = 0;
                foreach (var intersection in Intersections)
                {
                    if (intersection.Id == intersectionId)
                        return i;
                    i++;
                }
                return -1; // not found
            }

            // Get neighbors of an intersection (for Dijkstra)
            public List<(int toId, double time)> GetNeighbors(int id)
            {
                List<(int toId, double time)> neighbors = new List<(int, double)>();
                IntersectionBL from = FindIntersection(id);
                if (from == null) return neighbors;

                RoadNode temp = from.RoadsHead;
                while (temp != null)
                {
                    neighbors.Add((temp.ToId, temp.TravelTime));
                    temp = temp.Next;
                }
                return neighbors;
            }

            // Debug print graph
            public void PrintGraph()
            {
                foreach (var intersection in Intersections)
                {
                    Console.Write($"Intersection {intersection.Id} ({intersection.Name}) → ");
                    RoadNode temp = intersection.RoadsHead;
                    while (temp != null)
                    {
                        Console.Write($"{temp.ToId}({temp.TravelTime} min) ");
                        temp = temp.Next;
                    }
                    Console.WriteLine();
                }
            }
        }
}

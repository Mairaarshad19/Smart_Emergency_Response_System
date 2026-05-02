using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergency_Response_System.BL
{
    public class Dijkstra
    {
        public static double[] Run(CityGraph graph, int sourceId)
        {
            int maxId = graph.Intersections.Max(i => i.Id); 
            double[] dist = new double[maxId + 1]; 
            bool[] visited = new bool[maxId + 1];
            // initialize distances
            for (int i = 0; i < maxId; i++)
                dist[i] = double.PositiveInfinity;

            dist[sourceId] = 0;

            for (int step = 0; step < maxId; step++)
            {
                // find unvisited node with smallest distance
                int u = -1;
                double minDist = double.PositiveInfinity;
                for (int i = 0; i < maxId; i++)
                {
                    if (!visited[i] && dist[i] < minDist)
                    {
                        minDist = dist[i];
                        u = i;
                    }
                }

                if (u == -1) break; // no reachable nodes left
                visited[u] = true;

                // relax edges
                IntersectionBL node = graph.GetIntersectionByIndex(u);
                RoadNode road = node.RoadsHead;
                while (road != null)
                {
                    int v = road.ToId;
                    double alt = dist[u] + road.TravelTime;
                    if (alt < dist[v])
                        dist[v] = alt;
                    road = road.Next;
                }
            }

            return dist;
        }
    }

}

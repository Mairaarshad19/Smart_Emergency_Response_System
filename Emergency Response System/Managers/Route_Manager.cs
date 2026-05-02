using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emergency_Response_System.BL;
using Emergency_Response_System.DL;
using Emergency_Response_System.Helpers;
using Microsoft.EntityFrameworkCore.Internal;

namespace Emergency_Response_System.Managers
{ 
    public class RouteManager
    {
        public static LinkedList<RouteBL> Routes = new LinkedList<RouteBL>();
        public RouteResult ComputeRoute(int startId, int endId, GraphBL g)
        {
            int n = g.NodeCount;
            double[] dist = new double[n + 1];
            int[] prev = new int[n + 1];
            bool[] used = new bool[n + 1];

            for (int i = 1; i <= n; i++) { dist[i] = double.PositiveInfinity; prev[i] = 0; used[i] = false; }
            if (startId < 1 || startId > n || endId < 1 || endId > n)
                throw new ArgumentOutOfRangeException("Start or end ID exceeds graph size");

            dist[startId] = 0.0;

            // Dijkstra (linear scan)
            for (int iter = 1; iter <= n; iter++)
            {
                int u = -1; double best = double.PositiveInfinity;
                for (int i = 1; i <= n; i++) if (!used[i] && dist[i] < best) { best = dist[i]; u = i; }
                if (u == -1) break;           // no reachable nodes
                used[u] = true;
                if (u == endId) break;

                var e = g.Head(u);
                while (e != null)
                {
                    int v = e.To;
                    double w = e.Minutes;
                    if (!used[v] && dist[u] + w < dist[v])
                    {
                        dist[v] = dist[u] + w;
                        prev[v] = u;
                    }
                    e = e.Next;
                }
            }

            // If end not reached
            if (double.IsPositiveInfinity(dist[endId]))
            {
                return new RouteResult
                {
                    Steps = Array.Empty<RouteStep>(),
                    TotalMinutes = 0,
                    TotalDistanceKm = 0,
                    PathText = ""
                };
            }

            // Reconstruct path
            int[] stack = new int[n + 1]; int sp = 0; int cur = endId;
            while (cur != 0) { stack[sp++] = cur; cur = prev[cur]; }
            Array.Reverse(stack, 0, sp);

            RouteStep[] steps = new RouteStep[Math.Max(0, sp - 1)];
            double totalMinutes = 0, totalKm = 0;
            for (int i = 0; i < sp - 1; i++)
            {
                int from = stack[i], to = stack[i + 1];
                var e = g.Head(from);
                while (e != null && e.To != to) e = e.Next;
                if (e != null)
                {
                    steps[i] = new RouteStep
                    {
                        From = from,
                        To = to,
                        RoadName = e.Name,
                        DistanceKm = e.DistanceKm,
                        SegmentMinutes = e.Minutes
                    };
                    totalMinutes += e.Minutes;
                    totalKm += e.DistanceKm;
                }
            }

            string pathText = string.Join("-", stack, 0, sp);
            int safeMinutes = (int)Math.Min(totalMinutes + 0.5, int.MaxValue);

            return new RouteResult
            {
                Steps = steps,
                TotalMinutes = safeMinutes,
                TotalDistanceKm = totalKm,
                PathText = pathText
            };
        }

        public static void LoadRoutes()
        {
            Routes.Clear();
            foreach (var route in RouteDL.GetAllRoutes())
            {
                Routes.AddLast(route);
            }
        }
    }

}

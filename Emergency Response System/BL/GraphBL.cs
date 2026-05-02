using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emergency_Response_System.DL;

namespace Emergency_Response_System.BL
{
    public class GraphBL
    {
        private readonly Edge[] _adj; // head per intersection (1-based)
        public int NodeCount { get; }

        public GraphBL(int nodeCount)
        {
            NodeCount = nodeCount;
            _adj = new Edge[nodeCount + 1];
        }

       /* public int GetIndexById(int intersectionId)
        {
            for (int i = 0; i < Intersections.Count; i++)
            {
                if (Intersections[i].Id == intersectionId)
                    return i;
            }
            return -1; // not found
        }

        */
        public void AddDirected(int from, int to, double minutes, double tf, string status, string name, double distKm)
        {
            if (status == "Closed")
            {
                MessageBox.Show($"Skipping closed road: {name}");
                return;
            }
            MessageBox.Show($"Adding road {name} with factor {tf}, effective minutes={minutes * tf}");


            double effectiveMinutes = minutes * tf;

            var e = new Edge
            {
                To = to,
                Minutes = effectiveMinutes,
                TrafficFactor = tf,
                Status = status,
                Name = name,
                DistanceKm = distKm,
                Next = _adj[from]
            };
            _adj[from] = e;
        }



        public Edge Head(int node) => _adj[node];
    }

}

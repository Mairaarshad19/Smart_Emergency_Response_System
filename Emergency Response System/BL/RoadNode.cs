using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergency_Response_System.BL
{
    public class RoadNode
    {
        public int ToId;
        public double TravelTime;
        public RoadNode Next;

        public RoadNode(int toId, double travelTime)
        {
            ToId = toId;
            TravelTime = travelTime;
            Next = null;
        }
    }

}

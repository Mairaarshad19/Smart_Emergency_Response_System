using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergency_Response_System.BL
{
    public class RoadBL
    {
        public int RoadId { get; set; }
        public int FromIntersectionId { get; set; }
        public int ToIntersectionId { get; set; }
        public double TravelTimeMinutes { get; set; }
        public RoadBL(int roadId, int fromIntersectionId, int toIntersectionId, double travelTimeMinutes)
        {
            RoadId = roadId; FromIntersectionId = fromIntersectionId;
            ToIntersectionId = toIntersectionId;
            TravelTimeMinutes = travelTimeMinutes;
        }
    }
}

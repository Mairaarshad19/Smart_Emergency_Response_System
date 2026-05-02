using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergency_Response_System.BL
{
    public class IntersectionBL
    {
        public int Id;
        public string Name;
        public RoadNode RoadsHead;

        // Optional: coordinates for nearest-intersection mapping
        public double Latitude;
        public double Longitude;

        public IntersectionBL(int id, string name, double latitude = 0, double longitude = 0)
        {
            Id = id;
            Name = name;
            RoadsHead = null;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}

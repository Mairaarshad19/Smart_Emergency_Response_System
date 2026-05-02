using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergency_Response_System.BL
{
    public class AmbulanceLocation
    {
            public int AmbulanceId { get; set; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }
            public DateTime LastUpdated { get; set; }
            public string Status { get; set; }
    }
}

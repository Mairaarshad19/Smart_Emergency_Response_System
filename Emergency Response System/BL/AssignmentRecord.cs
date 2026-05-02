using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergency_Response_System.BL
{
    public class AssignmentRecord
    {
        public int EmergencyId { get; set; }
        public int AmbulanceId { get; set; }
        public DateTime AssignedAt { get; set; }
    }

}

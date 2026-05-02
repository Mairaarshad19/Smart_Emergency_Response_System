using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergency_Response_System.BL
{
    public class DispatchBL
    { 
        public int DispatchId { get; set; } 
        public int EmergencyId { get; set; } 
        public int AmbulanceId { get; set; } 
        public DateTime AssignedAt { get; set; }
        public int EtaMinutes { get; set; } 
        public DateTime? ArrivalTime { get; set; }
        public string Status { get; set; }
        public static LinkedList<DispatchBL> GetCurrentAssignments()
        {
            LinkedList<DispatchBL> currentAssignments = new LinkedList<DispatchBL>();

                string query = @"
            SELECT e.emergency_id, e.status, d.ambulance_id, d.dispatch_id, d.assigned_at
            FROM emergencies e
            LEFT JOIN (
                SELECT emergency_id, ambulance_id, dispatch_id, assigned_at
                FROM dispatches d1
                WHERE dispatch_id = (
                    SELECT MAX(dispatch_id) 
                    FROM dispatches d2 
                    WHERE d2.emergency_id = d1.emergency_id
                )
            ) d ON e.emergency_id = d.emergency_id";

            DataTable dt = DatabaseHelper.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                DispatchBL log = new DispatchBL
                {
                    DispatchId = row["dispatch_id"] != DBNull.Value ? Convert.ToInt32(row["dispatch_id"]) : 0,
                    EmergencyId = Convert.ToInt32(row["emergency_id"]),
                    AmbulanceId = row["ambulance_id"] != DBNull.Value ? Convert.ToInt32(row["ambulance_id"]) : 0,
                    AssignedAt = row["assigned_at"] != DBNull.Value ? Convert.ToDateTime(row["assigned_at"]) : DateTime.MinValue,
                    Status = row["status"].ToString()
                };

                currentAssignments.AddLast(log);
            }

            return currentAssignments;
        }

    }
}

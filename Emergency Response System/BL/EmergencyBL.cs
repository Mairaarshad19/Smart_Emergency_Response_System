using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emergency_Response_System.DL;
using static Emergency_Response_System.BL.EmergencyBL;
using static Mysqlx.Error.Types;

namespace Emergency_Response_System.BL
{
    public class EmergencyBL
    {
        public int emergency_id { get; set; }
        public string caller_name { get; set; }
        public string caller_phone { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        public string severity { get; set; } // Critical, High, Medium, Low
        public string description { get; set; }
        public string status { get; set; } = "Waiting"; // Default
        public DateTime created_at { get; set; }
        public int intersection_id { get; set; }

        public EmergencyBL() { }

        public EmergencyBL(int emergencyId)
        {
            this.emergency_id = emergencyId;
        }

        public EmergencyBL(string callerName, string callerPhone, decimal lat, decimal lng, string severity, string description, string status)
        {
            this.caller_name = callerName;
            this.caller_phone = callerPhone;
            this.latitude = lat;
            this.longitude = lng;
            this.severity = severity;
            this.description = description;
            this.status = status;
        }

        public EmergencyBL(int emergencyId, string severity, string description, string status, DateTime createdAt)
        {
            this.emergency_id = emergencyId;
            this.severity = severity;
            this.description = description;
            this.status = status;
            this.created_at = createdAt;
        }

        public EmergencyBL(int emergencyId, string callerName, string callerPhone, decimal lat, decimal lng, string severity, string description, string status, DateTime createdAt)
        {
            this.emergency_id = emergencyId;
            this.caller_name = callerName;
            this.caller_phone = callerPhone;
            this.latitude = lat;
            this.longitude = lng;
            this.severity = severity;
            this.description = description;
            this.status = status;
            this.created_at = createdAt;
        }
        public EmergencyBL(int emergencyId, string callerName, string callerPhone, decimal lat, decimal lng, string severity, string description, string status, DateTime createdAt, int intersectionid)
        {
            this.emergency_id = emergencyId;
            this.caller_name = callerName;
            this.caller_phone = callerPhone;
            this.latitude = lat;
            this.longitude = lng;
            this.severity = severity;
            this.description = description;
            this.status = status;
            this.created_at = createdAt;
            this.intersection_id = intersectionid;
        }
        public static Queue<EmergencyBL> FindEmergenciesAtLocation(int intersectionId)
        {
            return EmergencyDL.GetEmergenciesByLocation(intersectionId);
        }

        // Validation
        public bool IsValid()
        {
            return !string.IsNullOrEmpty(caller_name) &&
                   !string.IsNullOrEmpty(caller_phone) &&
                   latitude != 0 && longitude != 0 &&
                   !string.IsNullOrEmpty(severity);
        }
        public int GetPriorityLevel() 
        { 
            switch (severity) 
            { 
                case "Critical": return 1;
                case "High": return 2;
                case "Medium": return 3;
                case "Low": return 4;
                default: return 5;
            } 
        }
    }
}

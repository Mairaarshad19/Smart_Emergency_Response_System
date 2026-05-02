using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emergency_Response_System.BL;
using MySql.Data.MySqlClient;

namespace Emergency_Response_System.Managers
{
    public static class Ambulance_Assignment_Manager
    {
        private static Stack<AssignmentRecord> assignmentHistory = new Stack<AssignmentRecord>();

        public static void AssignAmbulance(int emergencyId, int ambulanceId)
        {
            // Update DB: mark ambulance assigned to emergency
            string query = @"UPDATE emergencies SET ambulance_id = @AmbulanceId, status = 'Assigned'
                         WHERE emergency_id = @EmergencyId";

            DatabaseHelper.ExecuteNonQuery(query,
                new MySqlParameter("@AmbulanceId", ambulanceId),
                new MySqlParameter("@EmergencyId", emergencyId));

            // Push onto stack for undo
            assignmentHistory.Push(new AssignmentRecord
            {
                EmergencyId = emergencyId,
                AmbulanceId = ambulanceId,
                AssignedAt = DateTime.Now
            });
        }

        public static void UndoLastAssignment()
        {
            if (assignmentHistory.Count > 0)
            {
                var last = assignmentHistory.Pop();

                // Revert DB: remove ambulance assignment
                string query = @"UPDATE emergencies SET ambulance_id = NULL, status = 'Waiting'
                             WHERE emergency_id = @EmergencyId";

                DatabaseHelper.ExecuteNonQuery(query,
                    new MySqlParameter("@EmergencyId", last.EmergencyId));
            }
        }
    }

}

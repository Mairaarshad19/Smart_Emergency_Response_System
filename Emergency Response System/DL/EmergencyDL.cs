using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emergency_Response_System.BL;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Asn1.X509;

namespace Emergency_Response_System.DL
{
    public class EmergencyDL
    {
        public static Queue<EmergencyBL> emergencies = new Queue<EmergencyBL>();
        public static Queue<EmergencyBL> GetEmergenciesByLocation(int intersectionId)
        {
            Queue<EmergencyBL> emergencies = new Queue<EmergencyBL>();

            string query = @"SELECT emergency_id, caller_name, caller_phone, latitude, longitude, 
                            severity, description, status, created_at, intersection_id 
                     FROM emergencies 
                     WHERE intersection_id = @IntersectionId";

            DataTable dt = DatabaseHelper.ExecuteQuery(query,
                new MySqlParameter("@IntersectionId", intersectionId));

            foreach (DataRow row in dt.Rows)
            {
                EmergencyBL emergency = new EmergencyBL(
                    Convert.ToInt32(row["emergency_id"]),
                    row["caller_name"].ToString(),
                    row["caller_phone"].ToString(),
                    row["latitude"] == DBNull.Value ? 0 : Convert.ToDecimal(row["latitude"]),
                    row["longitude"] == DBNull.Value ? 0 : Convert.ToDecimal(row["longitude"]),
                    row["severity"].ToString(),
                    row["description"] == DBNull.Value ? "" : row["description"].ToString(),
                    row["status"].ToString(),
                    row["created_at"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["created_at"]),
                    Convert.ToInt32(row["intersection_id"])
                );

                emergencies.Enqueue(emergency);
            }

            return emergencies;
        }
      

        public static LinkedList<EmergencyBL> GetAllEmergencies()
            {
                LinkedList<EmergencyBL> emergencies = new LinkedList<EmergencyBL>();

                string query = "SELECT emergency_id, caller_name, caller_phone, latitude, longitude, severity, description, status, created_at, intersection_id FROM emergencies";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);

                foreach (DataRow row in dt.Rows)
                {
                    EmergencyBL emergency = new EmergencyBL(
                        Convert.ToInt32(row["emergency_id"]),
                        row["caller_name"].ToString(),
                        row["caller_phone"].ToString(),
                        row["latitude"] == DBNull.Value ? 0 : Convert.ToDecimal(row["latitude"]),
                        row["longitude"] == DBNull.Value ? 0 : Convert.ToDecimal(row["longitude"]),
                        row["severity"].ToString(),
                        row["description"] == DBNull.Value ? "" : row["description"].ToString(),
                        row["status"].ToString(),
                        row["created_at"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["created_at"]),
                        Convert.ToInt32(row["intersection_id"])
                    );

                    emergencies.AddLast(emergency);
                }

                return emergencies;
            }


        public static void LoadEmergencies()
        {   
            emergencies.Clear();
            string query = "SELECT * FROM emergencies ORDER BY created_at ASC"; // oldest first
            DataTable dt = DatabaseHelper.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                EmergencyBL em = new EmergencyBL(
                    Convert.ToInt32(row["emergency_id"]),
                    row["caller_name"].ToString(),
                    row["caller_phone"].ToString(),
                    Convert.ToDecimal(row["latitude"]),
                    Convert.ToDecimal(row["longitude"]),
                    row["severity"].ToString(),
                    row["description"].ToString(),
                    row["status"].ToString(),
                    Convert.ToDateTime(row["created_at"])
                );
                emergencies.Enqueue(em); // add to queue
            }
        }

        public static int AddEmergency(EmergencyBL emergency)
        {
            string query = @"INSERT INTO emergencies 
                     (caller_name, caller_phone, latitude, longitude, severity, description, status, intersection_id) 
                     VALUES (@CallerName, @CallerPhone, @Latitude, @Longitude, @Severity, @Description, @Status, @IntersectionId);
                     SELECT LAST_INSERT_ID();";

            object result = DatabaseHelper.ExecuteScalar(query,
                new MySqlParameter("@CallerName", emergency.caller_name),
                new MySqlParameter("@CallerPhone", emergency.caller_phone),
                new MySqlParameter("@Latitude", emergency.latitude),
                new MySqlParameter("@Longitude", emergency.longitude),
                new MySqlParameter("@Severity", emergency.severity),
                new MySqlParameter("@Description", emergency.description),
                new MySqlParameter("@Status", emergency.status),
                new MySqlParameter("@IntersectionId", emergency.intersection_id)
            );

            int newId = Convert.ToInt32(result);
            emergency.emergency_id = newId;   // update object
            emergencies.Enqueue(emergency);   // add to queue
            return newId; 

        }


        // Process next emergency (FIFO)
        public static EmergencyBL ProcessNextEmergency()
        {
            if (emergencies.Count > 0)
            {
                return emergencies.Dequeue(); 
            }
            return null;
        }

        // Peek at next emergency without removing
        public static EmergencyBL PeekNextEmergency()
        {
            if (emergencies.Count > 0)
            {
                return emergencies.Peek();
            }
            return null;
        }

        // Update emergency status in DB
        public static void UpdateEmergencyStatus(int emergencyId, string newStatus)
        {
            string query = "UPDATE emergencies SET status=@Status WHERE emergency_id=@EmergencyId";

            DatabaseHelper.ExecuteNonQuery(query,
                new MySqlParameter("@Status", newStatus),
                new MySqlParameter("@EmergencyId", emergencyId)
            );
        }

        // Delete emergency from DB (and queue if present)
        public static void DeleteEmergency(int emergencyId)
        {
            string query = "DELETE FROM emergencies WHERE emergency_id=@EmergencyId";
            DatabaseHelper.ExecuteNonQuery(query,
                new MySqlParameter("@EmergencyId", emergencyId)
            );

            // Remove from queue
            Queue<EmergencyBL> tempQueue = new Queue<EmergencyBL>();
            while (emergencies.Count > 0)
            {
                EmergencyBL em = emergencies.Dequeue();
                if (em.emergency_id != emergencyId)
                {
                    tempQueue.Enqueue(em);
                }
            }
            emergencies = tempQueue;
        }
    }
}

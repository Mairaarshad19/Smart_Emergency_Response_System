using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Emergency_Response_System.BL;
using System.Data.SqlClient;
using Emergency_Response_System.BL.Emergency_Response_System.BL;

namespace Emergency_Response_System.DL
{
    public class AmbulanceDL
    {
        public static LinkedList<AmbulanceBL> ambulances = new LinkedList<AmbulanceBL>();

        public static Queue<EmergencyBL> GetEmergenciesByLocation(int intersectionId)
        {
            Queue<EmergencyBL> emergencies = new Queue<EmergencyBL>();

            string query = "SELECT * FROM emergencies WHERE intersection_id = @IntersectionId";

            using (MySqlDataReader reader = DatabaseHelper.ExecuteReader(query,
                new MySqlParameter("@IntersectionId", intersectionId)))
            {
                while (reader.Read())
                {
                    EmergencyBL emergency = new EmergencyBL
                    {
                        emergency_id = Convert.ToInt32(reader["emergency_id"]),
                        caller_name = reader["caller_name"].ToString(),
                        caller_phone = reader["caller_phone"].ToString(),
                        latitude = Convert.ToDecimal(reader["current_latitude"]),
                        longitude = Convert.ToDecimal(reader["current_longitude"]),
                        severity = reader["severity"].ToString(),
                        description = reader["description"].ToString(),
                        status = reader["status"].ToString(),
                        intersection_id = Convert.ToInt32(reader["intersection_id"]),
                        created_at = Convert.ToDateTime(reader["created_at"])
                    };
                    emergencies.Enqueue(emergency);
                }
            }

            return emergencies;
        }

        public static AmbulanceLocation GetAmbulanceLocation(int ambulanceId)
        {
            string sql = "SELECT ambulance_id, status, current_latitude, current_longitude FROM ambulances WHERE ambulance_id=@Id";
            using (var reader = DatabaseHelper.ExecuteReader(sql, new MySqlParameter("@Id", ambulanceId)))
            {
                if (reader.Read())
                {
                    return new AmbulanceLocation
                    {
                        AmbulanceId = reader.GetInt32("ambulance_id"),
                        Latitude = reader.GetDouble("current_latitude"),
                        Longitude = reader.GetDouble("current_longitude"),
                        Status = reader.GetString("status")
                    };
                }
            }
            return null;
        }



        public static void UpdateAmbulanceLocation(int ambulanceId, double lat, double lon)
        {
            string query = "UPDATE ambulances SET current_latitude=@Lat, current_longitude=@Lon WHERE ambulance_id=@Id";
            DatabaseHelper.ExecuteNonQuery(query,
                new MySqlParameter("@Lat", lat),
                new MySqlParameter("@Lon", lon),
                new MySqlParameter("@Id", ambulanceId)
            );
        }

        public static LinkedList<AmbulanceBL> GetAllAmbulances()
        {
            ambulances.Clear();
            string query = "SELECT * FROM ambulances";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                AmbulanceBL amb = new AmbulanceBL(
                Convert.ToInt32(row["ambulance_id"]),
                Convert.ToInt32(row["station_id"]),
                row["plate_number"].ToString(),
                row["equipment"] == DBNull.Value ? "" : row["equipment"].ToString(),
                row["status"].ToString(),
                row["current_latitude"] == DBNull.Value ? 0.0 : Convert.ToDouble(row["current_latitude"]),
                row["current_longitude"] == DBNull.Value ? 0.0 : Convert.ToDouble(row["current_longitude"])
            );


                ambulances.AddLast(amb);
            }

            return ambulances;
        }

        public static LinkedList<AmbulanceBL> LoadActiveAmbulances()
        {
            ambulances.Clear();

            // ✅ Only load active ambulances
            string query = "SELECT * FROM ambulances WHERE is_active = 1";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                AmbulanceBL amb = new AmbulanceBL(
                    Convert.ToInt32(row["ambulance_id"]),
                    Convert.ToInt32(row["station_id"]),
                    row["plate_number"].ToString(),
                    row["equipment"] == DBNull.Value ? "" : row["equipment"].ToString(),
                    row["status"].ToString(),
                    row["current_latitude"] == DBNull.Value ? 0.0 : Convert.ToDouble(row["current_latitude"]),
                    row["current_longitude"] == DBNull.Value ? 0.0 : Convert.ToDouble(row["current_longitude"])
                );

                ambulances.AddLast(amb);
            }

            return ambulances;
        }


        // Add ambulance (DB + LinkedList)
        public static void AddAmbulance(AmbulanceBL ambulance)
            {
            string query = "INSERT INTO ambulances (station_id, plate_number, equipment, status,current_latitude, current_longitude) " + "VALUES (@StationId, @PlateNumber, @Equipment, @Status, @Latitude, @Longitude)";
            DatabaseHelper.ExecuteNonQuery(query,
                new MySqlParameter("@StationId", ambulance.station_id),
                new MySqlParameter("@PlateNumber", ambulance.plate_number),
                new MySqlParameter("@Equipment", ambulance.equipment),
                new MySqlParameter("@Status", ambulance.status),
                new MySqlParameter("@Latitude", ambulance.current_latitude),
                new MySqlParameter("@Longitude", ambulance.current_longitude));
            ambulances.AddLast(ambulance);
        }
        // Delete ambulance (DB + LinkedList)
        public static int MarkInactive(int ambulanceId)
        {
            string query = "UPDATE ambulances SET is_active = 0 WHERE ambulance_id=@AmbulanceId";
            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query,
                new MySqlParameter("@AmbulanceId", ambulanceId)
            );

            if (rowsAffected > 0)
            {
                var node = ambulances.First;
                while (node != null)
                {
                    if (node.Value.ambulance_id == ambulanceId)
                    {
                        ambulances.Remove(node);
                        break;

                    }
                    node = node.Next;
                }
            }

            return rowsAffected;
        }


        // Update ambulance
        public static void UpdateAmbulance(AmbulanceBL ambulance)
        {
            string query = "UPDATE ambulances SET station_id=@StationId, plate_number=@PlateNumber, " + "equipment=@Equipment, status=@Status, current_latitude=@Latitude, current_longitude=@Longitude " + "WHERE ambulance_id=@AmbulanceId";
            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query,
                new MySqlParameter("@StationId", ambulance.station_id),
                new MySqlParameter("@PlateNumber", ambulance.plate_number),
                new MySqlParameter("@Equipment", ambulance.equipment),
                new MySqlParameter("@Status", ambulance.status),
                new MySqlParameter("@Latitude", ambulance.current_latitude),
                new MySqlParameter("@Longitude", ambulance.current_longitude),
                new MySqlParameter("@AmbulanceId", ambulance.ambulance_id));
            if (rowsAffected > 0)
            {
                // Update in LinkedList
                var node = ambulances.First;
                while (node != null)
                {
                    if (node.Value.ambulance_id == ambulance.ambulance_id)
                    {
                        node.Value = ambulance;
                        break;
                    }
                    node = node.Next;
                }
            }
        }
        public static void AssignedAmbulance(AmbulanceBL amb)
        {
            var existing = ambulances.FirstOrDefault(a => a.ambulance_id == amb.ambulance_id);
            if (existing != null)
            {
                existing.status = amb.status; 
                existing.station_id = amb.station_id;
                existing.plate_number = amb.plate_number;
            }
        }

    }
}

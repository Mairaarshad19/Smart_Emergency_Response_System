using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emergency_Response_System.BL;
using MySql.Data.MySqlClient;

namespace Emergency_Response_System.DL
{
    public class DispatchDL 
    { 

        public static LinkedList<DispatchBL> dispatches = new LinkedList<DispatchBL>();
        // Load all dispatches from DB into LinkedList

        public static LinkedList<DispatchBL> GetAllDispatches()
        {
            dispatches.Clear();
            string query = "SELECT * FROM dispatches";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                DispatchBL log = new DispatchBL
                {
                    DispatchId = Convert.ToInt32(row["dispatch_id"]),
                    EmergencyId = Convert.ToInt32(row["emergency_id"]),
                    AmbulanceId = Convert.ToInt32(row["ambulance_id"]),
                AssignedAt = row["assigned_at"] != DBNull.Value
                        ? Convert.ToDateTime(row["assigned_at"])
                        : DateTime.MinValue,

                    EtaMinutes = row["eta_minutes"] != DBNull.Value
                        ? Convert.ToInt32(row["eta_minutes"])
                        : 0,

                    ArrivalTime = row["arrival_time"] != DBNull.Value
                        ? Convert.ToDateTime(row["arrival_time"])
                        : (DateTime?)null,

                    Status = row["status"] != DBNull.Value
                        ? row["status"].ToString()
                        : string.Empty
                };

                dispatches.AddLast(log);
            }

            return dispatches;
        }


        public static void UndoLastDispatch()
        {
            // 1. Get the most recent dispatch
            string selectQuery = @"SELECT dispatch_id, emergency_id, ambulance_id 
                           FROM dispatches 
                           ORDER BY dispatch_id DESC LIMIT 1";

            DataTable dt = DatabaseHelper.ExecuteQuery(selectQuery);

            if (dt.Rows.Count > 0)
            {
                int dispatchId = Convert.ToInt32(dt.Rows[0]["dispatch_id"]);
                int emergencyId = Convert.ToInt32(dt.Rows[0]["emergency_id"]);
                int ambulanceId = Convert.ToInt32(dt.Rows[0]["ambulance_id"]);

                string updateDispatch = @"UPDATE dispatches 
                          SET status = 'Cancelled' 
                          WHERE dispatch_id = @DispatchId";
                DatabaseHelper.ExecuteNonQuery(updateDispatch,
                    new MySqlParameter("@DispatchId", dispatchId));


                // 3. Reset emergency status
                string updateEmergency = @"UPDATE emergencies 
                                   SET status = 'Waiting' 
                                   WHERE emergency_id = @EmergencyId";
                DatabaseHelper.ExecuteNonQuery(updateEmergency,
                    new MySqlParameter("@EmergencyId", emergencyId));

                // 4. Reset ambulance status
                string updateAmbulance = @"UPDATE ambulances 
                                   SET status = 'Available' 
                                   WHERE ambulance_id = @AmbulanceId";
                DatabaseHelper.ExecuteNonQuery(updateAmbulance,
                    new MySqlParameter("@AmbulanceId", ambulanceId));
            }
        }




        // Add dispatch (DB + LinkedList)
        public static int AddDispatch(DispatchBL log)
        {
            string query = @"INSERT INTO dispatches 
                     (emergency_id, ambulance_id, eta_minutes, arrival_time, assigned_at, status) 
                     VALUES (@EmergencyId, @AmbulanceId, @EtaMinutes, @ArrivalTime, @AssignedAt, @Status);
                     SELECT LAST_INSERT_ID();";

            object result = DatabaseHelper.ExecuteScalar(query,
                new MySqlParameter("@EmergencyId", log.EmergencyId),
                new MySqlParameter("@AmbulanceId", log.AmbulanceId),
                new MySqlParameter("@EtaMinutes", log.EtaMinutes),
                new MySqlParameter("@ArrivalTime", (object)log.ArrivalTime ?? DBNull.Value),
                new MySqlParameter("@AssignedAt", DateTime.Now),   
                new MySqlParameter("@Status", "Assigned")       
            );

            int newId = Convert.ToInt32(result);

            log.DispatchId = newId;
            log.AssignedAt = DateTime.Now;   // keep in memory too
            log.Status = "Dispatched";

            dispatches.AddLast(log);

            return newId;
        }


        // Delete dispatch (DB + LinkedList)
        public static int DeleteDispatch(int dispatchId) 
        { 
            string query = "DELETE FROM dispatches WHERE dispatch_id=@DispatchId";
            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, new MySqlParameter("@DispatchId", dispatchId) ); 
            if (rowsAffected > 0) 
            { var node = dispatches.First;
                while (node != null) 
                { 
                    if (node.Value.DispatchId == dispatchId) 
                    { 
                        dispatches.Remove(node); 
                        break;
                    } 
                    node = node.Next;
                } 
            } 
            return rowsAffected;
        } 
        // Update dispatch (DB + LinkedList)
        public static void UpdateDispatch(DispatchBL log) 
        { 
            string query = "UPDATE dispatches SET emergency_id=@EmergencyId, ambulance_id=@AmbulanceId, " 
                + "eta_minutes=@EtaMinutes, arrival_time=@ArrivalTime " 
                + "WHERE dispatch_id=@DispatchId";
            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, new MySqlParameter("@EmergencyId", log.EmergencyId),
                new MySqlParameter("@AmbulanceId", log.AmbulanceId), 
                new MySqlParameter("@EtaMinutes", log.EtaMinutes),
                new MySqlParameter("@ArrivalTime", (object)log.ArrivalTime ?? DBNull.Value), new MySqlParameter("@DispatchId", log.DispatchId) );
            if (rowsAffected > 0) 
            { 
                var node = dispatches.First; 
                while (node != null) 
                { 
                    if (node.Value.DispatchId == log.DispatchId) 
                    { 
                        node.Value = log;
                        break;
                    } 
                    node = node.Next;
                }
            }
        }
        public static void UpdateArrivalTime(int dispatchId, DateTime arrivalTime)
        {
            string query = "UPDATE dispatches SET arrival_time = @ArrivalTime WHERE dispatch_id = @DispatchId";

            DatabaseHelper.ExecuteNonQuery(query,
                new MySqlParameter("@ArrivalTime", arrivalTime),
                new MySqlParameter("@DispatchId", dispatchId)
            );
        }

    }
}
using System;
using System.Collections.Generic;
using System.Data;
using Emergency_Response_System.BL;
using MySql.Data.MySqlClient;

namespace Emergency_Response_System.DL
{
    public class RoadDL
    {
        // Returns detailed road records with all fields
        public static RoadRecord[] GetAllRoadsDetails()
        {
            string sql = "SELECT road_id, from_intersection_id, to_intersection_id, " +
                         "travel_time_minutes, status, traffic_factor, name, distance_km FROM roads";

            DataTable table = DatabaseHelper.ExecuteQuery(sql);

            RoadRecord[] roads = new RoadRecord[table.Rows.Count];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                var row = table.Rows[i];
                roads[i] = new RoadRecord
                {
                    RoadId = Convert.ToInt32(row["road_id"]),
                    FromIntersectionId = Convert.ToInt32(row["from_intersection_id"]),
                    ToIntersectionId = Convert.ToInt32(row["to_intersection_id"]),
                    TravelTimeMinutes = Convert.ToDouble(row["travel_time_minutes"]),
                    Status = row["status"].ToString(),
                    TrafficFactor = Convert.ToDouble(row["traffic_factor"]),
                    Name = row["name"] == DBNull.Value ? "" : row["name"].ToString(),
                    DistanceKm = row["distance_km"] == DBNull.Value ? 0.0 : Convert.ToDouble(row["distance_km"])
                };
            }
            return roads;
        }

        // Returns simplified BL objects
        public static List<RoadBL> GetAllRoads()
        {
            string query = "SELECT road_id, from_intersection_id, to_intersection_id, travel_time_minutes FROM roads";
            List<RoadBL> roads = new List<RoadBL>();

            using (MySqlDataReader reader = DatabaseHelper.ExecuteReader(query))
            {
                while (reader.Read())
                {
                    int roadId = reader.GetInt32("road_id");
                    int fromId = reader.GetInt32("from_intersection_id");
                    int toId = reader.GetInt32("to_intersection_id");
                    double travelTimeMinutes = reader.GetDouble("travel_time_minutes");

                    roads.Add(new RoadBL(roadId, fromId, toId, travelTimeMinutes));
                }
            }
            return roads;
        }

        public static void AddRoad(int fromIntersectionId, int toIntersectionId, double travelTimeMinutes)
        {
            string query = "INSERT INTO roads (from_intersection_id, to_intersection_id, travel_time_minutes) " +
                           "VALUES (@From, @To, @Time)";

            DatabaseHelper.ExecuteNonQuery(query,
                new MySqlParameter("@From", fromIntersectionId),
                new MySqlParameter("@To", toIntersectionId),
                new MySqlParameter("@Time", travelTimeMinutes));
        }

        public static void UpdateRoadTime(int roadId, double newTime)
        {
            string query = "UPDATE roads SET travel_time_minutes=@Time WHERE road_id=@RoadId";

            DatabaseHelper.ExecuteNonQuery(query,
                new MySqlParameter("@Time", newTime),
                new MySqlParameter("@RoadId", roadId));
        }

        public static void DeleteRoad(int roadId)
        {
            string query = "DELETE FROM roads WHERE road_id=@RoadId";

            DatabaseHelper.ExecuteNonQuery(query,
                new MySqlParameter("@RoadId", roadId));
        }
    }

    public class RoadRecord
    {
        public int RoadId { get; set; }
        public int FromIntersectionId { get; set; }
        public int ToIntersectionId { get; set; }
        public double TravelTimeMinutes { get; set; }
        public string Status { get; set; }
        public double TrafficFactor { get; set; }
        public string Name { get; set; }
        public double DistanceKm { get; set; }
    }
}

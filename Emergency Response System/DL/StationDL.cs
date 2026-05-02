using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emergency_Response_System.BL;
using MySql.Data.MySqlClient;

namespace Emergency_Response_System.DL
{
    public class StationDL
    {
        // LinkedList to store stations in memory
        public static LinkedList<StationBL> stations = new LinkedList<StationBL>();

        public static int GetIntersectionIdByStation(int stationId)
        {
            string query = "SELECT intersection_id FROM stations WHERE station_id = @StationId";

            DataTable dt = DatabaseHelper.ExecuteQuery(query,
                new MySqlParameter("@StationId", stationId));

            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["intersection_id"]);
            }
            else
            {
                throw new Exception($"No station found with ID {stationId}");
            }
        }

        public static List<(int stationId, string stationName, int ambulanceCount)> GetAmbulanceCountPerStation()
        {
            string query = @"SELECT s.station_id, s.name, COUNT(a.ambulance_id) AS ambulance_count
                     FROM stations s
                     LEFT JOIN ambulances a ON s.station_id = a.station_id
                     GROUP BY s.station_id, s.name";

            List<(int, string, int)> results = new List<(int, string, int)>();

            using (MySqlDataReader reader = DatabaseHelper.ExecuteReader(query))
            {
                while (reader.Read())
                {
                    int stationId = reader.GetInt32("station_id");
                    string name = reader.GetString("name");
                    int count = reader.GetInt32("ambulance_count");

                    results.Add((stationId, name, count));
                }
            }

            return results;
        }

        public static List<string> GetDistinctStationNames() 
        { 
            string query = "SELECT DISTINCT name FROM stations"; 
            List<string> names = new List<string>(); 
            using (MySqlDataReader reader = DatabaseHelper.ExecuteReader(query)) 
            { 
                while (reader.Read()) 
                { 
                    names.Add(reader.GetString("name")); 
                } 
            } 
            return names; 
        }

        public static List<StationBL> GetAllStations()
        {
            string query = "SELECT station_id, name, latitude, longitude, intersection_id, created_at FROM stations";
            List<StationBL> stations = new List<StationBL>();

            using (MySqlDataReader reader = DatabaseHelper.ExecuteReader(query))
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32("station_id");
                    string name = reader.GetString("name");

                    double latitude = (double)reader.GetDecimal(reader.GetOrdinal("latitude"));
                    double longitude = (double)reader.GetDecimal(reader.GetOrdinal("longitude"));

                    DateTime createdAt = reader.GetDateTime(reader.GetOrdinal("created_at"));

                    int intersectionId = reader.IsDBNull(reader.GetOrdinal("intersection_id"))
                        ? -1
                        : reader.GetInt32(reader.GetOrdinal("intersection_id"));
                    stations.Add(new StationBL(id, name, latitude, longitude, createdAt, intersectionId));
                }
            }
            return stations;
        }

        // Add station
        public static void AddStation(StationBL station)
        {
            string query = "INSERT INTO stations (name, latitude, longitude) " +
                           "VALUES (@Name, @Latitude, @Longitude)";

            DatabaseHelper.ExecuteNonQuery(query,
                new MySqlParameter("@Name", station.name),
                new MySqlParameter("@Latitude", station.latitude),
                new MySqlParameter("@Longitude", station.longitude)
            );

            stations.AddLast(station);
        }

        // Update station
        public static void UpdateStation(StationBL station)
        {
            string query = "UPDATE stations SET name=@Name, latitude=@Latitude, longitude=@Longitude " +
                           "WHERE station_id=@StationId";

            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query,
                new MySqlParameter("@Name", station.name),
                new MySqlParameter("@Latitude", station.latitude),
                new MySqlParameter("@Longitude", station.longitude),
                new MySqlParameter("@StationId", station.station_id)
            );

            if (rowsAffected > 0)
            {
                var node = stations.First;
                while (node != null)
                {
                    if (node.Value.station_id == station.station_id)
                    {
                        node.Value = station;
                        break;
                    }
                    node = node.Next;
                }
            }
        }

        // Delete station
        public static int DeleteStation(int stationId)
        {
            string query = "DELETE FROM stations WHERE station_id=@StationId";
            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query,
                new MySqlParameter("@StationId", stationId)
            );

            if (rowsAffected > 0)
            {
                var node = stations.First;
                while (node != null)
                {
                    if (node.Value.station_id == stationId)
                    {
                        stations.Remove(node);
                        break;
                    }
                    node = node.Next;
                }
            }
            return rowsAffected;
        }
    }
}

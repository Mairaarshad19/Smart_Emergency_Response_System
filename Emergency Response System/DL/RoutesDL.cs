using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emergency_Response_System.BL;
using MySql.Data.MySqlClient;

namespace Emergency_Response_System.DL
{
    public static class RouteDL
    {
        public static List<RouteBL> GetAllRoutes()
        {
            string query = "SELECT route_id, dispatch_id, path, total_distance, total_time FROM routes";
            List<RouteBL> routes = new List<RouteBL>();

            using (MySqlDataReader reader = DatabaseHelper.ExecuteReader(query))
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32("route_id");
                    int dispatchId = reader.GetInt32("dispatch_id");
                    string path = reader.GetString("path");
                    double distance = reader.GetDouble("total_distance");
                    int time = reader.GetInt32("total_time");

                    routes.Add(new RouteBL(id, dispatchId, path, distance, time));
                }
            }
            return routes;
        }

        public static void AddRoute(RouteBL route)
        {
            string query = @"INSERT INTO routes (dispatch_id, path, total_distance, total_time)
                         VALUES (@DispatchId, @Path, @Distance, @Time)";
            DatabaseHelper.ExecuteNonQuery(query,
                new MySqlParameter("@DispatchId", route.DispatchId),
                new MySqlParameter("@Path", route.Path),
                new MySqlParameter("@Distance", route.TotalDistance),
                new MySqlParameter("@Time", route.TotalTime));
        }
    }

}

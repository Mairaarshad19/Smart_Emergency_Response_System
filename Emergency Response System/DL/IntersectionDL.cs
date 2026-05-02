using System;
using System.Collections.Generic;
using System.Data;
using Emergency_Response_System.BL;
using MySql.Data.MySqlClient;

namespace Emergency_Response_System.DL
{
    public class IntersectionDL
    {
        // Get maximum intersection_id
        public static int GetMaxId()
        {
            string sql = "SELECT MAX(intersection_id) FROM intersections";
            object result = DatabaseHelper.ExecuteScalar(sql);

            return result == DBNull.Value ? 0 : Convert.ToInt32(result);
        }

        // Get all intersections
        public static LinkedList<IntersectionBL> GetAllIntersections()
        {
            string query = "SELECT intersection_id, name FROM intersections";
            LinkedList<IntersectionBL> intersections = new LinkedList<IntersectionBL>();

            using (MySqlDataReader reader = DatabaseHelper.ExecuteReader(query))
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32("intersection_id");
                    string name = reader.GetString("name");

                    intersections.AddLast(new IntersectionBL(id, name));
                }
            }
            return intersections;
        }


        public class IntersectionRecord
        {
            public int IntersectionId { get; set; }
            public string Name { get; set; }
        }
    }
}
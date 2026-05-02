using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emergency_Response_System.BL;
using Emergency_Response_System.BL.DSA;
using Emergency_Response_System.DL;
using Emergency_Response_System.Helpers;

namespace Emergency_Response_System.Managers
{
    public static class StationManager
    {
        private static StationAVLTree tree = new StationAVLTree();
        private static StationHashTable table = new StationHashTable(2048);

        private static int nextId = 1;
        public static int GenerateStationId() => nextId++;

        public static void CreateStation(CityGraph graph, string name, int intersectionId, double lat, double lng, string plateno)
        {
            int stationId = GenerateStationId();

            StationBL station = new StationBL
            {
                station_id = stationId,
                name = name,
                IntersectionId = intersectionId,
                latitude = lat,
                longitude = lng,
                plate_no = plateno  
            };

            tree.Insert(station);
            table.Put(stationId, station);
        }

        public static StationBL GetById(int stationId) => table.Get(stationId);

        public static void UpdateStation(int stationId, Action<StationBL> mutate)
        {
            StationBL s = table.Get(stationId);
            if (s != null) mutate(s);
        }

        public static bool DeleteStation(int stationId)
        {
            StationBL s = table.Get(stationId);
            if (s == null) return false;

            bool removed = table.Remove(stationId);
            tree.Delete(stationId);
            return removed;
        }

        public static void ForEachSorted(Action<StationBL> visit) => tree.InOrder(visit);

        // LinkedList to store stations in memory
        public static LinkedList<StationBL> Stations = new LinkedList<StationBL>();

        public static int GetMappedIntersectionId(string stationName)
        {
            foreach (var station in Stations) 
            { 
                if (station.name.Equals(stationName, StringComparison.OrdinalIgnoreCase)) 
                { 
                    return station.IntersectionId; 
                } 
            }
            return -1; 
            // Not found
            } 
        // Add station in memory only (used after DB insert)
        public static void AddStation(StationBL station)
        {
            Stations.AddLast(station);
        }
        public static void LoadStations()
        {
            Stations.Clear(); // clear old data
            foreach (var station in StationDL.GetAllStations()) 
            { 
                Stations.AddLast(station);
            } 
        }
        }
}

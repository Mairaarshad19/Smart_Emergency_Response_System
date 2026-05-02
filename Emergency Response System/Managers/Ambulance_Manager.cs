using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emergency_Response_System.BL;
using Emergency_Response_System.BL.Emergency_Response_System.BL;
using Emergency_Response_System.DL;
using Emergency_Response_System.Helpers;

namespace Emergency_Response_System.Managers
{
    public static class AmbulanceManager
    {
        public static LinkedList<AmbulanceBL> Ambulances = new LinkedList<AmbulanceBL>();

        private static AmbulanceNode head;
        private class AmbulanceNode
        {
            public AmbulanceBL Data;
            public AmbulanceNode Next;
            public AmbulanceNode(AmbulanceBL amb) { Data = amb; Next = null; }
        }
        public static void LoadAmbulances()
        {
            Ambulances.Clear();
            var list = DL.AmbulanceDL.GetAllAmbulances();
            foreach (var amb in list)
            {
                Ambulances.AddLast(amb);
            }
        }

        // Remove ambulance by ID (only in memory)
        public static void RemoveAmbulance(int ambulanceId)
        {
            var node = Ambulances.First;
            while (node != null)
            {
                if (node.Value.ambulance_id == ambulanceId)
                {
                    Ambulances.Remove(node);
                    break;
                }
                node = node.Next;
            }
        }

        public static void AddAmbulance(AmbulanceBL amb)
        {
            AmbulanceNode newNode = new AmbulanceNode(amb);
            newNode.Next = head;
            head = newNode;
        }

        public static int CountByStation(int stationId)
        {
            int count = 0;
            AmbulanceNode current = head;

            while (current != null)
            {
                if (current.Data.station_id == stationId)
                {
                    count++;
                }
                current = current.Next;
            }

            return count;
        }

        // Optional: Get all ambulances for a station
        public static AmbulanceBL[] GetByStation(int stationId)
        {
            // Count first
            int count = CountByStation(stationId);
            AmbulanceBL[] result = new AmbulanceBL[count];
            int index = 0;

            AmbulanceNode current = head;
            while (current != null)
            {
                if (current.Data.station_id == stationId)
                {
                    result[index++] = current.Data;
                }
                current = current.Next;
            }

            return result;
        }
    }
}

    // LinkedList to store ambulances in memory


    // Load from DB into LinkedList
    /*public static AmbulanceBL[] GetPrioritizedAmbulances(GraphBL cityGraph, int emergencyIntersection)
    {
        // Step 1: Load ambulances into linked list
        AmbulanceLinkedList list = new AmbulanceLinkedList();
        foreach (var amb in AmbulanceDL.GetAllAmbulances())
        {
            list.Add(amb);
        }

        // Step 2: Convert to array
        AmbulanceBL[] ambulances = list.ToArrayManual();

        // Step 3: Compute ETA for each ambulance
        for (int i = 0; i < ambulances.Length; i++)
        {
            int startIntersection = StationDL.GetIntersectionIdByStation(ambulances[i].station_id);
            int endIntersection = emergencyIntersection;

            int startIndex = cityGraph.GetIndexById(startIntersection); // implement in GraphBL
            int endIndex = cityGraph.GetIndexById(endIntersection);

            double routeTime = GraphAlgorithms.FindFastestRoute(cityGraph, startIndex, endIndex);

            ambulances[i].EtaMinutes = (routeTime <= 0 || double.IsInfinity(routeTime))
                ? int.MaxValue
                : (int)Math.Min(routeTime + 0.5, int.MaxValue);
        }

        // Step 4: Sort by ETA
        SortManager.QuickSortAmbulances(ambulances, 0, ambulances.Length - 1);

        return ambulances;
    }
    */

        
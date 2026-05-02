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
    public static class SortManager
    {
        public static void QuickSortEmergencies(List<EmergencyBL> emergencies, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = PartitionEmergencies(emergencies, low, high);
                QuickSortEmergencies(emergencies, low, pivotIndex - 1);
                QuickSortEmergencies(emergencies, pivotIndex + 1, high);
            }
        }

        private static int PartitionEmergencies(List<EmergencyBL> emergencies, int low, int high)
        {
            int pivot = SeverityHelper.GetSeverityRank(emergencies[high].severity);
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (SeverityHelper.GetSeverityRank(emergencies[j].severity) >= pivot)
                {
                    i++;
                    EmergencyBL temp = emergencies[i];
                    emergencies[i] = emergencies[j];
                    emergencies[j] = temp;
                }
            }

            EmergencyBL temp2 = emergencies[i + 1];
            emergencies[i + 1] = emergencies[high];
            emergencies[high] = temp2;

            return i + 1;
        }
        public static List<EmergencyBL> GetPrioritizedEmergencies()
        {
            var emergenciesLinked = EmergencyDL.GetAllEmergencies(); // returns LinkedList<EmergencyBL>
            var emergencies = emergenciesLinked.ToList();            // convert to List<EmergencyBL>

            QuickSortEmergencies(emergencies, 0, emergencies.Count - 1);
            return emergencies;
        }
        public static void QuickSortAmbulances(AmbulanceBL[] arr, int low, int high)
        {
            if (low < high)
            {
                int p = PartitionAmbulances(arr, low, high);
                QuickSortAmbulances(arr, low, p - 1);
                QuickSortAmbulances(arr, p + 1, high);
            }
        }

        private static int PartitionAmbulances(AmbulanceBL[] arr, int low, int high)
        {
            int pivot = arr[high].EtaMinutes;
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (arr[j].EtaMinutes <= pivot)
                {
                    i++;
                    AmbulanceBL t = arr[i];
                    arr[i] = arr[j];
                    arr[j] = t;
                }
            }

            AmbulanceBL t2 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = t2;

            return i + 1;
        }
    }
}

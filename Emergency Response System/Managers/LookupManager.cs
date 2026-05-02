using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emergency_Response_System.BL;
using Emergency_Response_System.DL;

namespace Emergency_Response_System.Managers
{
    public static class LookupManager
    {
        private static HashTable<int, AmbulanceBL> ambulanceTable = new HashTable<int, AmbulanceBL>(50);
        private static HashTable<int, EmergencyBL> emergencyTable = new HashTable<int, EmergencyBL>(50);

        public static void LoadData()
        {
            // Load ambulances
            foreach (var amb in AmbulanceDL.GetAllAmbulances())
            {
                ambulanceTable.Insert(amb.ambulance_id, amb);
            }

            // Load emergencies
            foreach (var em in EmergencyDL.GetAllEmergencies())
            {
                emergencyTable.Insert(em.emergency_id, em);
            }
        }

        public static AmbulanceBL GetAmbulanceById(int id)
        {
            return ambulanceTable.Search(id);
        }

        public static EmergencyBL GetEmergencyById(int id)
        {
            return emergencyTable.Search(id);
        }
    }
}

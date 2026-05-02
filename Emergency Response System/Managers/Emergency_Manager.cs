using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emergency_Response_System.BL;
using Emergency_Response_System.DL;

namespace Emergency_Response_System.Managers
{
    public static class EmergencyManager
    {
        public static Queue<EmergencyBL> Emergencies = new Queue<EmergencyBL>();

        public static Queue<EmergencyBL> SearchEmergenciesByLocation(int intersectionId)
        {
            return EmergencyBL.FindEmergenciesAtLocation(intersectionId);
        }

        public static void LoadEmergencies()
        {
            Emergencies.Clear();
            var list = DL.EmergencyDL.emergencies; 
            foreach (var em in list)
            {
                Emergencies.Enqueue(em);
            }
        }

        // Add emergency (in memory only)
        public static void AddEmergency(EmergencyBL emergency)
        {
            Emergencies.Enqueue(emergency);
        }

        // Process next emergency (FIFO)
        public static EmergencyBL ProcessNextEmergency()
        {
            if (Emergencies.Count > 0)
            {
                return Emergencies.Dequeue();
            }
            return null;
        }

        // Peek at next emergency without removing
        public static EmergencyBL PeekNextEmergency()
        {
            if (Emergencies.Count > 0)
            {
                return Emergencies.Peek();
            }
            return null;
        }

        // Remove emergency by ID (in memory only)
        public static void RemoveEmergency(int emergencyId)
        {
            Queue<EmergencyBL> tempQueue = new Queue<EmergencyBL>();
            while (Emergencies.Count > 0)
            {
                EmergencyBL em = Emergencies.Dequeue();
                if (em.emergency_id != emergencyId)
                {
                    tempQueue.Enqueue(em);
                }
            }
            Emergencies = tempQueue;
        }
    }
}

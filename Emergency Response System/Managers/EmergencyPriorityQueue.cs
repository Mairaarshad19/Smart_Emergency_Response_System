using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emergency_Response_System.BL;

namespace Emergency_Response_System.UI
{
    public class EmergencyPriorityQueue
    {
        private List<EmergencyBL> queue;

        public EmergencyPriorityQueue()
        {
            queue = new List<EmergencyBL>();
        }

        // Insert emergency into queue
        public void Enqueue(EmergencyBL emergency)
        {
            // Add to list
            queue.Add(emergency);

            // Manual insertion sort based on priority
            int i = queue.Count - 1;
            while (i > 0 && queue[i].GetPriorityLevel() < queue[i - 1].GetPriorityLevel())
            {
                // Swap
                var temp = queue[i];
                queue[i] = queue[i - 1];
                queue[i - 1] = temp;
                i--;
            }
        }

        // Remove highest priority (front of queue)
        public EmergencyBL Dequeue()
        {
            if (IsEmpty()) return null;

            EmergencyBL emergency = queue[0];
            queue.RemoveAt(0);
            return emergency;
        }

        // Peek at highest priority without removing
        public EmergencyBL Peek()
        {
            return IsEmpty() ? null : queue[0];
        }

        // Check if queue is empty
        public bool IsEmpty()
        {
            return queue.Count == 0;
        }

        // Get count
        public int Count()
        {
            return queue.Count;
        }

        // Display queue (for debugging / showing in UI)
        public List<EmergencyBL> GetAll()
        {
            return new List<EmergencyBL>(queue);
        }
    }
}

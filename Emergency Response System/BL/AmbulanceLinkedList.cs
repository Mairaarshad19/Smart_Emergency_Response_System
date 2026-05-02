using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergency_Response_System.BL
{
    namespace Emergency_Response_System.BL
    {
        public class AmbulanceNode
        {
            public AmbulanceBL data;
            public AmbulanceNode next;

            public AmbulanceNode(AmbulanceBL amb)
            {
                data = amb;
                next = null;
            }
        }

        public class AmbulanceLinkedList
        {
            public AmbulanceNode head;

            public void Add(AmbulanceBL amb)
            {
                AmbulanceNode node = new AmbulanceNode(amb);
                if (head == null) head = node;
                else
                {
                    AmbulanceNode temp = head;
                    while (temp.next != null) temp = temp.next;
                    temp.next = node;
                }
            }

                // Convert linked list to array manually
            public AmbulanceBL[] ToArrayManual()
            {
                List<AmbulanceBL> result = new List<AmbulanceBL>();
                AmbulanceNode temp = head;
                while (temp != null)
                {
                    result.Add(temp.data);
                    temp = temp.next;
                }
                return result.ToArray();
            }
        }
    }
}

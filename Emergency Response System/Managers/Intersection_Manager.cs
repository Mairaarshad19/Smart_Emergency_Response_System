using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emergency_Response_System.BL;
using Emergency_Response_System.DL;

namespace Emergency_Response_System.Managers
{
    public static class IntersectionManager
    {
        public static LinkedList<IntersectionBL> Intersections = new LinkedList<IntersectionBL>();

        public static void LoadIntersections()
        {
            Intersections.Clear();
            foreach (var intersection in IntersectionDL.GetAllIntersections())
            {
                Intersections.AddLast(intersection); // FIX: AddLast
            }
        }

        // Find by name (manual traversal; replaces Exists + lambda)
        public static int GetIntersectionIdByName(string name)
        {
            foreach (var intersection in Intersections)
            {
                if (intersection.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    return intersection.Id;
            }
            return -1;
        }

        // Exists by name (manual check; replaces Exists)
        public static bool ExistsByName(string name)
        {
            foreach (var intersection in Intersections)
            {
                if (intersection.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        // Get by index (if you really need index-style access)
        public static IntersectionBL GetByIndex(int index)
        {
            int i = 0;
            var node = Intersections.First;
            while (node != null)
            {
                if (i == index) return node.Value;
                i++;
                node = node.Next;
            }
            throw new IndexOutOfRangeException("Index out of bounds for Intersections linked list.");
        }

        // Convert to array (for algorithms that need indexing like Quick Sort)
        public static IntersectionBL[] ToArrayManual()
        {
            int count = Intersections.Count;
            var arr = new IntersectionBL[count];
            int i = 0;
            var node = Intersections.First;
            while (node != null)
            {
                arr[i++] = node.Value;
                node = node.Next;
            }
            return arr;
        }
    }

}

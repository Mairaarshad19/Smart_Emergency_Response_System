using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergency_Response_System.BL.DSA
{
    public class StationHashTable
    {
        private StationEntry[] buckets;
        private int capacity;

        public StationHashTable(int capacity = 1024)
        {
            this.capacity = capacity;
            buckets = new StationEntry[capacity];
        }

        private int Hash(int key) => (key & 0x7FFFFFFF) % capacity;

        public void Put(int key, StationBL value)
        {
            int idx = Hash(key);
            StationEntry head = buckets[idx];

            if (head == null) { buckets[idx] = new StationEntry(key, value); return; }

            StationEntry cur = head;
            while (true)
            {
                if (cur.Key == key) { cur.Value = value; return; } // update
                if (cur.Next == null) { cur.Next = new StationEntry(key, value); return; }
                cur = cur.Next;
            }
        }

        public StationBL Get(int key)
        {
            int idx = Hash(key);
            StationEntry cur = buckets[idx];
            while (cur != null)
            {
                if (cur.Key == key) return cur.Value;
                cur = cur.Next;
            }
            return null;
        }

        public bool Remove(int key)
        {
            int idx = Hash(key);
            StationEntry cur = buckets[idx], prev = null;

            while (cur != null)
            {
                if (cur.Key == key)
                {
                    if (prev == null) buckets[idx] = cur.Next;
                    else prev.Next = cur.Next;
                    return true;
                }
                prev = cur; cur = cur.Next;
            }
            return false;
        }
    }
}

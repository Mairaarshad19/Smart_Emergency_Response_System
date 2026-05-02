using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emergency_Response_System.BL;

namespace Emergency_Response_System.Managers
{
    public class HashTable<K, V>
    {
        private int size;
        private HashNode<K, V>[] buckets;

        public HashTable(int size)
        {
            this.size = size;
            buckets = new HashNode<K, V>[size];
        }

        // Hash function
        private int GetBucketIndex(K key)
        {
            int hashCode = key.GetHashCode();
            return Math.Abs(hashCode % size);
        }

        // Insert
        public void Insert(K key, V value)
        {
            int index = GetBucketIndex(key);
            HashNode<K, V> newNode = new HashNode<K, V>(key, value);

            if (buckets[index] == null)
            {
                buckets[index] = newNode;
            }
            else
            {
                HashNode<K, V> current = buckets[index];
                while (current.Next != null)
                {
                    if (current.Key.Equals(key))
                    {
                        current.Value = value; // update existing
                        return;
                    }
                    current = current.Next;
                }
                current.Next = newNode; // add at end
            }
        }

        // Search
        public V Search(K key)
        {
            int index = GetBucketIndex(key);
            HashNode<K, V> current = buckets[index];

            while (current != null)
            {
                if (current.Key.Equals(key))
                {
                    return current.Value;
                }
                current = current.Next;
            }
            return default(V); // not found
        }

        // Delete
        public void Delete(K key)
        {
            int index = GetBucketIndex(key);
            HashNode<K, V> current = buckets[index];
            HashNode<K, V> prev = null;

            while (current != null)
            {
                if (current.Key.Equals(key))
                {
                    if (prev == null)
                    {
                        buckets[index] = current.Next;
                    }
                    else
                    {
                        prev.Next = current.Next;
                    }
                    return;
                }
                prev = current;
                current = current.Next;
            }
        }
    }
}

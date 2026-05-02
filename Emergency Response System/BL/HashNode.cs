using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergency_Response_System.BL
{
    public class HashNode<K, V>
    {
        public K Key { get; set; }
        public V Value { get; set; }
        public HashNode<K, V> Next { get; set; }

        public HashNode(K key, V value)
        {
            Key = key;
            Value = value;
            Next = null;
        }
    }

}

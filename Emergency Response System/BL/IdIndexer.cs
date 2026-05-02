using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergency_Response_System.BL
{
    public class IdIndexer
    {
        private readonly Dictionary<int, int> _map = new Dictionary<int, int>();
        private readonly List<int> _rev = new List<int>(); // 1-based reverse map

        public int GetOrAdd(int id)
        {
            if (_map.TryGetValue(id, out int idx)) return idx;
            int newIdx = _map.Count + 1;
            _map[id] = newIdx;
            _rev.Add(id); // index (newIdx) stored at _rev[newIdx-1]
            return newIdx;
        }

        public int Count => _map.Count;

        public int ToIndex(int id) => _map[id];

        public int ToOriginal(int idx) => _rev[idx - 1];
    }

}

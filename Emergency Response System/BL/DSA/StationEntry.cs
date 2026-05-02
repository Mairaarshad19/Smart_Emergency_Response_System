using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergency_Response_System.BL.DSA
{
    public class StationEntry
    {
        public int Key; // station_id
        public StationBL Value;
        public StationEntry Next;

        public StationEntry(int key, StationBL value)
        {
            Key = key; Value = value; Next = null;
        }
    }
}

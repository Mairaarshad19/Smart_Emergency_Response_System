using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergency_Response_System.BL
{
    public class StationNode
    {
        public StationBL Data;
        public StationNode Left;
        public StationNode Right;
        public int Height; // needed for AVL balancing

        public StationNode(StationBL station)
        {
            Data = station;
            Left = null;
            Right = null;
            Height = 1;
        }
    }

}

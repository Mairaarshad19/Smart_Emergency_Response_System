using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emergency_Response_System.BL;
using Emergency_Response_System.DL;

namespace Emergency_Response_System.Managers
{
    public class DispatchManager
    {
        public static LinkedList<DispatchBL> GetCurrentAssignments()
        {
            return DispatchBL.GetCurrentAssignments();
        }

    }

}
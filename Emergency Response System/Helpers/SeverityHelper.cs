using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergency_Response_System.Helpers
{
    public static class SeverityHelper
    {
        public static int GetSeverityRank(string severity)
        {
            switch (severity.ToLower())
            {
                case "critical": return 4;
                case "high": return 3;
                case "medium": return 2;
                case "low": return 1;
                default: return 0;
            }
        }
    }

}

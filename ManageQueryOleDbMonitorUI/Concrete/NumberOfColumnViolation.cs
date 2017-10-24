using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageQueryOleDbMonitorUI.Concrete
{
    public class NumberOfColumnViolation : ITestReport
    {
        private static NumberOfColumnViolation _instance;
        public static NumberOfColumnViolation Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new NumberOfColumnViolation();
                }
                return _instance;
            }
        }
        public string UiText()
        {
            return "Number Of Columns is invialid, please rewrite your query";
        }
    }
}

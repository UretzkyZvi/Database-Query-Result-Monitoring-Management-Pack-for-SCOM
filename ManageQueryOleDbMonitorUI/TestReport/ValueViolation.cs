using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageQueryOleDbMonitorUI.TestReport
{
    public class ValueViolation : ITestReport
    {
        private static ValueViolation _instance;
        public static ValueViolation Instance
        {
            get
            {
                if (_instance==null)
                {
                    _instance = new ValueViolation();
                }
                return _instance;
            }
        }
        public string UiText()
        {
            return "Numerical value violation, to be able to do all the magic. query must return numerical value";
        }
    }
}

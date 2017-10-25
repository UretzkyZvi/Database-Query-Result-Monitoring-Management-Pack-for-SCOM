using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageQueryOleDbMonitorUI.TestReport
{
    public class RowsViolation : ITestReport
    {
        private static RowsViolation _instance;
        public static RowsViolation Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new RowsViolation();
                return _instance;
            }
        }
        public RowsViolation() { }
        public string UiText()
        {
            return "Number of rows violation";
        }
    }
}

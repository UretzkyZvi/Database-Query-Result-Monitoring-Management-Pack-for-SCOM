using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageQueryOleDbMonitorUI.Concrete
{
    public class NumberOfRowsViolation: ITestReport
    {
        private static NumberOfRowsViolation _instance;
        public static NumberOfRowsViolation Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new NumberOfRowsViolation();
                }
                return _instance;
            }
        }

        public string UiText()
        {
            return "Number of rows violation";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageQueryOleDbMonitorUI.Concrete
{
    public class NumericalValueViolation : ITestReport
    {
        private static NumericalValueViolation _instance;
        public static NumericalValueViolation Instance
        {
            get
            {
                if (_instance==null)
                {
                    _instance = new NumericalValueViolation();
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

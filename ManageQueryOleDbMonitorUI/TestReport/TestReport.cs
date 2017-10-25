using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageQueryOleDbMonitorUI.TestReport
{
    public class TestReport : ITestReport
    {
        public int value { get; set; }

        public TestReport(int value)
        {
            this.value = value;
        }

        public string UiText()
        {
            return "Succeeded test return value is:" + value;
        }
    }
}

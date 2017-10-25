using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageQueryOleDbMonitorUI.TestReport
{
    public class ErrorTest : ITestReport
    {
        
        private string value { get; set; }

        public ErrorTest(string value)
        {
            this.value = value;
        }

        public string UiText()
        {
            return "Error test: " + value;
        }
    }
}

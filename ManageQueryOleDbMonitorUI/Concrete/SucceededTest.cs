using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageQueryOleDbMonitorUI.Concrete
{
    class SucceededTest : ITestReport
    {
        public int value { get; set; }

        public SucceededTest(int value)
        {
            this.value = value;
        }

        public string UiText()
        {
            return "Succeeded test return value is:" + value;
        }
    }
}

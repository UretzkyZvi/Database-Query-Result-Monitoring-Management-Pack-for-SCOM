using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageQueryOleDbMonitorUI.TestReport
{
    public class ColumnViolation : ITestReport
    {
        private readonly int currentLength;

        public ColumnViolation(int currentLength)
        {
            this.currentLength = currentLength;
        }
        public string UiText()
        {
            return string.Format("Current number Of Columns is {0} and it invialid, please rewrite your query", currentLength);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageQueryOleDbMonitorUI.TestReport
{
    public class TestReportFactory : ITestReportFactory
    {
        public ITestReport CreateColumnValidation(int columnLenght)
        {
            return new ColumnViolation(columnLenght);
        }

        public ITestReport CreateErrorTest(string Error)
        {
            return new ErrorTest(Error);
        }

        public ITestReport CreateRowsValidation()
        {
            return RowsViolation.Instance;
        }

        public ITestReport CreateTestReport(int value)
        {
            return new TestReport(value);
        }

        public ITestReport CreateValueValidation()
        {
            return ValueViolation.Instance;
        }
    }
}

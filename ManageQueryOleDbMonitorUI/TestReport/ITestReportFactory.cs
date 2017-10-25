using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageQueryOleDbMonitorUI.TestReport
{
    public interface ITestReportFactory
    {
        ITestReport CreateColumnValidation(int columnLenght);
        ITestReport CreateRowsValidation();
        ITestReport CreateValueValidation();
        ITestReport CreateErrorTest(string Error);
        ITestReport CreateTestReport(int value);
    }
}

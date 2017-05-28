using Microsoft.EnterpriseManagement;
using Microsoft.EnterpriseManagement.Common;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageSCOMOleDbQueryMonitor
{
    public static class SqlStringExtensions
    {
        public static bool IsValidSql(this string str)
        {
            return !str.ValidateSql().Any();
        }

        public static IEnumerable<string> ValidateSql(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return new[] { "SQL query should be non empty." };
            }
            var parser = new TSql120Parser(false);
            IList<ParseError> errors;
            using (var reader = new StringReader(str))
            {
                parser.Parse(reader, out errors);
            }
            return errors.Select(err => err.Message);
        }
    }
    public enum DaysMask
    {
        Sunday = 1,
        Monday = 2,
        Tuesday = 4,
        Wednesday = 8,
        Thursday = 16,
        Friday = 32,
        Saturday = 64
    }

    public class QueryData
    {
        public string Database { get; set; }
        public string ConnectionString { get; set; }
        public string Query { get; set; }
    }

    public class MonitorDifinition
    {
        public string StartDay { get; set; }
        public string EndDay { get; set; }
        public string SyncTime { get; set; }
        public int IntervalSeconds { get; set; }
        public int DaysOfWeekMask { get; set; }
        public string GroupName { get; set; }
        public string QueryName { get; set; }
        public string ErrorMessage { get; set; }
        public string MetricType { get; set; }
        public string Direction { get; set; }
        public int Samples { get; set; }
        public double Threshold { get; set; }
    }


    public class SharedData
    {
        public ManagementGroup MGConnection { get; set; }
        public EnterpriseManagementObject DBEngine { get; set; }
        public QueryData QueryDataInfo { get; set; }
        public MonitorDifinition MonitorDifinitionInfo { get; set; }
    }
}

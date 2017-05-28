using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageSCOMOleDbQueryMonitor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SharedData data = new SharedData();
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (!string.IsNullOrEmpty(config.AppSettings.Settings["ConnectionServer"].ToString()))
            {
                try
                {
                   data.MGConnection =
                         new Microsoft.EnterpriseManagement.ManagementGroup(ConfigurationManager.AppSettings["ConnectionServer"]);
                }
                catch
                {
                    Connection con = new Connection(data);
                    con.ShowDialog();
                }
            }
            else
            {
                Connection con = new Connection(data);
                con.ShowDialog();
            }
            Application.Run(new ManageOleDBQuery(data));
        }
    }
}

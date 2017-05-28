using BrightIdeasSoftware;
using ComponentFactory.Krypton.Ribbon;
using ComponentFactory.Krypton.Toolkit;
using Microsoft.EnterpriseManagement.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageSCOMOleDbQueryMonitor
{
    public partial class ManageOleDBQuery : KryptonForm
    {
        private SharedData data;
        private SCOMSDKWrapper sdk;
        public ManageOleDBQuery()
        {
            InitializeComponent();
        }

        public ManageOleDBQuery(SharedData data) : this()
        {
            this.data = data;

            if (data.MGConnection != null)
            {
                if (sdk == null)
                {
                    sdk = new SCOMSDKWrapper(data);
                }

                SetupOLVTable();
            }
        }

        private void SetupOLVTable()
        {
            IObjectReader<EnterpriseManagementObject> reader = sdk.GetEnterpriseManagementObjects("OleDBQueryMonitoring", "QueryOleDbMonitorLibrary");
            List<OleDBObject> lstOleDBObjects = new List<OleDBObject>();
            foreach (EnterpriseManagementObject item in reader)
            {
                OleDBObject OleDBObj = new OleDBObject();
                OleDBObj.UniqueID = Guid.Parse(item.Id.ToString());
                OleDBObj.Instance = item.Values.Where(x => x.Type.Name == "Instance").FirstOrDefault().Value.ToString();
                OleDBObj.StartDay = item.Values.Where(x => x.Type.Name == "StartDay").FirstOrDefault().Value.ToString();
                OleDBObj.EndDay = item.Values.Where(x => x.Type.Name == "EndDay").FirstOrDefault().Value.ToString();
                OleDBObj.DaysOfWeekMask = int.Parse(item.Values.Where(x => x.Type.Name == "DaysOfWeekMask").FirstOrDefault().Value.ToString());
                OleDBObj.Query = item.Values.Where(x => x.Type.Name == "Query").FirstOrDefault().Value.ToString();
                OleDBObj.QueryName = item.Values.Where(x => x.Type.Name == "QueryName").FirstOrDefault().Value.ToString();
                OleDBObj.GroupName = item.Values.Where(x => x.Type.Name == "GroupName").FirstOrDefault().Value.ToString();
                OleDBObj.Direction = item.Values.Where(x => x.Type.Name == "Direction").FirstOrDefault().Value.ToString();
                OleDBObj.Samples = int.Parse(item.Values.Where(x => x.Type.Name == "Samples").FirstOrDefault().Value.ToString());
                OleDBObj.Threshold = double.Parse(item.Values.Where(x => x.Type.Name == "Threshold").FirstOrDefault().Value.ToString());
                lstOleDBObjects.Add(OleDBObj);
            }

            tblOleDBQueries.SetObjects(lstOleDBObjects);
            tblOleDBQueries.UseFiltering = true;
        }

        private void cmdAddQuery_Execute(object sender, EventArgs e)
        {
            ImportToSCOM frm = new ImportToSCOM(data);
            frm.ShowDialog();
        }

        private void tblOleDBQueries_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (tblOleDBQueries.CheckedItems.Count > 0)
            {
                btnRemove.Visible = true;

            }
            else
            {
                btnRemove.Visible = false;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (OLVListItem item in tblOleDBQueries.CheckedItems)
            {
                sdk.DeleteInstanceWithGroup(((OleDBObject)item.RowObject).UniqueID, ((OleDBObject)item.RowObject).GroupName);
            }
            SetupOLVTable();
        }

        private void tblOleDBQueries_ItemsChanged(object sender, ItemsChangedEventArgs e)
        {
            ObjectListView olvTbl = sender as ObjectListView;
            if (olvTbl.Items.Count == 0)
            {
                btnRemove.Visible = false;
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            tblOleDBQueries.ModelFilter = new ModelFilter(delegate (object x)
            {
                OleDBObject oledb = x as OleDBObject;
                KryptonRibbonGroupTextBox txt = sender as KryptonRibbonGroupTextBox;
                return x != null && (oledb.Instance.Contains(txt.Text));
            });
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SetupOLVTable();
        }

        private void krpBtnConnection_Click(object sender, EventArgs e)
        {
            Connection con = new Connection(data);
            con.ShowDialog();
        }
    }

    public class OleDBObject
    {

        public Guid UniqueID { get; set; }
        public string Instance { get; set; }
        public string StartDay { get; set; }
        public string EndDay { get; set; }
        public int DaysOfWeekMask { get; set; }
        public string Query { get; set; }
        public string QueryName { get; set; }
        public string GroupName { get; set; }
        public string Direction { get; set; }
        public int Samples { get; set; }
        public double Threshold { get; set; }
    }
}

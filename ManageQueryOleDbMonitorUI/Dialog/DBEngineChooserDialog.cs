using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EnterpriseManagement.Mom.Internal.UI;
using Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls;

namespace ManageQueryOleDbMonitorUI
{
    public partial class DBEngineChooserDialog : AsyncSimpleChooserDialog
    {

        public DBEngineChooserDialog(IContainer parentContainer) : base(new DBEnginePickerControl(), parentContainer)
		{
            this.InitializeDialog();
        }
        public DBEngineChooserDialog(IAsyncChooserControlSearch searchControl, IContainer parentContainer) : base(searchControl, parentContainer)
        {
            this.InitializeDialog();
        }

        private void InitializeDialog()
        {
            this.InitializeComponent();
            this.mainChooserControl.Columns.Add(new ChooserControlColumnDefinition("Server", "Path", 300));
            this.mainChooserControl.Columns.Add(new ChooserControlColumnDefinition("Instance", "DisplayName", 270));
        }
    }
}

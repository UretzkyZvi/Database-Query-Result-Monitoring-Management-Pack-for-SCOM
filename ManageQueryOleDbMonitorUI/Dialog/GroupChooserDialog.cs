using Microsoft.EnterpriseManagement.Mom.Internal.UI;
using Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls;
using System.ComponentModel;

namespace ManageQueryOleDbMonitorUI
{
    public partial class GroupChooserDialog : AsyncSimpleChooserDialog
    {
        public GroupChooserDialog(IContainer parentContainer) : base(new GroupPickerControl(), parentContainer)
        {
            this.InitializeDialog();
        }

        public GroupChooserDialog(IAsyncChooserControlSearch searchControl, IContainer parentContainer) : base(searchControl, parentContainer)
        {
            this.InitializeDialog();
        }

        private void InitializeDialog()
        {
            this.InitializeComponent();
            this.mainChooserControl.Columns.Add(new ChooserControlColumnDefinition("Group Name", "DisplayName", 400));
        }
    }
}
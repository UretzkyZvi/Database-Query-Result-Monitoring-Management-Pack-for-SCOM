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
using System.Collections.ObjectModel;
using Microsoft.EnterpriseManagement.Common;
using System.Globalization;
using Microsoft.EnterpriseManagement.Mom.Internal.UI.Common;
using Microsoft.EnterpriseManagement.Configuration;

namespace ManageQueryOleDbMonitorUI
{
    public partial class GroupPickerControl : UserControl, IAsyncChooserControlSearch
    {

        #region Properties
        private ICollection<EnterpriseManagementObject> groups;
        private Dictionary<System.Guid, Image> localImageCache;
        private Image GroupsImage;
        //private IContainer components;

        ManagementPackClass monitoringClass;

        #endregion


        #region Constrctor
        public GroupPickerControl()
        {
            InitializeComponent();
            this.localImageCache = new Dictionary<System.Guid, Image>();
        }
        #endregion

        #region Public Methods
        public Control SearchControl
        {
            get
            {
                return this;
            }
        }

        public ReadOnlyCollection<IChooserControlItem> Search(CancelFlagWrapper cancelFlag)
        {
            if (cancelFlag.Cancel)
            {
                return null;
            }
            if (groups == null)
            {
                PopulateGroups();
            }
            List<IChooserControlItem> list = new List<IChooserControlItem>();
            if (groups != null)
            {
                foreach (EnterpriseManagementObject current in groups)
                {
                    if ((!string.IsNullOrEmpty(current.Path) && current.Path.ToLower(CultureInfo.CurrentCulture).
                        Contains(txtFilter.Text.ToLower(CultureInfo.CurrentCulture))) ||
                        (!string.IsNullOrEmpty(current.DisplayName) &&
                        current.DisplayName.ToLower(CultureInfo.CurrentCulture).
                        Contains(txtFilter.Text.ToLower(CultureInfo.CurrentCulture))))
                    {
                        list.Add(CreateChooserControlItem(current));
                    }
                }
            }
            return new ReadOnlyCollection<IChooserControlItem>(list);
        }

        #endregion

        #region Private Methods
        private void PopulateGroups()
        {
            IManagementGroupSession managementGroupSession = null;
            if (base.ParentForm != null && base.ParentForm.Site != null)
            {
                managementGroupSession = (base.ParentForm.Site.GetService(typeof(IManagementGroupSession)) as IManagementGroupSession);
            }

            if (managementGroupSession == null || managementGroupSession.ManagementGroup == null)
            {
                return;
            }

            using (ManageQueryOleDBSDKHelper helper = new ManageQueryOleDBSDKHelper(managementGroupSession.ManagementGroup))
            {
                monitoringClass = helper.GetManagementPackClass("QueryOleDbMonitorLibrary", "OleDBQueryMonitoringGroup");
                if (GroupsImage == null)
                {
                    GroupsImage = ComponentMethodLibrary.GetImageFromSharedCache(monitoringClass, base.ParentForm);
                }
                List<EnterpriseManagementObject> list = new List<EnterpriseManagementObject>();
                IObjectReader<EnterpriseManagementObject> allGroups = helper.GetEnterpriseManagementObjects(monitoringClass);
                if (allGroups != null)
                {
                    foreach (EnterpriseManagementObject current in allGroups)
                    {
                        list.Add(current);
                    }
                }
                groups = list;
            }
        }

        private IChooserControlItem CreateChooserControlItem(EnterpriseManagementObject current)
        {
            if (!localImageCache.ContainsKey(current.Id))
            {
                localImageCache.Add(current.Id, GroupsImage);
            }
            return new ChooserControlItem(current.Id.ToString(), current, GroupsImage);
        }
        #endregion
    }
}

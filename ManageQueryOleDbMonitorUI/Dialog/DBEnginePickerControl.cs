using Microsoft.EnterpriseManagement.Administration;
using Microsoft.EnterpriseManagement.Common;
using Microsoft.EnterpriseManagement.Configuration;
using Microsoft.EnterpriseManagement.Mom.Internal.UI;
using Microsoft.EnterpriseManagement.Mom.Internal.UI.Common;
using Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace ManageQueryOleDbMonitorUI
{
    public class DBEnginePickerControl : UserControl, IAsyncChooserControlSearch
    {
        private ICollection<EnterpriseManagementObject> DBEngines;

        private Dictionary<System.Guid, Image> localImageCache;
        private Image DBEngineImage;
        private IContainer components;

        private Label lblSearch;
        private TextBox txtFilterDBEngine;
        public DBEnginePickerControl()
        {
            this.InitializeComponent();
            this.localImageCache = new Dictionary<System.Guid, Image>();
        }

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
            if (DBEngines == null)
            {
                PopulateDBEngines();
            }
            List<IChooserControlItem> list = new List<IChooserControlItem>();
            if (DBEngines != null)
            {
                foreach (EnterpriseManagementObject current in DBEngines)
                {
                    if ((!string.IsNullOrEmpty(current.Path) && current.Path.ToLower(CultureInfo.CurrentCulture).
                        Contains(txtFilterDBEngine.Text.ToLower(CultureInfo.CurrentCulture))) ||
                        (!string.IsNullOrEmpty(current.DisplayName) &&
                        current.DisplayName.ToLower(CultureInfo.CurrentCulture).
                        Contains(txtFilterDBEngine.Text.ToLower(CultureInfo.CurrentCulture))))
                    {
                        list.Add(CreateChooserControlItem(current));
                    }
                }
            }
            return new ReadOnlyCollection<IChooserControlItem>(list);
        }
        ManagementPackClass monitoringClassDBEngine;
        ManagementPackClass monitoringClassDBEngine14;
        ManagementPackClass monitoringClassDBEngine16;
        private void PopulateDBEngines()
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
                List<EnterpriseManagementObject> list = new List<EnterpriseManagementObject>();
                monitoringClassDBEngine = helper.GetManagementPackClass("Microsoft.SQLServer.Library", "Microsoft.SQLServer.DBEngine");
                IObjectReader<EnterpriseManagementObject> allDBEngines = helper.GetEnterpriseManagementObjects(monitoringClassDBEngine);

                if (allDBEngines != null)
                {
                    foreach (EnterpriseManagementObject current in allDBEngines)
                    {
                        list.Add(current);
                    }
                }
                try
                {
                    monitoringClassDBEngine14 = helper.GetManagementPackClass("Microsoft.SQLServer.2014.Discovery", "Microsoft.SQLServer.2014.DBEngine");
                    IObjectReader<EnterpriseManagementObject> allDBEngines14 = helper.GetEnterpriseManagementObjects(monitoringClassDBEngine14);
                    if (allDBEngines14 != null)
                    {
                        foreach (EnterpriseManagementObject current in allDBEngines14)
                        {
                            list.Add(current);
                        }
                    }
                }
                catch
                {
                    //you dont have sql 2014 mp
                }
                try
                {
                    monitoringClassDBEngine16 = helper.GetManagementPackClass("Microsoft.SQLServer.2016.Discovery", "Microsoft.SQLServer.2016.DBEngine");
                    IObjectReader<EnterpriseManagementObject> allDBEngines16 = helper.GetEnterpriseManagementObjects(monitoringClassDBEngine16);
                    if (allDBEngines16 != null)
                    {
                        foreach (EnterpriseManagementObject current in allDBEngines16)
                        {
                            list.Add(current);
                        }
                    }
                }
                catch
                {
                    //you dont have sql 2016 mp
                }

                if (DBEngineImage == null)
                {
                    DBEngineImage = ComponentMethodLibrary.GetImageFromSharedCache(monitoringClassDBEngine, base.ParentForm);
                }


                DBEngines = list;
            }

        }

        private IChooserControlItem CreateChooserControlItem(EnterpriseManagementObject DBEngine)
        {
            if (!localImageCache.ContainsKey(DBEngine.Id))
            {
                localImageCache.Add(DBEngine.Id, DBEngineImage);
            }
            return new ChooserControlItem(DBEngine.Id.ToString(), DBEngine, this.DBEngineImage);
        }

        private void InitializeComponent()
        {
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtFilterDBEngine = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(-3, 20);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(144, 13);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Enter your search text below:";
            // 
            // txtFilterDBEngine
            // 
            this.txtFilterDBEngine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtFilterDBEngine.Location = new System.Drawing.Point(0, 49);
            this.txtFilterDBEngine.Name = "txtFilterDBEngine";
            this.txtFilterDBEngine.Size = new System.Drawing.Size(319, 20);
            this.txtFilterDBEngine.TabIndex = 1;
            // 
            // DBEnginePickerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtFilterDBEngine);
            this.Controls.Add(this.lblSearch);
            this.Name = "DBEnginePickerControl";
            this.Size = new System.Drawing.Size(319, 69);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

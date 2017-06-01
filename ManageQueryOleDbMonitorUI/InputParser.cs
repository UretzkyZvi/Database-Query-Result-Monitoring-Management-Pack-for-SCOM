using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Text.RegularExpressions;
using Microsoft.EnterpriseManagement.Common;
using Microsoft.EnterpriseManagement.Configuration;
using Microsoft.EnterpriseManagement.Internal.UI.Authoring.Extensibility;
using Microsoft.EnterpriseManagement.Mom.Internal.UI.Common;
using Microsoft.EnterpriseManagement.UI;

namespace ManageQueryOleDbMonitorUI
{
    public class InputParser : Component, IInputConfigurationParser
    {
        private const string ClassNamePrefix = "OleDBQueryMonitoring";
        private const string DiscoveryNamePrefix = "QueryOleDbMonitorInitialDiscovery.";
        private const string ValueNodeRegex = "<Value>([^<]*)</Value>";

        public InputParser(IContainer parentContainer)
        {
            if (parentContainer != null)
            {
                parentContainer.Add(this);
            }
        }

        public bool LoadConfigurationXml(IPageContext pageContext)
        {
            if (pageContext == null)
            {
                throw new ArgumentNullException("pageContext");
            }
            ITemplateContext templateContext = (ITemplateContext)pageContext;
            TemplateInputConfig templateConfig = new TemplateInputConfig
            {
                Name = templateContext.OutputFolder.DisplayName,
                Description = templateContext.OutputFolder.Description,
            };
            GetDiscoveryConfig(templateContext, ref templateConfig);
            pageContext.ConfigurationXml = XmlHelper.Serialize(templateConfig, false);
            return true;
        }

        private void GetDiscoveryConfig(ITemplateContext templateContext, ref TemplateInputConfig templateConfig)
        {
            if (templateContext == null)
            {
                throw new ArgumentNullException("templateContext");
            }
            foreach (ManagementPackDiscovery discovery in SDKHelper.GetFolderItems<ManagementPackDiscovery>(this, templateContext.OutputFolder))
            {
                if (discovery.Name.StartsWith(DiscoveryNamePrefix, StringComparison.OrdinalIgnoreCase))
                {
                    MatchCollection matchs =
                        new Regex(ValueNodeRegex, RegexOptions.CultureInvariant | RegexOptions.Compiled).Matches(discovery.DataSource.Configuration);

                    templateConfig.TemplateIdString = matchs[0].Groups[1].Value;
                    templateConfig.Instance = matchs[1].Groups[1].Value;
                    templateConfig.Database = matchs[2].Groups[1].Value;

                    templateConfig.QueryName = matchs[3].Groups[1].Value;
                    templateConfig.StartDay = matchs[4].Groups[1].Value;
                    templateConfig.EndDay = matchs[5].Groups[1].Value;
                    templateConfig.SyncTime = matchs[6].Groups[1].Value;
                    templateConfig.IntervalSeconds = int.Parse(matchs[7].Groups[1].Value);
                    templateConfig.Query = matchs[8].Groups[1].Value;
                    templateConfig.DaysOfWeekMask = int.Parse(matchs[9].Groups[1].Value);
                    templateConfig.GroupName = matchs[10].Groups[1].Value;
                    templateConfig.Direction = matchs[11].Groups[1].Value;
                    templateConfig.ErrorMessage = matchs[12].Groups[1].Value;
                    templateConfig.MetricType = matchs[13].Groups[1].Value;
                    templateConfig.Samples = int.Parse(matchs[14].Groups[1].Value);
                    templateConfig.Threshold = double.Parse(matchs[15].Groups[1].Value);
                    templateConfig.PrincipalName = matchs[16].Groups[1].Value;



                    return;
                }
            }
            throw new ObjectNotFoundException("my message");
        }

        private string GetTemplateIdString(ITemplateContext templateContext)
        {
            if (templateContext == null)
            {
                throw new ArgumentNullException("templateContext");
            }
            foreach (ManagementPackClass class2 in SDKHelper.GetFolderItems<ManagementPackClass>(this, templateContext.OutputFolder))
            {
                if (class2.Name.StartsWith(ClassNamePrefix, StringComparison.OrdinalIgnoreCase))
                {
                    return class2.Name.Remove(0, ClassNamePrefix.Length);
                }
            }
            throw new ObjectNotFoundException();
        }
    }
}

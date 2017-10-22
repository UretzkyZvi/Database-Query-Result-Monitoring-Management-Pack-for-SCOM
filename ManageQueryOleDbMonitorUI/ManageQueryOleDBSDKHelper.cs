using Microsoft.EnterpriseManagement;
using Microsoft.EnterpriseManagement.Common;
using Microsoft.EnterpriseManagement.Configuration;
using Microsoft.EnterpriseManagement.Monitoring;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml;

namespace ManageQueryOleDbMonitorUI
{
    public static class ManageQueryOleDBExtension
    {
        public static IEnumerable<Enum> GetUniqueFlags(this Enum flags)
        {
            ulong flag = 1;
            foreach (var value in Enum.GetValues(flags.GetType()).Cast<Enum>())
            {
                ulong bits = Convert.ToUInt64(value);
                while (flag < bits)
                {
                    flag <<= 1;
                }

                if (flag == bits && flags.HasFlag(value))
                {
                    yield return value;
                }
            }
        }
    }

    public class ManageQueryOleDBSDKHelper : IDisposable
    {

        private ManagementGroup managementGroup;

        public ManageQueryOleDBSDKHelper(ManagementGroup managementGroup)
        {
            this.managementGroup = managementGroup;
        }

        internal IObjectReader<EnterpriseManagementObject> GetEnterpriseManagementObjects(ManagementPackClass classtype)
        {
            try
            {
                return managementGroup.EntityObjects.GetObjectReader<EnterpriseManagementObject>(classtype, ObjectQueryOptions.Default);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal IObjectReader<EnterpriseManagementObject> GetEnterpriseManagementObjects(string managementPackName, string className)
        {
            try
            {
                IList<ManagementPack> mps = managementGroup.ManagementPacks.GetManagementPacks(new ManagementPackCriteria(string.Format("Name = '{0}'", managementPackName)));
                ManagementPackClass requestClass = managementGroup.EntityTypes.GetClass(className, mps[0]);
                return managementGroup.EntityObjects.GetObjectReader<EnterpriseManagementObject>(requestClass, ObjectQueryOptions.Default);
            }
            catch
            {
                throw new Exception(string.Format("Error Management Pack {1} not exist in {0} Management Group", managementGroup.Name, managementPackName));
            }
        }

        internal ManagementPackClass GetManagementPackClass(string managementPackName, string className)
        {
            IList<ManagementPack> mps = managementGroup.ManagementPacks.GetManagementPacks(new ManagementPackCriteria(string.Format("Name = '{0}'", managementPackName)));

            if (mps.Count != 0)
            {
                ManagementPackClass requestClass = managementGroup.EntityTypes.GetClass(className, mps[0]);
                if (requestClass == null)
                {
                    throw new Exception(string.Format("Error Class {0} not exist in {1} Management Pack", className, managementPackName));
                }
                return requestClass;
            }
            else
            {
                return null;
            }
        }

        internal IObjectReader<EnterpriseManagementObject> GetObjectsByName(string name, ManagementPackClass cls)
        {
            return managementGroup.EntityObjects.GetObjectReader<EnterpriseManagementObject>(new MonitoringObjectGenericCriteria(string.Format("Name = '{0}'", name)), cls, ObjectQueryOptions.Default);
        }
        internal IList<EnterpriseManagementObject> GetRelatedObjects(Guid objectID, string managementPackName, string className)
        {
            ManagementPackClass rClass = GetManagementPackClass(managementPackName, className);
            if (rClass != null)
            {
                return managementGroup.EntityObjects.GetRelatedObjects<EnterpriseManagementObject>(objectID, rClass, TraversalDepth.Recursive, ObjectQueryOptions.Default);
            }
            else
            {
                throw new Exception(string.Format("Error no related objects"));
            }
        }

        internal string RunTestTask(string connectionString, string query)
        {
            ManagementPackClass AllManagementServersPoolClass =
                GetManagementPackClass("Microsoft.SystemCenter.Library", "Microsoft.SystemCenter.AllManagementServersPool");

            IObjectReader<MonitoringObject> Targets = managementGroup.EntityObjects.GetObjectReader<MonitoringObject>(AllManagementServersPoolClass, ObjectQueryOptions.Default);
            EnterpriseManagementObject Target = Targets.First();
            // Get the task.
            string TaskQuery = "Name = 'Microsoft.SystemCenter.SyntheticTransactions.OleDbPing'";
            ManagementPackTaskCriteria taskCriteria = new ManagementPackTaskCriteria(TaskQuery);

            IList<ManagementPackTask> tasks = managementGroup.TaskConfiguration.GetTasks(taskCriteria);
            ManagementPackTask task = null;
            if (tasks.Count == 1)
                task = tasks[0];
            else
                throw new InvalidOperationException(
                    "Error! Expected one task with: " + query);

            // Use the default task configuration.
            Microsoft.EnterpriseManagement.Runtime.TaskConfiguration config =
                new Microsoft.EnterpriseManagement.Runtime.TaskConfiguration();

            //Get OleDbTriggerProbe module to override paramters
            ManagementPackModuleType OleDbTriggerProbeMoudule =
                managementGroup.Monitoring.GetModuleType("System.OleDbTriggerProbe", managementGroup.ManagementPacks.GetManagementPack(SystemManagementPack.System));

            ManagementPackOverrideableParameter overrideConnecionStringParam = OleDbTriggerProbeMoudule.OverrideableParameterCollection["ConnectionString"];
            ManagementPackOverrideableParameter overrideQueryParam = OleDbTriggerProbeMoudule.OverrideableParameterCollection["Query"];


            config.Overrides.Add(new Pair<ManagementPackOverrideableParameter, string>(overrideConnecionStringParam,
                   connectionString
                    ));
            config.Overrides.Add(new Pair<ManagementPackOverrideableParameter, string>(overrideQueryParam,
                   query
                    ));

            //execute task

            IList<Microsoft.EnterpriseManagement.Runtime.TaskResult> result = managementGroup.TaskRuntime.ExecuteTask(Target, task, config);

            if (result[0].ErrorCode == 0)
            {
                //XmlDocument xd = new XmlDocument();
                //xd.LoadXml(result[0].Output);
                IList<Microsoft.EnterpriseManagement.Runtime.TaskResult> results = managementGroup.TaskRuntime.GetTaskResultsByBatchId(result[0].BatchId);
                return "Succeeded result: " + results[0].Output;
            }
            else
            {
                return "Error result: " + result[0].ErrorMessage;
            }

        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ManageQueryOleDBSDKHelper() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
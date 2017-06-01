using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EnterpriseManagement;
using Microsoft.EnterpriseManagement.Common;
using Microsoft.EnterpriseManagement.Configuration;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using Microsoft.EnterpriseManagement.Monitoring;

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

        internal IObjectReader<EnterpriseManagementObject> GetObjectsByName(string name,ManagementPackClass cls)
        {
            return managementGroup.EntityObjects.GetObjectReader<EnterpriseManagementObject>(new MonitoringObjectGenericCriteria(string.Format("Name = '{0}'", name)), cls, ObjectQueryOptions.Default);
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
            if (mps == null)
            {
                throw new Exception(string.Format("Error Management Pack {1} not exist in {0} Management Group", managementGroup.Name, managementPackName));
            }
            if (mps.Count>=1)
            {
                ManagementPackClass requestClass = managementGroup.EntityTypes.GetClass(className, mps[0]);
                return requestClass;
            }
            throw new Exception(string.Format("Error Class {0} not exist in {1} Management Pack", className, managementPackName));
        }

        internal IList<EnterpriseManagementObject> GetRelatedObjects(Guid objectID, string managementPackName, string className)
        {
            ManagementPackClass rClass = GetManagementPackClass(managementPackName, className);
            if (rClass!=null)
            {
               return managementGroup.EntityObjects.GetRelatedObjects<EnterpriseManagementObject>(objectID, rClass, TraversalDepth.Recursive, ObjectQueryOptions.Default);
            }
            else
            {
                throw new Exception(string.Format("Error no related objects"));
            }
        }

        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }
    }
}

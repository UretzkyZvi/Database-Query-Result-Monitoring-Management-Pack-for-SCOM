using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EnterpriseManagement;
using Microsoft.EnterpriseManagement.Common;
using Microsoft.EnterpriseManagement.Configuration;
using Microsoft.EnterpriseManagement.ConnectorFramework;

namespace ManageSCOMOleDbQueryMonitor
{
    public class SCOMSDKWrapper
    {
        string _strLibraryMP = "QueryOleDbMonitorLibrary";
        string _strMicrosoftMP = "Microsoft.Windows.Library";
        string _strSystemMP = "System.Library";
        string _strSystemEntityClass = "System.Entity";
        string _strComputerClass = "Microsoft.Windows.Computer";
        string _strOleDBMonitoringClass = "OleDBQueryMonitoring";
        string _strOleDBMonitoringGroupClass = "OleDBQueryMonitoringGroup";
        string _strRelationship = "OleDBQueryMonitoringGroupecontainOleDBQueryMonitoring";



        IList<ManagementPack> _LibraryMP;
        IList<ManagementPack> _MicrosoftMP;
        IList<ManagementPack> _SystemMP;
        ManagementPackClass _GroupClass;
        ManagementPackClass _OleDBMonitoringClass;
        ManagementPackClass _ComputerClass;
        ManagementPackClass _SystemEntityClass;
        ManagementPackRelationship _GroupContainOleDBMonitoringRelationship;
        SharedData _Data;

        public SCOMSDKWrapper(SharedData data)
        {
            _Data = data;
        }

        public IObjectReader<EnterpriseManagementObject> GetEnterpriseManagementObjects(string className, string managementPackName)
        {
            try
            {
                IList<ManagementPack> mps = _Data.MGConnection.ManagementPacks.GetManagementPacks(new ManagementPackCriteria(string.Format("Name = '{0}'", managementPackName)));
                ManagementPackClass requestClass = _Data.MGConnection.EntityTypes.GetClass(className, mps[0]);
                return _Data.MGConnection.EntityObjects.GetObjectReader<EnterpriseManagementObject>(requestClass, ObjectQueryOptions.Default);
            }
            catch
            {

                throw new Exception(string.Format("Error Management Pack QueryOleDbMonitorLibrary not exist in {0} Management Group", _Data.MGConnection.Name));
            }

        }

        public void DeleteInstanceWithGroup(Guid id, string groupName)
        {

            DeleteInstance(id);

            DeleteAGroup(groupName);
        }

        public void DeleteInstance(Guid id)
        {
            IncrementalDiscoveryData discovery = new IncrementalDiscoveryData();

            EnterpriseManagementObject existingObject = _Data.MGConnection.EntityObjects.GetObject<EnterpriseManagementObject>(id, ObjectQueryOptions.Default);

            discovery.Remove(existingObject);

            discovery.Commit(_Data.MGConnection);
        }

        public void DeleteAGroup(string groupName)
        {
            _LibraryMP = _Data.MGConnection.ManagementPacks.GetManagementPacks(new ManagementPackCriteria(string.Format("Name = '{0}'", _strLibraryMP)));
            _GroupClass = _LibraryMP[0].GetClass(_strOleDBMonitoringGroupClass);


            EnterpriseManagementObject groupObject = null;
            IObjectReader<EnterpriseManagementObject> ObjReaders =
                 _Data.MGConnection.EntityObjects.GetObjectReader<EnterpriseManagementObject>(_GroupClass, ObjectQueryOptions.Default);
            foreach (EnterpriseManagementObject emObject in ObjReaders)
            {
                if (emObject.Name == groupName)
                {
                    groupObject = emObject;
                    break;
                }
            }

            if (groupObject != null)
            {
                IList<EnterpriseManagementObject> items =
                    _Data.MGConnection.EntityObjects.GetRelatedObjects<EnterpriseManagementObject>(groupObject.Id, TraversalDepth.OneLevel, ObjectQueryOptions.Default);

                if (items.Count() == 0)
                {
                    DeleteInstance(groupObject.Id);
                }
            }


        }
        public void CreateInstance()
        {
            _LibraryMP = _Data.MGConnection.ManagementPacks.GetManagementPacks(new ManagementPackCriteria(string.Format("Name = '{0}'", _strLibraryMP)));
            _GroupClass = _LibraryMP[0].GetClass(_strOleDBMonitoringGroupClass);

            _OleDBMonitoringClass = _LibraryMP[0].GetClass(_strOleDBMonitoringClass);
            _GroupContainOleDBMonitoringRelationship = _LibraryMP[0].GetRelationship(_strRelationship);


            _MicrosoftMP = _Data.MGConnection.ManagementPacks.GetManagementPacks(new ManagementPackCriteria(string.Format("Name = '{0}'", _strMicrosoftMP)));
            _ComputerClass = _MicrosoftMP[0].GetClass(_strComputerClass);

            _SystemMP = _Data.MGConnection.ManagementPacks.GetManagementPacks(new ManagementPackCriteria(string.Format("Name = '{0}'", _strSystemMP)));
            _SystemEntityClass = _SystemMP[0].GetClass(_strSystemEntityClass);

            EnterpriseManagementObject OleDBMonitorObject = CreateOleDBMonitor();

            if (OleDBMonitorObject != null)
            {
                CreateGroup();
                CreateRelationship(CreateGroup(), OleDBMonitorObject);
            }
        }
        private EnterpriseManagementObject IsGroupExist(string groupName)
        {
            try
            {
                //get all instances
                IObjectReader<EnterpriseManagementObject> ObjReaders =
                         _Data.MGConnection.EntityObjects.GetObjectReader<EnterpriseManagementObject>(_GroupClass, ObjectQueryOptions.Default);

                foreach (EnterpriseManagementObject emObject in ObjReaders)
                {
                    if (emObject.Name == groupName)
                    {
                        return emObject;
                    }
                }
                return null;

            }
            catch (Exception)
            {

                throw;
            }

        }

        private EnterpriseManagementObject CreateOleDBMonitor()
        {
            CreatableEnterpriseManagementObject requestOleDBMonitor = new CreatableEnterpriseManagementObject(_Data.MGConnection, _OleDBMonitoringClass);

            requestOleDBMonitor[_OleDBMonitoringClass, "UniqueID"].Value = Guid.NewGuid();
            requestOleDBMonitor[_OleDBMonitoringClass, "Instance"].Value = _Data.DBEngine.Path + "\\" + _Data.DBEngine.DisplayName;
            requestOleDBMonitor[_OleDBMonitoringClass, "Database"].Value = _Data.QueryDataInfo.Database;
            requestOleDBMonitor[_OleDBMonitoringClass, "QueryName"].Value = _Data.MonitorDifinitionInfo.QueryName;
            requestOleDBMonitor[_OleDBMonitoringClass, "StartDay"].Value = _Data.MonitorDifinitionInfo.StartDay;
            requestOleDBMonitor[_OleDBMonitoringClass, "EndDay"].Value = _Data.MonitorDifinitionInfo.EndDay;
            requestOleDBMonitor[_OleDBMonitoringClass, "SyncTime"].Value = _Data.MonitorDifinitionInfo.SyncTime;
            requestOleDBMonitor[_OleDBMonitoringClass, "IntervalSeconds"].Value = _Data.MonitorDifinitionInfo.IntervalSeconds;
            requestOleDBMonitor[_OleDBMonitoringClass, "Query"].Value = _Data.QueryDataInfo.Query;
            requestOleDBMonitor[_OleDBMonitoringClass, "DaysOfWeekMask"].Value = _Data.MonitorDifinitionInfo.DaysOfWeekMask;
            requestOleDBMonitor[_OleDBMonitoringClass, "GroupName"].Value = _Data.MonitorDifinitionInfo.GroupName;
            requestOleDBMonitor[_OleDBMonitoringClass, "Direction"].Value = _Data.MonitorDifinitionInfo.Direction;
            requestOleDBMonitor[_OleDBMonitoringClass, "ErrorMessage"].Value = _Data.MonitorDifinitionInfo.ErrorMessage;
            requestOleDBMonitor[_OleDBMonitoringClass, "MetricType"].Value = _Data.MonitorDifinitionInfo.MetricType;
            requestOleDBMonitor[_OleDBMonitoringClass, "Samples"].Value = _Data.MonitorDifinitionInfo.Samples;
            requestOleDBMonitor[_OleDBMonitoringClass, "Threshold"].Value = _Data.MonitorDifinitionInfo.Threshold;
            requestOleDBMonitor[_ComputerClass, "PrincipalName"].Value = _Data.DBEngine.Path;
            requestOleDBMonitor[_SystemEntityClass, "DisplayName"].Value = string.Format("{0}", _Data.MonitorDifinitionInfo.QueryName);
            try
            {
                requestOleDBMonitor.Commit();
                return requestOleDBMonitor;
            }
            catch
            {
                return null;
            }

        }
        private EnterpriseManagementObject CreateGroup()
        {
            EnterpriseManagementObject GroupObj = IsGroupExist(_Data.MonitorDifinitionInfo.GroupName);
            if (IsGroupExist(_Data.MonitorDifinitionInfo.GroupName) == null)
            {
                CreatableEnterpriseManagementObject requestGroup = new CreatableEnterpriseManagementObject(_Data.MGConnection, _GroupClass);
                requestGroup[_GroupClass, "Name"].Value = _Data.MonitorDifinitionInfo.GroupName;
                requestGroup.Commit();
                return requestGroup;
            }
            else
            {
                return GroupObj;
            }
        }
        private void CreateRelationship(EnterpriseManagementObject Source, EnterpriseManagementObject Target)
        {
            CreatableEnterpriseManagementRelationshipObject requestGroup = new CreatableEnterpriseManagementRelationshipObject(_Data.MGConnection, _GroupContainOleDBMonitoringRelationship);
            requestGroup.SetSource(Source);
            requestGroup.SetTarget(Target);
            requestGroup.Commit();
        }

    }
}

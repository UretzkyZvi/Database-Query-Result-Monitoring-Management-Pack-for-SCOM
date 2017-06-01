using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ManageQueryOleDbMonitorUI
{
    [Serializable, XmlType(AnonymousType = true), XmlRoot(Namespace = "", IsNullable = false)]
    public class TemplateInputConfig
    {
        //// Fields
        //private string nameField;
        //private string descriptionField;
        //private string templateIdStringField;
        //private string fullInstanceNameField;
        //private string databaseName;
        //private string query;
        //private int intervalSeconds;
        //private string dbEnginId;
        //private string instanceName;

        //// Properties

        //[XmlElement(Form = XmlSchemaForm.Unqualified)]
        //public string Description
        //{
        //    get
        //    {
        //        return this.descriptionField;
        //    }
        //    set
        //    {
        //        this.descriptionField = value;
        //    }
        //}

        //[XmlElement(Form = XmlSchemaForm.Unqualified)]
        //public string Name
        //{
        //    get
        //    {
        //        return this.nameField;
        //    }
        //    set
        //    {
        //        this.nameField = value;
        //    }
        //}

        //[XmlElement(Form = XmlSchemaForm.Unqualified)]
        //public string TemplateIdString
        //{
        //    get
        //    {
        //        return this.templateIdStringField;
        //    }
        //    set
        //    {
        //        this.templateIdStringField = value;
        //    }
        //}

        //[XmlElement(Form = XmlSchemaForm.Unqualified)]
        //public string FullInstanceNameName
        //{
        //    get
        //    {
        //        return this.fullInstanceNameField;
        //    }
        //    set
        //    {
        //        this.fullInstanceNameField = value;
        //    }
        //}
        //[XmlElement(Form = XmlSchemaForm.Unqualified)]
        //public string DatabaseName
        //{
        //    get
        //    {
        //        return databaseName;
        //    }

        //    set
        //    {
        //        databaseName = value;
        //    }
        //}
        //[XmlElement(Form = XmlSchemaForm.Unqualified)]
        //public string Query
        //{
        //    get
        //    {
        //        return query;
        //    }

        //    set
        //    {
        //        query = value;
        //    }
        //}
        //[XmlElement(Form = XmlSchemaForm.Unqualified)]
        //public int IntervalSeconds
        //{
        //    get
        //    {
        //        return intervalSeconds;
        //    }

        //    set
        //    {
        //        intervalSeconds = value;
        //    }
        //}
        //[XmlElement(Form = XmlSchemaForm.Unqualified)]
        //public string DBEngineId
        //{
        //    get
        //    {
        //        return dbEnginId;
        //    }

        //    set
        //    {
        //        dbEnginId = value;
        //    }
        //}
        //[XmlElement(Form = XmlSchemaForm.Unqualified)]
        //public string InstanceName
        //{
        //    get
        //    {
        //        return instanceName;
        //    }

        //    set
        //    {
        //        instanceName = value;
        //    }
        //}

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Name { get; set; }
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Description { get; set; }
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string TemplateIdString { get; set; }
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public Guid UniqueId { get; set; }
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Instance { get; set; }
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Database { get; set; }
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string QueryName { get; set; }
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string StartDay { get; set; }
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string EndDay { get; set; }
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string SyncTime { get; set; }
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public int IntervalSeconds { get; set; }
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Query { get; set; }
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public int DaysOfWeekMask { get; set; }
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string GroupName { get; set; }
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Direction { get; set; }
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string ErrorMessage { get; set; }
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string MetricType { get; set; }
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public int Samples { get; set; }
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public double Threshold { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string PrincipalName { get; set; }

    }
}

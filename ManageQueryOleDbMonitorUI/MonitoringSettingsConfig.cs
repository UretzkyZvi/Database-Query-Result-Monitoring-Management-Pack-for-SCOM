using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace ManageQueryOleDbMonitorUI
{
    [Serializable, XmlType(AnonymousType = true), XmlRoot(Namespace = "", IsNullable = false)]
    public class MonitoringSettingsConfig
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Direction { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public double Threshold { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public int Samples { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string ErrorMessage { get; set; }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string GroupName { get; set; }
    }
}
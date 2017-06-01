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
    public class SchedulerSettingsConfig
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public int IntervalSeconds { get; set; }
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string StartDay { get; set; }
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string EndDay { get; set; }
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string SyncTime { get; set; }
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public int DaysOfWeekMask { get; set; }
    }
}

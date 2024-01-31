using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CFDataLocker.Model
{
    [XmlType("Group")]
    public class Group
    {
        [XmlAttribute("ID")]
        public string ID { get; set; }
        [XmlAttribute("Description")]
        public string Description { get; set; }
    }
}

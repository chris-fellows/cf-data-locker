using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CFDataLocker.Model
{
    [XmlType("Document")]
    public class Document
    {
        [XmlArray("Groups")]
        [XmlArrayItem("Group")]
        public List<Group> Groups = new List<Group>();
        [XmlArray("DataItems")]
        [XmlArrayItem("DataItem")]
        public List<DataItem> DataItems = new List<DataItem>();        
    }
}

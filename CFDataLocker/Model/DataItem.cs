using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CFDataLocker.Model
{
    /// <summary>
    /// Data item
    /// </summary>
    [XmlType("DataItem")]
    public class DataItem
    {
        /// <summary>
        /// Unique ID
        /// </summary>
        [XmlAttribute("ID")]
        public string ID { get; set; }

        /// <summary>
        /// Group that data item is a member of
        /// </summary>
        [XmlAttribute("GroupID")]
        public string GroupID { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [XmlAttribute("Description")]
        public string Description { get; set; }

        /// <summary>
        /// Account number
        /// </summary>
        [XmlAttribute("AccountNumber")]
        public string AccountNumber { get; set; }

        /// <summary>
        /// Login credentials
        /// </summary>
        [XmlElement("Credentials")]
        public Credentials Credentials { get; set; }  
        
        /// <summary>
        /// Contact details for company/website
        /// </summary>
        [XmlElement("Contact")]
        public Contact Contact { get; set; }

        /// <summary>
        /// Notes
        /// </summary>
        [XmlElement("Notes")]
        public string Notes { get; set; }

        /// <summary>
        /// URL. E.g. Website to log in to
        /// </summary>
        [XmlAttribute("URL")]
        public string URL { get; set; }

        /// <summary>
        /// Whether data item is active
        /// </summary>
        [XmlAttribute("Active")]
        public bool Active { get; set; }
    }
}

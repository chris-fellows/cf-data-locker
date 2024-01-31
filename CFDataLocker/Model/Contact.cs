using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CFDataLocker.Model
{
    /// <summary>
    /// Contact details
    /// </summary>
    [XmlType("Contact")]
    public class Contact
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("EmailAddress")]
        public string EmailAddress { get; set; }
        [XmlAttribute("Telephone")]
        public string Telephone { get; set; }
    }
}

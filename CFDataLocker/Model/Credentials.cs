using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CFDataLocker.Model
{
    /// <summary>
    /// Login credentials
    /// </summary>
    [XmlType("Credentials")]
    public class Credentials
    {
        [XmlAttribute("UserName")]
        public string UserName { get; set; }

        [XmlAttribute("Password")]
        public string Password { get; set; }
    }
}

using System.Xml.Serialization;

namespace CFDataLocker.Models
{
    /// <summary>
    /// Group for data items
    /// </summary>
    [XmlType("Group")]
    public class Group
    {
        [XmlAttribute("ID")]
        public string ID { get; set; }
        [XmlAttribute("Description")]
        public string Description { get; set; }

        public object Clone()
        {
            return new Group()
            {
                ID = ID,
                Description = Description
            };
        }        
    }
}

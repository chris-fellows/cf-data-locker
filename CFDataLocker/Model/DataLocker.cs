using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace CFDataLocker.Model
{
    /// <summary>
    /// Locker for data items
    /// </summary>
    [XmlType("DataLocker")]
    public class DataLocker : ICloneable
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlArray("Groups")]
        [XmlArrayItem("Group")]
        public List<Group> Groups = new List<Group>();
        [XmlArray("DataItems")]
        [XmlArrayItem("DataItem")]
        public List<DataItem> DataItems = new List<DataItem>();        

        public object Clone()
        {
            return new DataLocker()
            {
                Name = Name,
                Groups = Groups == null ? null : Groups.Select(g => (Group)g.Clone()).ToList(),
                DataItems = DataItems == null ? null : DataItems.Select(di => (DataItem)di.Clone()).ToList()
            };
        }

        /// <summary>
        /// Encodes data so that is can be saved
        /// </summary>
        public void Encode()
        {
            DataItems.ForEach(di => di.Encode());
        }

        /// <summary>
        /// Decodes encoded data
        /// </summary>
        public void Decode()
        {
            DataItems.ForEach(di => di.Decode());
        }
    }
}

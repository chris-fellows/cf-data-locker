using CFUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CFDataLocker.Models
{
    /// <summary>
    /// Address details
    /// </summary>
    [XmlType("Address")]
    public class Address
    {
        /// <summary>
        /// Line 1
        /// </summary>
        [XmlAttribute("Line1")]
        public string Line1 { get; set; }

        /// <summary>
        /// Line 2
        /// </summary>
        [XmlAttribute("Line2")]
        public string Line2 { get; set; }

        /// <summary>
        /// Town
        /// </summary>
        [XmlAttribute("Town")]
        public string Town { get; set; }

        /// <summary>
        /// County
        /// </summary>
        [XmlAttribute("County")]
        public string County { get; set; }

        /// <summary>
        /// Postcode
        /// </summary>
        [XmlAttribute("Postcode")]
        public string Postcode { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        [XmlAttribute("Country")]        
        public string Country { get; set; }

        public object Clone()
        {
            return new Address()
            {
                Line1 = Line1,
                Line2 = Line2,
                Town = Town,
                County = County,
                Postcode = Postcode,
                Country = Country
            };
        }

        public void Encode()
        {
            this.Line1 = String.IsNullOrEmpty(this.Line1) ? this.Line1 : StringUtilities.EncodeToBase64(this.Line1);
            this.Line2 = String.IsNullOrEmpty(this.Line2) ? this.Line2 : StringUtilities.EncodeToBase64(this.Line2);
            this.Town = String.IsNullOrEmpty(this.Town) ? this.Town : StringUtilities.EncodeToBase64(this.Town);
            this.County = String.IsNullOrEmpty(this.County) ? this.County : StringUtilities.EncodeToBase64(this.County);
            this.Postcode = String.IsNullOrEmpty(this.Postcode) ? this.Postcode : StringUtilities.EncodeToBase64(this.Postcode);
            this.Country = String.IsNullOrEmpty(this.Country) ? this.Country : StringUtilities.EncodeToBase64(this.Country);
        }

        public void Decode()
        {
            this.Line1 = String.IsNullOrEmpty(this.Line1) ? this.Line1 : StringUtilities.DecodeFromBase64(this.Line1);
            this.Line2 = String.IsNullOrEmpty(this.Line2) ? this.Line2 : StringUtilities.DecodeFromBase64(this.Line2);
            this.Town = String.IsNullOrEmpty(this.Town) ? this.Town : StringUtilities.DecodeFromBase64(this.Town);
            this.County = String.IsNullOrEmpty(this.County) ? this.County : StringUtilities.DecodeFromBase64(this.County);
            this.Postcode = String.IsNullOrEmpty(this.Postcode) ? this.Postcode : StringUtilities.DecodeFromBase64(this.Postcode);
            this.Country = String.IsNullOrEmpty(this.Country) ? this.Country : StringUtilities.DecodeFromBase64(this.Country);
        }
    }
}

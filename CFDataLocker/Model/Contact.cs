using CFUtilities;
using System;
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

        [XmlAttribute("Address")]
        public string Address { get; set; }

        [XmlAttribute("EmailAddress")]
        public string EmailAddress { get; set; }

        [XmlAttribute("Telephone")]
        public string Telephone { get; set; }

        public object Clone()
        {
            return new Contact()
            {
                Name = Name,
                Address = Address,
                EmailAddress = EmailAddress,
                Telephone = Telephone
            };
        }


        public void Encode()
        {
            this.EmailAddress = String.IsNullOrEmpty(this.EmailAddress) ? this.EmailAddress : StringUtilities.EncodeToBase64(this.EmailAddress);
            this.Address = String.IsNullOrEmpty(this.Address) ? this.Address : StringUtilities.EncodeToBase64(this.Address);
            this.Name = String.IsNullOrEmpty(this.Name) ? this.Name : StringUtilities.EncodeToBase64(this.Name);
            this.Telephone = String.IsNullOrEmpty(this.Telephone) ? this.Telephone : StringUtilities.EncodeToBase64(this.Telephone);
        }

        public void Decode()
        {
            this.EmailAddress = String.IsNullOrEmpty(this.EmailAddress) ? this.EmailAddress : StringUtilities.DecodeFromBase64(this.EmailAddress);
            this.Address = String.IsNullOrEmpty(this.Address) ? this.Address : StringUtilities.DecodeFromBase64(this.Address);
            this.Name = String.IsNullOrEmpty(this.Name) ? this.Name : StringUtilities.DecodeFromBase64(this.Name);
            this.Telephone = String.IsNullOrEmpty(this.Telephone) ? this.Telephone : StringUtilities.DecodeFromBase64(this.Telephone);
        }
    }
}

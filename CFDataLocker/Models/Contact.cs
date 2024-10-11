using CFUtilities;
using System;
using System.Xml.Serialization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CFDataLocker.Models
{
    /// <summary>
    /// Contact details
    /// </summary>
    [XmlType("Contact")]
    public class Contact
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlElement("Address")]
        public Address Address { get; set; }

        [XmlAttribute("Email")]
        [EmailAddress]
        public string Email { get; set; }

        [XmlAttribute("Telephone")]
        [Phone]
        public string Telephone { get; set; }

        public object Clone()
        {
            return new Contact()
            {
                Name = Name,
                Address = Address == null ? null : (Address)Address.Clone(),
                Email = Email,
                Telephone = Telephone
            };
        }


        public void Encode()
        {
            this.Email = String.IsNullOrEmpty(this.Email) ? this.Email : StringUtilities.EncodeToBase64(this.Email);            
            this.Name = String.IsNullOrEmpty(this.Name) ? this.Name : StringUtilities.EncodeToBase64(this.Name);
            this.Telephone = String.IsNullOrEmpty(this.Telephone) ? this.Telephone : StringUtilities.EncodeToBase64(this.Telephone);

            this.Address?.Encode();
        }

        public void Decode()
        {
            this.Email = String.IsNullOrEmpty(this.Email) ? this.Email : StringUtilities.DecodeFromBase64(this.Email);            
            this.Name = String.IsNullOrEmpty(this.Name) ? this.Name : StringUtilities.DecodeFromBase64(this.Name);
            this.Telephone = String.IsNullOrEmpty(this.Telephone) ? this.Telephone : StringUtilities.DecodeFromBase64(this.Telephone);

            this.Address?.Decode();
        }
    }
}

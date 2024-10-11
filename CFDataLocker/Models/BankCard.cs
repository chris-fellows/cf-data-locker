using CFUtilities;
using System;
using System.Xml.Serialization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CFDataLocker.Models
{
    /// <summary>
    /// Bank card details
    /// </summary>
    [XmlType("BankCard")]
    public class BankCard
    {
        /// <summary>
        /// Bank card name
        /// </summary>
        [XmlAttribute("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Bank card number
        /// </summary>
        [XmlAttribute("Number")]
        [MaxLength(20, ErrorMessage = "Number must be no longer than 20")]
        [RegularExpression(@"/^\d+$/", ErrorMessage = "Number must be numeric digits only")]
        public string Number { get; set; }

        /// <summary>
        /// Bank card expiry date
        /// </summary>
        [XmlAttribute("ExpiryDate")]
        [MaxLength(7, ErrorMessage = "ExpiryDate must be no longer than 7")]
        public string ExpiryDate { get; set; }

        /// <summary>
        /// Bank card security
        /// </summary>
        [XmlAttribute("Security")]
        [MaxLength(5, ErrorMessage = "Security must be no longer than 5")]
        [RegularExpression(@"/^\d+$/", ErrorMessage = "Security must be numeric digits only")]
        public string Security { get; set; }

        public object Clone()
        {
            return new BankCard()
            {
                Name = Name,            
                Number = Number,
                ExpiryDate = ExpiryDate,
                Security = Security
            };
        }

        public void Encode()
        {            
            this.Name = String.IsNullOrEmpty(this.Name) ? this.Name : StringUtilities.EncodeToBase64(this.Name);
            this.Number = String.IsNullOrEmpty(this.Number) ? this.Number : StringUtilities.EncodeToBase64(this.Number);
            this.ExpiryDate = String.IsNullOrEmpty(this.ExpiryDate) ? this.ExpiryDate : StringUtilities.EncodeToBase64(this.ExpiryDate);
            this.Security = String.IsNullOrEmpty(this.Security) ? this.Security : StringUtilities.EncodeToBase64(this.Security);
        }

        public void Decode()
        {            
            this.Name = String.IsNullOrEmpty(this.Name) ? this.Name : StringUtilities.DecodeFromBase64(this.Name);
            this.Number = String.IsNullOrEmpty(this.Number) ? this.Number : StringUtilities.DecodeFromBase64(this.Number);
            this.ExpiryDate = String.IsNullOrEmpty(this.ExpiryDate) ? this.ExpiryDate : StringUtilities.DecodeFromBase64(this.ExpiryDate);
            this.Security = String.IsNullOrEmpty(this.Security) ? this.Security : StringUtilities.DecodeFromBase64(this.Security);
        }
    }
}

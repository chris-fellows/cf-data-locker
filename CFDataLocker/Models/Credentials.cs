using CFUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CFDataLocker.Models
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

        [XmlAttribute("Pin")]
        public string Pin { get; set; }

        public object Clone()
        {
            return new Credentials()
            {
                Password = Password,
                UserName = UserName,
                Pin = Pin
            };
        }

        public void Encode()
        {
            this.Password = String.IsNullOrEmpty(this.Password) ? this.Password : StringUtilities.EncodeToBase64(this.Password);
            this.UserName = String.IsNullOrEmpty(this.UserName) ? this.UserName : StringUtilities.EncodeToBase64(this.UserName);
            this.Pin = String.IsNullOrEmpty(this.Pin) ? this.Pin : StringUtilities.EncodeToBase64(this.Pin);
        }

        public void Decode()
        {
            this.Password = String.IsNullOrEmpty(this.Password) ? this.Password : StringUtilities.DecodeFromBase64(this.Password);
            this.UserName = String.IsNullOrEmpty(this.UserName) ? this.UserName : StringUtilities.DecodeFromBase64(this.UserName);
            this.Pin = String.IsNullOrEmpty(this.Pin) ? this.Pin : StringUtilities.DecodeFromBase64(this.Pin);
        }
    }
}

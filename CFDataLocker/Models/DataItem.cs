using CFUtilities;
using System;
using System.Xml.Serialization;

namespace CFDataLocker.Models
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

        /// <summary>
        /// Bank card
        /// </summary>
        [XmlElement("BankCard")]
        public BankCard BankCard { get; set; }

        /// <summary>
        /// Security questions
        /// </summary>
        [XmlElement("SecurityQuestions")]
        public SecurityQuestions SecurityQuestions { get; set; }

        public object Clone()
        {
            return new DataItem()
            {
                AccountNumber = AccountNumber,
                Active = Active,
                Contact = Contact == null ? null : (Contact)Contact.Clone(),
                Credentials = Credentials == null ? null : (Credentials)Credentials.Clone(),
                Description = Description,
                GroupID = GroupID,
                ID = ID,
                Notes = Notes,
                URL = URL,
                BankCard = BankCard == null ? null : (BankCard)BankCard.Clone(),
                SecurityQuestions = SecurityQuestions == null ? null : (SecurityQuestions)SecurityQuestions.Clone()
            }; 
        }
        
        public void Encode()
        {
            AccountNumber = String.IsNullOrEmpty(AccountNumber) ? AccountNumber : StringUtilities.EncodeToBase64(AccountNumber);
            Description = String.IsNullOrEmpty(Description) ? Description : StringUtilities.EncodeToBase64(Description);
            Notes = String.IsNullOrEmpty(Notes) ? Notes : StringUtilities.EncodeToBase64(Notes);
            URL = String.IsNullOrEmpty(URL) ? URL : StringUtilities.EncodeToBase64(URL);

            Credentials?.Encode();
            Contact?.Encode();
            BankCard?.Encode();
            SecurityQuestions?.Encode();
        }
        
        public void Decode()
        {
            AccountNumber = String.IsNullOrEmpty(AccountNumber) ? AccountNumber : StringUtilities.DecodeFromBase64(AccountNumber);
            Description = String.IsNullOrEmpty(Description) ? Description : StringUtilities.DecodeFromBase64(Description);
            Notes = String.IsNullOrEmpty(Notes) ? Notes : StringUtilities.DecodeFromBase64(Notes);
            URL = String.IsNullOrEmpty(URL) ? URL : StringUtilities.DecodeFromBase64(URL);

            Credentials?.Decode();
            Contact?.Decode();
            BankCard?.Decode();
            SecurityQuestions?.Decode();
        }
    }
}

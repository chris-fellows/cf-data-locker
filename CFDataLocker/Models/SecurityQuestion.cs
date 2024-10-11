using CFUtilities;
using System;
using System.Xml.Serialization;

namespace CFDataLocker.Models
{
    /// <summary>
    /// Security question
    /// </summary>
    [XmlType("SecurityQuestion")]
    public class SecurityQuestion
    {
        [XmlElement("Question")]
        public string Question { get; set; } = String.Empty;

        [XmlElement("Answer")]
        public string Answer { get; set; } = String.Empty;

        public object Clone()
        {
            return new SecurityQuestion()
            {
                Question = Question,
                Answer = Answer
            };
        }

        public void Encode()
        {
            this.Question = String.IsNullOrEmpty(this.Question) ? this.Question : StringUtilities.EncodeToBase64(this.Question);
            this.Answer = String.IsNullOrEmpty(this.Answer) ? this.Answer : StringUtilities.EncodeToBase64(this.Answer);            
        }

        public void Decode()
        {
            this.Question = String.IsNullOrEmpty(this.Question) ? this.Question : StringUtilities.DecodeFromBase64(this.Question);
            this.Answer = String.IsNullOrEmpty(this.Answer) ? this.Answer : StringUtilities.DecodeFromBase64(this.Answer);            
        }
    }
}

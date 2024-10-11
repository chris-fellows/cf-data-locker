using CFUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CFDataLocker.Models
{
    /// <summary>
    /// Security questions
    /// </summary>
    [XmlType("SecurityQuestions")]
    public class SecurityQuestions
    {
        [XmlArray("Questions")]
        [XmlArrayItem("Question")]
        public List<SecurityQuestion> Questions { get; set; }

        public object Clone()
        {
            return new SecurityQuestions()
            {
                Questions = Questions == null ? null : Questions.Select(g => (SecurityQuestion)g.Clone()).ToList(),                
            };
        }

        /// <summary>
        /// Encodes data so that is can be saved
        /// </summary>
        public void Encode()
        {
            Questions.ForEach(q => q.Encode());
        }

        /// <summary>
        /// Decodes encoded data
        /// </summary>
        public void Decode()
        {
            Questions.ForEach(q => q.Decode());
        }
    }
}

namespace CFDataLocker.Models
{
    /// <summary>
    /// Message associated with a property
    /// </summary>
    public class PropertyMessage
    {
        public string Property { get; internal set; }

        public string Text { get; internal set; }

        public PropertyMessage(string property,string text)
        {
            Property = property;
            Text = text;
        }
    }
}

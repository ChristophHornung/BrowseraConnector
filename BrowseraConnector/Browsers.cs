namespace BrowseraConnector
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>
    /// A list of browsers.
    /// </summary>
    [Serializable]
    public class Browsers
    {
        public Browsers()
        {
            this.Type = "array";
        }

        /// <summary>
        /// Gets or sets the browser values, that is the string list of browsers.
        /// </summary>
        /// <value>
        /// The browser values.
        /// </value>
        [XmlElement("browser")]
        public List<string> BrowserValues { get; set; }

        /// <summary>
        /// Gets or sets the type (always "array").
        /// </summary>
        /// <remarks>This is required for the API as an attribute on the xml array element.</remarks>
        /// <value>
        /// The type.
        /// </value>
        [XmlAttribute("type")]
        public string Type { get; set; }
    }
}
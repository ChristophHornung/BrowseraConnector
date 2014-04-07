namespace BrowseraConnector
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>
    /// A list of urls.
    /// </summary>
    [Serializable]
    public class Urls
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Urls"/> class.
        /// </summary>
        public Urls()
        {
            this.Type = "array";
        }

        /// <summary>
        /// Gets or sets the URL values.
        /// </summary>
        /// <value>
        /// The URL values.
        /// </value>
        [XmlElement("url")]
        public List<string> UrlValues { get; set; }

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
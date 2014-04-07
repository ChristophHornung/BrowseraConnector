namespace BrowseraConnector
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>
    /// The pages to exclude from crawling.
    /// </summary>
    [Serializable]
    public class ExcludeCrawlPages
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExcludeCrawlPages"/> class.
        /// </summary>
        public ExcludeCrawlPages()
        {
            this.Type = "array";
        }

        /// <summary>
        /// Gets or sets the URL matches to exclude.
        /// </summary>
        /// <value>
        /// The URL matches.
        /// </value>
        [XmlElement("url_match")]
        public List<string> UrlMatches { get; set; }

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
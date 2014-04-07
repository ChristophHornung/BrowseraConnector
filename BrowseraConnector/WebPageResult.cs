namespace BrowseraConnector
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>
    /// The results for a web page after a test run.
    /// </summary>
    [Serializable]
    public class WebPageResult
    {
        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        [XmlElement("url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        [XmlElement("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the number of layout differences.
        /// </summary>
        /// <value>
        /// The number of layout differences.
        /// </value>
        [XmlElement("number_of_layout_differences")]
        public int NumberOfLayoutDifferences { get; set; }

        /// <summary>
        /// Gets or sets the browser rederings.
        /// </summary>
        /// <value>
        /// The browser rederings.
        /// </value>
        [XmlArray("browser_renderings")]
        [XmlArrayItem("browser_rendering")]
        public List<BrowserRendering> BrowserRederings { get; set; }
    }
}
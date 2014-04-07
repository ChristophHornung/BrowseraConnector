namespace BrowseraConnector
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>
    /// A rendering for a browser.
    /// </summary>
    [Serializable]
    public class BrowserRendering
    {
        /// <summary>
        /// Gets or sets the browser.
        /// </summary>
        /// <value>
        /// The browser.
        /// </value>
        [XmlElement("browser")]
        public string Browser { get; set; }

        /// <summary>
        /// Gets or sets the low res image URL.
        /// </summary>
        /// <value>
        /// The low res image URL.
        /// </value>
        [XmlElement("low_res_image_url")]
        public string LowResImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the high res image URL.
        /// </summary>
        /// <value>
        /// The high res image URL.
        /// </value>
        [XmlElement("high_res_image_url")]
        public string HighResImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the javascript errors that occured on rendering.
        /// </summary>
        /// <value>
        /// The javascript errors.
        /// </value>
        [XmlArray("javascript_errors")]
        [XmlArrayItem("javascript_error")]
        public List<string> JavascriptErrors { get; set; }
    }
}
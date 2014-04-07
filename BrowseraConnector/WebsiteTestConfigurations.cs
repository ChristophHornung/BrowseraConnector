namespace BrowseraConnector
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>
    /// A list of web sites.
    /// </summary>
    [XmlRoot("web_sites")]
    public class WebsiteTestConfigurations
    {
        /// <summary>
        /// Gets or sets the website test configuration values.
        /// </summary>
        /// <value>
        /// The website test configuration values.
        /// </value>
        [XmlElement("web_site")]
        public List<WebsiteTestConfiguration> WebsiteTestConfigurationValues { get; set; }
    }
}
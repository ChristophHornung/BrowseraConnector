namespace BrowseraConnector
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// The configuration for a test run.
    /// </summary>
    [Serializable]
    [XmlRoot("test_run")]
    public class TestRunConfiguration
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
namespace BrowseraConnector
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>
    /// A test run on browsera.
    /// </summary>
    [Serializable]
    [XmlRoot("test_run")]
    public class TestRun
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        [XmlElement("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the date this instance was created at.
        /// </summary>
        /// <value>
        /// The created at.
        /// </value>
        [XmlElement("created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the date this instance was completed at.
        /// </summary>
        /// <value>
        /// The completed at.
        /// </value>
        [XmlElement("completed_at")]
        public string CompletedAt { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <remarks>Is 'Complete' for finished runs.</remarks>
        /// <value>
        /// The status.
        /// </value>
        [XmlElement("status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the completion percentage.
        /// </summary>
        /// <remarks>100 does not always mean 'finished'. Use the status field for that.</remarks>
        /// <value>
        /// The completion percentage.
        /// </value>
        [XmlElement("completion_percentage")]
        public int CompletionPercentage { get; set; }

        /// <summary>
        /// Gets or sets the base line browser.
        /// </summary>
        /// <value>
        /// The base line browser.
        /// </value>
        [XmlElement("baseline_browser")]
        public string BaseLineBrowser { get; set; }

        /// <summary>
        /// Gets or sets the browsers.
        /// </summary>
        /// <value>
        /// The browsers.
        /// </value>
        [XmlArray("browsers")]
        [XmlArrayItem("browser")]
        public List<string> Browsers { get; set; }

        /// <summary>
        /// Gets or sets the web page results.
        /// </summary>
        /// <value>
        /// The web page results.
        /// </value>
        [XmlArray("web_pages")]
        [XmlArrayItem("web_page")]
        public List<WebPageResult> WebPages { get; set; }
    }
}
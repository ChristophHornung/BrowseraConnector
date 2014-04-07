namespace BrowseraConnector
{
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;

    /// <summary>
    /// A configuration for a web site to test.
    /// </summary>
    [Serializable]
    [XmlRoot("web_site")]
    public class WebsiteTestConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebsiteTestConfiguration"/> class.
        /// </summary>
        public WebsiteTestConfiguration()
        {
            this.ExcludeCrawlPages = new ExcludeCrawlPages();
            this.Urls = new Urls();
            this.Browsers = new Browsers();
            this.TestRuns = new TestRuns();
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        [XmlElement("id")]
        [DefaultValue(0)]
        public int Id { get; set; }

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
        [XmlElement("browsers")]
        public Browsers Browsers { get; set; }

        /// <summary>
        /// Gets or sets the urls.
        /// </summary>
        /// <value>
        /// The urls.
        /// </value>
        [XmlElement("urls")]
        public Urls Urls { get; set; }

        /// <summary>
        /// Gets or sets the max crawl pages.
        /// </summary>
        /// <value>
        /// The max crawl pages.
        /// </value>
        [XmlElement("max_crawl_pages")]
        public int MaxCrawlPages { get; set; }

        /// <summary>
        /// Gets or sets the exclude crawl pages.
        /// </summary>
        /// <value>
        /// The exclude crawl pages.
        /// </value>
        [XmlElement("exclude_crawl_pages")]
        public ExcludeCrawlPages ExcludeCrawlPages { get; set; }

        /// <summary>
        /// Gets or sets the interval at which to repeat the test (in weeks).
        /// </summary>
        /// <value>
        /// The retesting interval.
        /// </value>
        [XmlElement("repeat_test_in_weeks")]
        [DefaultValue(0)]
        public int RepeatTestInWeeks { get; set; }

        /// <summary>
        /// Gets or sets the site login configuration.
        /// </summary>
        /// <value>
        /// The site login configuration.
        /// </value>
        [XmlElement("site_login")]
        public SiteLoginConfiguration SiteLoginConfiguration { get; set; }

        /// <summary>
        /// Gets or sets the test runs.
        /// </summary>
        /// <value>
        /// The test runs.
        /// </value>
        [XmlElement("test_runs")]
        public TestRuns TestRuns { get; set; }
    }
}
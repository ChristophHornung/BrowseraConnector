namespace BrowseraConnector
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Xml.Serialization;

    /// <summary>
    /// The connector for the lowest api level.
    /// </summary>
    public class BrowseraConnector
    {
        private const string TestRunsUrl = "https://api.browsera.com/v0.1a/web_sites/{1}/test_runs.xml?api_key={0}";

        private const string GetTestRunUrl =
            "https://api.browsera.com/v0.1a/web_sites/{1}/test_runs/{2}.xml?api_key={0}";

        private const string WebSitesUrl = "https://api.browsera.com/v0.1a/web_sites.xml?api_key={0}";
        private const string GetWebSiteUrl = "https://api.browsera.com/v0.1a/web_sites/{1}.xml?api_key={0}";
        private readonly string apiKey;

        /// <summary>
        /// Initializes a new instance of the <see cref="BrowseraConnector"/> class.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        public BrowseraConnector(string apiKey)
        {
            this.apiKey = apiKey;
        }

        /// <summary>
        /// Lists all the test runs.
        /// </summary>
        /// <param name="webSiteId">The web site id to get all runs for.</param>
        /// <returns>All test runs for the given web site.</returns>
        public IEnumerable<TestRun> ListTestRuns(int webSiteId)
        {
            WebRequest request = WebRequest.Create(String.Format(TestRunsUrl, this.apiKey, webSiteId));
            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof (TestRuns));
                TestRuns result = (TestRuns) xmlSerializer.Deserialize(responseStream);
                return result.TestRunValues;
            }
        }

        /// <summary>
        /// Creates the test run for the given web site.
        /// </summary>
        /// <param name="webSiteId">The web site id.</param>
        /// <param name="testRunConfiguration">The test run configuration to create.</param>
        /// <returns>The created test run.</returns>
        public TestRun CreateTestRun(int webSiteId, TestRunConfiguration testRunConfiguration)
        {
            WebRequest request = WebRequest.Create(String.Format(TestRunsUrl, this.apiKey, webSiteId));
            request.Method = "POST";
            request.ContentType = "application/xml";
            using (Stream requestStream = request.GetRequestStream())
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof (TestRunConfiguration));
                xmlSerializer.Serialize(requestStream, testRunConfiguration);
            }
            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof (TestRun));
                TestRun result = (TestRun) xmlSerializer.Deserialize(responseStream);
                return result;
            }
        }

        /// <summary>
        /// Gets the test run for the given web site configuration and id.
        /// </summary>
        /// <param name="webSiteId">The web site id.</param>
        /// <param name="id">The id of the test run.</param>
        /// <returns>The test run with the given id for the web site with the given id.</returns>
        public TestRun GetTestRun(int webSiteId, int id)
        {
            WebRequest request = WebRequest.Create(String.Format(GetTestRunUrl, this.apiKey, webSiteId, id));
            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof (TestRun));
                TestRun result = (TestRun) xmlSerializer.Deserialize(responseStream);
                return result;
            }
        }

        /// <summary>
        /// Lists all web site configurations.
        /// </summary>
        /// <returns>All web site configurations.</returns>
        public IEnumerable<WebsiteTestConfiguration> ListWebSites()
        {
            WebRequest request = WebRequest.Create(String.Format(WebSitesUrl, this.apiKey));
            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof (WebsiteTestConfigurations));
                WebsiteTestConfigurations result = (WebsiteTestConfigurations) xmlSerializer.Deserialize(responseStream);
                return result.WebsiteTestConfigurationValues;
            }
        }

        /// <summary>
        /// Creates a web site configuration.
        /// </summary>
        /// <param name="website">The website configuration to create.</param>
        /// <returns>The created configuration.</returns>
        public WebsiteTestConfiguration CreateWebSite(WebsiteTestConfiguration website)
        {
            WebRequest request = WebRequest.Create(String.Format(WebSitesUrl, this.apiKey));
            request.Method = "POST";
            request.ContentType = "application/xml";
            using (Stream requestStream = request.GetRequestStream())
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof (WebsiteTestConfiguration));
                xmlSerializer.Serialize(requestStream, website);
            }
            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof (WebsiteTestConfiguration));
                WebsiteTestConfiguration result = (WebsiteTestConfiguration) xmlSerializer.Deserialize(responseStream);
                return result;
            }
        }

        /// <summary>
        /// Gets the web site configuration with the given id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The web site configuration for the given id.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public WebsiteTestConfiguration GetWebSite(int id)
        {
            throw new NotImplementedException();
        }
    }
}
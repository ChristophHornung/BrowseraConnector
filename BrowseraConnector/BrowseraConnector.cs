#region header

//     This file is part of BrowseraConnector.
// 
//     BrowseraConnector is free software: you can redistribute it and/or modify
//     it under the terms of the GNU Lesser General Public License as published by
//     the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
// 
//     BrowseraConnector is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU Lesser General Public License for more details.
// 
//     You should have received a copy of the GNU Lesser General Public License
//     along with Foobar.  If not, see <http://www.gnu.org/licenses/>.

#endregion

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
    /// <remarks>This is the http access to the xml structures that browsera supports. 
    /// This api only provides limited access though, since some methods are only available from their web interface.
    /// </remarks>
    public class BrowseraConnector
    {
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
            WebRequest request = WebRequest.Create(String.Format(ConnectionUrl.TestRunsUrl, this.apiKey, webSiteId));
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
            WebRequest request = WebRequest.Create(String.Format(ConnectionUrl.TestRunsUrl, this.apiKey, webSiteId));
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
            WebRequest request =
                WebRequest.Create(String.Format(ConnectionUrl.GetTestRunUrl, this.apiKey, webSiteId, id));
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
            WebRequest request = WebRequest.Create(String.Format(ConnectionUrl.WebSitesUrl, this.apiKey));
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
            WebRequest request = WebRequest.Create(String.Format(ConnectionUrl.WebSitesUrl, this.apiKey));
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
        public WebsiteTestConfiguration GetWebSite(int id)
        {
            WebRequest request = WebRequest.Create(String.Format(ConnectionUrl.GetWebSiteUrl, this.apiKey, id));
            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof (WebsiteTestConfiguration));
                WebsiteTestConfiguration result = (WebsiteTestConfiguration) xmlSerializer.Deserialize(responseStream);
                return result;
            }
        }
    }
}
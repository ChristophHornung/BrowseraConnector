namespace BrowseraConnector
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// An executor that abstracts away the browsera API.
    /// </summary>
    public class BrowseraTestExecutor
    {
        private readonly string apiKey;

        /// <summary>
        /// The connector
        /// </summary>
        private readonly BrowseraConnector connector;


        /// <summary>
        /// Initializes a new instance of the <see cref="BrowseraTestExecutor"/> class.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        public BrowseraTestExecutor(string apiKey)
        {
            this.apiKey = apiKey;
            this.connector = new BrowseraConnector(apiKey);
        }

        /// <summary>
        /// Runs a new test on site.
        /// </summary>
        /// <param name="siteName">The name of the site to run the test on.</param>
        /// <returns>The started test run.</returns>
        public TestRun RunTestOnSite(string siteName)
        {
            return this.RunTestOnSiteInternal(siteName, false, null);
        }

        /// <summary>
        /// Runs the test on the given site and polls the result until finished and then copies the result into a directory.
        /// </summary>
        /// <param name="siteName">The name of the site.</param>
        /// <param name="targetDirectory">The target directory.</param>
        /// <returns>The finished test run.</returns>
        public TestRun RunTestOnSiteAndPollResult(string siteName, string targetDirectory)
        {
            return this.RunTestOnSiteInternal(siteName, true, targetDirectory);
        }

        private TestRun RunTestOnSiteInternal(string siteName, bool poll, string targetDirectory)
        {
            IEnumerable<WebsiteTestConfiguration> sites = this.connector.ListWebSites();
            WebsiteTestConfiguration site =
                sites.SingleOrDefault(p => p.Name.Equals(siteName, StringComparison.InvariantCultureIgnoreCase));
            if (site == null)
            {
                throw new InvalidOperationException("Could not find specified site.");
            }

            TestRun testRun = this.connector.CreateTestRun(site.Id, CreateTestRunConfiguration());

            if (poll)
            {
                TestRunResultPoller poller = new TestRunResultPoller(this.apiKey);
                testRun = poller.PollResultToDirectory(site.Id, testRun.Id, targetDirectory);
            }

            return testRun;
        }


        private static TestRunConfiguration CreateTestRunConfiguration()
        {
            return new TestRunConfiguration() {Name = "Automatic test " + DateTime.Now};
        }

        /// <summary>
        /// Creates a new site and runs a test.
        /// </summary>
        /// <param name="configuration">The configuration for the new site.</param>
        public void CreateSiteAndRunTest(WebsiteTestConfiguration configuration)
        {
            WebsiteTestConfiguration site = this.connector.CreateWebSite(configuration);
            this.connector.CreateTestRun(site.Id, CreateTestRunConfiguration());
        }
    }
}
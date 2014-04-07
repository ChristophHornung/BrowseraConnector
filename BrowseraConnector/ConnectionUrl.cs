namespace BrowseraConnector
{
    /// <summary>
    /// The different urls for the browsera API.
    /// </summary>
    public static class ConnectionUrl
    {
        public const string TestRunsUrl = "https://api.browsera.com/v0.1a/web_sites/{1}/test_runs.xml?api_key={0}";

        public const string GetTestRunUrl =
            "https://api.browsera.com/v0.1a/web_sites/{1}/test_runs/{2}.xml?api_key={0}";

        public const string WebSitesUrl = "https://api.browsera.com/v0.1a/web_sites.xml?api_key={0}";
        public const string GetWebSiteUrl = "https://api.browsera.com/v0.1a/web_sites/{1}.xml?api_key={0}";
    }
}
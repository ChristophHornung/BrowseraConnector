namespace Tester
{
    using System.Collections.Generic;
    using BrowseraConnector;

    internal class Program
    {
        private static void Main(string[] args)
        {
            string apiKey = "";
            BrowseraConnector connector = new BrowseraConnector(apiKey);
            var result2 = connector.ListWebSites();
            var runs = connector.ListTestRuns(29350);
        }

        private static WebsiteTestConfiguration GetWebsiteTestConfiguration()
        {
            return new WebsiteTestConfiguration()
            {
                BaseLineBrowser = "Chrome 33",
                Browsers = new Browsers()
                {
                    BrowserValues = new List<string>()
                    {
                        "Chrome 33",
                        "Firefox 3.6",
                        "Firefox 24",
                        "Firefox 26",
                        "Firefox 27",
                        "Internet Explorer 6",
                        "Internet Explorer 7",
                        "Internet Explorer 8",
                        "Internet Explorer 9",
                        "Internet Explorer 10",
                        "Internet Explorer 11",
                        "Safari 3.2",
                        "Safari 4",
                        "Safari 5",
                        "Safari 6"
                    }
                },
                MaxCrawlPages = 0,
                Name = "Test",
                Urls = new Urls() {UrlValues = new List<string>() {@"http://test.com/"}},
                SiteLoginConfiguration = GetLoginConfiguration()
            };
        }

        private static SiteLoginConfiguration GetLoginConfiguration()
        {
            return null;
            return new SiteLoginConfiguration()
            {
                IsWebsiteLogin = true,
                LoginPageUrl = "http://test.com/",
                Password = "testtest",
                UserName = "test",
                PasswordInputId = "splash-password",
                UserNameInputId = "splash-username"
            };
        }
    }
}
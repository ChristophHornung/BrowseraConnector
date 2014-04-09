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

namespace BrowseraBuildTasks
{
    using System.Collections.Generic;
    using System.IO;
    using BrowseraConnector;
    using Microsoft.Build.Utilities;

    /// <summary>
    /// A build task to automate creation and starts of browsera tasks
    /// </summary>
    public class AutomatedBrowseraTask : Task
    {
        public string CustomJavascript { get; set; }

        public string LoginUrl { get; set; }

        public string[] Pages { get; set; }

        public string[] Browsers { get; set; }

        public string ApiKey { get; set; }

        public string ResultDirectory { get; set; }

        public string SiteName { get; set; }

        public string BaseLineBrowser { get; set; }

        public static string SubmitInputId { get; set; }

        public static string UserNameInputId { get; set; }

        public static string PasswordInputId { get; set; }

        public static string UserName { get; set; }

        public static string Password { get; set; }

        public override bool Execute()
        {
            Directory.CreateDirectory(this.ResultDirectory);
            BrowseraTestExecutor executor = new BrowseraTestExecutor(this.ApiKey);
            executor.CreateSiteAndRunTestAndPollResult(this.GetWebsiteTestConfiguration(), this.ResultDirectory);
            return true;
        }

        private WebsiteTestConfiguration GetWebsiteTestConfiguration()
        {
            return new WebsiteTestConfiguration()
            {
                BaseLineBrowser = this.BaseLineBrowser,
                Browsers = new Browsers()
                {
                    BrowserValues = new List<string>(this.Browsers)
                },
                MaxCrawlPages = 0,
                Name = this.SiteName,
                Urls = new Urls() {UrlValues = new List<string>(this.Pages)},
                SiteLoginConfiguration = this.GetLoginConfiguration()
            };
        }

        private SiteLoginConfiguration GetLoginConfiguration()
        {
            return new SiteLoginConfiguration()
            {
                IsWebsiteLogin = true,
                LoginPageUrl = this.LoginUrl,
                Password = Password,
                UserName = UserName,
                PasswordInputId = PasswordInputId,
                UserNameInputId = UserNameInputId,
                SubmitInputId = SubmitInputId,
                SubmitJavascript = this.CustomJavascript
            };
        }
    }
}
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
    using System;
    using System.Collections.Generic;
    using System.IO;
    using BrowseraConnector;
    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;

    /// <summary>
    /// A build task to automate creation and starts of browsera tasks
    /// </summary>
    public class SimpleBrowseraTestTask : BrowseraBaseTask
    {
        public SimpleBrowseraTestTask() : base(false)
        {
        }

        protected override WebsiteTestConfiguration GetWebsiteTestConfiguration()
        {
            throw new NotImplementedException();
        }
    }

    public abstract class BrowseraBaseTask : Task
    {
        private readonly bool createNewSite;

        protected BrowseraBaseTask(bool createNewSite)
        {
            this.createNewSite = createNewSite;
        }

        public string SiteName { get; set; }

        public string ApiKey { get; set; }

        public string ResultDirectory { get; set; }

        public override bool Execute()
        {
            if (!Directory.Exists(this.ResultDirectory))
            {
                this.Log.LogMessage(MessageImportance.Low, "Creating result directory " + this.ResultDirectory);
                Directory.CreateDirectory(this.ResultDirectory);
            }

            BrowseraTestExecutor executor = new BrowseraTestExecutor(this.ApiKey);
            if (this.createNewSite)
            {
                executor.CreateSiteAndRunTestAndPollResult(this.GetWebsiteTestConfiguration(), this.ResultDirectory);
            }
            else
            {
                executor.RunTestOnSiteAndPollResult(this.SiteName, this.ResultDirectory);
            }
            return true;
        }

        protected abstract WebsiteTestConfiguration GetWebsiteTestConfiguration();
    }

    /// <summary>
    /// A build task to automate creation and starts of browsera tasks
    /// </summary>
    public class ComplexBrowseraTestTask : BrowseraBaseTask
    {
        public ComplexBrowseraTestTask() : base(true)
        {
        }

        public string CustomJavascript { get; set; }

        public string LoginUrl { get; set; }

        public string[] Pages { get; set; }

        public string[] Browsers { get; set; }

        public string BaseLineBrowser { get; set; }

        public static string SubmitInputId { get; set; }

        public static string UserNameInputId { get; set; }

        public static string PasswordInputId { get; set; }

        public static string UserName { get; set; }

        public static string Password { get; set; }

        protected override WebsiteTestConfiguration GetWebsiteTestConfiguration()
        {
            return new WebsiteTestConfiguration()
            {
                BaseLineBrowser = this.BaseLineBrowser,
                Browsers = new Browsers()
                {
                    BrowserValues = new List<string>(this.Browsers)
                },
                MaxCrawlPages = 0,
                Name = this.SiteName + " (" + DateTime.UtcNow + ")",
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
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
    using BrowseraConnector;
    using Microsoft.Build.Framework;

    /// <summary>
    /// A build task to automate creation and start of a Browsera test run.
    /// </summary>
    public class CreateAndRunBrowseraTestTask : BrowseraBaseTask
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateAndRunBrowseraTestTask"/> class.
        /// </summary>
        public CreateAndRunBrowseraTestTask() : base(true)
        {
        }

        /// <summary>
        /// Gets or sets the custom javascript used for the login configuration.
        /// </summary>
        /// <value>
        /// The custom javascript.
        /// </value>
        public string CustomJavascript { get; set; }

        /// <summary>
        /// Gets or sets the login URL.
        /// </summary>
        /// <value>
        /// The login URL.
        /// </value>
        public string LoginUrl { get; set; }

        /// <summary>
        /// Gets or sets the pages that should be tested.
        /// </summary>
        /// <value>
        /// The pages.
        /// </value>
        [Required]
        public string[] Pages { get; set; }

        /// <summary>
        /// Gets or sets the browsers the test should use.
        /// </summary>
        /// <value>
        /// The browsers.
        /// </value>
        [Required]
        public string[] Browsers { get; set; }

        /// <summary>
        /// Gets or sets the base line browser to use for the test.
        /// </summary>
        /// <value>
        /// The base line browser.
        /// </value>
        [Required]
        public string BaseLineBrowser { get; set; }

        /// <summary>
        /// Gets or sets the submit input id for the login configuration.
        /// </summary>
        /// <value>
        /// The submit input id.
        /// </value>
        public string SubmitInputId { get; set; }

        /// <summary>
        /// Gets or sets the user name input id for the login configuration.
        /// </summary>
        /// <value>
        /// The user name input id.
        /// </value>
        public string UserNameInputId { get; set; }

        /// <summary>
        /// Gets or sets the password input id for the login configuration.
        /// </summary>
        /// <value>
        /// The password input id.
        /// </value>
        public string PasswordInputId { get; set; }

        /// <summary>
        /// Gets or sets the name of the user for the login configuration.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password for the login configuration.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }

        /// <summary>
        /// Gets the website test configuration.
        /// </summary>
        /// <returns>The website that should be created.</returns>
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
                IsWebsiteLogin = IsWebsiteLogin,
                LoginPageUrl = this.LoginUrl,
                Password = Password,
                UserName = UserName,
                PasswordInputId = PasswordInputId,
                UserNameInputId = UserNameInputId,
                SubmitInputId = SubmitInputId,
                SubmitJavascript = this.CustomJavascript
            };
        }

        /// <summary>
        /// Gets or sets a value indicating whether to use a website login.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is website login; otherwise, <c>false</c>.
        /// </value>
        public bool IsWebsiteLogin { get; set; }
    }
}
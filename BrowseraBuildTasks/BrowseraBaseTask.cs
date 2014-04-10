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
    using System.IO;
    using BrowseraConnector;
    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;

    /// <summary>
    /// The base task for browsera test runs.
    /// </summary>
    public abstract class BrowseraBaseTask : Task
    {
        private readonly bool createNewSite;

        protected BrowseraBaseTask(bool createNewSite)
        {
            this.createNewSite = createNewSite;
        }

        /// <summary>
        /// Gets or sets the name of the site to run the test on.
        /// </summary>
        /// <value>
        /// The name of the site to run the test on.
        /// </value>
        [Required]
        public string SiteName { get; set; }

        /// <summary>
        /// Gets or sets the API key.
        /// </summary>
        /// <value>
        /// The API key.
        /// </value>
        [Required]
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets or sets the directory where the test results are polled into.
        /// </summary>
        /// <value>
        /// The result directory.
        /// </value>
        [Required]
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

        /// <summary>
        /// Gets the website test configuration.
        /// </summary>
        /// <returns>The website that should be created.</returns>
        protected abstract WebsiteTestConfiguration GetWebsiteTestConfiguration();
    }
}
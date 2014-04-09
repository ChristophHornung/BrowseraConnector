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

    public abstract class BrowseraBaseTask : Task
    {
        private readonly bool createNewSite;

        protected BrowseraBaseTask(bool createNewSite)
        {
            this.createNewSite = createNewSite;
        }

        [Required]
        public string SiteName { get; set; }

        [Required]
        public string ApiKey { get; set; }

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

        protected abstract WebsiteTestConfiguration GetWebsiteTestConfiguration();
    }
}
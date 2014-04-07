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
    /// <summary>
    /// The different urls for the browsera API.
    /// </summary>
    internal static class ConnectionUrl
    {
        /// <summary>
        /// The URL to access all test runs.
        /// </summary>
        internal const string TestRunsUrl = "https://api.browsera.com/v0.1a/web_sites/{1}/test_runs.xml?api_key={0}";

        /// <summary>
        /// The URL to access a specific test run.
        /// </summary>
        internal const string GetTestRunUrl =
            "https://api.browsera.com/v0.1a/web_sites/{1}/test_runs/{2}.xml?api_key={0}";

        /// <summary>
        /// The URL to access all websites.
        /// </summary>
        internal const string WebSitesUrl = "https://api.browsera.com/v0.1a/web_sites.xml?api_key={0}";

        /// <summary>
        /// The URL to access a specific website.
        /// </summary>
        internal const string GetWebSiteUrl = "https://api.browsera.com/v0.1a/web_sites/{1}.xml?api_key={0}";
    }
}
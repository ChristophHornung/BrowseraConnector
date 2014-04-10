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
    using BrowseraConnector;

    /// <summary>
    /// A build task to automate starting a Browsera test for an already existing site.
    /// </summary>
    public class RunBrowseraTestTask : BrowseraBaseTask
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RunBrowseraTestTask"/> class.
        /// </summary>
        public RunBrowseraTestTask() : base(false)
        {
        }

        protected override WebsiteTestConfiguration GetWebsiteTestConfiguration()
        {
            // we don't need to implement this because this task won't create a new configuratin.
            throw new NotImplementedException();
        }
    }
}
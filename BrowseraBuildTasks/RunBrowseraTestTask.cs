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
    /// A build task to automate creation and starts of browsera tasks
    /// </summary>
    public class RunBrowseraTestTask : BrowseraBaseTask
    {
        public RunBrowseraTestTask() : base(false)
        {
        }

        protected override WebsiteTestConfiguration GetWebsiteTestConfiguration()
        {
            throw new NotImplementedException();
        }
    }
}
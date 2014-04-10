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

namespace BrowseraPoller
{
    using System;
    using System.IO;
    using BrowseraConnector;

    /// <summary>
    /// The main command line poller. This is a simple command line utility that 
    /// allows running a test on an already configured site and polling the result to a given
    /// directory.
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("Usage: BrowseraPoller SiteName ApiKey ResultDir");
                return;
            }

            string siteName = args[0];
            string apiKey = args[1];
            string resultDir = args[2];

            Directory.CreateDirectory(resultDir);
            BrowseraTestExecutor executor = new BrowseraTestExecutor(apiKey);
            TestRun result = executor.RunTestOnSiteAndPollResult(siteName, resultDir);
            Console.WriteLine("Finished test run " + result.Name);
        }
    }
}
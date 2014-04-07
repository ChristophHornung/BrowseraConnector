namespace BrowseraPoller
{
    using System;
    using System.IO;
    using BrowseraConnector;

    /// <summary>
    /// The main command line poller.
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
namespace BrowseraConnector
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text.RegularExpressions;
    using System.Threading;

    /// <summary>
    /// A poller to monitor a run and poll all results into a directory.
    /// </summary>
    public class TestRunResultPoller
    {
        private readonly BrowseraConnector connector;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestRunResultPoller"/> class.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        public TestRunResultPoller(string apiKey)
        {
            this.connector = new BrowseraConnector(apiKey);
        }

        /// <summary>
        /// Polls the result until the run is finished and saves it to a directory.
        /// </summary>
        /// <param name="webSiteId">The web site id.</param>
        /// <param name="testId">The test id.</param>
        /// <param name="directory">The directory to save to.</param>
        /// <returns>The finished test run.</returns>
        public TestRun PollResultToDirectory(int webSiteId, int testId, string directory)
        {
            Directory.CreateDirectory(directory);

            bool finished = false;
            TestRun run = null;
            while (!finished)
            {
                run = this.connector.GetTestRun(webSiteId, testId);
                if (run.Status == "Complete")
                {
                    finished = true;
                }
                else
                {
                    Thread.Sleep(60000);
                }
            }

            List<string> javascriptErrorLines = new List<string>();

            // Lets save all high res images.
            foreach (WebPageResult webPage in run.WebPages)
            {
                foreach (BrowserRendering rendering in webPage.BrowserRederings)
                {
                    this.CopyRendering(webPage, rendering, directory);
                    javascriptErrorLines.AddRange(
                        rendering.JavascriptErrors.Select(error => rendering.Browser + ": " + error));
                }
            }

            // Lets also write out all javascript errors.
            using (var writer = new StreamWriter(directory + Path.DirectorySeparatorChar + "javascripterrors.txt"))
            {
                foreach (string line in javascriptErrorLines)
                {
                    writer.WriteLine(line);
                }
            }

            return run;
        }

        private void CopyRendering(WebPageResult webPage, BrowserRendering rendering, string directory)
        {
            string targetFile = directory + Path.DirectorySeparatorChar +
                                ToValidFileName(webPage.Url + rendering.Browser) + ".jpg";
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFile(rendering.HighResImageUrl, targetFile);
            }
        }

        private static string ToValidFileName(string name)
        {
            string invalidChars = Regex.Escape(new string(Path.GetInvalidFileNameChars()));
            string regEx = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);

            return Regex.Replace(name, regEx, "_");
        }
    }
}
namespace BrowseraConnector
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>
    /// A list of <see cref="TestRun"/>s.
    /// </summary>
    [Serializable]
    [XmlRoot("test_runs")]
    public class TestRuns
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestRuns"/> class.
        /// </summary>
        public TestRuns()
        {
            this.Type = "array";
        }

        /// <summary>
        /// Gets or sets the test runs.
        /// </summary>
        /// <value>
        /// The test runs.
        /// </value>
        [XmlElement("test_run")]
        public List<TestRun> TestRunValues { get; set; }

        /// <summary>
        /// Gets or sets the type (always "array").
        /// </summary>
        /// <remarks>This is required for the API as an attribute on the xml array element.</remarks>
        /// <value>
        /// The type.
        /// </value>
        [XmlAttribute("type")]
        public string Type { get; set; }
    }
}
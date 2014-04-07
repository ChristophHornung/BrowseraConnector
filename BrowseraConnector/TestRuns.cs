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
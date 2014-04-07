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
    /// The results for a web page after a test run.
    /// </summary>
    [Serializable]
    public class WebPageResult
    {
        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        [XmlElement("url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        [XmlElement("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the number of layout differences.
        /// </summary>
        /// <value>
        /// The number of layout differences.
        /// </value>
        [XmlElement("number_of_layout_differences")]
        public int NumberOfLayoutDifferences { get; set; }

        /// <summary>
        /// Gets or sets the browser rederings.
        /// </summary>
        /// <value>
        /// The browser rederings.
        /// </value>
        [XmlArray("browser_renderings")]
        [XmlArrayItem("browser_rendering")]
        public List<BrowserRendering> BrowserRederings { get; set; }
    }
}
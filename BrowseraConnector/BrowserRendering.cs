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
    /// A rendering for a browser.
    /// </summary>
    [Serializable]
    public class BrowserRendering
    {
        /// <summary>
        /// Gets or sets the browser.
        /// </summary>
        /// <value>
        /// The browser.
        /// </value>
        [XmlElement("browser")]
        public string Browser { get; set; }

        /// <summary>
        /// Gets or sets the low res image URL.
        /// </summary>
        /// <value>
        /// The low res image URL.
        /// </value>
        [XmlElement("low_res_image_url")]
        public string LowResImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the high res image URL.
        /// </summary>
        /// <value>
        /// The high res image URL.
        /// </value>
        [XmlElement("high_res_image_url")]
        public string HighResImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the javascript errors that occured on rendering.
        /// </summary>
        /// <value>
        /// The javascript errors.
        /// </value>
        [XmlArray("javascript_errors")]
        [XmlArrayItem("javascript_error")]
        public List<string> JavascriptErrors { get; set; }
    }
}
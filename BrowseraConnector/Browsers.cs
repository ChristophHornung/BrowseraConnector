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
    /// A list of browsers.
    /// </summary>
    [Serializable]
    public class Browsers
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Browsers"/> class.
        /// </summary>
        public Browsers()
        {
            this.Type = "array";
        }

        /// <summary>
        /// Gets or sets the browser values, that is the string list of browsers.
        /// </summary>
        /// <value>
        /// The browser values.
        /// </value>
        [XmlElement("browser")]
        public List<string> BrowserValues { get; set; }

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
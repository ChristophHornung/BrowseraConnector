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
    using System.Xml.Serialization;

    /// <summary>
    /// The configuration for a site login.
    /// </summary>
    [Serializable]
    public class SiteLoginConfiguration
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        [XmlElement("user_name")]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [XmlElement("password")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is a website login or basicAuth authentication.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is a website login; or if <c>false</c> a basicAuth authentication.
        /// </value>
        [XmlElement("website_login")]
        public bool IsWebsiteLogin { get; set; }

        /// <summary>
        /// Gets or sets the login page URL.
        /// </summary>
        /// <value>
        /// The login page URL.
        /// </value>
        [XmlElement("login_page_url")]
        public string LoginPageUrl { get; set; }

        /// <summary>
        /// Gets or sets the user name input field's html id.
        /// </summary>
        /// <value>
        /// The user name input id.
        /// </value>
        [XmlElement("user_name_input_id")]
        public string UserNameInputId { get; set; }

        /// <summary>
        /// Gets or sets the password field's input id.
        /// </summary>
        /// <value>
        /// The password input id.
        /// </value>
        [XmlElement("password_input_id")]
        public string PasswordInputId { get; set; }

        /// <summary>
        /// Gets or sets the submit input id.
        /// </summary>
        /// <value>
        /// The submit input id.
        /// </value>
        [XmlElement("submit_input_id")]
        public string SubmitInputId { get; set; }

        /// <summary>
        /// Gets or sets the submit javascript.
        /// </summary>
        /// <value>
        /// The submit javascript.
        /// </value>
        [XmlElement("submit_javascript")]
        public string SubmitJavascript { get; set; }
    }
}
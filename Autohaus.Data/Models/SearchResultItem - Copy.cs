// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SearchResultItem.cs" company="Sitecore">
//   Copyright (c) Sitecore. All rights reserved.
// </copyright>
// <summary>
//   A small implementation of the Sitecore Item Class
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Autohaus.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    using Sitecore.ContentSearch;
    using Sitecore.Data;
    using Sitecore.Data.Items;
    using Sitecore.Links;

    /// <summary>
    /// A small implementation of the Sitecore item Class
    /// </summary>
    [DebuggerDisplay("Name={Name}, TemplateName={TemplateName}, Version={Version}, Language={Language}")]
    [DataContract]
    public class SearchResultItem
    {
        private string group;

        #region Constructors and Destructors

        /// <summary>
        /// The fields.
        /// </summary>
        private readonly Dictionary<string, object> fields = new Dictionary<string, object>();

        #endregion

        #region Public Properties

        [IndexField("_content")]
        public string Content { get; set; }
        [DataMember]
        [IndexField("_displayname")]
        public string DisplayName { get; set; }

        [IndexField("_group")]
        public string Id
        {
            get
            {
                return ShortID.Decode(this.@group);
            }

            set
            {
                this.@group = value;
            }
        }

        /// <summary>Gets or sets the created date.</summary>
        [IndexField("__smallcreateddate")]
        public DateTime CreatedDate
        {
            get;
            set;
        }

        /// <summary>Gets or sets the created by.</summary>
        [IndexField("_creator")]
        public string CreatedBy
        {
            get;
            set;
        }


        /// <summary>Gets the item id.</summary>
        public string ItemId
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Uri) && ItemUri.IsItemUri(this.Uri))
                {
                    return ItemUri.Parse(this.Uri).ItemID.ToString();
                }

                return ID.Null.ToString();
            }
        }

        /// <summary>Gets or sets the language.</summary>
        [IndexField("_language")]
        public string Language
        {
            get;
            set;
        }

        /// <summary>Gets or sets the name.</summary>
        [IndexField("_name")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>Gets or sets the path.</summary>
        [IndexField("_fullpath")]
        public string Path
        {
            get;
            set;
        }


        /// <summary>Gets or sets the template name.</summary>
        [IndexField("_template")]
        public Guid TemplateId
        {
            get;
            set;
        }

        /// <summary>Gets or sets the template name.</summary>
        [IndexField("_templatename")]
        public string TemplateName
        {
            get;
            set;
        }

        /// <summary>Gets or sets the updated.</summary>
        [IndexField("__smallupdateddate")]
        public DateTime Updated
        {
            get;
            set;
        }

        /// <summary>Gets or sets the uri.</summary>
        [XmlIgnore]
        [IndexField("_uniqueid")]
        public string Uri { get; set; }

        /// <summary>Gets or sets the version.</summary>
        public string Version
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Uri) && ItemUri.IsItemUri(this.Uri))
                {
                    return ItemUri.Parse(this.Uri).Version.Number.ToString(CultureInfo.InvariantCulture);
                }

                return string.Empty;
            }

            set
            {
            }
        }

        #endregion

        public string this[string key]
        {
            get
            {
                if (key == null)
                {
                    throw new ArgumentNullException("key");
                }

                return this.fields[key.ToLowerInvariant()].ToString();
            }

            set
            {
                if (key == null)
                {
                    throw new ArgumentNullException("key");
                }

                this.fields[key.ToLowerInvariant()] = value;
            }
        }
    }
}
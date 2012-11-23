/********
 * This file is part of Ext.NET.
 *     
 * Ext.NET is free software: you can redistribute it and/or modify
 * it under the terms of the GNU AFFERO GENERAL PUBLIC LICENSE as 
 * published by the Free Software Foundation, either version 3 of the 
 * License, or (at your option) any later version.
 * 
 * Ext.NET is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU AFFERO GENERAL PUBLIC LICENSE for more details.
 * 
 * You should have received a copy of the GNU AFFERO GENERAL PUBLIC LICENSE
 * along with Ext.NET.  If not, see <http://www.gnu.org/licenses/>.
 *
 *
 * @version   : 2.1.0 - Ext.NET Community License (AGPLv3 License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-11-21
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : GNU AFFERO GENERAL PUBLIC LICENSE (AGPL) 3.0. 
 *              See license.txt and http://www.ext.net/license/.
 *              See AGPL License at http://www.gnu.org/licenses/agpl-3.0.txt
 ********/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
    public abstract partial class ServerProxy
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Config : AbstractProxy.Config 
        { 
			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			        
			private CRUDUrls aPI = null;

			/// <summary>
			/// Specific urls to call on CRUD action methods \"read\", \"create\", \"update\" and \"destroy\".
			/// </summary>
			public CRUDUrls API
			{
				get
				{
					if (this.aPI == null)
					{
						this.aPI = new CRUDUrls();
					}
			
					return this.aPI;
				}
			}
			
			private string cacheString = "_dc";

			/// <summary>
			/// The name of the cache param added to the url when using noCache (defaults to \"_dc\")
			/// </summary>
			[DefaultValue("_dc")]
			public virtual string CacheString 
			{ 
				get
				{
					return this.cacheString;
				}
				set
				{
					this.cacheString = value;
				}
			}

			private string directionParam = "dir";

			/// <summary>
			/// The name of the direction parameter to send in a request. This is only used when simpleSortMode is set to true. Defaults to 'dir'.
			/// </summary>
			[DefaultValue("dir")]
			public virtual string DirectionParam 
			{ 
				get
				{
					return this.directionParam;
				}
				set
				{
					this.directionParam = value;
				}
			}
        
			private ParameterCollection extraParams = null;

			/// <summary>
			/// Extra parameters that will be included on every request. Individual requests with params of the same name will override these params when they are in conflict.
			/// </summary>
			public ParameterCollection ExtraParams
			{
				get
				{
					if (this.extraParams == null)
					{
						this.extraParams = new ParameterCollection();
					}
			
					return this.extraParams;
				}
			}
			
			private string filterParam = "filter";

			/// <summary>
			/// The name of the 'filter' parameter to send in a request. Defaults to 'filter'. Set this to undefined if you don't want to send a filter parameter
			/// </summary>
			[DefaultValue("filter")]
			public virtual string FilterParam 
			{ 
				get
				{
					return this.filterParam;
				}
				set
				{
					this.filterParam = value;
				}
			}

			private string groupParam = "group";

			/// <summary>
			/// The name of the 'group' parameter to send in a request. Defaults to 'group'. Set this to undefined if you don't want to send a group parameter
			/// </summary>
			[DefaultValue("group")]
			public virtual string GroupParam 
			{ 
				get
				{
					return this.groupParam;
				}
				set
				{
					this.groupParam = value;
				}
			}

			private string groupDirectionParam = "groupDir";

			/// <summary>
			/// The name of the direction parameter to send in a request. This is only used when simpleGroupMode is set to true. Defaults to 'groupDir'.
			/// </summary>
			[DefaultValue("groupDir")]
			public virtual string GroupDirectionParam 
			{ 
				get
				{
					return this.groupDirectionParam;
				}
				set
				{
					this.groupDirectionParam = value;
				}
			}

			private string iDParam = "id";

			/// <summary>
			/// The name of the parameter which carries the id of the entity being operated upon. Defaults to: \"id\"
			/// </summary>
			[DefaultValue("id")]
			public virtual string IDParam 
			{ 
				get
				{
					return this.iDParam;
				}
				set
				{
					this.iDParam = value;
				}
			}

			private string limitParam = "limit";

			/// <summary>
			/// The name of the 'limit' parameter to send in a request. Defaults to 'limit'. Set this to undefined if you don't want to send a limit parameter
			/// </summary>
			[DefaultValue("limit")]
			public virtual string LimitParam 
			{ 
				get
				{
					return this.limitParam;
				}
				set
				{
					this.limitParam = value;
				}
			}

			private bool noCache = true;

			/// <summary>
			///  Defaults to true. Disable caching by adding a unique parameter name to the request. Set to false to allow caching. Defaults to true.
			/// </summary>
			[DefaultValue(true)]
			public virtual bool NoCache 
			{ 
				get
				{
					return this.noCache;
				}
				set
				{
					this.noCache = value;
				}
			}

			private bool appendAction = true;

			/// <summary>
			/// 
			/// </summary>
			[DefaultValue(true)]
			public virtual bool AppendAction 
			{ 
				get
				{
					return this.appendAction;
				}
				set
				{
					this.appendAction = value;
				}
			}

			private string pageParam = "page";

			/// <summary>
			/// The name of the 'page' parameter to send in a request. Defaults to 'page'. Set this to undefined if you don't want to send a page parameter
			/// </summary>
			[DefaultValue("page")]
			public virtual string PageParam 
			{ 
				get
				{
					return this.pageParam;
				}
				set
				{
					this.pageParam = value;
				}
			}
        
			private ReaderCollection reader = null;

			/// <summary>
			/// The Ext.data.reader.Reader to use to decode the server's response. This can either be a Reader instance, a config object or just a valid Reader type name (e.g. 'json', 'xml').
			/// </summary>
			public ReaderCollection Reader
			{
				get
				{
					if (this.reader == null)
					{
						this.reader = new ReaderCollection();
					}
			
					return this.reader;
				}
			}
			
			private bool simpleSortMode = false;

			/// <summary>
			/// Enabling simpleSortMode in conjunction with remoteSort will only send one sort property and a direction when a remote sort is requested. The directionParam and sortParam will be sent with the property name and either 'ASC' or 'DESC'. Defaults to: false
			/// </summary>
			[DefaultValue(false)]
			public virtual bool SimpleSortMode 
			{ 
				get
				{
					return this.simpleSortMode;
				}
				set
				{
					this.simpleSortMode = value;
				}
			}

			private bool simpleGroupMode = false;

			/// <summary>
			/// Enabling simpleGroupMode in conjunction with remoteGroup will only send one group property and a direction when a remote group is requested. The groupDirectionParam and groupParam will be sent with the property name and either 'ASC' or 'DESC'. Defaults to: false
			/// </summary>
			[DefaultValue(false)]
			public virtual bool SimpleGroupMode 
			{ 
				get
				{
					return this.simpleGroupMode;
				}
				set
				{
					this.simpleGroupMode = value;
				}
			}

			private string sortParam = "sort";

			/// <summary>
			/// The name of the 'sort' parameter to send in a request. Defaults to 'sort'. Set this to undefined if you don't want to send a sort parameter
			/// </summary>
			[DefaultValue("sort")]
			public virtual string SortParam 
			{ 
				get
				{
					return this.sortParam;
				}
				set
				{
					this.sortParam = value;
				}
			}

			private string startParam = "start";

			/// <summary>
			/// The name of the 'start' parameter to send in a request. Defaults to 'start'. Set this to undefined if you don't want to send a start parameter
			/// </summary>
			[DefaultValue("start")]
			public virtual string StartParam 
			{ 
				get
				{
					return this.startParam;
				}
				set
				{
					this.startParam = value;
				}
			}

			private int timeout = 30000;

			/// <summary>
			/// The number of milliseconds to wait for a response. Defaults to 30000 milliseconds (30 seconds).
			/// </summary>
			[DefaultValue(30000)]
			public virtual int Timeout 
			{ 
				get
				{
					return this.timeout;
				}
				set
				{
					this.timeout = value;
				}
			}

			private string url = "";

			/// <summary>
			/// The default URL to be used for requests to the server.
			/// </summary>
			[DefaultValue("")]
			public virtual string Url 
			{ 
				get
				{
					return this.url;
				}
				set
				{
					this.url = value;
				}
			}
        
			private WriterCollection writer = null;

			/// <summary>
			/// The Ext.data.writer.Writer to use to encode any request sent to the server. This can either be a Writer instance, a config object or just a valid Writer type name (e.g. 'json', 'xml').
			/// </summary>
			public WriterCollection Writer
			{
				get
				{
					if (this.writer == null)
					{
						this.writer = new WriterCollection();
					}
			
					return this.writer;
				}
			}
			        
			private ProxyListeners listeners = null;

			/// <summary>
			/// Client-side JavaScript Event Handlers
			/// </summary>
			public ProxyListeners Listeners
			{
				get
				{
					if (this.listeners == null)
					{
						this.listeners = new ProxyListeners();
					}
			
					return this.listeners;
				}
			}
			        
			private JFunction buildUrl = null;

			/// <summary>
			/// Generates a url based on a given Ext.data.Request object. By default, ServerProxy's buildUrl will add the cache-buster param to the end of the url. Subclasses may need to perform additional modifications to the url.
			/// </summary>
			public JFunction BuildUrl
			{
				get
				{
					if (this.buildUrl == null)
					{
						this.buildUrl = new JFunction();
					}
			
					return this.buildUrl;
				}
			}
			
        }
    }
}
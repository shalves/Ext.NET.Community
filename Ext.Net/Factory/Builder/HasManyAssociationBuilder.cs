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
    public partial class HasManyAssociation
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<THasManyAssociation, TBuilder> : AbstractAssociation.Builder<THasManyAssociation, TBuilder>
            where THasManyAssociation : HasManyAssociation
            where TBuilder : Builder<THasManyAssociation, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(THasManyAssociation component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// True to automatically load the related store from a remote source when instantiated. Defaults to false.
			/// </summary>
            public virtual TBuilder AutoLoad(bool autoLoad)
            {
                this.ToComponent().AutoLoad = autoLoad;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Optionally overrides the default filter that is set up on the associated Store. If this is not set, a filter is automatically created which filters the association based on the configured foreignKey. See intro docs for more details. Defaults to undefined
			/// </summary>
            public virtual TBuilder FilterProperty(string filterProperty)
            {
                this.ToComponent().FilterProperty = filterProperty;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The name of the foreign key on the associated model that links it to the owner model. Defaults to the lowercased name of the owner model plus \"_id\", e.g. an association with a where a model called Group hasMany Users would create 'group_id' as the foreign key.
			/// </summary>
            public virtual TBuilder ForeignKey(string foreignKey)
            {
                this.ToComponent().ForeignKey = foreignKey;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The name of the function to create on the owner model to retrieve the child store. If not specified, the pluralized name of the child model is used.
			/// </summary>
            public virtual TBuilder Name(string name)
            {
                this.ToComponent().Name = name;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Optional configuration object that will be passed to the generated Store. Defaults to undefined.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder StoreConfig(Action<Store> action)
            {
                action(this.ToComponent().StoreConfig);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : HasManyAssociation.Builder<HasManyAssociation, HasManyAssociation.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new HasManyAssociation()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(HasManyAssociation component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(HasManyAssociation.Config config) : base(new HasManyAssociation(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(HasManyAssociation component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public HasManyAssociation.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.HasManyAssociation(this);
		}
		
		/// <summary>
        /// 
        /// </summary>
        public override IControlBuilder ToNativeBuilder()
		{
			return (IControlBuilder)this.ToBuilder();
		}
    }
    
    
    /*  Builder
        -----------------------------------------------------------------------------------------------*/
    
    public partial class BuilderFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public HasManyAssociation.Builder HasManyAssociation()
        {
#if MVC
			return this.HasManyAssociation(new HasManyAssociation { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.HasManyAssociation(new HasManyAssociation());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public HasManyAssociation.Builder HasManyAssociation(HasManyAssociation component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new HasManyAssociation.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public HasManyAssociation.Builder HasManyAssociation(HasManyAssociation.Config config)
        {
#if MVC
			return new HasManyAssociation.Builder(new HasManyAssociation(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new HasManyAssociation.Builder(new HasManyAssociation(config));
#endif			
        }
    }
}
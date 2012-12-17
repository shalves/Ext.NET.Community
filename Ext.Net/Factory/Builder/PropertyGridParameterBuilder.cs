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
 * @version   : 2.1.1 - Ext.NET Community License (AGPLv3 License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-12-10
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
    public partial class PropertyGridParameter
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TPropertyGridParameter, TBuilder> : BaseParameter.Builder<TPropertyGridParameter, TBuilder>
            where TPropertyGridParameter : PropertyGridParameter
            where TBuilder : Builder<TPropertyGridParameter, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TPropertyGridParameter component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// A custom name to appear as label for this field. If specified, the display name will be shown in the name column instead of the property name.
			/// </summary>
            public virtual TBuilder DisplayName(string displayName)
            {
                this.ToComponent().DisplayName = displayName;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Used to explicitly specify the editor type for a particular value. By default, the type is automatically inferred from the value. See inferTypes.
			/// </summary>
            public virtual TBuilder EditorType(PropertyGridEditorType editorType)
            {
                this.ToComponent().EditorType = editorType;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Allows the grid to support additional types of editable fields. By default, the grid supports strongly-typed editing of strings, dates, numbers and booleans using built-in form editors, but any custom type can be supported and associated with a custom input control by specifying a custom editor.
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Editor(Action<EditorCollection> action)
            {
                action(this.ToComponent().Editor);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Editor options
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder EditorOptions(Action<CellEditorOptions> action)
            {
                action(this.ToComponent().EditorOptions);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : PropertyGridParameter.Builder<PropertyGridParameter, PropertyGridParameter.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new PropertyGridParameter()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(PropertyGridParameter component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(PropertyGridParameter.Config config) : base(new PropertyGridParameter(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(PropertyGridParameter component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public PropertyGridParameter.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.PropertyGridParameter(this);
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
        public PropertyGridParameter.Builder PropertyGridParameter()
        {
#if MVC
			return this.PropertyGridParameter(new PropertyGridParameter { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.PropertyGridParameter(new PropertyGridParameter());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public PropertyGridParameter.Builder PropertyGridParameter(PropertyGridParameter component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new PropertyGridParameter.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public PropertyGridParameter.Builder PropertyGridParameter(PropertyGridParameter.Config config)
        {
#if MVC
			return new PropertyGridParameter.Builder(new PropertyGridParameter(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new PropertyGridParameter.Builder(new PropertyGridParameter(config));
#endif			
        }
    }
}
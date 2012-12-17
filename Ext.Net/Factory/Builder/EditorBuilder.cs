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
    public partial class Editor
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TEditor, TBuilder> : AbstractContainer.Builder<TEditor, TBuilder>
            where TEditor : Editor
            where TBuilder : Builder<TEditor, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TEditor component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// Event name for activate the editor
			/// </summary>
            public virtual TBuilder ActivateEvent(string activateEvent)
            {
                this.ToComponent().ActivateEvent = activateEvent;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The position to align to (see Ext.Element.alignTo for more details, defaults to \"c-c?\").
			/// </summary>
            public virtual TBuilder Alignment(string alignment)
            {
                this.ToComponent().Alignment = alignment;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The position to align to (see Ext.Element.alignTo for more details, defaults to \"c-c?\").
			/// </summary>
            public virtual TBuilder AlignmentConfig(EditorAlignmentConfig alignmentConfig)
            {
                this.ToComponent().AlignmentConfig = alignmentConfig;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True for the editor to automatically adopt the size of the underlying field. Otherwise, an object can be passed to indicate where to get each dimension. The available properties are 'boundEl' and 'field'. If a dimension is not specified, it will use the underlying height/width specified on the editor object. 
			/// </summary>
            public virtual TBuilder AutoSize(bool autoSize)
            {
                this.ToComponent().AutoSize = autoSize;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True for the editor to automatically adopt the size of the underlying field. Otherwise, an object can be passed to indicate where to get each dimension. The available properties are 'boundEl' and 'field'. If a dimension is not specified, it will use the underlying height/width specified on the editor object.
			/// </summary>
            public virtual TBuilder AutoSizeConfig(EditorAutoSize autoSizeConfig)
            {
                this.ToComponent().AutoSizeConfig = autoSizeConfig;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to complete the editing process if in edit mode when the field is blurred. Defaults to true.
			/// </summary>
            public virtual TBuilder AllowBlur(bool allowBlur)
            {
                this.ToComponent().AllowBlur = allowBlur;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to cancel the edit when the blur event is fired (defaults to false)
			/// </summary>
            public virtual TBuilder CancelOnBlur(bool cancelOnBlur)
            {
                this.ToComponent().CancelOnBlur = cancelOnBlur;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to cancel the edit when the escape key is pressed. Defaults to: true
			/// </summary>
            public virtual TBuilder CancelOnEsc(bool cancelOnEsc)
            {
                this.ToComponent().CancelOnEsc = cancelOnEsc;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to complete the edit when the enter key is pressed (defaults to false)
			/// </summary>
            public virtual TBuilder CompleteOnEnter(bool completeOnEnter)
            {
                this.ToComponent().CompleteOnEnter = completeOnEnter;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to constrain the editor to the viewport. Defaults to: false
			/// </summary>
            public virtual TBuilder Constrain(bool constrain)
            {
                this.ToComponent().Constrain = constrain;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// False to keep the bound element visible while the editor is displayed. Defaults to: true
			/// </summary>
            public virtual TBuilder HideEl(bool hideEl)
            {
                this.ToComponent().HideEl = hideEl;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The Field object (or descendant)
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Field(Action<ItemsCollection<Field>> action)
            {
                action(this.ToComponent().Field);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// True to skip the edit completion process (no save, no events fired) if the user completes an edit and the value has not changed. Applies only to string values - edits for other data types will never be ignored. Defaults to: false
			/// </summary>
            public virtual TBuilder IgnoreNoChange(bool ignoreNoChange)
            {
                this.ToComponent().IgnoreNoChange = ignoreNoChange;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// An element to render to. Defaults to the document.body.
			/// </summary>
            public virtual TBuilder ParentElement(string parentElement)
            {
                this.ToComponent().ParentElement = parentElement;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to automatically revert the field value and cancel the edit when the user completes an edit and the field validation fails (defaults to true)
			/// </summary>
            public virtual TBuilder RevertInvalid(bool revertInvalid)
            {
                this.ToComponent().RevertInvalid = revertInvalid;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Handle the keydown/keypress events so they don't propagate (defaults to true)
			/// </summary>
            public virtual TBuilder SwallowKeys(bool swallowKeys)
            {
                this.ToComponent().SwallowKeys = swallowKeys;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to update the innerHTML of the bound element when the update completes (defaults to false)
			/// </summary>
            public virtual TBuilder UpdateEl(bool updateEl)
            {
                this.ToComponent().UpdateEl = updateEl;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The data value of the underlying field (defaults to \"\")
			/// </summary>
            public virtual TBuilder Value(string value)
            {
                this.ToComponent().Value = value;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder TargetControl(Action<Control> action)
            {
                action(this.ToComponent().TargetControl);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// The target id to associate with this tooltip.
			/// </summary>
            public virtual TBuilder Target(string target)
            {
                this.ToComponent().Target = target;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// true to use innerHTML of bound element, otherwise innerText will be used
			/// </summary>
            public virtual TBuilder UseHtml(bool useHtml)
            {
                this.ToComponent().UseHtml = useHtml;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to encode value before start editing
			/// </summary>
            public virtual TBuilder HtmlEncode(bool htmlEncode)
            {
                this.ToComponent().HtmlEncode = htmlEncode;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to decode value after editing
			/// </summary>
            public virtual TBuilder HtmlDecode(bool htmlDecode)
            {
                this.ToComponent().HtmlDecode = htmlDecode;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Listeners(Action<InlineEditorListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Server-side DirectEventHandlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder DirectEvents(Action<InlineEditorDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder CancelEdit(bool remainVisible)
            {
                this.ToComponent().CancelEdit(remainVisible);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder CancelEdit()
            {
                this.ToComponent().CancelEdit();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder CompleteEdit(bool remainVisible)
            {
                this.ToComponent().CompleteEdit(remainVisible);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder CompleteEdit()
            {
                this.ToComponent().CompleteEdit();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Realign()
            {
                this.ToComponent().Realign();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder Realign(bool autoSize)
            {
                this.ToComponent().Realign(autoSize);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Starts the editing process and shows the editor.
			/// </summary>
            public virtual TBuilder StartEdit(string el, string value)
            {
                this.ToComponent().StartEdit(el, value);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// Starts the editing process and shows the editor.
			/// </summary>
            public virtual TBuilder StartEdit(string el)
            {
                this.ToComponent().StartEdit(el);
                return this as TBuilder;
            }
            
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : Editor.Builder<Editor, Editor.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new Editor()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Editor component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Editor.Config config) : base(new Editor(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(Editor component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Editor.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.Editor(this);
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
        public Editor.Builder Editor()
        {
#if MVC
			return this.Editor(new Editor { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.Editor(new Editor());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public Editor.Builder Editor(Editor component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new Editor.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public Editor.Builder Editor(Editor.Config config)
        {
#if MVC
			return new Editor.Builder(new Editor(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new Editor.Builder(new Editor(config));
#endif			
        }
    }
}
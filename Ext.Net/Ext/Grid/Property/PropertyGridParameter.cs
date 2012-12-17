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

using System.ComponentModel;
using System.Text;
using System.Web.UI;

using Ext.Net.Utilities;
using System.Collections.Generic;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Meta]
    [Description("")]
    public partial class PropertyGridParameter : BaseParameter
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public PropertyGridParameter() { }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public PropertyGridParameter(string name, string value) : base(name, value) { }

        /// <summary>
        /// A custom name to appear as label for this field. If specified, the display name will be shown in the name column instead of the property name.
        /// </summary>
        [Meta]
        [Category("Config Options")]
        [NotifyParentProperty(true)]
        [DefaultValue("")]
        [Description("A custom name to appear as label for this field. If specified, the display name will be shown in the name column instead of the property name.")]
        public string DisplayName
        {
            get
            {
                return this.State.Get<string>("DisplayName", "");
            }
            set
            {
                this.State.Set("DisplayName", value);
            }
        }

        private Renderer renderer;

        /// <summary>
        /// A function used to transform the underlying value before it is displayed in the grid. By default, the grid supports strongly-typed rendering of strings, dates, numbers and booleans using built-in form editors, but any custom type can be supported and associated with the type of the value. 
        ///
        /// The render function is called with the following parameters:
        ///     value : Object
        ///         The data value for the cell.
        ///     metadata : Object
        ///         An object in which you may set the following attributes:
        ///         
        ///         css : String
        ///             A CSS class name to add to the cell's TD element.
        ///         attr : String
        ///             An HTML attribute definition string to apply to the data container element
        ///              within the table cell (e.g. 'style="color:red;"').
        ///     
        ///     record : Ext.data.record
        ///         The Ext.data.Record from which the data was extracted.
        /// Returns:
        ///     void
        /// </summary>
        [Category("Config Options")]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("A function used to transform the underlying value before it is displayed in the grid. By default, the grid supports strongly-typed rendering of strings, dates, numbers and booleans using built-in form editors, but any custom type can be supported and associated with the type of the value. ")]
        public virtual Renderer Renderer
        {
            get
            {
                if (this.renderer == null)
                {
                    this.renderer = new Renderer();
                }

                return this.renderer;
            }
        }

        /// <summary>
        /// Used to explicitly specify the editor type for a particular value. By default, the type is automatically inferred from the value. See inferTypes.
        /// </summary>
        [Meta]
        [Category("Config Options")]
        [NotifyParentProperty(true)]
        [DefaultValue(PropertyGridEditorType.Auto)]
        [Description("Used to explicitly specify the editor type for a particular value. By default, the type is automatically inferred from the value. See inferTypes.")]
        public PropertyGridEditorType EditorType
        {
            get
            {
                return this.State.Get<PropertyGridEditorType>("EditorType", PropertyGridEditorType.Auto);
            }
            set
            {
                this.State.Set("EditorType", value);
            }
        }

        private EditorCollection editor;

        /// <summary>
        /// Allows the grid to support additional types of editable fields. By default, the grid supports strongly-typed editing of strings, dates, numbers and booleans using built-in form editors, but any custom type can be supported and associated with a custom input control by specifying a custom editor.
        /// </summary>
        [Meta]
        [Category("Config Options")]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Allows the grid to support additional types of editable fields. By default, the grid supports strongly-typed editing of strings, dates, numbers and booleans using built-in form editors, but any custom type can be supported and associated with a custom input control by specifying a custom editor.")]
        public virtual EditorCollection Editor
        {
            get
            {
                if (this.editor == null)
                {
                    editor = new EditorCollection();
                }

                return editor;
            }
        }

        private CellEditorOptions editorOptions;

        /// <summary>
        /// Editor options
        /// </summary>
        [Meta]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("Editor options")]
        public virtual CellEditorOptions EditorOptions
        {
            get
            {
                if (this.editorOptions == null)
                {
                    editorOptions = new CellEditorOptions();
                }

                return editorOptions;
            }
        }
        
        private bool isChanged;

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue(false)]
        [Description("")]
        public bool IsChanged
        {
            get 
            { 
                return this.isChanged; 
            }
            internal set 
            { 
                this.isChanged = value; 
            }
        }

        public virtual string ToConfig()
        {
            return this.ToConfig(false);
        }

        public virtual string ToConfig(bool dynamic)
        {
            StringBuilder sb = new StringBuilder(256);
            bool comma = false;
            sb.Append(JSON.Serialize(this.ToName()) + ":{");

            if (this.DisplayName.IsNotEmpty())
            {
                sb.Append("displayName:").Append(JSON.Serialize(this.DisplayName));
                comma = true;
            }

            if (!this.Renderer.IsDefault)
            {                
                sb.Append(comma ? ",":"").Append("renderer:").Append(this.Renderer.ToConfigString());
                comma = true;
            }

            if (this.EditorType != PropertyGridEditorType.Auto)
            {
                sb.Append(comma ? "," : "").Append("type:").Append(JSON.Serialize(this.EditorType.ToString().ToLowerInvariant()));
                comma = true;
            }

            if (this.Editor.Count > 0)
            {
                string options = this.EditorOptions.Serialize();
                options = options.Replace("{", "{{").Replace("}", "}}");
                string tpl = "new " + this.EditorOptions.InstanceName + "(Ext.apply({{field:{0}}}, " + options + "))";
                sb.Append(comma ? "," : "").Append("editor:");

                if(dynamic)
                {                
                    this.Editor[0].PreventRenderTo = true;
                    this.Editor[0].Visible = true;
                    sb.AppendFormat(tpl, this.Editor[0].ToConfig(LazyMode.Config));
                    this.Editor[0].Visible = false;
                }
                else
                {
                    sb.Append(Transformer.NET.Net.CreateToken(typeof(Transformer.NET.AnchorTag), new Dictionary<string, string>{                        
                        {"id", this.Editor[0].BaseClientID + "_ClientInit"},
                        {"tpl", tpl}
                    }));
                }

                comma = true;
            }

            if (!comma)
            {
                return "";
            }

            sb.Append("}");
            return sb.ToString();
        }

        public virtual string ToName()
        {
            return this.CamelName ? this.Name.ToLowerCamelCase() : this.Name;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class PropertyGridParameterCollection : BaseItemCollection<PropertyGridParameter>
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public PropertyGridParameter this[string name]
        {
            get 
            {
                return GetParameterByName(name);
            }
        }

        private PropertyGridParameter GetParameterByName(string name)
        {
            foreach (PropertyGridParameter parameter in this)
            {
                if (parameter.Name == name)
                {
                    return parameter;
                }
            }

            return null;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string Config()
        {
            if (this.Count == 0)
            {
                return "";
            }

            StringBuilder sb = new StringBuilder(256);
            sb.Append("{");

            foreach (PropertyGridParameter parameter in this)
            {
                string config = parameter.ToConfig();
                
                if (config.IsNotEmpty())
                {
                    sb.Append(config.ConcatWith(","));
                }
            }

            if (sb.Length <= 1)
            {
                return "";
            }

            sb.Remove(sb.Length - 1, 1);
            sb.Append("}");

            return sb.ToString();
        }

        public string Source()
        {
            if (this.Count == 0)
            {
                return "";
            }

            StringBuilder sb = new StringBuilder(256);
            sb.Append("{");

            foreach (PropertyGridParameter parameter in this)
            {
                sb.Append(parameter.ToString().ConcatWith(","));
            }

            sb.Remove(sb.Length - 1, 1);
            sb.Append("}");

            return sb.ToString();
        }
    }
}
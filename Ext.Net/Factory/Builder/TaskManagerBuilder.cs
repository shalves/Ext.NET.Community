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
    public partial class TaskManager
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TTaskManager, TBuilder> : LazyObservable.Builder<TTaskManager, TBuilder>
            where TTaskManager : TaskManager
            where TBuilder : Builder<TTaskManager, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TTaskManager component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// The minimum precision in milliseconds supported by this TaskRunner instance (defaults to 10)
			/// </summary>
            public virtual TBuilder Interval(int interval)
            {
                this.ToComponent().Interval = interval;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The start delay in milliseconds for autorun tasks
			/// </summary>
            public virtual TBuilder AutoRunDelay(int autoRunDelay)
            {
                this.ToComponent().AutoRunDelay = autoRunDelay;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Tasks(Action<TaskCollection> action)
            {
                action(this.ToComponent().Tasks);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder AddTask(Task task)
            {
                this.ToComponent().AddTask(task);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RemoveTask(int index)
            {
                this.ToComponent().RemoveTask(index);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder RemoveTask(string name)
            {
                this.ToComponent().RemoveTask(name);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder StartAll()
            {
                this.ToComponent().StartAll();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder StopAll()
            {
                this.ToComponent().StopAll();
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder StartTask(int index)
            {
                this.ToComponent().StartTask(index);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder StopTask(int index)
            {
                this.ToComponent().StopTask(index);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder StartTask(string name)
            {
                this.ToComponent().StartTask(name);
                return this as TBuilder;
            }
            
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder StopTask(string name)
            {
                this.ToComponent().StopTask(name);
                return this as TBuilder;
            }
            
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : TaskManager.Builder<TaskManager, TaskManager.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new TaskManager()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TaskManager component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(TaskManager.Config config) : base(new TaskManager(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(TaskManager component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public TaskManager.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.TaskManager(this);
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
        public TaskManager.Builder TaskManager()
        {
#if MVC
			return this.TaskManager(new TaskManager { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.TaskManager(new TaskManager());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public TaskManager.Builder TaskManager(TaskManager component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new TaskManager.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public TaskManager.Builder TaskManager(TaskManager.Config config)
        {
#if MVC
			return new TaskManager.Builder(new TaskManager(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new TaskManager.Builder(new TaskManager(config));
#endif			
        }
    }
}
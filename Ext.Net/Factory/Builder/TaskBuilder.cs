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
    public partial class Task
    {
        /// <summary>
        /// 
        /// </summary>
        new public abstract partial class Builder<TTask, TBuilder> : BaseItem.Builder<TTask, TBuilder>
            where TTask : Task
            where TBuilder : Builder<TTask, TBuilder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder(TTask component) : base(component) { }


			/*  ConfigOptions
				-----------------------------------------------------------------------------------------------*/
			 
 			/// <summary>
			/// (optional) The TaskID.
			/// </summary>
            public virtual TBuilder TaskID(string taskID)
            {
                this.ToComponent().TaskID = taskID;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to auto run task (defaults to false).
			/// </summary>
            public virtual TBuilder AutoRun(bool autoRun)
            {
                this.ToComponent().AutoRun = autoRun;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// True to wait previous request.
			/// </summary>
            public virtual TBuilder WaitPreviousRequest(bool waitPreviousRequest)
            {
                this.ToComponent().WaitPreviousRequest = waitPreviousRequest;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// The frequency in milliseconds with which the task should be executed (defaults to 1000)
			/// </summary>
            public virtual TBuilder Interval(int interval)
            {
                this.ToComponent().Interval = interval;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// (optional) An array of arguments to be passed to the function specified by run
			/// </summary>
            public virtual TBuilder Args(string[] args)
            {
                this.ToComponent().Args = args;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// (optional) The scope in which to execute the run function.
			/// </summary>
            public virtual TBuilder Scope(string scope)
            {
                this.ToComponent().Scope = scope;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// (optional) The length of time in milliseconds to execute the task before stopping automatically (defaults to indefinite).
			/// </summary>
            public virtual TBuilder Duration(int duration)
            {
                this.ToComponent().Duration = duration;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// (optional) The number of times to execute the task before stopping automatically (defaults to indefinite).
			/// </summary>
            public virtual TBuilder Repeat(int repeat)
            {
                this.ToComponent().Repeat = repeat;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder OnStart(string onStart)
            {
                this.ToComponent().OnStart = onStart;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// 
			/// </summary>
            public virtual TBuilder OnStop(string onStop)
            {
                this.ToComponent().OnStop = onStop;
                return this as TBuilder;
            }
             
 			/// <summary>
			/// Client-side JavaScript Event Handlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder Listeners(Action<TaskListeners> action)
            {
                action(this.ToComponent().Listeners);
                return this as TBuilder;
            }
			 
 			/// <summary>
			/// Server-side DirectEventHandlers
 			/// </summary>
 			/// <param name="action">The action delegate</param>
 			/// <returns>An instance of TBuilder</returns>
            public virtual TBuilder DirectEvents(Action<TaskDirectEvents> action)
            {
                action(this.ToComponent().DirectEvents);
                return this as TBuilder;
            }
			

			/*  Methods
				-----------------------------------------------------------------------------------------------*/
			
        }
		
		/// <summary>
        /// 
        /// </summary>
        public partial class Builder : Task.Builder<Task, Task.Builder>
        {
            /*  Ctor
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public Builder() : base(new Task()) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Task component) : base(component) { }

			/// <summary>
			/// 
			/// </summary>
            public Builder(Task.Config config) : base(new Task(config)) { }


            /*  Implicit Conversion
                -----------------------------------------------------------------------------------------------*/

			/// <summary>
			/// 
			/// </summary>
            public static implicit operator Builder(Task component)
            {
                return component.ToBuilder();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Task.Builder ToBuilder()
		{
			return Ext.Net.X.Builder.Task(this);
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
        public Task.Builder Task()
        {
#if MVC
			return this.Task(new Task { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return this.Task(new Task());
#endif			
        }

        /// <summary>
        /// 
        /// </summary>
        public Task.Builder Task(Task component)
        {
#if MVC
			component.ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null;
#endif			
			return new Task.Builder(component);
        }

        /// <summary>
        /// 
        /// </summary>
        public Task.Builder Task(Task.Config config)
        {
#if MVC
			return new Task.Builder(new Task(config) { ViewContext = this.HtmlHelper != null ? this.HtmlHelper.ViewContext : null });
#else
			return new Task.Builder(new Task(config));
#endif			
        }
    }
}
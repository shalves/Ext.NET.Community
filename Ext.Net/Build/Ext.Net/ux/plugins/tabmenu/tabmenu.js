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
 * @version   : 1.6.0 - Ext.NET Community License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-11-21
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : GNU AFFERO GENERAL PUBLIC LICENSE (AGPL) 3.0. 
 *              See license.txt and http://www.ext.net/license/.
 *              See AGPL License at http://www.gnu.org/licenses/agpl-3.0.txt
 ********/
 
 Ext.net.TabMenu = Ext.extend(Object, {
    init : function (tabPanel) {
        this.tabPanel = tabPanel;        
        this.tabPanel.initTab = this.tabPanel.initTab.createSequence(this.initTab, this);
        this.tabPanel.onStripMouseDown = this.tabPanel.onStripMouseDown.createInterceptor(this.onStripMouseDown);
        
        this.tabPanel.addEvents("beforetabmenushow");
        
        var m;
        if (m = this.tabPanel.defaultTabMenu) {
            this.tabPanel.defaultTabMenu = m.render ? m : Ext.ComponentMgr.create(m, "menu");
        }
    },
    
    initTab : function (item, index) {
        var m;
        if (m = item.tabMenu) {
            item.tabMenu = m.render ? m : Ext.ComponentMgr.create(m, "menu");            
        }
        
        if ((item.tabMenu || this.tabPanel.defaultTabMenu)) {            
            Ext.fly(item.tabEl).addClass("x-tab-strip-withmenu");
            
            item.menuEl = Ext.fly(item.tabEl).insertFirst({
                tag : "a", 
                cls : "x-tab-strip-menu", 
                onclick : "return false;"
            });
            
            if (item.tabMenuHidden === true) {
                item.menuEl.hide();
            }
            
            item.hideTabMenu = this.hideTabMenu.createDelegate(item);
            item.showTabMenu = this.showTabMenu.createDelegate(item);
        }
    },
    
    hideTabMenu : function () {
        this.menuEl.hide();
    },
    
    showTabMenu : function () {
        this.menuEl.show();
    },
    
    onStripMouseDown : function (e) {
        if (e.button !== 0) {
            return;
        }
        
        var t = this.findTargets(e),
            isMenu = e.getTarget(".x-tab-strip-menu", this.strip),
            menu;
            
        if (isMenu) {
            e.preventDefault();
            menu = t.item.tabMenu || this.defaultTabMenu;
            
            if (this.fireEvent("beforetabmenushow", this, t.item, menu) === false) {
                return false;
            }
            
            menu.tab = t.item;
            menu.show(t.item.menuEl);
            return false;
        }
    }
});

Ext.net.ResourceMgr.notifyScriptLoaded();
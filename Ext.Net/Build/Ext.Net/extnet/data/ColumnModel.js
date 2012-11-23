
// @source data/ColumnModel.js
Ext.chromeVersion = Ext.isChrome ? parseInt(( /chrome\/(\d{2})/ ).exec(navigator.userAgent.toLowerCase())[1],10) : NaN;

Ext.grid.ColumnModel.override({
    defaultSortable: true, 
    
    getTotalWidth : function (includeHidden) {
		if (!this.totalWidth) {
			var boxsizeadj = (Ext.isChrome && Ext.chromeVersion > 18 ? 2 : 0);
			this.totalWidth = 0;
			for (var i = 0, len = this.config.length; i < len; i++) {
				if (includeHidden || !this.isHidden(i)) {
					this.totalWidth += (this.getColumnWidth(i) + boxsizeadj);
				}
			}
		}
		return this.totalWidth;
	},
    
    isMenuDisabled : function (col) {
        var column = this.config[col];
        
        if (Ext.isEmpty(column)) {
            return true;
        }
        
        return !!column.menuDisabled;
    },
    
    isSortable : function (col) {
        var column = this.config[col];
        
        if (Ext.isEmpty(column)) {
            return false;
        }
    
        if (typeof this.config[col].sortable === "undefined") {
            return this.defaultSortable;
        }
        
        return this.config[col].sortable;
    },
    
    isHidden : function (colIndex) {        
        return colIndex >= 0 && this.config[colIndex].hidden;
    },

    isFixed : function (colIndex) {
        return colIndex >= 0 && this.config[colIndex].fixed;
    }
});

Ext.grid.Column.override({
    forbidIdScoping : true,

    getCellEditor: function (rowIndex) {
        var ed = this.getEditor(rowIndex);
        if (ed) {
            if (!ed.startEdit) {
                if (!ed.gridEditor) {
                    ed.gridEditor = new Ext.grid.GridEditor(ed);
                }
                ed = ed.gridEditor;
            }
            else if (ed.field) {
                ed.field.gridEditor = ed;
            }
        }
        return ed;
    }
});
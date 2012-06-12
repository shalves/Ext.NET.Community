
// @source core/tips/ToolTip.js

Ext.ToolTip.override({
    initTarget : function (target) {
        var targetEl = Ext.net.getEl(target);

        if (!Ext.isEmpty(targetEl)) {
            this.initTargetEvents(targetEl);
        } else {
            var getTargetTask = new Ext.util.DelayedTask(function (task) {
                targetEl = Ext.net.getEl(target);

                if (!Ext.isEmpty(targetEl)) {
                    this.initTargetEvents(targetEl);
                    task.cancel();
                } else {
                    task.delay(500, undefined, this, [ task ]);
                }
            }, this);
            
            getTargetTask.delay(1, undefined, this, [ getTargetTask ]);
        }
    },

    initTargetEvents : function (targetEl) {
        this.target = targetEl;
        var t = Ext.get(this.target);
        
        if (t) {
            if (this.target) {
                this.target = Ext.get(this.target);
                this.mun(this.target, "mouseover", this.onTargetOver, this);
                this.mun(this.target, "mouseout", this.onTargetOut, this);
                this.mun(this.target, "mousemove", this.onMouseMove, this);
            }
        
            this.mon(t, {
                freezeEvent: true,
                mouseover : this.onTargetOver,
                mouseout  : this.onTargetOut,
                mousemove : this.onMouseMove,
                scope     : this
            });
            this.target = t;
        }
        
        if (this.anchor) {
            this.anchorTarget = this.target;
        }
    }
});
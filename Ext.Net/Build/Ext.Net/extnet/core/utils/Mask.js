
// @source core/utils/Mask.js

Ext.net.Mask = function () {
    var instance, 
        bmask, 
        init = function () {
            bmask = Ext.getBody().createChild({ 
                cls   : "x-page-mask",
                style : "top:0;left:0;z-index:20000;position:absolute;background-color:transparent,width:100%,height:100%,zoom:1;"
            })
                .enableDisplayMode("block")
                .hide();
                     
            Ext.EventManager.onWindowResize(function () { 
                var scroll = Ext.getBody().getScroll(),
                    el = instance.child(".ext-el-mask-msg");
                bmask.setSize(Ext.lib.Dom.getViewWidth(false), Ext.lib.Dom.getViewHeight(false)); 
                bmask.setStyle({
                    top  : scroll.top + "px",
                    left : scroll.left + "px"
                });
                if (el) {
                    el.center(Ext.getBody());
                }
            });
        };
 
    return {
        show : function (cfg) {
            this.hide();
 
            cfg = Ext.apply({
                msg    : Ext.LoadMask.prototype.msg,
                msgCls : "x-mask-loading",
                el     : Ext.getBody()
            }, cfg || {});
 
            if (cfg.el === Ext.getBody()) {
                if (Ext.isEmpty(bmask)) {
                    init();
                }
                        
                Ext.getBody().addClass("x-masked");
                 
                bmask.setSize(Ext.lib.Dom.getViewWidth(false), Ext.lib.Dom.getViewHeight(false)).show();
                var scroll = Ext.getBody().getScroll();
                bmask.setStyle({
                    top  : scroll.top + "px",
                    left : scroll.left + "px"
                });
                cfg.el = bmask;                        
            } else {
                cfg.el = Ext.net.getEl(cfg.el);
            }
             
            cfg.el.mask(cfg.msg, cfg.msgCls);
 
            instance = cfg.el;
        },
         
        hide : function () {
            if (instance) {
                instance.unmask();
            }
                    
            if (bmask) {
                Ext.getBody().removeClass("x-masked");
                bmask.hide();
            }
 
            if (Ext.getBody().isMasked() === true) {
                Ext.getBody().unmask();
            }
        }
    };
}();

Ext.view.AbstractView.override({
     wasFirstRefresh : false,

     doFirstRefresh: function (store) {
        var me = this;

        if (store && !store.loading) {
            if (me.deferInitialRefresh) {
                Ext.Function.defer(function () {
                    if (!me.isDestroyed) {
                        me.wasFirstRefresh = true;
                        me.refresh();
                    }
                }, 1);
            } else {
                me.wasFirstRefresh = true;
                me.refresh();
            }
        }
        else {
            me.wasFirstRefresh = true;
        }
     },

     setMaskBind: function (store) {
        var mask = this.loadMask;
        if (mask) {
            if (mask.bindStore) {
                mask.bindStore(store);
            }
            else {
                this.maskShouldBeBound = true;
            }
        }
     },

     onRender: function () {
        var me = this,
            mask;

        me.callParent(arguments);

        mask = me.loadMask;

        if (me.maskShouldBeBound && mask && mask.bindStore) {
            mask.bindStore(me.store);
            delete me.maskShouldBeBound;
        }
    },

     onDataRefresh: function () {
        if (this.blockRefresh !== true && this.wasFirstRefresh) {
            this.refresh.apply(this, arguments);
        }
     },
     
     initComponent : Ext.Function.createSequence(Ext.view.AbstractView.prototype.initComponent, function () {
         this.addEvents('beforeitemupdate', 'beforeitemremove');
     }),
     
     onUpdate : Ext.Function.createInterceptor(Ext.view.AbstractView.prototype.onUpdate, function (ds, record) {
           var me = this,
            index = me.store.indexOf(record);
            
           me.fireEvent('beforeitemupdate', me, record, index);
     }),
     
     onRemove : Ext.Function.createInterceptor(Ext.view.AbstractView.prototype.onRemove, function (ds, record, index) {
           this.fireEvent('beforeitemremove', this, record, index);
     })
});
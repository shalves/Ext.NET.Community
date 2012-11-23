<%@ Control Language="C#" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<ext:FormPanel 
    runat="server"
    Region="North"
    Split="true"
    Height="330"
    MinHeight="330"
    Layout="FormLayout"
    BodyPadding="5">
    <FieldDefaults LabelWidth="190" />
    <Items>
        <ext:NumberField 
            runat="server"
            FieldLabel="Ajax latency (ms)"
            ItemID="latency"
            Number="1000"
            MaxValue="5000" />

        <ext:NumberField 
            runat="server"
            FieldLabel="Dataset row count"
            ItemID="rowCount"
            Number="50000"
            MinValue="200" />

        <ext:NumberField 
            runat="server"
            FieldLabel="<a href='http://docs.sencha.com/ext-js/4-1/#!/api/Ext.data.Store-cfg-pageSize' target='docs'>Store pageSize</a>"
            ItemID="pageSize"
            Number="150" />

        <ext:NumberField 
            runat="server"        
            FieldLabel="<a href='http://docs.sencha.com/ext-js/4-1/#!/api/Ext.data.Store-cfg-trailingBufferZone' target='docs'>Store trailingBufferZone</a>"
            ItemID="storeTrailingBufferZone"
            Number="25" />

        <ext:NumberField 
            runat="server"            
            FieldLabel="<a href='http://docs.sencha.com/ext-js/4-1/#!/api/Ext.data.Store-cfg-leadingBufferZone' target='docs'>Store leadingBufferZone</a>"
            ItemID="storeLeadingBufferZone"
            Number="200" />

        <ext:NumberField 
            runat="server"            
            FieldLabel="<a href='http://docs.sencha.com/ext-js/4-1/#!/api/Ext.grid.PagingScroller-cfg-numFromEdge' target='docs'>PagingScroller numFromEdge</a>"
            ItemID="scrollerNumFromEdge"
            Number="2"
            MaxValue="20" />

        <ext:NumberField 
            runat="server"            
            FieldLabel="<a href='http://docs.sencha.com/ext-js/4-1/#!/api/Ext.grid.PagingScroller-cfg-trailingBufferZone' target='docs'>PagingScroller trailingBufferZone</a>"
            ItemID="scrollerTrailingBufferZone"
            Number="5"
            MaxValue="100" />

        <ext:NumberField 
            runat="server"            
            FieldLabel="<a href='http://docs.sencha.com/ext-js/4-1/#!/api/Ext.grid.PagingScroller-cfg-leadingBufferZone' target='docs'>PagingScroller leadingBufferZone</a>"
            ItemID="scrollerLeadingBufferZone"
            Number="15"
            MaxValue="100" />

        <ext:NumberField 
            runat="server"
            FieldLabel="Num columns"
            ItemID="numFields"
            Number="10"
            MinValue="1" />

        <ext:NumberField 
            runat="server"            
            FieldLabel="<a href='http://docs.sencha.com/ext-js/4-1/#!/api/Ext.data.Store-cfg-purgePageCount' target='docs'>Store purgePageCount</a>"
            ItemID="purgePageCount"
            Number="5"
            MinValue="0" />

        <ext:NumberField 
            runat="server"            
            FieldLabel="<a href='http://docs.sencha.com/ext-js/4-1/#!/api/Ext.grid.PagingScroller-cfg-scrollToLoadBuffer' target='docs'>PagingScroller scrollToLoadBuffer</a>"
            ItemID="scrollToLoadBuffer"
            Number="200"
            MinValue="0"
            MaxValue="1000">
            <Listeners>
                <Change Handler="App.TestGrid.verticalScroller.scrollToLoadBuffer = newVal;" />
            </Listeners>
        </ext:NumberField>
    </Items>

    <TopBar>
        <ext:Toolbar runat="server">
            <Items>
                <ext:Button runat="server" Text="Reload" Handler="initializeGrid" />
            </Items>
        </ext:Toolbar>
    </TopBar>

    <HtmlBin>
        <script>
            var createStore = function (numFields) {
                var fields = [],
                    i;

                for (i = 0; i < numFields; ++i) {
                    fields.push('field' + i);
                }

                simlet.numFields = numFields;

                return Ext.create('Ext.data.Store', {
                    remoteSort: true,                
                    buffered: true,
                    fields: fields,
                    showWarningOnFailure: false,
                    proxy: {                        
                        type: 'ajax',                        
                        url: 'localAjaxSimulator',
                        reader: {
                            root: 'topics',
                            totalProperty: 'totalCount'
                        }
                    }
                });
            };
            
            var initializeGrid = function (btn) {
                var controls = btn.up("form"),
                    grid = App.TestGrid,
                    logPanel = App.LogPanel,
                    numFields = controls.down('#numFields').getValue(),
                    columns = [{
                        xtype: 'rownumberer',
                        width: 50,
                        sortable: false
                    }],
                    i,
                    numRecords,
                    start,
                    store = grid.store
                    oldStore = store;

                Ext.suspendLayouts();
                store.removeAll();
                store.pageMap.clear();
                logPanel.body.update('');

                for (i = 0; i < numFields; ++i) {
                    columns.push({ text: 'Field ' + (i+1), dataIndex: 'field' + i });
                }

                numRecords = controls.down('#rowCount').getValue();
                simlet.numRecords = numRecords;
                store.proxy.numRecords = numRecords;
                
                store = createStore(numFields);

                store.pageSize = controls.down('#pageSize').getValue();
                store.trailingBufferZone = controls.down('#storeTrailingBufferZone').getValue();
                store.leadingBufferZone = controls.down('#storeLeadingBufferZone').getValue();
                store.pageMap.maxSize = store.purgePageCount = controls.down('#purgePageCount').getValue();

                grid.verticalScroller.numFromEdge = controls.down('#scrollerNumFromEdge').getValue();
                grid.verticalScroller.trailingBufferZone = controls.down('#scrollerTrailingBufferZone').getValue();
                grid.verticalScroller.leadingBufferZone = controls.down('#scrollerLeadingBufferZone').getValue();

                Ext.ux.ajax.SimManager.delay = controls.down('#latency').getValue();

                grid.setTitle('Random data (' + numRecords + ' records)');
                start = new Date().getTime();
                grid.reconfigure(store, columns);
                logPanel.log(numRecords + ' rows x ' + numFields + ' columns in ' + (new Date().getTime() - start) + 'ms');

                // Load the first page. It will be diverted through the prefetch buffer.
                store.loadPage(1);
                oldStore.destroy();
                Ext.resumeLayouts(true);
            };
        </script>
    </HtmlBin>
</ext:FormPanel>
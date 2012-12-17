<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Infinite Scrolling Tuner - Ext.NET Examples</title>

    <link href="/resources/css/examples.css" rel="stylesheet" />

    <script src="ajax/SimXhr.js"></script>
    <script src="ajax/Simlet.js"></script>
    <script src="ajax/JsonSimlet.js"></script>
    <script src="ajax/SimManager.js"></script>

    <script>
        Ext.define('BigDataSimlet', {
            extend: 'Ext.ux.ajax.JsonSimlet',

            data: [],
            numFields: 10,
            numRecords: 50*1000,

            getData: function () {
                var me = this,
                    data = me.data;

                if (data.length != me.numRecords || me.lastNumColumns != me.numFields) {
                    me.currentOrder = null;
                    me.lastNumColumns = me.numFields;

                    data.length = 0;
                    for (var r = 0, k = me.numRecords; r < k; r++) {
                        var rec = {
                            id: 'rec-' + r
                        };
                        for (var i = 0; i < me.numFields; i++) {
                            rec['field' + i] = 'row' + (r + 1) + '/col' + (i+1);
                        }
                        data.push(rec);
                    }
                }

                return this.callParent(arguments);
            }
        });
        
        var simlet = new BigDataSimlet();

        Ext.ux.ajax.SimManager.init({
            delay: 1000
        }).register({
            localAjaxSimulator: simlet
        });
        
        Ext.data.Store.prototype.prefetch = Ext.Function.createInterceptor(Ext.data.Store.prototype.prefetch, function(options) {
            if (this.pagesRequested && !this.pagesRequested[options.page]) {
                App.LogPanel.log('Prefetch rows ' + options.start + '-' + (options.start + options.limit));
            }
        });

        Ext.data.Store.prototype.onProxyPrefetch = Ext.Function.createSequence(Ext.data.Store.prototype.onProxyPrefetch, function(operation) {
            App.LogPanel.log('Prefetch returned ' + operation.start + '-' + (operation.start + operation.limit));
        });

        Ext.data.Store.prototype.PageMap.prototype.prune = Ext.Function.createSequence(Ext.data.Store.prototype.PageMap.prototype.prune, function() {
            App.LogPanel.log('Page cache contains pages ' + this.getKeys().join(',') + '<br>&#160;&#160;&#160;&#160;' + this.pageSize * this.getCount() + ' records in cache');
        });

        Ext.grid.PagingScroller.prototype.onViewRefresh = Ext.Function.createSequence(Ext.grid.PagingScroller.prototype.onViewRefresh, function() {
            var me = this,
                table = me.view.el.child('table', true);

            App.LogPanel.log('Table moved to top: ' + table.style.top);
        });
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <ext:Viewport runat="server">
            <LayoutConfig>
                <ext:BorderLayoutConfig Padding="5" />
            </LayoutConfig>

            <Items>
                <ext:Panel 
                    runat="server"
                    Region="West"
                    Title="Configuration"
                    Border="false"
                    BodyBorder="0"
                    Collapsible="true"
                    Split="true"
                    Width="270"
                    MinWidth="270"
                    Layout="BorderLayout">
                    <Items>
                        <ext:UserControlLoader runat="server" Path="Controls.ascx" />

                        <ext:Panel 
                            ID="LogPanel"
                            runat="server"
                            Title="Log"
                            Region="Center"
                            AutoScroll="true">
                            <TopBar>
                                <ext:Toolbar runat="server">
                                    <Items>
                                        <ext:Button 
                                            runat="server" 
                                            Text="Clear" 
                                            Handler="function(){ this.up('panel').body.update(''); }" />
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>

                            <CustomConfig>
                                <ext:ConfigItem 
                                    Name="log" 
                                    Value="function (m) { this.body.createChild({html: m}); this.body.dom.scrollTop = 1000000; }" 
                                    Mode="Raw" />
                            </CustomConfig>
                        </ext:Panel>
                    </Items>
                </ext:Panel>

                <ext:GridPanel 
                    ID="TestGrid"
                    runat="server"
                    Region="Center"
                    Title="Random data (50000 records)">
                    <Store>
                        <ext:Store runat="server" Buffered="true">
                            <Model>
                                <ext:Model runat="server">
                                    <Fields>
                                        <ext:ModelField Name="dummy" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <ColumnModel>
                        <Columns>
                            <ext:RowNumbererColumn runat="server" Width="50" Sortable="false" />
                        </Columns>
                    </ColumnModel>
                    <SelectionModel>
                        <ext:RowSelectionModel runat="server" PruneRemoved="false" Mode="Multi" />
                    </SelectionModel>
                </ext:GridPanel>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>
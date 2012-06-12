<%@ Page Language="C#" %>
  
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Custom XML file loading - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        var idConvert = function (value, xmlNode) {
            return xmlNode.attributes[0].value;   
        };

        var categoryConvert = function (value, xmlNode) {
            return xmlNode.attributes[1].value;   
        };

        var linksConvert = function (value, xmlNode) {
            var nodes = xmlNode.childNodes,
                links = [],
                i,
                j,
                link,
                url;

            for (i = 0; i < nodes.length; i++) {
                link = nodes[i];
                if (link.nodeName === "link") {
                    for (j = 0; j < link.childNodes.length; j++) {
                        url = link.childNodes[j];
                        if (url.nodeName === "url") {
                            links.push([url.childNodes[0].data]);
                        }
                    }
                }
            }
            return links;
        };
    </script>
</head>
<body>
    <ext:ResourceManager runat="server" />

    <h1>Custom XML file loading</h1>
        
    <p>This example shows how to load a data from a custom XML file directly.</p>
        
    <ext:GridPanel 
        runat="server"
        Title="Categories"
        Frame="true" 
        AutoHeight="true" 
        Width="300"
        AutoExpandColumn="Category">
        <Store>
            <ext:Store runat="server">
                <Proxy>
                    <ext:HttpProxy Url="categories.xml" />
                </Proxy>
                <Reader>
                    <ext:XmlReader Record="category">
                        <Fields>
                            <ext:RecordField Name="id">
                                <Convert Fn="idConvert" />
                            </ext:RecordField>
                            <ext:RecordField Name="category">
                                <Convert Fn="categoryConvert" />
                            </ext:RecordField>
                            <ext:RecordField Name="links">
                                <Convert Fn="linksConvert" />
                            </ext:RecordField>
                        </Fields>
                    </ext:XmlReader>
                </Reader>
            </ext:Store>
        </Store>
        <ColumnModel runat="server">
            <Columns>
                <ext:Column ColumnID="Category" Header="Category" DataIndex="category" />
                <ext:Column Header="ID" DataIndex="id" />
            </Columns>
        </ColumnModel>
        <Plugins>
            <ext:RowExpander runat="server">
                <Component>
                    <ext:GridPanel runat="server" AutoHeight="true" Title="Links">
                        <Store>
                            <ext:Store ID="StoreLinks" runat="server">
                                <Reader>
                                    <ext:ArrayReader>
                                        <Fields>
                                            <ext:RecordField Name="link" />
                                        </Fields>
                                    </ext:ArrayReader>
                                </Reader>
                            </ext:Store>
                        </Store>
                        <ColumnModel>
                            <Columns>
                                <ext:Column Header="Link" DataIndex="link" />
                            </Columns>
                        </ColumnModel>
                        <View>
                            <ext:GridView runat="server" ForceFit="true" />
                        </View>
                    </ext:GridPanel>
                </Component>
                <Listeners>
                    <BeforeExpand Handler="StoreLinks.loadData(record.get('links'));" />
                </Listeners>
            </ext:RowExpander>
        </Plugins>
        <LoadMask ShowMask="true" />
    </ext:GridPanel>
</body>
</html>
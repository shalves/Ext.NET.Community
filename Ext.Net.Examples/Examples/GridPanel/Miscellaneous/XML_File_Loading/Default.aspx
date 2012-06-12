<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>XML File Loading - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <ext:ResourceManager runat="server" />
    
    <h1>XML file loading</h1>
    
    <p>This example shows how to load a data from an XML file directly.</p>

    <ext:GridPanel 
        runat="server"
        Title="Plants" 
        Frame="true" 
        Width="600" 
        Height="300" 
        AutoExpandColumn="common">
        <Store>
            <ext:Store runat="server">
                <Proxy>
                    <ext:HttpProxy Url="../../Shared/Plants.xml" />
                </Proxy>
                <Reader>
                    <ext:XmlReader Record="plant">
                        <Fields>
                            <ext:RecordField Name="common" />
                            <ext:RecordField Name="botanical" />
                            <ext:RecordField Name="light" />
                            <ext:RecordField Name="price" Type="Float" />
                            <ext:RecordField Name="availability" Type="Date" />
                            <ext:RecordField Name="indoor" Type="Boolean" />
                        </Fields>
                    </ext:XmlReader>
                </Reader>
                <SortInfo Field="common" Direction="ASC" />
            </ext:Store>
        </Store>
        <ColumnModel runat="server">
            <Columns>
                <ext:Column 
                    ColumnID="common" 
                    Header="Common Name" 
                    DataIndex="common" />
                <ext:Column 
                    Header="Light" 
                    DataIndex="light" 
                    Width="130" />
                <ext:Column 
                    Header="Price" 
                    DataIndex="price" 
                    Width="70" 
                    Align="right">
                    <Renderer Format="UsMoney" />
                </ext:Column>
                <ext:DateColumn 
                    Header="Available" 
                    DataIndex="availability" 
                    Width="95" 
                    Format="yyyy-MM-dd" />
                <ext:Column 
                    Header="Indoor?" 
                    DataIndex="indoor" 
                    Width="55" />
            </Columns>
        </ColumnModel>
        <LoadMask ShowMask="true" />
    </ext:GridPanel>
</body>
</html>

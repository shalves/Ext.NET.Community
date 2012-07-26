<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Assembly="Ext.Net.Examples" Namespace="Ext.Net.Examples.SimpleTasks" TagPrefix="task" %>

<html>
<head runat="server">
    <title>Simple Tasks - Ext.NET Examples</title>    
    
    <link href="resources/main.css" rel="stylesheet" type="text/css" />
    <script src="resources/main.js" type="text/javascript"></script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager 
            runat="server"            
            Namespace="" 
            DirectEventUrl="Default.aspx" />
        
        <ext:Viewport runat="server" Layout="BorderLayout">
            <Items>
                <task:TasksTopBar 
                    runat="server" 
                    Region="North" 
                    />
                <task:TasksTree 
                    ID="TasksTree1"
                    runat="server" 
                    Region="West" 
                    Margins="3 0 3 3" 
                    CMargins="3 3 3 3" 
                    MinWidth="120" 
                    Split="true">
                        <Listeners>                            
                            <BeforeCollapse Handler="this.setTitle('');" />
                            <BeforeExpand Handler="this.setTitle(this.initialConfig.title);" />
                        </Listeners>
                    </task:TasksTree>
                <task:TasksGrid 
                    ID="TasksGrid1"
                    runat="server" 
                    Region="Center" 
                    Margins="3 3 3 0"
                    />                         
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>

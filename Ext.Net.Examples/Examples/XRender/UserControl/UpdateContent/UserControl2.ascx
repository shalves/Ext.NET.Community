<%@ Control Language="C#" %>

<script runat="server">
    protected void HelloFromServer(object sender, DirectEventArgs e)
    {
        X.Msg.Alert("Server", "Hello from server - UserControl №2").Show();
    }        
</script>

<ext:ResourcesRegistrator runat="server">
    <ResourceItems>
        <ext:ClientResourceItem Path="script.js" />
    </ResourceItems>
</ext:ResourcesRegistrator>

<h1>№2</h1>
<ext:Label ID="Label1" runat="server" Text="I am User control №2" />
<br />
<ext:Button ID="Button1" runat="server" Text="User control №2: Ext.Net button" OnDirectClick="HelloFromServer" />
<br />
<asp:Button runat="server" Text="User control №2: ASP.NET button" OnClientClick="helloFromClient('UserControl №2');return false;" />
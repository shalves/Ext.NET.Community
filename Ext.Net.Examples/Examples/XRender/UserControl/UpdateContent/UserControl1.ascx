<%@ Control Language="C#" %>

<script runat="server">
    protected void HelloFromServer(object sender, DirectEventArgs e)
    {
        X.Msg.Alert("Server", "Hello from server - UserControl №1").Show();
    }        
</script>

<ext:ResourcesRegistrator runat="server">
    <ResourceItems>
        <ext:ClientResourceItem Path="script.js" />
    </ResourceItems>
</ext:ResourcesRegistrator>

<h1>№1</h1>
<ext:Label ID="Label1" runat="server" Text="I am User control №1" />
<br />
<ext:Button ID="Button1" runat="server" Text="User control №1: Ext.Net button" OnDirectClick="HelloFromServer" />
<br />
<asp:Button runat="server" Text="User control №1: ASP.NET button" OnClientClick="helloFromClient('UserControl №1');return false;" />
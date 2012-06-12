<%@ Page Language="C#" EnableSessionState="False" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void Button1_Click(object sender, DirectEventArgs e) 
    {
        System.Threading.Thread.Sleep(10000);
        this.Label1.Text = "Label1 : " + DateTime.Now.ToLongTimeString();
    }

    protected void Button2_Click(object sender, DirectEventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        this.Label2.Text = "Label2 : " + DateTime.Now.ToLongTimeString();
    }

    protected void Button3_Click(object sender, DirectEventArgs e)
    {
        System.Threading.Thread.Sleep(5000);
        this.Label3.Text = "Label3 : " + DateTime.Now.ToLongTimeString();
    }

    protected void Button4_Click(object sender, DirectEventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        this.Label4.Text = "Label4 : " + DateTime.Now.ToLongTimeString();
    }
</script>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
  
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Asynchronous DirectEvents - Ext.NET Example</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />

        <h1>Asynchronous DirectEvents</h1>

        <p>Click each Button quickly in succession. Each will value will be returned after its configured delay, 
        which simulates a long running server-side task.</p>

        <ext:Button runat="server" Text="Submit 1 (10 sec)" OnDirectClick="Button1_Click" />
        <ext:Button runat="server" Text="Submit 2 (1 sec)" OnDirectClick="Button2_Click" />
        <ext:Button runat="server" Text="Submit 3 (5 sec)" OnDirectClick="Button3_Click" />
        <ext:Button runat="server" Text="Submit 4 (1 sec)" OnDirectClick="Button4_Click" />

        <ext:Label ID="Label1" runat="server" /><br />
        <ext:Label ID="Label2" runat="server" /><br />
        <ext:Label ID="Label3" runat="server" /><br />
        <ext:Label ID="Label4" runat="server" />
    </form>
</body>
</html>
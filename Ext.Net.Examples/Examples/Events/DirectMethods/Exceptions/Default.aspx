<%@ Page Language="C#" %>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<script runat="server">
    [DirectMethod]
    public void UnhandledException()
    {
        throw new Exception("Unhandled Exception");
    }

    [DirectMethod]
    public void CatchException()
    {
        try
        {
            throw new Exception("An Exception was Thrown");
        }
        catch(Exception e)
        {
            Ext.Net.ResourceManager.AjaxSuccess = false;
            Ext.Net.ResourceManager.AjaxErrorMessage = e.Message;
        }
    }
</script>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DirectMethod and UserControls - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        var onFailure = function (msg) { 
            Ext.Msg.alert('Failure', msg); 
        };
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" DirectMethodNamespace="CompanyX" />
        
        <h1>Handling Exceptions in [DirectMethod]</h1>
        
        <div class="information">
            <p>The <code>DirectMethodNamespace</code> property has been set to "<b>CompanyX</b>" on the &lt;ext:ResourceManager> which overrides the default <code>[DirectMethod]</code> Namespace value of "<b>Ext.net.DirectMethods</b>".</p>
        </div>
        
        <h2>Dealing with [DirectMethod] Exceptions and request failure</h2>
        
        <p>&nbsp;</p>
        
        <h3>Example</h3>
           
        <ext:Button runat="server" Text="Unhandled Exception">
            <Listeners>
                <Click Handler="CompanyX.UnhandledException({ 
                                    failure : onFailure
                                });" />
            </Listeners>
        </ext:Button>
        
        <br />
        
        <ext:Button runat="server" Text="Catch Exception">
            <Listeners>
                <Click Handler="CompanyX.CatchException({ 
                                    failure : onFailure
                                });" />
            </Listeners>
        </ext:Button>
    </form>
</body>
</html>
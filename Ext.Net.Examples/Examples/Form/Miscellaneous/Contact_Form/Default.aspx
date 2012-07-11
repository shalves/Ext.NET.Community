<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void ShowContactForm(object sender, DirectEventArgs e)
    {
        var config = new UserControlRendrerConfig
        {
            UserControlPath = "ContactForm.ascx",
            SingleControl = true,
            Mode = RenderMode.RenderTo,
            Element = this.Form.ClientID
        };

        config.BeforeRender += delegate(ComponentAddedEventArgs ce)
        {
            ce.Control.ID = BaseControl.GenerateID();
            e.ExtraParamsResponse.Add(new Ext.Net.Parameter("windowId", ce.Control.ConfigID));            
        };
        
        UserControlRenderer.Render(config);
    }
</script>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Contact Form - Ext.NET Examples</title>
    <link href="/resources/css/examples.css" rel="stylesheet" type="text/css" />       

    <style type="text/css">
        .contactBtn button {
            padding: 0 5px;
            font-size: 16px;
        }
    </style>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>Contact Form</h1>

        <p>
            This shows an example of a common "Contact Us" form in a popup window. The form uses vbox and hbox
            layouts to acheive a uniform flexible layout even when the window is resized.
        </p>

        <ext:Panel 
            runat="server"
            Title="Welcome!"
            Width="500"
            BodyPadding="20">
            <Items>
                <ext:Component runat="server" StyleSpec="margin-bottom: 20px;">
                    <Content>
                        Thank you for visiting our site! We welcome your feedback; please click the button below to send us a message. We will respond to your inquiry as quickly as possible.
                    </Content>
                </ext:Component>

                <ext:Container runat="server" StyleSpec="text-align:center">
                    <Items>
                        <ext:Button 
                            runat="server" 
                            Cls="contactBtn" 
                            Scale="Large" 
                            Text="Contact Us">                            
                            <DirectEvents>
                                <Click 
                                    OnEvent="ShowContactForm" 
                                    Single="true" 
                                    Success="this.windowId = result.extraParamsResponse.windowId; this.on('click', function(){Ext.getCmp(this.windowId).show();}, this);" />
                            </DirectEvents>
                        </ext:Button>
                    </Items>
                </ext:Container>
            </Items>        
        </ext:Panel>
    </form>
</body>
</html>
<%@ Page Language="C#" %>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>
    
<!DOCTYPE html>

<html>
<head runat="server">
    <title>ColorPalate Overview - Ext.NET Examples</title>
    <link href="/resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
        .x-color-picker {
            width: 350px !important;
        }
    </style>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <ext:ColorPicker runat="server">
            <Template runat="server">
                <Html>
					<tpl for="colors">
						<a href="#" class="color-{.}" hidefocus="on">
							<em style="padding:2px;">
								<span style="background:#{.}; width:50px; height:20px; border:1px solid black;" unselectable="on">
									&#160;
								</span>
								<div style="font-size:10px;text-align:center;">#{.}</div>
							</em>
						</a>
					</tpl>
				</Html>
            </Template>
        </ext:ColorPicker>
    </form>
</body>
</html>

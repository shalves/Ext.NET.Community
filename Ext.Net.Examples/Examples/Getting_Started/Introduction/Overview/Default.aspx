<%@ Page Language="C#" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Getting Started - Ext.NET Examples</title>
    <link href="/resources/css/examples.css"  rel="stylesheet" />
    <base target="_blank" />
</head>
<body>
    <form runat="server">
        <h1>Welcome to the Ext.NET Examples Explorer</h1>
        
        <h2>Overview</h2>
        
        <p>Ext.NET is a toolkit of AJAX enabled ASP.NET Web Controls.</p>
        
        <p>Ext.NET includes the powerful desktop application development platform 
        <a href="http://www.sencha.com/products/extjs/"> Sencha Ext JS</a>. 
        Ext JS provides unparalleled cross-browser compatibility enabling you to develop incredible web apps for any browser.</p>

        <p>Direct access to the latest Ext.NET source code, via read-only SVN access, is available to all Ext.NET Pro 
            license holders with a valid Premium Support Subscription. An Ext.NET Pro license and Premium Support
            subscription can be purchased in the <a href="http://ext.net/store/">Store</a></p>
            
        <h2>System Requirements</h2>
        
        <ol class="expanded">
            <li><a href="http://www.microsoft.com/visualstudio/eng/products/visual-studio-overview">Visual Studio</a> 2008, 2010 or 2012, or</li>
            <li><a href="http://www.microsoft.com/visualstudio/eng/products/visual-studio-express-products">Visual Studio Express</a> 2008, 2010 or 2012</li>
            <li>.NET Framework 3.5, 4.0* or 4.5</li>
        </ol>

        <p>*minimum required for Ext.NET MVC</p>
        
        <h2>Getting Started (NuGet)</h2>
        
        <p>The easiest and quickest way to install Ext.NET is using <a href="http://nuget.org/packages/Ext.NET">NuGet</a>. Run the following command in Visual Studio Command panel, 
        or seach for "Ext.NET" in NuGet Package Manager.</p>

        <p><code>Install-Package Ext.NET</code></p>

        <h2>Getting Started (Manual)</h2>

        <ol class="expanded">
            <li>First ensure you have Visual Studio or Visual Web Developer Express installed on your computer.
                <div class="information"><p>If you do not have a copy of Visual Studio already installed, the <a href="http://www.microsoft.com/visualstudio/eng/products/visual-studio-express-products/">Visual Studio Express</a> is free to use and 
                is a great way to get started with ASP.NET and Ext.NET. The Ext.NET Components work exactly the same in both environments.</p></div></li>
            
            <li><p>A Manual installation package (.zip) is available for download at <a href="http://www.ext.net/download/">http://www.ext.net/download/</a>.</p></li>
            
            <li>Create your first "Web Site" Project.
                <ol style="list-style-type: lower-roman;">
                    <li>Open Visual Studio (or Visual Web Developer) and create a new "Web Site" project. From the File Menu, select New > Web Site.</li>
                    <li>The "New Web Site" dialog will open, ensure "ASP.NET Web Site" is selected from the list of Templates.</li>
                    <li>For your first project, the "Location" option of "File System" and default file path should be fine, or modify to fit your preference.</li>
                    <li>Please select your "Language" preference. Whether you choose "Visual C#" or "Visual Basic" is ultimately just dependent on personal coding preferences. 
                        Ext.NET is written in C#, but can be used in any .NET language, including Visual Basic or C#.</li>
                    <li>Click "OK".</li>
                </ol>
            </li>
            
            <li>Add the Ext.NET Controls to your Visual Studio (or Visual Web Developer) Toolbox, see also <a href="http://examples.ext.net/#/Getting_Started/Introduction/README/">README.txt</a>
                <ol style="list-style-type: lower-roman;">
                    <li>Open Visual Studio or Visual Web Developer Express</li>
                    <li>Open an existing web site or create a new web site project.</li>
                    <li>Open or create a new .aspx page.</li>
                    <li>Open the ToolBox panel, typically located on the left side in a fly-out panel (Ctrl + Alt + x).</li>
                    <li>Create a new "Ext.NET" Tab:
                        <ol style="list-style-type: lower-alpha;">
                            <li>Right-Click in the ToolBox area</li>
                            <li>Select "Add Tab"</li>
                            <li>Enter "Ext.NET"</li>
                        </ol>
                    </li>
		            <li>Inside the "Ext.NET" tab, Right-Click and select "Choose Items...".</li>
		            <li>Under the ".NET Framework Components" Tab select the "Browse" button.</li>
		            <li>Navigate to and select the Ext.Net.dll file, choose open.</li>
                    <li>Ext.NET controls should now be added to the list and pre-checked. You can confirm by sorting the list by "Namespace" and scrolling to "Ext.Net"</li>
                    <li>Click "OK". The icons should be added to your ToolBox. You should now be able to drag/drop a Ext.NET component onto your .aspx Page.</li>
                </ol>
            </li>
           
            <li>Create your first web page.
                <ol style="list-style-type: lower-roman;">
                    <li>Open a .aspx Page</li>
                    <li>Drag the Ext.NET "ResourceManager" control onto your Page. One &lt;ext:ResourceManager> is required on each .aspx Page</li>
                    <li>Drag an Ext.NET "Window" Control onto your Page, then Save (Ctrl + s) your Page.</li>
                    <li>Hit "F5" to start debugging, or Right-Click on the Page and select "View in Browser". Your Page should now render in the browser and the &lt;ext:Window> will be displayed.</li>
                    <li>Enjoy.</li>
                </ol>
            </li>
        </ol>
    </form>
  </body>
</html>    

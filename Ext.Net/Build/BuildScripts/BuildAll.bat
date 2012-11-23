SET _=%~dp0
%_%..\JSBuilder\JSBuildConsole.exe /path=%_%..\Ext.Net\extnet\extnet-all.jsb 
%_%..\JSBuilder\JSBuildConsole.exe /path=%_%..\Ext.Net\extnet\resources\extnet-all-css.jsb
%_%..\JSBuilder\JSBuildConsole.exe /path=%_%..\Ext.Net\ux\grid\gridfilters\gridfilters.jsb
%_%..\JSBuilder\JSBuildConsole.exe /path=%_%..\Ext.Net\ux\calendar\calendar-all.jsb
%_%..\JSBuilder\JSBuildConsole.exe /path=%_%..\Ext.Net\ux\desktop\desktop.jsb
%_%..\JSBuilder\JSBuildConsole.exe /path=%_%..\Ext.Net\ux\extnet-ux.jsb
%_%..\JSBuilder\JSBuildConsole.exe /path=%_%..\Ext.Net\ux\resources\extnet-ux-css.jsb
%_%..\JSBuilder\JSBuildConsole.exe /path=%_%..\Ext.Net\ux\resources\extnet-ux-css-embedded.jsb
"%_%..\ERB\Ext.Net.ResourceBuilder.exe " "%_%..\..\..\Ext.Net\ " "Ext.Net.Build" "%_%..\..\..\Ext.Net\ " ""
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports Rhino.PlugIns

' Plug-in Description Attributes - all of these are optional
' These will show in Rhino's option dialog, in the tab Plug-ins
<Assembly: PlugInDescription(DescriptionType.Address, "")>
<Assembly: PlugInDescription(DescriptionType.Country, "")>
<Assembly: PlugInDescription(DescriptionType.Email, "")>
<Assembly: PlugInDescription(DescriptionType.Phone, "")>
<Assembly: PlugInDescription(DescriptionType.Fax, "")>
<Assembly: PlugInDescription(DescriptionType.Organization, "")>
<Assembly: PlugInDescription(DescriptionType.UpdateUrl, "")>
<Assembly: PlugInDescription(DescriptionType.WebSite, "")>

<Assembly: AssemblyTitle("CNCWORKSHOP")> 
<Assembly: AssemblyDescription("tool for zund cutter devices")>
<Assembly: AssemblyCompany("")>
<Assembly: AssemblyProduct("CNCWORKSHOP")> 
<Assembly: AssemblyCopyright("Copyright ©  2016")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("ff5845e3-9ab8-4817-9989-9846d203704c")> 

' Version information for an assembly consists of the following four values:
'
'      Major Version
'      Minor Version 
'      Build Number
'      Revision
'
' You can specify all the values or you can default the Build and Revision Numbers 
' by using the '*' as shown below:

<Assembly: AssemblyVersion("1.1.*")> 
<Assembly: AssemblyFileVersion("1.0.0.0")> 

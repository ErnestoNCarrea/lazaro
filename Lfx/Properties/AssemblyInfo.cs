#region Using directives

using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Resources;
using System.Security.Permissions;

#endregion

[assembly: AssemblyTitle("Lázaro Framework")]
[assembly: AssemblyVersion("2.0.*")]
[assembly: AssemblyDescription("Lázaro Framework versión 1.0")]
[assembly: AssemblyCompany("Ernesto Nicolás Carrea")]
[assembly: AssemblyProduct("Lázaro")]
[assembly: AssemblyCopyright("Copyright 2004-2017 Ernesto Nicolás Carrea y colaboradores")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: System.Runtime.InteropServices.ComVisible (false)]
[assembly: CLSCompliant(true)]
[assembly: NeutralResourcesLanguageAttribute ("es-AR")]

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]
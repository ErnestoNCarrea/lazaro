#region Using directives

using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Resources;
using System.Security.Permissions;

#endregion

[assembly: AssemblyTitle("Lázaro")]
[assembly: AssemblyVersion("2.0.*")]
[assembly: AssemblyDescription("Sistema de gestión comercial Lázaro")]
[assembly: AssemblyCompany("Ernesto Nicolás Carrea")]
[assembly: AssemblyProduct("Lázaro")]
[assembly: AssemblyCopyright("Copyright 2004-2017 Ernesto Nicolás Carrea y colaboradores")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: CLSCompliant(true)]
[assembly: System.Runtime.InteropServices.ComVisible(false)]
[assembly: Guid("AF00B35F-6655-4ABB-907E-E767F63DB494")]
[assembly: NeutralResourcesLanguageAttribute ("es-AR")]

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]
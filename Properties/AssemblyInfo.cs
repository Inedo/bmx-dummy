using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Inedo.BuildMaster.Extensibility;

[assembly: AssemblyTitle("Dummy")]
[assembly: AssemblyDescription("Contains dummy/mock actions and providers to test deployment plans and workflow logic.")]

[assembly: ComVisible(false)]
[assembly: AssemblyCompany("Inedo, LLC")]
[assembly: AssemblyProduct("BuildMaster")]
[assembly: AssemblyCopyright("Copyright © 2008 - 2012")]
[assembly: AssemblyVersion("0.0.0.0")]
[assembly: AssemblyFileVersion("0.0")]
[assembly: BuildMasterAssembly]
[assembly: CLSCompliant(false)]
[assembly: RequiredBuildMasterVersion("3.0.0")]
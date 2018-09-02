using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace xViewer.Handlers.Decompiler
{
    public static class AssemblyMetadata
    {
        public static string GetMetadata(Assembly asm)
        {
            string ret = "";

            ret = ret + "// " + asm.FullName + "\n";
            ret = ret + "\n";
            ret = ret + "// Location:    " + asm.Location + "\n";
            ret = ret + "// Entry Point: " + asm.EntryPoint.Name + "\n";
            ret = ret + "\n";
            ret = ret + "\n";

            foreach (AssemblyName module in asm.GetReferencedAssemblies())
            {
                ret = ret + "using " + module.Name + ";\n";
            }

            ret = ret + "\n";
            ret = ret + "[assembly: AssemblyVersion(\"" + asm.GetName().Version + "\")\n";
            ret = ret + "[assembly: AssemblyTitle(\"" + asm.ManifestModule.ScopeName + "\")]\n";
            ret = ret + "[assembly: Guid(\"" + asm.ManifestModule.ModuleVersionId + "\")]\n";

            return ret;
        }
    }
}

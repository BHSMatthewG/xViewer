using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using xViewer.Handlers.Decompiler.Methods;

namespace xViewer.Handlers.Decompiler
{
    public class Decompiler
    {
        bool Scanned = false;
        private List<MethodInfo> Methods = new List<MethodInfo>() { };
        private List<MemberInfo> Members = new List<MemberInfo>() { };

        public void Scan(Assembly asm)
        {
            if (!Scanned)
            {
                Scanned = true;
                ScanModules(asm);
                ScanNamespaces(asm);
            }
        }

        private void ScanModules(Assembly asm)
        {
            foreach (Module module in asm.GetModules())
            {
                foreach (MethodInfo info in module.GetMethods())
                {
                    Methods.Add(info);
                }
            }
        }

        private void ScanNamespaces(Assembly asm)
        {
            foreach (Type typ in asm.GetTypes())
            {
                foreach (MethodInfo info in typ.GetMethods())
                {
                    Methods.Add(info);
                }
            }
        }

        public string Decompile(TreeNode node)
        {
            string ret = "";

            if (node.ImageIndex == 1)
            {
                foreach (MethodInfo info in Methods)
                {
                    if (info.Name == node.Text)
                    {
                        if (info.MetadataToken.ToString() == node.Name)
                        {
                            ret = DecompileMethod.Decompile(info);
                        }
                    }
                }
            }

            return ret;
        }
    }
}

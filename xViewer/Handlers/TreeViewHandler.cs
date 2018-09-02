using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xViewer.Handlers
{
    public class TreeViewHandler
    {
        private TreeView viewer;
        private Assembly assembly;

        // Main Nodes
        TreeNode BaseProgram;
        TreeNode References;
        TreeNode PE;
        TreeNode DefaultNamespace;
        TreeNode Resources;

        // Less Important Nodes
        List<TreeNode> Namespaces = new List<TreeNode>() { };
        List<TreeNode> Classes    = new List<TreeNode>() { };

        public TreeViewHandler(TreeView treeView, Assembly asm)
        {
            viewer = treeView;
            assembly = asm;
        }

        public void PopulateTreeView()
        {
            BaseProgram = viewer.Nodes.Add(assembly.GetName().Name);
            BaseProgram.Name = "BaseProgram";

            References = BaseProgram.Nodes.Add("References");
            PE = BaseProgram.Nodes.Add("PE");
            Resources = BaseProgram.Nodes.Add("Resources");

            References.ImageIndex = 3;
            References.SelectedImageIndex = 3;

            PopulateReferences();
            PopulateNamespaces();
            PopulateResources();
        }

        private bool CheckIfGotNamespace(string nspace)
        {
            bool r = false;
            foreach (TreeNode node in Namespaces) {
                if (node.Text == nspace)
                {
                    r = true;
                }
            }
            return r;
        }

        private bool CheckIfGotClass(string nclass)
        {
            bool r = false;
            foreach (TreeNode node in Classes)
            {
                if (node.Text == nclass)
                {
                    r = true;
                }
            }
            return r;
        }

        private void PopulateResources()
        {
            foreach (string rName in assembly.GetManifestResourceNames())
            {
                TreeNode node = Resources.Nodes.Add(rName);
                node.ImageIndex = 4;
                node.SelectedImageIndex = 4;
            }
        }

        private void PopulateNamespaces()
        {
            foreach (Type typ in assembly.GetTypes())
            {
                if (!CheckIfGotNamespace(typ.Namespace))
                {
                    TreeNode node = BaseProgram.Nodes.Add(typ.Namespace);
                    node.ImageIndex = 0;
                    node.SelectedImageIndex = 0;

                    Namespaces.Add(node);
                    PopulateClasses(node, typ.Namespace);
                    if (typ.Namespace == assembly.GetName().Name)
                    {
                        DefaultNamespace = node;
                    }
                }
            }
        }

        private void PopulateClasses(TreeNode nameSpace, string tNamespace)
        {
            foreach (Type typ in assembly.GetTypes())
            {
                if (!CheckIfGotClass(typ.FullName))
                {
                    if (typ.Namespace == tNamespace)
                    {
                        TreeNode node = nameSpace.Nodes.Add(typ.Name);
                        node.ImageIndex = 5;
                        node.SelectedImageIndex = 5;

                        Classes.Add(node);

                        PopulateMethods(node, typ);
                    }
                }
            }
        }

        private void PopulateMethods(TreeNode ClassSpace, Type typ)
        {
            foreach (MethodInfo info in typ.GetMethods())
            {
                TreeNode node = ClassSpace.Nodes.Add(info.Name);

                node.ImageIndex = 1;
                node.SelectedImageIndex = 1;
                node.Name = info.MetadataToken.ToString();
            }
        }

        private void PopulateMembers(TreeNode nameSpace, Type tNamespace)
        {
            foreach (MemberInfo info in tNamespace.GetMembers())
            {
                TreeNode node = nameSpace.Nodes.Add(info.Name);
                node.ImageIndex = 1;
                node.SelectedImageIndex = 1;
            }
        }

        private void PopulateReferences()
        {
            foreach (AssemblyName name in assembly.GetReferencedAssemblies())
            {
                TreeNode node = References.Nodes.Add(name.Name);
                node.ImageIndex = 2;
                node.SelectedImageIndex = 2;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using xViewer.Handlers;
using xViewer.Handlers.Decompiler;

namespace xViewer
{
    public partial class MainForm : Form
    {
        string file;
        Assembly asm;
        Decompiler decompiler;

        public MainForm()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Application Files|*.exe;*.dll";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    file = dialog.FileName;
                    asm = Assembly.LoadFile(@file);

                    TreeViewHandler handler = new TreeViewHandler(ProgramView, asm);
                    handler.PopulateTreeView();

                    decompiler = new Decompiler();
                }
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void ProgramView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            tabControl1.TabPages.Clear();
            decompiler.Scan(asm);

            TreeNode selectedItem = ProgramView.SelectedNode;

            if (selectedItem.Name == "BaseProgram")
            {
                try
                {
                    TabPage page = new TabPage();
                    page.Controls.Add(new RichTextBox()
                    {
                        Font = new Font(new FontFamily("Consolas"), 10, FontStyle.Regular),
                        Text = AssemblyMetadata.GetMetadata(asm),
                        Dock = DockStyle.Fill,
                        ReadOnly = true,
                        BackColor = Color.White
                    });
                    page.Text = selectedItem.Text;
                    page.Name = selectedItem.Name + " - " + selectedItem.Text;
                    tabControl1.TabPages.Add(page);
                } catch (Exception ex)
                {
                    TabPage page = new TabPage();
                    page.Controls.Add(new RichTextBox()
                    {
                        Font = new Font(new FontFamily("Consolas"), 10, FontStyle.Regular),
                        Text = "// Error Decompiling: " + ex.Message,
                        Dock = DockStyle.Fill,
                        ReadOnly = true,
                        BackColor = Color.White
                    });
                    page.Text = selectedItem.Text;
                    page.Name = selectedItem.Name + " - " + selectedItem.Text;
                    tabControl1.TabPages.Add(page);
                }
            } else
            {
                try
                {
                    TabPage page = new TabPage();
                    page.Controls.Add(new RichTextBox()
                    {
                        Font = new Font(new FontFamily("Consolas"), 10, FontStyle.Regular),
                        Text = decompiler.Decompile(selectedItem),
                        Dock = DockStyle.Fill,
                        ReadOnly = true,
                        BackColor = Color.White
                    });
                    page.Text = selectedItem.Text;
                    page.Name = selectedItem.Name + " - " + selectedItem.Text;
                    tabControl1.TabPages.Add(page);
                }
                catch (Exception ex)
                {
                    TabPage page = new TabPage();
                    page.Controls.Add(new RichTextBox()
                    {
                        Font = new Font(new FontFamily("Consolas"), 10, FontStyle.Regular),
                        Text = "// Error Decompiling: " + ex.Message,
                        Dock = DockStyle.Fill,
                        ReadOnly = true,
                        BackColor = Color.White
                    });
                    page.Text = selectedItem.Text;
                    page.Name = selectedItem.Name + " - " + selectedItem.Text;
                    tabControl1.TabPages.Add(page);
                }
            }
        }
    }
}

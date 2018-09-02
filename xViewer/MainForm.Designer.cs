namespace xViewer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.ProgramView = new System.Windows.Forms.TreeView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.TreeViewImages = new System.Windows.Forms.ImageList(this.components);
            this.Container1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Container1)).BeginInit();
            this.Container1.Panel1.SuspendLayout();
            this.Container1.Panel2.SuspendLayout();
            this.Container1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(592, 399);
            this.tabControl1.TabIndex = 0;
            // 
            // ProgramView
            // 
            this.ProgramView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgramView.ImageIndex = 0;
            this.ProgramView.ImageList = this.TreeViewImages;
            this.ProgramView.Location = new System.Drawing.Point(0, 0);
            this.ProgramView.Name = "ProgramView";
            this.ProgramView.SelectedImageIndex = 0;
            this.ProgramView.Size = new System.Drawing.Size(187, 399);
            this.ProgramView.TabIndex = 1;
            this.ProgramView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ProgramView_AfterSelect);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(802, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::xViewer.Properties.Resources.open_file_button;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // TreeViewImages
            // 
            this.TreeViewImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TreeViewImages.ImageStream")));
            this.TreeViewImages.TransparentColor = System.Drawing.Color.Green;
            this.TreeViewImages.Images.SetKeyName(0, "Class.Browser16.1.bmp");
            this.TreeViewImages.Images.SetKeyName(1, "Class.Browser16.66.bmp");
            this.TreeViewImages.Images.SetKeyName(2, "Class.Browser16.151.bmp");
            this.TreeViewImages.Images.SetKeyName(3, "Class.Browser16.155.bmp");
            this.TreeViewImages.Images.SetKeyName(4, "Class.Browser16.161.bmp");
            this.TreeViewImages.Images.SetKeyName(5, "Class.Browser16.7.bmp");
            // 
            // Container1
            // 
            this.Container1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Container1.Location = new System.Drawing.Point(8, 28);
            this.Container1.Name = "Container1";
            // 
            // Container1.Panel1
            // 
            this.Container1.Panel1.Controls.Add(this.ProgramView);
            // 
            // Container1.Panel2
            // 
            this.Container1.Panel2.Controls.Add(this.tabControl1);
            this.Container1.Size = new System.Drawing.Size(782, 399);
            this.Container1.SplitterDistance = 186;
            this.Container1.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 439);
            this.Controls.Add(this.Container1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainForm";
            this.Text = "Debugger";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.Container1.Panel1.ResumeLayout(false);
            this.Container1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Container1)).EndInit();
            this.Container1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TreeView ProgramView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ImageList TreeViewImages;
        private System.Windows.Forms.SplitContainer Container1;
    }
}


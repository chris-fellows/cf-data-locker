namespace CFDataLocker
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.tvwData = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupUserControl1 = new CFDataLocker.GroupUserControl();
            this.dataItemUserControl1 = new CFDataLocker.DataItemUserControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbLock = new System.Windows.Forms.ToolStripButton();
            this.tsbAddGroup = new System.Windows.Forms.ToolStripButton();
            this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addDataItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteDataItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbImportDataItems = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.cmsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Key:";
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(56, 28);
            this.txtKey.Name = "txtKey";
            this.txtKey.PasswordChar = '*';
            this.txtKey.Size = new System.Drawing.Size(212, 20);
            this.txtKey.TabIndex = 1;
            // 
            // tvwData
            // 
            this.tvwData.HideSelection = false;
            this.tvwData.Location = new System.Drawing.Point(8, 61);
            this.tvwData.Name = "tvwData";
            this.tvwData.Size = new System.Drawing.Size(260, 300);
            this.tvwData.TabIndex = 3;
            this.tvwData.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvwData_BeforeSelect);
            this.tvwData.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwData_AfterSelect);
            this.tvwData.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tvwData_MouseUp);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupUserControl1);
            this.panel1.Controls.Add(this.dataItemUserControl1);
            this.panel1.Location = new System.Drawing.Point(274, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(365, 216);
            this.panel1.TabIndex = 4;
            // 
            // groupUserControl1
            // 
            this.groupUserControl1.Group = null;
            this.groupUserControl1.Location = new System.Drawing.Point(0, 0);
            this.groupUserControl1.Name = "groupUserControl1";
            this.groupUserControl1.Size = new System.Drawing.Size(383, 42);
            this.groupUserControl1.TabIndex = 8;
            // 
            // dataItemUserControl1
            // 
            this.dataItemUserControl1.DataItem = null;
            this.dataItemUserControl1.Location = new System.Drawing.Point(2, -4);
            this.dataItemUserControl1.Name = "dataItemUserControl1";
            this.dataItemUserControl1.Size = new System.Drawing.Size(358, 238);
            this.dataItemUserControl1.TabIndex = 7;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbLock,
            this.tsbAddGroup,
            this.tsbImportDataItems});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(637, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbLock
            // 
            this.tsbLock.Image = ((System.Drawing.Image)(resources.GetObject("tsbLock.Image")));
            this.tsbLock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLock.Name = "tsbLock";
            this.tsbLock.Size = new System.Drawing.Size(52, 22);
            this.tsbLock.Text = "Lock";
            this.tsbLock.Click += new System.EventHandler(this.tsbLock_Click);
            // 
            // tsbAddGroup
            // 
            this.tsbAddGroup.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddGroup.Image")));
            this.tsbAddGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddGroup.Name = "tsbAddGroup";
            this.tsbAddGroup.Size = new System.Drawing.Size(85, 22);
            this.tsbAddGroup.Text = "Add Group";
            this.tsbAddGroup.Click += new System.EventHandler(this.tsbAddGroup_Click);
            // 
            // cmsMenu
            // 
            this.cmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addDataItemToolStripMenuItem,
            this.deleteDataItemToolStripMenuItem,
            this.deleteGroupToolStripMenuItem});
            this.cmsMenu.Name = "cmsMenu";
            this.cmsMenu.Size = new System.Drawing.Size(161, 70);
            // 
            // addDataItemToolStripMenuItem
            // 
            this.addDataItemToolStripMenuItem.Name = "addDataItemToolStripMenuItem";
            this.addDataItemToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.addDataItemToolStripMenuItem.Text = "Add data item";
            this.addDataItemToolStripMenuItem.Click += new System.EventHandler(this.addDataItemToolStripMenuItem_Click);
            // 
            // deleteDataItemToolStripMenuItem
            // 
            this.deleteDataItemToolStripMenuItem.Name = "deleteDataItemToolStripMenuItem";
            this.deleteDataItemToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.deleteDataItemToolStripMenuItem.Text = "Delete data item";
            this.deleteDataItemToolStripMenuItem.Click += new System.EventHandler(this.deleteDataItemToolStripMenuItem_Click);
            // 
            // deleteGroupToolStripMenuItem
            // 
            this.deleteGroupToolStripMenuItem.Name = "deleteGroupToolStripMenuItem";
            this.deleteGroupToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.deleteGroupToolStripMenuItem.Text = "Delete group";
            this.deleteGroupToolStripMenuItem.Click += new System.EventHandler(this.deleteGroupToolStripMenuItem_Click);
            // 
            // tsbImportDataItems
            // 
            this.tsbImportDataItems.Image = ((System.Drawing.Image)(resources.GetObject("tsbImportDataItems.Image")));
            this.tsbImportDataItems.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbImportDataItems.Name = "tsbImportDataItems";
            this.tsbImportDataItems.Size = new System.Drawing.Size(63, 22);
            this.tsbImportDataItems.Text = "Import";
            this.tsbImportDataItems.ToolTipText = "Imports CSV containing data items";
            this.tsbImportDataItems.Click += new System.EventHandler(this.tsbImportDataItems_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 373);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tvwData);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Locker";
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.cmsMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.TreeView tvwData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbLock;
        private System.Windows.Forms.ToolStripButton tsbAddGroup;
        private DataItemUserControl dataItemUserControl1;
        private GroupUserControl groupUserControl1;
        private System.Windows.Forms.ContextMenuStrip cmsMenu;
        private System.Windows.Forms.ToolStripMenuItem addDataItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteDataItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsbImportDataItems;
    }
}


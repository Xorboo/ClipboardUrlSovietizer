namespace ClipboardUrlSovietizer
{
    partial class frmMain
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
            ChangeClipboardChain(this.Handle, NextClipboardViewer);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.rtbData = new System.Windows.Forms.RichTextBox();
            this.notifyIconMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.NotifyIconMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripClose = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRemoveAutorun = new System.Windows.Forms.Button();
            this.btnAddToAutorun = new System.Windows.Forms.Button();
            this.chbLogClipboard = new System.Windows.Forms.CheckBox();
            this.chbEnabled = new System.Windows.Forms.CheckBox();
            this.toolStripEnabled = new System.Windows.Forms.ToolStripMenuItem();
            this.NotifyIconMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbData
            // 
            this.rtbData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbData.Location = new System.Drawing.Point(12, 12);
            this.rtbData.Name = "rtbData";
            this.rtbData.Size = new System.Drawing.Size(624, 298);
            this.rtbData.TabIndex = 0;
            this.rtbData.Text = "";
            // 
            // notifyIconMain
            // 
            this.notifyIconMain.ContextMenuStrip = this.NotifyIconMenuStrip;
            this.notifyIconMain.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconMain.Icon")));
            this.notifyIconMain.Text = "Clipboard URL Sovietizer";
            this.notifyIconMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconMain_MouseDoubleClick);
            // 
            // NotifyIconMenuStrip
            // 
            this.NotifyIconMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripOpen,
            this.toolStripEnabled,
            this.toolStripSeparator,
            this.toolStripClose});
            this.NotifyIconMenuStrip.Name = "NotifyIconMenuStrip";
            this.NotifyIconMenuStrip.Size = new System.Drawing.Size(153, 98);
            // 
            // toolStripOpen
            // 
            this.toolStripOpen.Name = "toolStripOpen";
            this.toolStripOpen.Size = new System.Drawing.Size(152, 22);
            this.toolStripOpen.Text = "Open";
            this.toolStripOpen.Click += new System.EventHandler(this.toolStripOpen_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripClose
            // 
            this.toolStripClose.Name = "toolStripClose";
            this.toolStripClose.Size = new System.Drawing.Size(152, 22);
            this.toolStripClose.Text = "Close";
            this.toolStripClose.Click += new System.EventHandler(this.toolStripClose_Click);
            // 
            // btnRemoveAutorun
            // 
            this.btnRemoveAutorun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveAutorun.Location = new System.Drawing.Point(517, 316);
            this.btnRemoveAutorun.Name = "btnRemoveAutorun";
            this.btnRemoveAutorun.Size = new System.Drawing.Size(119, 23);
            this.btnRemoveAutorun.TabIndex = 2;
            this.btnRemoveAutorun.Text = "Remove from Autorun";
            this.btnRemoveAutorun.UseVisualStyleBackColor = true;
            this.btnRemoveAutorun.Click += new System.EventHandler(this.btnRemoveAutorun_Click);
            // 
            // btnAddToAutorun
            // 
            this.btnAddToAutorun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddToAutorun.Location = new System.Drawing.Point(517, 316);
            this.btnAddToAutorun.Name = "btnAddToAutorun";
            this.btnAddToAutorun.Size = new System.Drawing.Size(119, 23);
            this.btnAddToAutorun.TabIndex = 3;
            this.btnAddToAutorun.Text = "Add to Autorun";
            this.btnAddToAutorun.UseVisualStyleBackColor = true;
            this.btnAddToAutorun.Click += new System.EventHandler(this.btnAddToAutorun_Click);
            // 
            // chbLogClipboard
            // 
            this.chbLogClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chbLogClipboard.AutoSize = true;
            this.chbLogClipboard.Location = new System.Drawing.Point(200, 316);
            this.chbLogClipboard.Name = "chbLogClipboard";
            this.chbLogClipboard.Size = new System.Drawing.Size(165, 17);
            this.chbLogClipboard.TabIndex = 4;
            this.chbLogClipboard.Text = "Show last clipboard operation";
            this.chbLogClipboard.UseVisualStyleBackColor = true;
            // 
            // chbEnabled
            // 
            this.chbEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chbEnabled.AutoSize = true;
            this.chbEnabled.Checked = true;
            this.chbEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbEnabled.Location = new System.Drawing.Point(12, 316);
            this.chbEnabled.Name = "chbEnabled";
            this.chbEnabled.Size = new System.Drawing.Size(106, 17);
            this.chbEnabled.TabIndex = 5;
            this.chbEnabled.Text = "Enable sovietizer";
            this.chbEnabled.UseVisualStyleBackColor = true;
            this.chbEnabled.CheckedChanged += new System.EventHandler(this.chbEnabled_CheckedChanged);
            // 
            // toolStripEnabled
            // 
            this.toolStripEnabled.Checked = true;
            this.toolStripEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripEnabled.Name = "toolStripEnabled";
            this.toolStripEnabled.Size = new System.Drawing.Size(152, 22);
            this.toolStripEnabled.Text = "Enabled";
            this.toolStripEnabled.Click += new System.EventHandler(this.toolStripEnabled_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 343);
            this.Controls.Add(this.chbEnabled);
            this.Controls.Add(this.chbLogClipboard);
            this.Controls.Add(this.btnAddToAutorun);
            this.Controls.Add(this.btnRemoveAutorun);
            this.Controls.Add(this.rtbData);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Clipboard URL Sovietizer";
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.NotifyIconMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbData;
        private System.Windows.Forms.NotifyIcon notifyIconMain;
        private System.Windows.Forms.ContextMenuStrip NotifyIconMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripOpen;
        private System.Windows.Forms.ToolStripMenuItem toolStripClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.Button btnRemoveAutorun;
        private System.Windows.Forms.Button btnAddToAutorun;
        private System.Windows.Forms.CheckBox chbLogClipboard;
        private System.Windows.Forms.CheckBox chbEnabled;
        private System.Windows.Forms.ToolStripMenuItem toolStripEnabled;
    }
}


namespace EasyTreeView
{
    partial class Form1
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.gbxNodeInfo = new System.Windows.Forms.GroupBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.cbOutputDebugView = new System.Windows.Forms.CheckBox();
			this.cbOutputLog = new System.Windows.Forms.CheckBox();
			this.lblFilename = new System.Windows.Forms.Label();
			this.btnFilename = new System.Windows.Forms.Button();
			this.txtFilename = new System.Windows.Forms.TextBox();
			this.btnOpenFolder = new System.Windows.Forms.Button();
			this.txtName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.ProcessResult = new System.Windows.Forms.Label();
			this.gbxSearchByText = new System.Windows.Forms.GroupBox();
			this.btnNodeTextSearch = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.txtNodeTextSearch = new System.Windows.Forms.TextBox();
			this.RevertAllBtn = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.CodeAnalysisButton = new System.Windows.Forms.Button();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.cmnuAddNode = new System.Windows.Forms.ToolStripMenuItem();
			this.cmnuRemoveNode = new System.Windows.Forms.ToolStripMenuItem();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.gbxNodeInfo.SuspendLayout();
			this.panel1.SuspendLayout();
			this.gbxSearchByText.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.gbxNodeInfo);
			this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.AutoScroll = true;
			this.splitContainer1.Panel2.Controls.Add(this.ProcessResult);
			this.splitContainer1.Panel2.Controls.Add(this.gbxSearchByText);
			this.splitContainer1.Panel2.Controls.Add(this.treeView1);
			this.splitContainer1.Size = new System.Drawing.Size(1006, 996);
			this.splitContainer1.SplitterDistance = 136;
			this.splitContainer1.SplitterWidth = 5;
			this.splitContainer1.TabIndex = 0;
			// 
			// gbxNodeInfo
			// 
			this.gbxNodeInfo.Controls.Add(this.panel1);
			this.gbxNodeInfo.Controls.Add(this.lblFilename);
			this.gbxNodeInfo.Controls.Add(this.btnFilename);
			this.gbxNodeInfo.Controls.Add(this.txtFilename);
			this.gbxNodeInfo.Controls.Add(this.btnOpenFolder);
			this.gbxNodeInfo.Controls.Add(this.txtName);
			this.gbxNodeInfo.Controls.Add(this.label1);
			this.gbxNodeInfo.Location = new System.Drawing.Point(16, 15);
			this.gbxNodeInfo.Margin = new System.Windows.Forms.Padding(4);
			this.gbxNodeInfo.Name = "gbxNodeInfo";
			this.gbxNodeInfo.Padding = new System.Windows.Forms.Padding(4);
			this.gbxNodeInfo.Size = new System.Drawing.Size(1103, 106);
			this.gbxNodeInfo.TabIndex = 0;
			this.gbxNodeInfo.TabStop = false;
			this.gbxNodeInfo.Text = "Select Globe Target";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.cbOutputDebugView);
			this.panel1.Controls.Add(this.cbOutputLog);
			this.panel1.Location = new System.Drawing.Point(764, 22);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(214, 71);
			this.panel1.TabIndex = 11;
			// 
			// cbOutputDebugView
			// 
			this.cbOutputDebugView.AutoSize = true;
			this.cbOutputDebugView.Location = new System.Drawing.Point(17, 30);
			this.cbOutputDebugView.Margin = new System.Windows.Forms.Padding(4);
			this.cbOutputDebugView.Name = "cbOutputDebugView";
			this.cbOutputDebugView.Size = new System.Drawing.Size(180, 21);
			this.cbOutputDebugView.TabIndex = 10;
			this.cbOutputDebugView.Text = "Display to DebugViewer";
			this.cbOutputDebugView.UseVisualStyleBackColor = true;
			this.cbOutputDebugView.CheckedChanged += new System.EventHandler(this.cbOutputDebugView_CheckedChanged);
			// 
			// cbOutputLog
			// 
			this.cbOutputLog.AutoSize = true;
			this.cbOutputLog.Location = new System.Drawing.Point(17, 4);
			this.cbOutputLog.Margin = new System.Windows.Forms.Padding(4);
			this.cbOutputLog.Name = "cbOutputLog";
			this.cbOutputLog.Size = new System.Drawing.Size(136, 21);
			this.cbOutputLog.TabIndex = 9;
			this.cbOutputLog.Text = "Generate Logfile";
			this.cbOutputLog.UseVisualStyleBackColor = true;
			this.cbOutputLog.CheckedChanged += new System.EventHandler(this.cbOutputLog_CheckedChanged);
			// 
			// lblFilename
			// 
			this.lblFilename.AutoSize = true;
			this.lblFilename.Location = new System.Drawing.Point(10, 60);
			this.lblFilename.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblFilename.Name = "lblFilename";
			this.lblFilename.Size = new System.Drawing.Size(119, 17);
			this.lblFilename.TabIndex = 8;
			this.lblFilename.Text = "Logfile Directory :";
			// 
			// btnFilename
			// 
			this.btnFilename.Location = new System.Drawing.Point(618, 57);
			this.btnFilename.Margin = new System.Windows.Forms.Padding(4);
			this.btnFilename.Name = "btnFilename";
			this.btnFilename.Size = new System.Drawing.Size(139, 25);
			this.btnFilename.TabIndex = 7;
			this.btnFilename.Text = "Change";
			this.btnFilename.UseVisualStyleBackColor = true;
			this.btnFilename.Click += new System.EventHandler(this.btnLogFile_Click);
			// 
			// txtFilename
			// 
			this.txtFilename.Location = new System.Drawing.Point(135, 60);
			this.txtFilename.Margin = new System.Windows.Forms.Padding(4);
			this.txtFilename.Name = "txtFilename";
			this.txtFilename.Size = new System.Drawing.Size(470, 22);
			this.txtFilename.TabIndex = 6;
			// 
			// btnOpenFolder
			// 
			this.btnOpenFolder.Location = new System.Drawing.Point(618, 26);
			this.btnOpenFolder.Margin = new System.Windows.Forms.Padding(4);
			this.btnOpenFolder.Name = "btnOpenFolder";
			this.btnOpenFolder.Size = new System.Drawing.Size(139, 25);
			this.btnOpenFolder.TabIndex = 5;
			this.btnOpenFolder.Text = "Open";
			this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(135, 31);
			this.txtName.Margin = new System.Windows.Forms.Padding(4);
			this.txtName.Multiline = true;
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(470, 20);
			this.txtName.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 34);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(119, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Target Directory :";
			// 
			// ProcessResult
			// 
			this.ProcessResult.AutoSize = true;
			this.ProcessResult.Location = new System.Drawing.Point(37, 6);
			this.ProcessResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.ProcessResult.Name = "ProcessResult";
			this.ProcessResult.Size = new System.Drawing.Size(0, 17);
			this.ProcessResult.TabIndex = 1;
			// 
			// gbxSearchByText
			// 
			this.gbxSearchByText.Controls.Add(this.btnNodeTextSearch);
			this.gbxSearchByText.Controls.Add(this.btnClose);
			this.gbxSearchByText.Controls.Add(this.txtNodeTextSearch);
			this.gbxSearchByText.Controls.Add(this.RevertAllBtn);
			this.gbxSearchByText.Controls.Add(this.label3);
			this.gbxSearchByText.Controls.Add(this.CodeAnalysisButton);
			this.gbxSearchByText.Location = new System.Drawing.Point(16, 728);
			this.gbxSearchByText.Margin = new System.Windows.Forms.Padding(4);
			this.gbxSearchByText.Name = "gbxSearchByText";
			this.gbxSearchByText.Padding = new System.Windows.Forms.Padding(4);
			this.gbxSearchByText.Size = new System.Drawing.Size(962, 114);
			this.gbxSearchByText.TabIndex = 2;
			this.gbxSearchByText.TabStop = false;
			// 
			// btnNodeTextSearch
			// 
			this.btnNodeTextSearch.Location = new System.Drawing.Point(618, 19);
			this.btnNodeTextSearch.Margin = new System.Windows.Forms.Padding(4);
			this.btnNodeTextSearch.Name = "btnNodeTextSearch";
			this.btnNodeTextSearch.Size = new System.Drawing.Size(139, 28);
			this.btnNodeTextSearch.TabIndex = 7;
			this.btnNodeTextSearch.Text = "Find";
			this.btnNodeTextSearch.UseVisualStyleBackColor = true;
			this.btnNodeTextSearch.Click += new System.EventHandler(this.btnNodeTextSearch_Click);
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(674, 60);
			this.btnClose.Margin = new System.Windows.Forms.Padding(4);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(280, 46);
			this.btnClose.TabIndex = 5;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.close_Click);
			// 
			// txtNodeTextSearch
			// 
			this.txtNodeTextSearch.Location = new System.Drawing.Point(168, 22);
			this.txtNodeTextSearch.Margin = new System.Windows.Forms.Padding(4);
			this.txtNodeTextSearch.Name = "txtNodeTextSearch";
			this.txtNodeTextSearch.Size = new System.Drawing.Size(437, 22);
			this.txtNodeTextSearch.TabIndex = 6;
			// 
			// RevertAllBtn
			// 
			this.RevertAllBtn.Location = new System.Drawing.Point(367, 60);
			this.RevertAllBtn.Margin = new System.Windows.Forms.Padding(4);
			this.RevertAllBtn.Name = "RevertAllBtn";
			this.RevertAllBtn.Size = new System.Drawing.Size(280, 46);
			this.RevertAllBtn.TabIndex = 4;
			this.RevertAllBtn.Text = "Revert All Changes";
			this.RevertAllBtn.UseVisualStyleBackColor = true;
			this.RevertAllBtn.Click += new System.EventHandler(this.revertAllButton_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(8, 25);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(156, 17);
			this.label3.TabIndex = 5;
			this.label3.Text = "Function Name Search:";
			// 
			// CodeAnalysisButton
			// 
			this.CodeAnalysisButton.Location = new System.Drawing.Point(0, 60);
			this.CodeAnalysisButton.Margin = new System.Windows.Forms.Padding(4);
			this.CodeAnalysisButton.Name = "CodeAnalysisButton";
			this.CodeAnalysisButton.Size = new System.Drawing.Size(280, 46);
			this.CodeAnalysisButton.TabIndex = 3;
			this.CodeAnalysisButton.Text = "Code Analysis";
			this.CodeAnalysisButton.UseVisualStyleBackColor = true;
			this.CodeAnalysisButton.Click += new System.EventHandler(this.codeAnalysisButton_Click);
			// 
			// treeView1
			// 
			this.treeView1.CheckBoxes = true;
			this.treeView1.ContextMenuStrip = this.contextMenuStrip1;
			this.treeView1.Location = new System.Drawing.Point(16, 26);
			this.treeView1.Margin = new System.Windows.Forms.Padding(4);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(962, 694);
			this.treeView1.TabIndex = 0;
			this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			this.treeView1.Click += new System.EventHandler(this.treeView1_Click);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuAddNode,
            this.cmnuRemoveNode});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(174, 52);
			// 
			// cmnuAddNode
			// 
			this.cmnuAddNode.Name = "cmnuAddNode";
			this.cmnuAddNode.Size = new System.Drawing.Size(173, 24);
			this.cmnuAddNode.Text = "Add Node";
			this.cmnuAddNode.Click += new System.EventHandler(this.cmnuAddNode_Click);
			// 
			// cmnuRemoveNode
			// 
			this.cmnuRemoveNode.Name = "cmnuRemoveNode";
			this.cmnuRemoveNode.Size = new System.Drawing.Size(173, 24);
			this.cmnuRemoveNode.Text = "Remove Node";
			this.cmnuRemoveNode.Click += new System.EventHandler(this.cmnuRemoveNode_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1006, 996);
			this.Controls.Add(this.splitContainer1);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "Form1";
			this.Text = "Globe System Logger";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.gbxNodeInfo.ResumeLayout(false);
			this.gbxNodeInfo.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.gbxSearchByText.ResumeLayout(false);
			this.gbxSearchByText.PerformLayout();
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.GroupBox gbxNodeInfo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cmnuAddNode;
        private System.Windows.Forms.ToolStripMenuItem cmnuRemoveNode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.GroupBox gbxSearchByText;
        private System.Windows.Forms.Button btnNodeTextSearch;
        private System.Windows.Forms.TextBox txtNodeTextSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button RevertAllBtn;
        private System.Windows.Forms.Button CodeAnalysisButton;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.Label ProcessResult;
        private System.Windows.Forms.Label lblFilename;
        private System.Windows.Forms.Button btnFilename;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.CheckBox cbOutputDebugView;
        private System.Windows.Forms.CheckBox cbOutputLog;
		private System.Windows.Forms.Panel panel1;
	}
}


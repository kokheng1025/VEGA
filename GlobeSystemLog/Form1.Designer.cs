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
            this.lblFilename = new System.Windows.Forms.Label();
            this.btnFilename = new System.Windows.Forms.Button();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ProcessResult = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.generateLoggerButton = new System.Windows.Forms.Button();
            this.CodeAnalysisButton = new System.Windows.Forms.Button();
            this.gbxSearchByText = new System.Windows.Forms.GroupBox();
            this.btnNodeTextSearch = new System.Windows.Forms.Button();
            this.txtNodeTextSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuAddNode = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuRemoveNode = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.cbOutputLog = new System.Windows.Forms.CheckBox();
            this.cbOutputDebugView = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbxNodeInfo.SuspendLayout();
            this.gbxSearchByText.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
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
            this.splitContainer1.Panel2.Controls.Add(this.ProcessResult);
            this.splitContainer1.Panel2.Controls.Add(this.btnClose);
            this.splitContainer1.Panel2.Controls.Add(this.generateLoggerButton);
            this.splitContainer1.Panel2.Controls.Add(this.CodeAnalysisButton);
            this.splitContainer1.Panel2.Controls.Add(this.gbxSearchByText);
            this.splitContainer1.Panel2.Controls.Add(this.treeView1);
            this.splitContainer1.Size = new System.Drawing.Size(893, 809);
            this.splitContainer1.SplitterDistance = 129;
            this.splitContainer1.TabIndex = 0;
            // 
            // gbxNodeInfo
            // 
            this.gbxNodeInfo.Controls.Add(this.cbOutputDebugView);
            this.gbxNodeInfo.Controls.Add(this.cbOutputLog);
            this.gbxNodeInfo.Controls.Add(this.lblFilename);
            this.gbxNodeInfo.Controls.Add(this.btnFilename);
            this.gbxNodeInfo.Controls.Add(this.txtFilename);
            this.gbxNodeInfo.Controls.Add(this.btnOpenFolder);
            this.gbxNodeInfo.Controls.Add(this.txtName);
            this.gbxNodeInfo.Controls.Add(this.label1);
            this.gbxNodeInfo.Location = new System.Drawing.Point(12, 12);
            this.gbxNodeInfo.Name = "gbxNodeInfo";
            this.gbxNodeInfo.Size = new System.Drawing.Size(870, 112);
            this.gbxNodeInfo.TabIndex = 0;
            this.gbxNodeInfo.TabStop = false;
            this.gbxNodeInfo.Text = "Select Globe Target";
            // 
            // lblFilename
            // 
            this.lblFilename.AutoSize = true;
            this.lblFilename.Location = new System.Drawing.Point(19, 74);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(76, 13);
            this.lblFilename.TabIndex = 8;
            this.lblFilename.Text = "Log Filename :";
            // 
            // btnFilename
            // 
            this.btnFilename.Location = new System.Drawing.Point(547, 69);
            this.btnFilename.Name = "btnFilename";
            this.btnFilename.Size = new System.Drawing.Size(104, 22);
            this.btnFilename.TabIndex = 7;
            this.btnFilename.Text = "Change";
            this.btnFilename.UseVisualStyleBackColor = true;
            this.btnFilename.Click += new System.EventHandler(this.btnLogFile_Click);
            // 
            // txtFilename
            // 
            this.txtFilename.Location = new System.Drawing.Point(101, 71);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(440, 20);
            this.txtFilename.TabIndex = 6;
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Location = new System.Drawing.Point(547, 23);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(104, 22);
            this.btnOpenFolder.TabIndex = 5;
            this.btnOpenFolder.Text = "Open";
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(101, 25);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(440, 20);
            this.txtName.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // ProcessResult
            // 
            this.ProcessResult.AutoSize = true;
            this.ProcessResult.Location = new System.Drawing.Point(28, 5);
            this.ProcessResult.Name = "ProcessResult";
            this.ProcessResult.Size = new System.Drawing.Size(0, 13);
            this.ProcessResult.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(474, 618);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(210, 37);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.close_Click);
            // 
            // generateLoggerButton
            // 
            this.generateLoggerButton.Location = new System.Drawing.Point(244, 618);
            this.generateLoggerButton.Name = "generateLoggerButton";
            this.generateLoggerButton.Size = new System.Drawing.Size(210, 37);
            this.generateLoggerButton.TabIndex = 4;
            this.generateLoggerButton.Text = "Logger Generator";
            this.generateLoggerButton.UseVisualStyleBackColor = true;
            // 
            // CodeAnalysisButton
            // 
            this.CodeAnalysisButton.Location = new System.Drawing.Point(12, 618);
            this.CodeAnalysisButton.Name = "CodeAnalysisButton";
            this.CodeAnalysisButton.Size = new System.Drawing.Size(210, 37);
            this.CodeAnalysisButton.TabIndex = 3;
            this.CodeAnalysisButton.Text = "Code Analysis";
            this.CodeAnalysisButton.UseVisualStyleBackColor = true;
            this.CodeAnalysisButton.Click += new System.EventHandler(this.codeAnalysisButton_Click);
            // 
            // gbxSearchByText
            // 
            this.gbxSearchByText.Controls.Add(this.btnNodeTextSearch);
            this.gbxSearchByText.Controls.Add(this.txtNodeTextSearch);
            this.gbxSearchByText.Controls.Add(this.label3);
            this.gbxSearchByText.Location = new System.Drawing.Point(12, 550);
            this.gbxSearchByText.Name = "gbxSearchByText";
            this.gbxSearchByText.Size = new System.Drawing.Size(672, 47);
            this.gbxSearchByText.TabIndex = 2;
            this.gbxSearchByText.TabStop = false;
            // 
            // btnNodeTextSearch
            // 
            this.btnNodeTextSearch.Location = new System.Drawing.Point(550, 14);
            this.btnNodeTextSearch.Name = "btnNodeTextSearch";
            this.btnNodeTextSearch.Size = new System.Drawing.Size(104, 23);
            this.btnNodeTextSearch.TabIndex = 7;
            this.btnNodeTextSearch.Text = "Find";
            this.btnNodeTextSearch.UseVisualStyleBackColor = true;
            this.btnNodeTextSearch.Click += new System.EventHandler(this.btnNodeTextSearch_Click);
            // 
            // txtNodeTextSearch
            // 
            this.txtNodeTextSearch.Location = new System.Drawing.Point(104, 16);
            this.txtNodeTextSearch.Name = "txtNodeTextSearch";
            this.txtNodeTextSearch.Size = new System.Drawing.Size(440, 20);
            this.txtNodeTextSearch.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Text:";
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeView1.Location = new System.Drawing.Point(12, 21);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(669, 523);
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
            this.contextMenuStrip1.Size = new System.Drawing.Size(150, 48);
            // 
            // cmnuAddNode
            // 
            this.cmnuAddNode.Name = "cmnuAddNode";
            this.cmnuAddNode.Size = new System.Drawing.Size(149, 22);
            this.cmnuAddNode.Text = "Add Node";
            this.cmnuAddNode.Click += new System.EventHandler(this.cmnuAddNode_Click);
            // 
            // cmnuRemoveNode
            // 
            this.cmnuRemoveNode.Name = "cmnuRemoveNode";
            this.cmnuRemoveNode.Size = new System.Drawing.Size(149, 22);
            this.cmnuRemoveNode.Text = "Remove Node";
            this.cmnuRemoveNode.Click += new System.EventHandler(this.cmnuRemoveNode_Click);
            // 
            // cbOutputLog
            // 
            this.cbOutputLog.AutoSize = true;
            this.cbOutputLog.Location = new System.Drawing.Point(704, 27);
            this.cbOutputLog.Name = "cbOutputLog";
            this.cbOutputLog.Size = new System.Drawing.Size(104, 17);
            this.cbOutputLog.TabIndex = 9;
            this.cbOutputLog.Text = "Output to Logfile";
            this.cbOutputLog.UseVisualStyleBackColor = true;
            this.cbOutputLog.CheckedChanged += new System.EventHandler(this.cbOutputLog_CheckedChanged);
            // 
            // cbOutputDebugView
            // 
            this.cbOutputDebugView.AutoSize = true;
            this.cbOutputDebugView.Location = new System.Drawing.Point(704, 69);
            this.cbOutputDebugView.Name = "cbOutputDebugView";
            this.cbOutputDebugView.Size = new System.Drawing.Size(128, 17);
            this.cbOutputDebugView.TabIndex = 10;
            this.cbOutputDebugView.Text = "Output to DebugView";
            this.cbOutputDebugView.UseVisualStyleBackColor = true;
            this.cbOutputDebugView.CheckedChanged += new System.EventHandler(this.cbOutputDebugView_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 809);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Globe System Logger";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbxNodeInfo.ResumeLayout(false);
            this.gbxNodeInfo.PerformLayout();
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
        private System.Windows.Forms.Button generateLoggerButton;
        private System.Windows.Forms.Button CodeAnalysisButton;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.Label ProcessResult;
        private System.Windows.Forms.Label lblFilename;
        private System.Windows.Forms.Button btnFilename;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.CheckBox cbOutputDebugView;
        private System.Windows.Forms.CheckBox cbOutputLog;
    }
}


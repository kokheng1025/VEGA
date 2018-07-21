using GlobeSystemLog;
using migrationTools.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace EasyTreeView
{
    public partial class Form1 : Form
    {
		public string FolderPath { get; set; }
        Settings oSettings = new Settings();
        PathSettings oPath;

        public TreeNode RootNode { get; set; }
        public List<String> CheckedFiles { get; set; }
        public Form1()
        {
            InitializeComponent();
            RootNode = new TreeNode();
            CheckedFiles = new List<String>();
            GetPathSettings();
        }

        private void GetPathSettings()
        {    
            oPath = oSettings.GetSettingsFromFile();

            txtName.Text = oPath.TargetFolder;
            txtFilename.Text = oPath.LogFilename;
            GetTreeView(txtName.Text);
        }
        
#region Add and Remove Nodes

        /// <summary>
        /// Add a Treeview node using a dialog box
        /// forcing the user to set the name and text properties
        /// of the node
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmnuAddNode_Click(object sender, EventArgs e)
        {
            NewNode n = new NewNode();
            n.ShowDialog();
            TreeNode nod = new TreeNode();
            nod.Name = n.NewNodeName.ToString();
            nod.Text = n.NewNodeText.ToString();
            nod.Tag = n.NewNodeTag.ToString();
            n.Close();

            treeView1.SelectedNode.Nodes.Add(nod);
            treeView1.SelectedNode.ExpandAll();
        }



        /// <summary>
        /// Remove the selected node and it children
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmnuRemoveNode_Click(object sender, EventArgs e)
        {
            treeView1.SelectedNode.Remove();
        }

        
#endregion


       
#region Treeview Event Handlers

        /// <summary>
        /// Display information about the selected node
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
               /* txtName.Text = "";
                txtParentName.Text = "";
                txtText.Text = "";
                txtTag.Text = "";

                txtName.Text = treeView1.SelectedNode.Name.ToString();
                txtText.Text = treeView1.SelectedNode.Text.ToString();
                txtTag.Text = treeView1.SelectedNode.Tag.ToString();
                txtParentName.Text = treeView1.SelectedNode.Parent.Text.ToString();
                */
            }
            catch { }
        }


        /// <summary>
        /// Clear nodes marked by the find functions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_Click(object sender, EventArgs e)
        {
            ClearBackColor();
        }

#endregion
        
        
#region Remove BackColor

        // recursively move through the treeview nodes
        // and reset backcolors to white
        private void ClearBackColor()
        {
            TreeNodeCollection nodes = treeView1.Nodes;
            foreach (TreeNode n in nodes)
            {
                ClearRecursive(n);
            }
        }

        // called by ClearBackColor function
        private void ClearRecursive(TreeNode treeNode)
        {
            foreach (TreeNode tn in treeNode.Nodes)
            {
                tn.BackColor = Color.White;
                ClearRecursive(tn);
            }
        }
        
#endregion
        
        
#region Find By Text

        /// <summary>
        /// Searching for nodes by text requires a special function
        /// this function recursively scans the treeview and
        /// marks matching items.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNodeTextSearch_Click(object sender, EventArgs e)
        {
            ClearBackColor();
            FindByText();
        }


        private void FindByText()
        {
            TreeNodeCollection nodes = treeView1.Nodes;
            foreach (TreeNode n in nodes)
            {
                FindRecursive(n);
            }
        }


        private void FindRecursive(TreeNode treeNode)
        {
            foreach (TreeNode tn in treeNode.Nodes)
            {
                // if the text properties match, color the item
                if (tn.Text.ToLower().Contains(this.txtNodeTextSearch.Text.ToLower()))
                    tn.BackColor = Color.Yellow;

                FindRecursive(tn);
            }
        }

        #endregion

        #region Find All Checked Nodes
        private List<TreeNode> CheckedNodes()
        {
            int checkFileOrFunction = 1;
            var checkedNodes = new List<TreeNode>();
            TreeNodeCollection nodes = treeView1.Nodes;
            foreach (TreeNode n in nodes)
            {
                FindCheckedNodes(checkedNodes, n, checkFileOrFunction);
            }

            return checkedNodes;
        }

        private void FindCheckedNodes(List<TreeNode> checkedNodes, TreeNode treeNode, int checkFileOrFunction)
        {
            bool parentFileFound = false;
            foreach (TreeNode tn in treeNode.Nodes)
            {
                if (tn.Checked)
                {
                    //Add files/function into the checked List
                    checkedNodes.Add(tn);

                    //If function is checked
                    if (checkFileOrFunction == 2 && parentFileFound == false)
                    {
                        //Check if parent file has been included into the checked List
                        foreach (TreeNode n in checkedNodes)
                        {
                            //Add parent file into the checked List
                            if (tn.Parent.Text.Equals(n.Text)) parentFileFound = true;
                        }

                        //Add parent of node(file) into the checked list
                        if (parentFileFound == false) checkedNodes.Add(tn.Parent);

                    }
                }
                //To check which functions has been checked
                FindCheckedNodes(checkedNodes, tn, checkFileOrFunction + 1);
            }
        }

        #endregion

        #region Check Child Nodes

        private void CheckChildNodes(bool check)
        {
            TreeNodeCollection nodes = treeView1.Nodes;
            foreach (TreeNode n in nodes)
            {
                DoCheckChildNodes(n, check);
            }
        }

        private void DoCheckChildNodes(TreeNode treeNode, bool check)
        {
            foreach (TreeNode tn in treeNode.Nodes)
            {
                tn.Checked = check;

                DoCheckChildNodes(tn, check);
            }
        }

        #endregion  
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void searchListOfFunctions(TreeNode n, string fileName)
        {
            // open file
            StreamReader Reader = new StreamReader(fileName, Encoding.ASCII, false, 65536);

            string line = String.Empty;
            string nextWord = String.Empty;
            string endProduceName = String.Empty;

            foreach (TreeNode tn in treeView1.SelectedNode.Nodes)
            {
                if (tn == n) {
                    treeView1.SelectedNode = tn;
                }
            }

            try
            {
                while ((line = Reader.ReadLine()) != null)
                {

                    if (line == null || line == String.Empty) continue;

                    // if line not yet finish, add it together
                    while (line.Substring(line.Length - 1, 1) == "_")
                    {
                        line += Reader.ReadLine();
                    }

                   
                    string startProduceName = String.Empty;
                    string keyWord = String.Empty;
                    if (Utils.IsFoundStartProcedureFunction(line, ref startProduceName, ref keyWord) == true)
                    {
                        //Add function in treeView
                        TreeNode newNode = new TreeNode();
                        newNode.Name = startProduceName;
                        newNode.Text = startProduceName;
                        newNode.Tag = startProduceName;

                        treeView1.SelectedNode.Nodes.Add(newNode);
                    }

                }
            }
            catch (Exception f)
            {
                Debug.WriteLine("error {0}", f.Message);
            }

            // close stream before exit
            Reader.Close();
        }

		private void btnOpenFolder_Click(object sender, EventArgs e)
		{
			DialogResult result = this.folderBrowserDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
                FolderPath = this.folderBrowserDialog.SelectedPath;
                GetTreeView(FolderPath);
			}
		}

        //Create Log
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            CheckedFiles.Clear();
            List<TreeNode> checkedNodes = CheckedNodes();
            foreach (TreeNode n in checkedNodes)
            {
                //MessageBox.Show(n.Text);
                CheckedFiles.Add(n.Text);                
            }
            foreach (string file in CheckedFiles)
            {
                MessageBox.Show(file);
            }
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node == RootNode)
            {
                foreach (TreeNode tn in e.Node.Nodes)
                {
                    tn.Checked = e.Node.Checked;
                }
            }
            else
            {

                foreach (TreeNode tn in RootNode.Nodes)
                {
                    if (tn == e.Node) {
                        foreach (TreeNode tnn in e.Node.Nodes)
                        {
                            tnn.Checked = e.Node.Checked;
                        }
                    }
                }

            }
        }

        private bool isFunction(string fileName)
        {
            bool flagFunction = false;

            string fileExt = fileName.Substring(fileName.Length - 3, 3);

            if (fileExt.ToUpper() == "FRM" || fileExt.ToUpper() == "BAS" || fileExt.ToUpper() == "CLS")
            {
                flagFunction = true;
            }

            return flagFunction;
        }

		private void codeAnalysisButton_Click(object sender, EventArgs e)
		{
            if (SaveSettings() == false)
            {
                return;
            }

            // Create GLBSysLog.bas file
            oSettings.WriteVBLoggerFile();

            int status = (int)SystemLogStatusCode.Success;
            string targetFile = String.Empty;

            CheckedFiles.Clear();
            List<TreeNode> checkedNodes = CheckedNodes();
            foreach (TreeNode n in checkedNodes)
            {
                CheckedFiles.Add(n.Text);
            }

			if (Utils.Initialize(oPath.TargetFolder) == (int)SystemLogStatusCode.Success)
			{
				foreach (string file in CheckedFiles)
				{
                    if(isFunction(file))
                    {
                        // code analysis
                        CodeParser parser = new CodeParser();
                        status = parser.ParseFile(Path.Combine(oPath.TargetFolder, file), CheckedFiles);
                        if (status != (int)SystemLogStatusCode.Success)
                        {
                            targetFile = file;
                            break;
                        }
                    }
				}
			}
                
            // overwrite all processed files into original folder 
            DialogResult dialogResult = MessageBox.Show("Overwrite the original files ?", "Add GlobeSystemLog Trace",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                if ((Utils.replaceTargetFiles(oPath.TargetFolder)) == (int)SystemLogStatusCode.Success)
                    ProcessResult.Text = "Sucessful!!";
                else
                    ProcessResult.Text = string.Format("Failed on generate Debug Trace Message --> {0}", targetFile);
            }
		}

        private void btnLogFile_Click(object sender, EventArgs e)
        {
            txtFilename.Text = "";
            this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialog.ShowNewFolderButton = false;
            DialogResult result = this.folderBrowserDialog.ShowDialog();
            txtFilename.Text = string.Format("{0}\\{1}", this.folderBrowserDialog.SelectedPath, Path.GetFileName(oPath.LogFilename));
        }

        private bool SaveSettings()
        {
            bool status = false;
            string logFilePath = Path.GetDirectoryName(txtFilename.Text);

            if (String.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Target Folder field cannot be empty");
            }
            else if (String.IsNullOrEmpty(txtFilename.Text))
            {
                MessageBox.Show("Filename field cannot be empty");
            }
            else if (Directory.Exists(txtName.Text) == false || Directory.Exists(logFilePath) == false)
            {
                MessageBox.Show("Invalid path");
            }
            else
            {
                // Save target foler & filename in json file
                oPath.TargetFolder = txtName.Text;
                oPath.LogFilename = txtFilename.Text;
                oSettings.WriteJsonFile();
                status = true;
            }

            return status;
        }

        private void GetTreeView(string folderPath)
        {

            this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialog.ShowNewFolderButton = false;

            TreeNodeCollection nodes = this.treeView1.Nodes;
            foreach (TreeNode tn in nodes)
            {
                // Clear child nodes
                tn.Nodes.Clear();
            }

            // Clear Root Nodes before creating new Root Nodes
            this.treeView1.Nodes.Clear();
            this.treeView1.Refresh();

            // print the folder name on a label
            this.txtName.Text = folderPath;

            // iterate over all files in the selected folder and add them to 
            // the treeview.
            RootNode.Name = Path.GetFileName(folderPath);
            RootNode.Text = Path.GetFileName(folderPath);
            this.treeView1.Nodes.Add(RootNode);
            this.treeView1.SelectedNode = RootNode;

            //string[] fileExts = { "*.frm", "*.bas", "*.cls", "*.ctl" };
            string[] fileExts = { "*.frm", "*.cls" };
            foreach (string ext in fileExts)
            {
                string[] files = Directory.GetFiles(folderPath, ext);
                foreach (string fileName in files)
                {
                    TreeNode nod = new TreeNode();
                    nod.Name = Path.GetFileName(fileName);
                    nod.Text = Path.GetFileName(fileName);
                    nod.Tag = Path.GetFileName(fileName);

                    this.treeView1.SelectedNode.Nodes.Add(nod);

                    //Display all functions available in the file
                    searchListOfFunctions(nod, fileName);

                    //Set selected node back to the root node
                    treeView1.SelectedNode = RootNode;

                }
            }

            //this.treeView1.SelectedNode.ExpandAll();
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbOutputLog_CheckedChanged(object sender, EventArgs e)
        {
            oPath.EnableOutputLog = cbOutputLog.Checked;
        }

        private void cbOutputDebugView_CheckedChanged(object sender, EventArgs e)
        {
            oPath.EnableOutputDebugView = cbOutputDebugView.Checked;
        }
    }
}
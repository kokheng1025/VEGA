using GlobeSystemLog;
using migrationTools.Components;
using System;
using System.Collections;
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

                    ////If function is checked
                    //if (checkFileOrFunction == 2 && parentFileFound == false)
                    //{
                    //    //Check if parent file has been included into the checked List
                    //    foreach (TreeNode n in checkedNodes)
                    //    {
                    //        //Add parent file into the checked List
                    //        if (tn.Parent.Text.Equals(n.Text)) parentFileFound = true;
                    //    }

                    //    //Add parent of node(file) into the checked list
                    //    if (parentFileFound == false) checkedNodes.Add(tn.Parent);

                    //}
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

		private ArrayList searchListOfFunctions(string fileName)
		{
			ArrayList nodeArrayList = new ArrayList();

			// open file
			StreamReader Reader = new StreamReader(fileName, Encoding.ASCII, false, 65536);

			string line = String.Empty;
			string nextWord = String.Empty;
			string endProduceName = String.Empty;

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
						if (!cbFormFunction.Checked && (startProduceName.IndexOf("Form") != -1) ||
							!cbClassFunction.Checked && (startProduceName.IndexOf("Class") != -1))
							continue;

						//Add function in treeView					
						TreeNode newNode = new TreeNode();
						newNode.Name = startProduceName;
						newNode.Text = startProduceName;
						newNode.Tag = startProduceName;
						nodeArrayList.Add(newNode);
					}
				}
			}
			catch (Exception f)
			{
				Debug.WriteLine("error {0}", f.Message);
			}

			// close stream before exit
			Reader.Close();

			IComparer myComparer = new nodeObjectArrayList();
			nodeArrayList.Sort(myComparer);

			return nodeArrayList;
		}

		private int numOfFile(string folderPath)
		{
			int numOfFiles = 0;

			// iterate over all files in the subfolder and add them into treeNodesArrayforFiles
			foreach (string ext in oSettings.FileExtensionList)
			{
				try
				{
					numOfFiles += Directory.GetFiles(folderPath, ext).Length;
				}
				catch (UnauthorizedAccessException) { }
			}

			return numOfFiles;
		}
		private void GetSingleFolderTreeView(string folderPath)
		{
			int idx = 0;
			int fileCount = numOfFile(folderPath);
			TreeNode[] treeNodesArrayforFiles = new TreeNode[fileCount];

			foreach (string ext in oSettings.FileExtensionList)
			{
				string[] files = Directory.GetFiles(folderPath, ext);
				foreach (string fileName in files)
				{
					string eachfileName = Path.GetFileName(fileName);
					ArrayList list = searchListOfFunctions(fileName);
					TreeNode[] treeNodesArrayForFunction = new TreeNode[list.Count];
					int listIdx = 0;
					foreach (object obj in list)
					{
						treeNodesArrayForFunction[listIdx] = (TreeNode)obj;
						listIdx++;
					}
					treeNodesArrayforFiles[idx] = new TreeNode(eachfileName, treeNodesArrayForFunction);
					idx++;
				}
			}

			TreeNode finalNode = new TreeNode(Path.GetFileName(folderPath), treeNodesArrayforFiles);
			this.treeView1.Nodes.Add(finalNode);
			this.treeView1.SelectedNode = finalNode;
			this.treeView1.SelectedNode.ExpandAll();
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
			
			int directoryCount = Directory.GetDirectories(folderPath).Length;

			
			if (directoryCount == 0) // No Sub directory
			{				
				GetSingleFolderTreeView(folderPath);
				return;
			}
			else if (directoryCount == 1) // if only temp folder
			{
				DirectoryInfo subfolder = new DirectoryInfo(Directory.GetDirectories(folderPath)[0]);
				if (subfolder.Name == "temp")
				{
					GetSingleFolderTreeView(folderPath);
					return;
				}
			}

			// list all sub directory and save into treeNodesArray
			TreeNode[] treeNodesArray = new TreeNode[directoryCount];

			int i = 0;
			int totalFileCount = 0; 

			foreach (string strDir in Directory.GetDirectories(folderPath))
			{
				DirectoryInfo subfolder = new DirectoryInfo(strDir);

				int idx = 0;
				int fileCount = numOfFile(strDir);

				TreeNode[] treeNodesArrayforFiles; 
				// skip if file count = 0 or temp folder
				if (fileCount == 0 || subfolder.Name == "temp")
				{
					treeNodesArrayforFiles = new TreeNode[1];
					string emptyFolderName = Path.GetFileName(strDir);
					treeNodesArray[i] = new TreeNode(emptyFolderName);
					i++;
					continue;
				}
				else
				{
					totalFileCount += fileCount;
				}

				treeNodesArrayforFiles = new TreeNode[fileCount];

				foreach (string ext in oSettings.FileExtensionList)
				{
					string[] files = Directory.GetFiles(strDir, ext);
					foreach (string fileName in files)
					{
						string eachfileName = Path.GetFileName(fileName);
						ArrayList list = searchListOfFunctions(fileName);
						TreeNode[] treeNodesArrayForFunction = new TreeNode[list.Count];
						int listIdx = 0;
						foreach(object obj in list)
						{
							treeNodesArrayForFunction[listIdx] = (TreeNode)obj;
							listIdx++;
						}
						treeNodesArrayforFiles[idx] = new TreeNode(eachfileName, treeNodesArrayForFunction);
						idx++;
					}
				}
				
				treeNodesArray[i] = new TreeNode(subfolder.Name, treeNodesArrayforFiles);
				i++;
			}

			if (totalFileCount > 0)
			{				
				TreeNode finalNode = new TreeNode(Path.GetFileName(folderPath), treeNodesArray);
				this.treeView1.Nodes.Add(finalNode);
				this.treeView1.SelectedNode = finalNode;
				this.treeView1.SelectedNode.ExpandAll();
			}
		}

		private void executeButton_Click(object sender, EventArgs e)
		{
			if (SaveSettings() == false)
				return;

			// Create GLBSysLog.bas file
			oSettings.WriteVBLoggerFile();

			int status = (int)SystemLogStatusCode.Success;
			string targetFile = String.Empty;

			CheckedFiles.Clear();
			List<TreeNode> checkedNodes = CheckedNodes();
			List<string> targetFolderDir = new List<string>();
			foreach (TreeNode n in checkedNodes)
			{
				//CheckedFiles.Add(n.Text);
				String[] pathSeparators = new String[] { "\\" };
				String[] pathSplitter = n.FullPath.Split(pathSeparators, StringSplitOptions.RemoveEmptyEntries);

				// error
				if (pathSplitter.Length > 4)
				{
					MessageBox.Show("Unable to open target folder!!");
					return;
				}

				int targetFolderLevel = pathSplitter.Length == 3 ? 0 : 1;
				if (!targetFolderDir.Contains(pathSplitter[targetFolderLevel]))
				{
					targetFolderDir.Add(pathSplitter[targetFolderLevel]);
				}
			}

			foreach (string dir in targetFolderDir)
			{
				bool initFolder = true;
				foreach(TreeNode n in checkedNodes)
				{
					String[] pathSeparators = new String[] { "\\" };
					String[] pathSplitter = n.FullPath.Split(pathSeparators, StringSplitOptions.RemoveEmptyEntries);

					//string parentFolder = n.Parent.FullPath;
					int targetFolderLevel = pathSplitter.Length == 3 ? 0 : 1;
					if (dir == pathSplitter[targetFolderLevel])
					{
						string targetfolderPath;
						if (targetFolderLevel == 1)
							targetfolderPath = Path.Combine(oPath.TargetFolder, pathSplitter[1]);
						else
							targetfolderPath = oPath.TargetFolder;

						if (Utils.Initialize(targetfolderPath, initFolder) == (int)SystemLogStatusCode.Success)
						{
							//foreach (string file in CheckedFiles)
							//{
							//	if (isFunction(file))
							//	{
							//		// code analysis
							//		CodeParser parser = new CodeParser();
							//		status = parser.ParseFile(Path.Combine(oPath.TargetFolder, file), CheckedFiles);
							//		if (status != (int)SystemLogStatusCode.Success)
							//		{
							//			targetFile = file;
							//			break;
							//		}
							//	}
							//}
						}

						initFolder = false;
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

		private void btnOpenFolder_Click(object sender, EventArgs e)
		{
			DialogResult result = this.folderBrowserDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				//oPath.TargetFolder = this.folderBrowserDialog.SelectedPath;

				txtName.Text = this.folderBrowserDialog.SelectedPath;

				SaveSettings();
				GetTreeView(this.folderBrowserDialog.SelectedPath);
			}
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

		private void revertAllButton_Click(object sender, EventArgs e)
		{
			if (!Directory.Exists(oPath.TargetFolder))
			{
				MessageBox.Show("Target Folder field cannot be empty");
				return;
			}
			
			string tempFolder = Path.Combine(oPath.TargetFolder, "temp");
			if (Directory.Exists(tempFolder))
			{
				foreach (string ext in oSettings.FileExtensionList)
				{
					string[] files = Directory.GetFiles(tempFolder, ext + "__");
					foreach (string fileName in files)
					{
						File.Delete(fileName);
					}
				}

				foreach (string ext in oSettings.FileExtensionList)
				{
					string[] files = Directory.GetFiles(tempFolder, ext);
					foreach (string fileName in files)
					{
						string eachfileName = Path.GetFileName(fileName);
						File.Copy(fileName, Path.Combine(oPath.TargetFolder, eachfileName), true);
					}
				}
			}

		}
		private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
		{

		}

		private void cbFormFunctions(object sender, EventArgs e)
		{
			GetTreeView(oPath.TargetFolder);
		}

		private void cbClassFunction_Click(object sender, EventArgs e)
		{
			GetTreeView(oPath.TargetFolder);
		}
	}
}
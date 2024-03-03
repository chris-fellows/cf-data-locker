using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using CFDataLocker.Controls;
using CFDataLocker.Interfaces;
using CFDataLocker.Models;
using CFDataLocker.Services;
using CFUtilities;

namespace CFDataLocker.Forms
{
    /// <summary>
    /// Main form
    /// </summary>
    public partial class MainForm : Form
    {
        private enum NodeTypes : byte
        {
            Group = 0,
            DataItem = 1
        }

        private IDataLockerService _dataLockerService = null;
        private DataLocker _dataLocker = null;
        private TreeNode _currentSelected = null;

        public MainForm()
        {
            InitializeComponent();

            // Set lock file
            var lockerFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "My Data Locker.locker");
            _dataLockerService = new DataLockerLocalFileService(lockerFile);

            // If lock file doesn't exist then create file with single default group
            if (!File.Exists(lockerFile))
            {
                var key = _dataLockerService.CreateRandomKey();
                CreateEmptyLocker(lockerFile, key);
                txtKey.Text = key;

                MessageBox.Show($"A new locker key has been created and copied to the clipboard.\nPlease save the key.", "New Key");
                Clipboard.SetText(key);
            }
            
            ShowLocked();                      
        }

        /// <summary>
        /// Creates empty locker
        /// </summary>
        /// <param name="lockFile"></param>
        /// <param name="key"></param>
        private void CreateEmptyLocker(string lockerFile, string key)
        {            
            DataLocker dataLocker = new DataLocker();
            var group = new Group()
            {
                ID = Guid.NewGuid().ToString(),
                Description = "Default"
            };
            dataLocker.Name = Path.GetFileNameWithoutExtension(lockerFile);
            dataLocker.Groups = new List<Group>() { group };

            //var dataItem = new DataItem()
            //{   
            //    ID = Guid.NewGuid().ToString(),
            //    Contact = new Contact(),
            //    Credentials = new Credentials(),
            //    Description = "[New]",
            //    Active = true,
            //    Notes = "Notes",                
            //};
            dataLocker.DataItems = new List<DataItem>();

            //var lockService = new DataLockerLocalFileService(lockFile);
            _dataLockerService.Lock(dataLocker, key);          
        }

        private static NodeTypes GetNodeType(TreeNode node)
        {
            if (node.Name.StartsWith("Group."))
            {
                return NodeTypes.Group;
            }
            else if (node.Name.StartsWith("DataItem."))
            {
                return NodeTypes.DataItem;
            }
            throw new ArgumentException("Invalid node type");
        }

        /// <summary>
        /// Converts Document model to view
        /// </summary>
        /// <param name="document"></param>
        private void ModelToView(DataLocker document)
        {
            tvwData.Nodes.Clear();
            foreach (Group group in document.Groups)
            {
                TreeNode nodeGroup = tvwData.Nodes.Add(string.Format("Group.{0}", group.ID), group.Description);
                nodeGroup.Tag = group;
                foreach (DataItem dataItem in document.DataItems.FindAll(item => item.GroupID.Equals(group.ID, StringComparison.InvariantCultureIgnoreCase)))
                {
                    TreeNode nodeDataItem = nodeGroup.Nodes.Add(string.Format("DataItem.{0}", dataItem.ID), dataItem.Description);
                    nodeDataItem.Tag = dataItem;
                }
                nodeGroup.Expand();    // Show expanded
            }
        }

        private void ViewToModel(DataLocker document)
        {        
            // Clear existing groups & data items
            document.Groups.Clear();
            document.DataItems.Clear();

            // Add groups and data items
            foreach (TreeNode nodeGroup in tvwData.Nodes)
            {
                Group group = (Group)nodeGroup.Tag;
                document.Groups.Add(group);
                foreach (TreeNode nodeDataItem in nodeGroup.Nodes)
                {
                    DataItem dataItem = (DataItem)nodeDataItem.Tag;
                    document.DataItems.Add(dataItem);
                }
            }
            document.Groups.Sort((x, y) => x.Description.CompareTo(y.Description));
            document.DataItems.Sort((x, y) => x.Description.CompareTo(y.Description));
        }
        
        /// <summary>
        /// Unlocks the document
        /// </summary>
        private void Unlock()
        {
            if (!String.IsNullOrEmpty(txtKey.Text))
            {
                _dataLocker = _dataLockerService.Unlock(txtKey.Text);
                if (_dataLocker == null)   // Failed to unlock
                {
                    ShowLocked();
                    MessageBox.Show("Key is invalid", "Unlock");
                }
                else     // Unlocked
                {
                    ShowUnlocked();
                    ModelToView(_dataLocker);                    
                }
            }
        }

        /// <summary>
        /// Show UI state as locker locked
        /// </summary>
        private void ShowLocked()
        {
            this.Text = "Data Locker";

            _currentSelected = null;
            tvwData.Nodes.Clear();
            groupUserControl1.Visible = false;
            dataItemUserControl1.Visible = false;
            tsbLock.Text = "Unlock";
            txtKey.Enabled = true;  // Allow change key          
            tsbImportDataItems.Visible = false;
            tsbExportDataItems.Visible = false;
        }

        /// <summary>
        /// Show UI state as locked unlocked
        /// </summary>
        private void ShowUnlocked()
        {
            this.Text = $"Data Locker - [{_dataLocker.Name}]";

            _currentSelected = null;
            txtKey.Enabled = false;  // Prevent change key
            tsbLock.Text = "Lock";
            tsbImportDataItems.Visible = true;
            tsbExportDataItems.Visible = true;
        }

        /// <summary>
        /// Applies changes from currently selected item
        /// </summary>
        /// <param name="e"></param>
        /// <returns>Whether changes applies (False: Validation error)</returns>
        private bool ApplyCurrentChanges(TreeViewCancelEventArgs e = null)
        {
            NodeTypes nodeType = GetNodeType(_currentSelected);
            switch (nodeType)
            {
                case NodeTypes.Group:
                    {
                        // Validate before apply changes
                        var messages = groupUserControl1.ValidateBeforeApplyChanges();
                        if (messages.Any())    // Display validation error and abort
                        {
                            MessageBox.Show(messages[0].Text, "Error");
                            if (e != null) e.Cancel = true; 
                            return false;
                        }
                        else
                        {
                            groupUserControl1.ApplyChanges();
                            _currentSelected.Text = groupUserControl1.Group.Description;
                        }
                    }
                    break;
                case NodeTypes.DataItem:
                    {
                        // Validate before apply changes
                        var messages = dataItemUserControl1.ValidateBeforeApplyChanges();
                        if (messages.Any()) // Display validation error and abort
                        {
                            MessageBox.Show(messages[0].Text, "Error");
                            if (e != null) e.Cancel = true;
                            return false;
                        }
                        else
                        {
                            dataItemUserControl1.ApplyChanges();
                            _currentSelected.Text = dataItemUserControl1.DataItem.Description;
                        }
                    }
                    break;
            }

            return true;
        }

        /// <summary>
        /// Locks the document. Fails if there are invalid current changes.
        /// </summary>
        private void Lock()
        {
            // Apply changes to currently selected node if any. Abort if validation error
            if (_currentSelected != null)
            {
                if (!ApplyCurrentChanges()) return;
            }

            ViewToModel(_dataLocker);            
            _dataLockerService.Lock(_dataLocker, txtKey.Text);
            ShowLocked();
        }

        private void tvwData_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _currentSelected = e.Node;
            NodeTypes nodeType = GetNodeType(e.Node);
            switch (nodeType)
            {
                case NodeTypes.Group:
                    Group group = (Group)e.Node.Tag;
                    groupUserControl1.Group = group;
                    groupUserControl1.Visible = true;
                    dataItemUserControl1.Visible = false;
                    break;
                case NodeTypes.DataItem:
                    groupUserControl1.Visible = false;
                    DataItem dataItem = (DataItem)e.Node.Tag;
                    dataItemUserControl1.Visible = true;
                    dataItemUserControl1.DataItem = dataItem;
                    break;
            }
        }

        private void tvwData_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {            
            // Apply changes to currently selected node if any. Will fail if validation issues that need to be
            // resolved.
            if (_currentSelected != null)
            {
                if (ApplyCurrentChanges(e))     // Changes applied
                {
                    _currentSelected = null;
                }
            }
        }

        private void tsbLock_Click(object sender, EventArgs e)
        {
            switch (tsbLock.Text)
            {
                case "Lock":
                    Lock();
                    break;
                case "Unlock":
                    Unlock();
                    break;
            }
        }
        private TreeNode AddGroup(Group group)
        {
                
            TreeNode nodeGroup = tvwData.Nodes.Add(string.Format("Group.{0}", group.ID), group.Description);
            nodeGroup.Tag = group;

            tvwData.SelectedNode = nodeGroup;
            return nodeGroup;
        }

        private void tsbAddGroup_Click(object sender, EventArgs e)
        {
            Group group = new Group()
            {
                ID = Guid.NewGuid().ToString(),
                Description = "[New]"
            };
            AddGroup(group); 
        }

        private void AddDataItem(TreeNode nodeGroup, DataItem dataItem)
        {
            Group group = (Group)nodeGroup.Tag;           

            TreeNode nodeDataItem = nodeGroup.Nodes.Add(string.Format("DataItem.{0}", dataItem.ID), dataItem.Description);
            nodeDataItem.Tag = dataItem;
            tvwData.SelectedNode = nodeDataItem;
        }

        private void tvwData_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right && tvwData.SelectedNode != null)
            {
                // Only display context menu if they right-clicked on selected node, not anywhere on control
                if (tvwData.GetNodeAt(e.X, e.Y) == tvwData.SelectedNode)
                {   
                    PrepareContextMenu();
                    cmsMenu.Show(tvwData, e.Location);
                }
            }
        }

        private void PrepareContextMenu()
        {
            NodeTypes nodeType = GetNodeType(tvwData.SelectedNode);
            bool isGroup = nodeType == NodeTypes.Group;
            bool isDataItem = nodeType == NodeTypes.DataItem;
            addDataItemToolStripMenuItem.Visible = isGroup;
            deleteDataItemToolStripMenuItem.Visible = isDataItem;
            deleteGroupToolStripMenuItem.Visible = isGroup;
        }

        private void addDataItemToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            if (GetNodeType(tvwData.SelectedNode) == NodeTypes.Group)       
            {
                Group group = (Group)tvwData.SelectedNode.Tag;

                DataItem dataItem = new DataItem()
                {
                    ID = Guid.NewGuid().ToString(),
                    Description = "[New]",
                    GroupID = group.ID,
                    Credentials = new Credentials(),
                    Contact = new Contact(),
                    Active = true
                };
                AddDataItem(tvwData.SelectedNode, dataItem);
            }
        }

        private void deleteDataItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GetNodeType(tvwData.SelectedNode) == NodeTypes.DataItem)
            {
                if (MessageBox.Show(string.Format("Delete {0}?", tvwData.SelectedNode.Text), "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DeleteDataItem(tvwData.SelectedNode);
                }
            }
        }

        private void DeleteDataItem(TreeNode node)
        {
            DataItem dataItem = (DataItem)node.Tag;
            tvwData.Nodes.Remove(node);
        }

        private void DeleteGroup(TreeNode node)
        {
            Group group = (Group)node.Tag;
            tvwData.Nodes.Remove(node);
        }

        private void deleteGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GetNodeType(tvwData.SelectedNode) == NodeTypes.Group)
            {
                if (MessageBox.Show(string.Format("Delete {0}?", tvwData.SelectedNode.Text), "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DeleteGroup(tvwData.SelectedNode);
                }
            }
        }

        private void tsbImportDataItems_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog()
            {
                Title = "Select input file",
                CheckFileExists = true
            };
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (MessageBox.Show("Do you want to import this file and replace all data?", "Import", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        var importer = new DataLockerImporterCSV(fileDialog.FileName);
                        importer.Import(_dataLocker);

                        // Display
                        ShowUnlocked();
                        ModelToView(_dataLocker);

                        MessageBox.Show("File has been imported", "Import");
                    }
                    catch(Exception exception)
                    {
                        MessageBox.Show($"There was an error importing the file:\n{exception.Message}", "Error", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void tsbExportDataItems_Click(object sender, EventArgs e)
        {
            if (_dataLocker != null)
            {
                // Export data locker
                var file = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"{_dataLocker.Name}.txt");
                var exporter = new DataLockerExporterCSV('\t', file, System.Text.Encoding.UTF8);
                exporter.Export(_dataLocker);

                // Open folder where file exported to
                IOUtilities.OpenDirectoryWithExplorer(Path.GetDirectoryName(file));
                //IOUtilities.OpenFileWithDefaultTextEditor(file);
            }
        }
    }
}

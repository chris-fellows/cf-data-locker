using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CFDataLocker.Model;

namespace CFDataLocker
{
    public partial class MainForm : Form
    {
        private enum NodeTypes : byte
        {
            Group = 0,
            DataItem = 1
        }

        private Locker _locker = null;
        private TreeNode _currentSelected = null;

        public MainForm()
        {
            InitializeComponent();
          
            _locker = new Locker(Path.Combine(Environment.CurrentDirectory, "Data.bin"));
            ShowLocked();

            txtKey.Text = "Q(S;3CMpe";

            //CreateEmptyDocument("Q(S;3CMpe");
        }

        private Document CreateEmptyDocument(string csvFile, string key)
        {     
            Document document = new Document();
            Group group = new Group()
            {
                ID = Guid.NewGuid().ToString(),
                Description = "Default"
            };
            document.Groups.Add(group);

            if (!String.IsNullOrEmpty(csvFile))
            {
                using (StreamReader reader = new StreamReader(csvFile, true))
                {
                    while (!reader.EndOfStream)
                    {
                        string[] values = reader.ReadLine().Split((Char)9);
                        DataItem dataItem = new DataItem()
                        {
                            ID = Guid.NewGuid().ToString(),
                            GroupID = group.ID,
                            Credentials = new Credentials()
                            {
                                UserName = values[0].Trim(),
                                Password = values[1].Trim()
                            },
                            Contact = new Contact(),                            
                            Description = values[2].Trim(), 
                            Active = true
                        };
                        document.DataItems.Add(dataItem);
                    }
                }
            }

            _locker.Lock(document, key);
            return document;
        }

        /// <summary>
        /// Returns node type
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private NodeTypes GetNodeType(TreeNode node)
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
        private void ModelToView(Document document)
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

        private void ViewToModel(Document document)
        {        
            document.Groups.Clear();
            document.DataItems.Clear();

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
            document.DataItems.Sort((x, y) => x.Description.CompareTo(y.Description));
        }
        
        /// <summary>
        /// Unlocks the document
        /// </summary>
        private void Unlock()
        {
            if (!String.IsNullOrEmpty(txtKey.Text))
            {
                Document document = _locker.Unlock(txtKey.Text);
                if (document == null)   // Failed to unlock
                {
                    ShowLocked();
                    MessageBox.Show("Key is invalid", "Unlock");
                }
                else     // Unlocked
                {
                    ShowUnlocked();
                    ModelToView(document);                    
                }
            }
        }

        private void ShowLocked()
        {
            tvwData.Nodes.Clear();
            groupUserControl1.Visible = false;
            dataItemUserControl1.Visible = false;
            tsbLock.Text = "Unlock";
            txtKey.Text = "";
            tsbImportDataItems.Visible = false;
        }

        private void ShowUnlocked()
        {
            tsbLock.Text = "Lock";
            tsbImportDataItems.Visible = true;            
        }

        /// <summary>
        ///  Locks the document
        /// </summary>
        private void Lock()
        {
            Document document = new Document();
            ViewToModel(document);            
            _locker.Lock(document, txtKey.Text);
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
            if (_currentSelected != null)
            {
                NodeTypes nodeType = GetNodeType(_currentSelected);
                switch(nodeType)
                {
                    case NodeTypes.Group:
                        groupUserControl1.ApplyChanges();
                        _currentSelected.Text = groupUserControl1.Group.Description;
                        break;
                    case NodeTypes.DataItem:
                        dataItemUserControl1.ApplyChanges();
                        _currentSelected.Text = dataItemUserControl1.DataItem.Description;
                        break;
                }
                _currentSelected = null;
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
                if (MessageBox.Show("Do you want to import this file?", "Import", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ImportDataItems(fileDialog.FileName);

                    MessageBox.Show("File has been imported", "Import");
                }
            }
        }

        /// <summary>
        /// Imports data items from file
        /// </summary>
        /// <param name="inputFile"></param>
        private void ImportDataItems(string inputFile)
        {
            // Read CSV file
            var csvFile = new CFUtilities.CSV.CSVFile();
            var csvSettings = new CFUtilities.CSV.CSVSettings(inputFile, (Char)9, false, false);
            var dataTable = csvFile.Read(csvSettings, null);

            // Clear existing data
            tvwData.Nodes.Clear();

            // Create list of groups
            List<string> groupNames = CFUtilities.DataTableUtilities.GetDistinctValues<string>(dataTable, "Group");
            Dictionary<string, TreeNode> nodeGroups = new Dictionary<string, TreeNode>();

            foreach (string groupName in groupNames)
            {
                Group group = new Group()
                {
                    ID = Guid.NewGuid().ToString(),
                    Description = groupName
                };
                TreeNode nodeGroup = AddGroup(group);
                nodeGroups.Add(groupName, nodeGroup);
            }
             
            // Create data items
            for (int rowIndex = 0; rowIndex < dataTable.Rows.Count; rowIndex++)
            {
                // Get group
                TreeNode nodeGroup = nodeGroups[dataTable.Rows[rowIndex]["Group"].ToString()];
                Group group = (Group)nodeGroup.Tag;

                // Add data item
                DataItem dataItem = new DataItem()
                {
                    Description = dataTable.Rows[rowIndex]["Description"].ToString(),
                    GroupID = group.ID,
                    ID = Guid.NewGuid().ToString(),
                    Notes = dataTable.Rows[rowIndex]["Notes"].ToString(),
                    URL = dataTable.Rows[rowIndex]["URL"].ToString(),
                    AccountNumber = dataTable.Rows[rowIndex]["AccountNumber"].ToString(),
                    Credentials = new Credentials()
                    {
                        Password = dataTable.Rows[rowIndex]["Password"].ToString(),
                        UserName = dataTable.Rows[rowIndex]["UserName"].ToString()
                    },                    
                    Contact = new Contact()
                    {
                        Name = dataTable.Rows[rowIndex]["ContactName"].ToString(),
                        EmailAddress = dataTable.Rows[rowIndex]["ContactEmail"].ToString(),
                        Telephone = dataTable.Rows[rowIndex]["ContactTelephone"].ToString()
                    },
                    Active = true
                };

                AddDataItem(nodeGroup, dataItem);
            }
        }
    }
}

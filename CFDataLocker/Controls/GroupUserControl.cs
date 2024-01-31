using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CFDataLocker.Model;

namespace CFDataLocker
{
    public partial class GroupUserControl : UserControl
    {
        private Group _group;

        public GroupUserControl()
        {
            InitializeComponent();
        }

        public Group Group
        {
            get { return _group; }
            set
            {
                _group = value;
                if (_group != null)
                {
                    ModelToView(_group);
                }
            }
        }

        public void ApplyChanges()
        {
            ViewToModel(_group);
        }

        private void ModelToView(Group group)
        {
            txtDescription.Text = group.Description;
        }

        private void ViewToModel(Group group)
        {
            group.Description = txtDescription.Text;
        }
        
    }
}

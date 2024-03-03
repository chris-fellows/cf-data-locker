using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CFDataLocker.Models;

namespace CFDataLocker.Controls
{
    /// <summary>
    /// Control for viewing or changing Group
    /// </summary>
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
            if (ValidateBeforeApplyChanges().Any())
            {
                throw new ApplicationException("Cannot apply changes if there are validation errors");
            }

            ViewToModel(_group);
        }

        public List<PropertyMessage> ValidateBeforeApplyChanges()
        {
            var messages = new List<PropertyMessage>();

            var group = new Group();
            ViewToModel(group);
            if (String.IsNullOrEmpty(group.Description))
            {
                messages.Add(new PropertyMessage(nameof(group.Description), "Description is invalid or not set"));
            }

            return messages;
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

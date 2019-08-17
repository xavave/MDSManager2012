// Type: MDSManageEntities.ucManageMembers
// Assembly: MDSManager, Version=1.0.7.2, Culture=neutral, PublicKeyToken=null
// Assembly location: C:\Users\Xavier\Documents\Visual Studio 2010\Projects\MDSManager\MDSManager.exe

using Common;
using Common.MDSService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common.Model;


namespace MDSManager2012.Desktop
{
    public class ucManageMembers : UserControl
    {
        private IContainer components = (IContainer)null;
        public ListBox lstAttributes;
        private GroupBox gbMemberNameCode;
        private RadioButton rbCodeName;
        private RadioButton rbNameCode;
        private GroupBox groupBox1;
        private RadioButton rbTypeName;
        private RadioButton rbNameType;
        private ToolTip toolTip1;
        private Button btnSearchMembersOK;
        private GroupBox gbMembersFiltering;
        private Button btResetFilter;
        public TextBox txtMemberFilter;
        public RadioButton rbSearchByName;
        public RadioButton rbSearchByCode;
        private Label lblSearchTerm;
        public TextBox txSearchTerm;
        private Label label3;
        private Label label4;
        public TextBox txSimLevel;
        public CheckedListBox lstMembers;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem tsmiDeleteCheckedMembers;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem tsmiCheckAll;
        private ToolStripMenuItem tsmiUncheckAll;
        private Button btCopyAttributesListClipboard;
        private Button btCopyMembersListClipboard;
        private CheckBox ckInvertCheckedMbrs;

        public ucManageMembers()
        {
            this.InitializeComponent();
            lstAttributes.AutoSize = true;
            lstMembers.AutoSize = true;
        }

        public void DisplayMembers(Identifier modelId, CustomVersion versionId, CustomEntity entity, string searchTerm)
        {
            try
            {
                if (modelId == null || versionId == null || entity == null)
                    return;
                List<Member> members = MDSWrapper.GetMembers(modelId, versionId.Identifier, entity, searchTerm);
                this.lstMembers.Items.Clear();
                (this.FindForm() as Form1).ProgressBar.Maximum = members.Count;
                foreach (Member m in members)
                {
                    ((ListBox.ObjectCollection)this.lstMembers.Items).Add((object)new CustomMember(m));
                    (this.FindForm() as Form1).ProgressBar.PerformStep();
                }
                this.lstMembers.DisplayMember = this.rbNameCode.Checked ? "NameCode" : "CodeName";
                (this.FindForm() as Form1).ProgressBar.Value = 0;
                //this.lblCntMembers.Text = this.lstMembers.Items.Count.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void lstMembers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstMembers.SelectedItem == null)
                return;
            Form1 form1 = this.FindForm() as Form1;
            CustomMember cm = this.lstMembers.SelectedItem as CustomMember;
            form1.txtAttributeValue.Text = cm.Code;
            form1.txtAttributeName.Text = cm.Name;
            form1.txtAttributeType.Text = cm.mbr.MemberId.MemberType.ToString();
            form1.txtValidationStatus.Text = this.DisplayMemberValidationStatus(cm);
            this.DisplayAttributes();
        }

        public void DisplayAttributes()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                OperationResult or = new OperationResult();
                Form1 form1 = this.FindForm() as Form1;
                CustomEntity customEntity = ((ucManageEntities)form1.FilterControlsOne(c => c is ucManageEntities)).lstEntities.SelectedItem as CustomEntity;
                if (customEntity == null || customEntity.entityId == null)
                    return;

                Metadata metaData = MDSWrapper.GetMetaData(new International(), ref or, (Identifier)form1.lstModels.SelectedItem, ((CustomVersion)form1.lstVersions.SelectedItem).Identifier, (Identifier)customEntity.entityId, MDAction.AttributesOnly);
                object selectedItem = this.lstAttributes.SelectedItem;
                int selectedIndex = this.lstAttributes.SelectedIndex;
                this.lstAttributes.Items.Clear();
                form1.ProgressBar.Maximum = metaData.Attributes.Count;
                foreach (MetadataAttribute attribute in metaData.Attributes)
                {
                    this.lstAttributes.Items.Add((object)new CustomMetaDataAttribute(attribute));
                    form1.ProgressBar.PerformStep();
                }
                form1.ProgressBar.Value = 0;
                this.lstAttributes.DisplayMember = this.rbNameType.Checked ? "NameType" : "TypeName";
                //this.lstAttributes.Items.Count.ToString();
                if (this.IsAttributeExists(selectedItem as CustomMetaDataAttribute, this.lstAttributes.Items))
                    this.lstAttributes.SelectedIndex = selectedIndex;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private bool IsAttributeExists(CustomMetaDataAttribute currentAttribute, ListBox.ObjectCollection attributeListToCheck)
        {
            if (currentAttribute != null && attributeListToCheck.Count > 0)
            {
                foreach (object obj in attributeListToCheck)
                {
                    if (obj != null && (obj as CustomMetaDataAttribute).Name == currentAttribute.Name)
                        return true;
                }
            }
            return false;
        }

        private void rbNameCode_CheckedChanged(object sender, EventArgs e)
        {
            this.RefreshMembersAttributes();
        }

        private void RefreshMembersAttributes()
        {
            try
            {
                Form1 form1 = this.FindForm() as Form1;
                ucManageEntities ucManageEntities = form1.FilterControlsOne(c => c is ucManageEntities) as ucManageEntities;
                if (ucManageEntities == null || (form1.lstModels.SelectedItem == null || form1.lstVersions.SelectedItem == null || ucManageEntities.lstEntities.SelectedItem == null))
                    return;
                form1.RefreshLstMembersAttributes((Identifier)form1.lstModels.SelectedItem, (CustomEntity)ucManageEntities.lstEntities.SelectedItem, (CustomVersion)form1.lstVersions.SelectedItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal void CleanListBoxes()
        {
            this.lstMembers.Items.Clear();
            this.lstAttributes.Items.Clear();
        }

        private void rbNameValue_CheckedChanged(object sender, EventArgs e)
        {
            this.RefreshMembersAttributes();
        }

        private void btnSearchMembersOK_Click(object sender, EventArgs e)
        {
            string str = this.rbSearchByCode.Checked ? "[Code]" : "[Name]";
            if (!string.IsNullOrEmpty(this.txtMemberFilter.Text.Trim()))
            {
                Form1 form1 = (Form1)this.FindForm();
                if (form1 == null)
                    return;
                ucManageEntities ucManageEntities = form1.FilterControlsOne(c => c is ucManageEntities) as ucManageEntities;
                if (ucManageEntities.lstEntities.SelectedItem != null && form1.lstModels.SelectedItem != null)
                {
                    string searchTerm = string.Format(" {0} " + (!string.IsNullOrEmpty(this.txSearchTerm.Text) ? this.txSearchTerm.Text : "LIKE") + " '{1}' " + (!string.IsNullOrEmpty(this.txSimLevel.Text) ? this.txSimLevel.Text + " " : "0.5 1 0.32 "), (object)str, (object)this.txtMemberFilter.Text);
                    this.DisplayMembers((Identifier)form1.lstModels.SelectedItem, (CustomVersion)form1.lstVersions.SelectedItem, (CustomEntity)ucManageEntities.lstEntities.SelectedItem, searchTerm);
                }
            }
            else
            {
                MessageBox.Show("Filter must not be an empty value");
            }
        }

        private void btResetFilter_Click(object sender, EventArgs e)
        {
            Form1 form1 = (Form1)this.FindForm();
            if (form1 == null)
                return;
            ucManageEntities ucManageEntities = form1.FilterControlsOne(c => c is ucManageEntities) as ucManageEntities;
            if (ucManageEntities.lstEntities.SelectedItem != null && form1.lstModels.SelectedItem != null)
            {
                this.DisplayMembers((Identifier)form1.lstModels.SelectedItem, (CustomVersion)form1.lstVersions.SelectedItem, (CustomEntity)ucManageEntities.lstEntities.SelectedItem, "");
                this.txSimLevel.Text = "0.5 1 0.32";
                this.txSearchTerm.Text = "LIKE";
            }
        }

        private void lstAttributes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Form1 form1 = this.FindForm() as Form1;
                if (this.lstAttributes.SelectedItem == null)
                    return;
                CustomMetaDataAttribute cmda = (CustomMetaDataAttribute)this.lstAttributes.SelectedItem;
                form1.txtAttributeName.Text = cmda.attribute.Identifier.Name;
                form1.txtAttributeType.Text = ((object)cmda.attribute.Identifier.MemberType).ToString();
                CustomMember cm = this.lstMembers.SelectedItem as CustomMember;
                form1.txtValidationStatus.Text = this.DisplayMemberValidationStatus(cm);
                if (cm != null)
                {
                    form1.txtAttributeType.Text = cm.MemberId.MemberType.ToString();
                    if (cmda.attribute != null && (cmda.attribute.IsCode || cmda.attribute.IsName))
                    {
                        form1.txtAttributeName.Text = cm.Name;
                        form1.txtAttributeValue.Text = cm.Code;
                       
                    }
                    else
                    {
                        Common.MDSService.Attribute attribute = Enumerable.FirstOrDefault<Common.MDSService.Attribute>((IEnumerable<Common.MDSService.Attribute>)cm.mbr.Attributes, (Func<Common.MDSService.Attribute, bool>)(p => p.Identifier.Name == cmda.attribute.Identifier.Name));
                        if (attribute != null && attribute.Value != null)
                        {
                            if (attribute.Type == AttributeValueType.Domain)
                                form1.txtAttributeValue.Text = ((Identifier)attribute.Value).Name;
                            else
                                form1.txtAttributeValue.Text = attribute.Value.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private string DisplayMemberValidationStatus(CustomMember cm)
        {
            return cm == null || cm.mbr == null ? string.Empty : cm.mbr.ValidationStatus.ToString();
        }

        private void lstMembers_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;
            this.lstMembers.SelectedIndex = this.lstMembers.IndexFromPoint(new Point(e.X, e.Y));
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            this.contextMenuStrip1.Enabled = this.lstMembers.SelectedIndex > -1;
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "tsmiCheckAll":
                    for (int index = 0; index < this.lstMembers.Items.Count; ++index)
                        this.lstMembers.SetItemChecked(index, true);
                    break;
                case "tsmiUncheckAll":
                    for (int index = 0; index < this.lstMembers.Items.Count; ++index)
                        this.lstMembers.SetItemChecked(index, false);
                    break;
            }
        }

        private void tsmiDeleteCheckedMembers_Click(object sender, EventArgs e)
        {
            try
            {
                Form1 form1 = (Form1)this.FindForm();
                if (form1 == null)
                    return;
                ucManageEntities ucManageEntities = form1.FilterControlsOne(c => c is ucManageEntities) as ucManageEntities;
                if (ucManageEntities.lstEntities.SelectedItem != null && form1.lstModels.SelectedItem != null && this.lstMembers.Items.Count > 0 && MessageBox.Show("This operation is irreversible. Are you sure you want to delete all checked members from this entity ?", "Delete all checked entity members from selected entity", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    this.DeleteCheckedMembersFromSelectedEntity(form1.lstModels.SelectedItem as Identifier, (form1.lstVersions.SelectedItem as CustomVersion).Identifier, (Identifier)(ucManageEntities.lstEntities.SelectedItem as CustomEntity).entityId);
                    this.DisplayMembers((Identifier)form1.lstModels.SelectedItem, (CustomVersion)form1.lstVersions.SelectedItem, (CustomEntity)ucManageEntities.lstEntities.SelectedItem, "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DeleteCheckedMembersFromSelectedEntity(Identifier ModelId, Identifier VersionId, Identifier EntityId)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                EntityMembers Members = new EntityMembers();
                Members.ModelId = ModelId;
                Members.EntityId = EntityId;
                Members.VersionId = VersionId;
                Members.MemberType = new MemberType?(MemberType.Leaf);
                Members.Members = new List<Member>();
                foreach (object obj in this.lstMembers.CheckedItems)
                    Members.Members.Add((obj as CustomMember).mbr);
                OperationResult operationResult = new OperationResult();

                operationResult = MDSWrapper.ServiceClient.EntityMembersDelete(new International(), Members);
                StringBuilder stringBuilder = new StringBuilder();
                if (operationResult.Errors.Count <= 0)
                    return;
                foreach (Common.MDSService.Error error in operationResult.Errors)
                    stringBuilder.AppendLine(Members.Members[0].MemberId.Code + " - " + error.Code + " - " + error.Description);
                MessageBox.Show(((object)stringBuilder).ToString(), "Errors");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btCopyAttributesListClipboard_Click(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int num1 = 0;
            foreach (object obj in this.lstAttributes.Items)
            {
                stringBuilder.AppendLine((obj as CustomMetaDataAttribute).Name);
                ++num1;
            }
            if (stringBuilder.Length <= 0)
                return;
            Clipboard.SetText(((object)stringBuilder).ToString());
            MessageBox.Show(num1.ToString() + " attribute name(s) copied to clipboard!");
        }

        private void btCopyMembersListClipboard_Click(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int num1 = 0;
            foreach (object obj in (ListBox.ObjectCollection)this.lstMembers.Items)
            {
                stringBuilder.AppendFormat("{0}{1}" + Environment.NewLine, (object)(obj as CustomMember).Code, !string.IsNullOrEmpty((obj as CustomMember).Name) ? (object)(" - " + (obj as CustomMember).Name) : (object)string.Empty);
                ++num1;
            }
            if (stringBuilder.Length <= 0)
                return;
            Clipboard.SetText(((object)stringBuilder).ToString());
            MessageBox.Show(num1.ToString() + " member code(s)/name(s) copied to clipboard!");
        }

        private void ckInvertCheckedMbrs_CheckedChanged(object sender, EventArgs e)
        {
            this.InvertChecked(this.lstMembers);
        }

        private void InvertChecked(CheckedListBox lst)
        {
            for (int index = 0; index < lst.Items.Count; ++index)
                lst.SetItemChecked(index, !lst.GetItemChecked(index));
        }

        private void lstMembers_MouseMove(object sender, MouseEventArgs e)
        {
            int index = this.lstMembers.IndexFromPoint(e.Location);
            if (index <= -1 || index >= this.lstMembers.Items.Count)
                return;
            CustomMember cm = this.lstMembers.Items[index] as CustomMember;
            string toolTip = this.toolTip1.GetToolTip((Control)this.lstMembers);
            string caption = cm.CodeName + " -->" + this.DisplayMemberValidationStatus(cm) + "\r\nUpdatedDateTime=" + cm.mbr.AuditInfo.UpdatedDateTime.ToString();
            if (toolTip != caption)
                this.toolTip1.SetToolTip((Control)this.lstMembers, caption);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lstAttributes = new System.Windows.Forms.ListBox();
            this.gbMemberNameCode = new System.Windows.Forms.GroupBox();
            this.rbCodeName = new System.Windows.Forms.RadioButton();
            this.rbNameCode = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbTypeName = new System.Windows.Forms.RadioButton();
            this.rbNameType = new System.Windows.Forms.RadioButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnSearchMembersOK = new System.Windows.Forms.Button();
            this.btResetFilter = new System.Windows.Forms.Button();
            this.btCopyMembersListClipboard = new System.Windows.Forms.Button();
            this.btCopyAttributesListClipboard = new System.Windows.Forms.Button();
            this.txtMemberFilter = new System.Windows.Forms.TextBox();
            this.gbMembersFiltering = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txSimLevel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSearchTerm = new System.Windows.Forms.Label();
            this.txSearchTerm = new System.Windows.Forms.TextBox();
            this.rbSearchByName = new System.Windows.Forms.RadioButton();
            this.rbSearchByCode = new System.Windows.Forms.RadioButton();
            this.lstMembers = new System.Windows.Forms.CheckedListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiDeleteCheckedMembers = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiCheckAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUncheckAll = new System.Windows.Forms.ToolStripMenuItem();
            this.ckInvertCheckedMbrs = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbMemberNameCode.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbMembersFiltering.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstAttributes
            // 
            this.lstAttributes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAttributes.FormattingEnabled = true;
            this.lstAttributes.Location = new System.Drawing.Point(3, 67);
            this.lstAttributes.Name = "lstAttributes";
            this.lstAttributes.Size = new System.Drawing.Size(329, 329);
            this.lstAttributes.TabIndex = 6;
            this.lstAttributes.SelectedIndexChanged += new System.EventHandler(this.lstAttributes_SelectedIndexChanged);
            // 
            // gbMemberNameCode
            // 
            this.gbMemberNameCode.Controls.Add(this.rbCodeName);
            this.gbMemberNameCode.Controls.Add(this.rbNameCode);
            this.gbMemberNameCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMemberNameCode.Location = new System.Drawing.Point(338, 3);
            this.gbMemberNameCode.MinimumSize = new System.Drawing.Size(0, 59);
            this.gbMemberNameCode.Name = "gbMemberNameCode";
            this.gbMemberNameCode.Size = new System.Drawing.Size(329, 59);
            this.gbMemberNameCode.TabIndex = 8;
            this.gbMemberNameCode.TabStop = false;
            this.gbMemberNameCode.Text = "Member(s) sort by";
            // 
            // rbCodeName
            // 
            this.rbCodeName.Location = new System.Drawing.Point(5, 34);
            this.rbCodeName.Name = "rbCodeName";
            this.rbCodeName.Size = new System.Drawing.Size(113, 21);
            this.rbCodeName.TabIndex = 1;
            this.rbCodeName.Text = "Code {Name}";
            this.rbCodeName.UseVisualStyleBackColor = true;
            // 
            // rbNameCode
            // 
            this.rbNameCode.Checked = true;
            this.rbNameCode.Location = new System.Drawing.Point(6, 16);
            this.rbNameCode.Name = "rbNameCode";
            this.rbNameCode.Size = new System.Drawing.Size(113, 21);
            this.rbNameCode.TabIndex = 0;
            this.rbNameCode.TabStop = true;
            this.rbNameCode.Text = "Name {Code}";
            this.rbNameCode.UseVisualStyleBackColor = true;
            this.rbNameCode.CheckedChanged += new System.EventHandler(this.rbNameCode_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rbTypeName);
            this.groupBox1.Controls.Add(this.rbNameType);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.MinimumSize = new System.Drawing.Size(0, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(329, 59);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Attribute(s) sort by";
            // 
            // rbTypeName
            // 
            this.rbTypeName.Location = new System.Drawing.Point(6, 35);
            this.rbTypeName.Name = "rbTypeName";
            this.rbTypeName.Size = new System.Drawing.Size(112, 21);
            this.rbTypeName.TabIndex = 1;
            this.rbTypeName.Text = "Type {Name}";
            this.rbTypeName.UseVisualStyleBackColor = true;
            // 
            // rbNameType
            // 
            this.rbNameType.Checked = true;
            this.rbNameType.Location = new System.Drawing.Point(6, 17);
            this.rbNameType.Name = "rbNameType";
            this.rbNameType.Size = new System.Drawing.Size(112, 21);
            this.rbNameType.TabIndex = 0;
            this.rbNameType.TabStop = true;
            this.rbNameType.Text = "Name {Type}";
            this.rbNameType.UseVisualStyleBackColor = true;
            this.rbNameType.CheckedChanged += new System.EventHandler(this.rbNameValue_CheckedChanged);
            // 
            // btnSearchMembersOK
            // 
            this.btnSearchMembersOK.BackgroundImage = global::MDSManager2012.Desktop.Properties.Resources.monitor;
            this.btnSearchMembersOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearchMembersOK.Location = new System.Drawing.Point(335, 37);
            this.btnSearchMembersOK.Name = "btnSearchMembersOK";
            this.btnSearchMembersOK.Size = new System.Drawing.Size(22, 22);
            this.btnSearchMembersOK.TabIndex = 30;
            this.toolTip1.SetToolTip(this.btnSearchMembersOK, "Apply filter");
            this.btnSearchMembersOK.UseVisualStyleBackColor = true;
            this.btnSearchMembersOK.Click += new System.EventHandler(this.btnSearchMembersOK_Click);
            // 
            // btResetFilter
            // 
            this.btResetFilter.BackgroundImage = global::MDSManager2012.Desktop.Properties.Resources.Button_Refresh_icon;
            this.btResetFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btResetFilter.Location = new System.Drawing.Point(363, 37);
            this.btResetFilter.Name = "btResetFilter";
            this.btResetFilter.Size = new System.Drawing.Size(22, 22);
            this.btResetFilter.TabIndex = 32;
            this.toolTip1.SetToolTip(this.btResetFilter, "Reset filter");
            this.btResetFilter.UseVisualStyleBackColor = true;
            this.btResetFilter.Click += new System.EventHandler(this.btResetFilter_Click);
            // 
            // btCopyMembersListClipboard
            // 
            this.btCopyMembersListClipboard.BackgroundImage = global::MDSManager2012.Desktop.Properties.Resources.pn_add_source_copy;
            this.btCopyMembersListClipboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btCopyMembersListClipboard.Location = new System.Drawing.Point(6, 1);
            this.btCopyMembersListClipboard.Name = "btCopyMembersListClipboard";
            this.btCopyMembersListClipboard.Size = new System.Drawing.Size(24, 25);
            this.btCopyMembersListClipboard.TabIndex = 39;
            this.toolTip1.SetToolTip(this.btCopyMembersListClipboard, "Copy Member List to clipboard");
            this.btCopyMembersListClipboard.UseVisualStyleBackColor = true;
            this.btCopyMembersListClipboard.Click += new System.EventHandler(this.btCopyMembersListClipboard_Click);
            // 
            // btCopyAttributesListClipboard
            // 
            this.btCopyAttributesListClipboard.BackgroundImage = global::MDSManager2012.Desktop.Properties.Resources.pn_add_source_copy;
            this.btCopyAttributesListClipboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btCopyAttributesListClipboard.Location = new System.Drawing.Point(3, 411);
            this.btCopyAttributesListClipboard.Name = "btCopyAttributesListClipboard";
            this.btCopyAttributesListClipboard.Size = new System.Drawing.Size(25, 25);
            this.btCopyAttributesListClipboard.TabIndex = 38;
            this.toolTip1.SetToolTip(this.btCopyAttributesListClipboard, "Copy Attribute List to clipboard");
            this.btCopyAttributesListClipboard.UseVisualStyleBackColor = true;
            this.btCopyAttributesListClipboard.Click += new System.EventHandler(this.btCopyAttributesListClipboard_Click);
            // 
            // txtMemberFilter
            // 
            this.txtMemberFilter.Location = new System.Drawing.Point(188, 37);
            this.txtMemberFilter.Name = "txtMemberFilter";
            this.txtMemberFilter.Size = new System.Drawing.Size(138, 20);
            this.txtMemberFilter.TabIndex = 28;
            // 
            // gbMembersFiltering
            // 
            this.gbMembersFiltering.Controls.Add(this.label4);
            this.gbMembersFiltering.Controls.Add(this.txSimLevel);
            this.gbMembersFiltering.Controls.Add(this.label3);
            this.gbMembersFiltering.Controls.Add(this.lblSearchTerm);
            this.gbMembersFiltering.Controls.Add(this.txSearchTerm);
            this.gbMembersFiltering.Controls.Add(this.rbSearchByName);
            this.gbMembersFiltering.Controls.Add(this.btResetFilter);
            this.gbMembersFiltering.Controls.Add(this.rbSearchByCode);
            this.gbMembersFiltering.Controls.Add(this.btnSearchMembersOK);
            this.gbMembersFiltering.Controls.Add(this.txtMemberFilter);
            this.gbMembersFiltering.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbMembersFiltering.Location = new System.Drawing.Point(0, 448);
            this.gbMembersFiltering.Name = "gbMembersFiltering";
            this.gbMembersFiltering.Size = new System.Drawing.Size(670, 102);
            this.gbMembersFiltering.TabIndex = 31;
            this.gbMembersFiltering.TabStop = false;
            this.gbMembersFiltering.Text = "Members Filtering : search by";
            this.gbMembersFiltering.Enter += new System.EventHandler(this.gbMembersFiltering_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Sim. Level";
            // 
            // txSimLevel
            // 
            this.txSimLevel.Location = new System.Drawing.Point(10, 37);
            this.txSimLevel.Name = "txSimLevel";
            this.txSimLevel.Size = new System.Drawing.Size(85, 20);
            this.txSimLevel.TabIndex = 37;
            this.txSimLevel.Text = "0.5 1 0.32";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(189, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Value to find (wildcard : %)";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblSearchTerm
            // 
            this.lblSearchTerm.AutoSize = true;
            this.lblSearchTerm.Location = new System.Drawing.Point(97, 63);
            this.lblSearchTerm.Name = "lblSearchTerm";
            this.lblSearchTerm.Size = new System.Drawing.Size(65, 13);
            this.lblSearchTerm.TabIndex = 34;
            this.lblSearchTerm.Text = "SearchTerm";
            // 
            // txSearchTerm
            // 
            this.txSearchTerm.Location = new System.Drawing.Point(98, 37);
            this.txSearchTerm.Name = "txSearchTerm";
            this.txSearchTerm.Size = new System.Drawing.Size(82, 20);
            this.txSearchTerm.TabIndex = 33;
            this.txSearchTerm.Text = "LIKE";
            // 
            // rbSearchByName
            // 
            this.rbSearchByName.AutoSize = true;
            this.rbSearchByName.Location = new System.Drawing.Point(75, 17);
            this.rbSearchByName.Name = "rbSearchByName";
            this.rbSearchByName.Size = new System.Drawing.Size(53, 17);
            this.rbSearchByName.TabIndex = 1;
            this.rbSearchByName.Text = "Name";
            this.rbSearchByName.UseVisualStyleBackColor = true;
            // 
            // rbSearchByCode
            // 
            this.rbSearchByCode.AutoSize = true;
            this.rbSearchByCode.Checked = true;
            this.rbSearchByCode.Location = new System.Drawing.Point(6, 17);
            this.rbSearchByCode.Name = "rbSearchByCode";
            this.rbSearchByCode.Size = new System.Drawing.Size(50, 17);
            this.rbSearchByCode.TabIndex = 0;
            this.rbSearchByCode.TabStop = true;
            this.rbSearchByCode.Text = "Code";
            this.rbSearchByCode.UseVisualStyleBackColor = true;
            // 
            // lstMembers
            // 
            this.lstMembers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstMembers.CheckOnClick = true;
            this.lstMembers.FormattingEnabled = true;
            this.lstMembers.Location = new System.Drawing.Point(338, 67);
            this.lstMembers.Name = "lstMembers";
            this.lstMembers.ScrollAlwaysVisible = true;
            this.lstMembers.Size = new System.Drawing.Size(329, 334);
            this.lstMembers.TabIndex = 36;
            this.lstMembers.ThreeDCheckBoxes = true;
            this.lstMembers.SelectedIndexChanged += new System.EventHandler(this.lstMembers_SelectedIndexChanged);
            this.lstMembers.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstMembers_MouseDown);
            this.lstMembers.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lstMembers_MouseMove);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDeleteCheckedMembers,
            this.toolStripSeparator1,
            this.tsmiCheckAll,
            this.tsmiUncheckAll});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(208, 76);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // tsmiDeleteCheckedMembers
            // 
            this.tsmiDeleteCheckedMembers.AutoToolTip = true;
            this.tsmiDeleteCheckedMembers.Name = "tsmiDeleteCheckedMembers";
            this.tsmiDeleteCheckedMembers.Size = new System.Drawing.Size(207, 22);
            this.tsmiDeleteCheckedMembers.Text = "Delete checked members";
            this.tsmiDeleteCheckedMembers.Click += new System.EventHandler(this.tsmiDeleteCheckedMembers_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(204, 6);
            // 
            // tsmiCheckAll
            // 
            this.tsmiCheckAll.Name = "tsmiCheckAll";
            this.tsmiCheckAll.Size = new System.Drawing.Size(207, 22);
            this.tsmiCheckAll.Text = "Check All Members";
            // 
            // tsmiUncheckAll
            // 
            this.tsmiUncheckAll.Name = "tsmiUncheckAll";
            this.tsmiUncheckAll.Size = new System.Drawing.Size(207, 22);
            this.tsmiUncheckAll.Text = "Uncheck All Members";
            // 
            // ckInvertCheckedMbrs
            // 
            this.ckInvertCheckedMbrs.AutoSize = true;
            this.ckInvertCheckedMbrs.Location = new System.Drawing.Point(75, 4);
            this.ckInvertCheckedMbrs.Name = "ckInvertCheckedMbrs";
            this.ckInvertCheckedMbrs.Size = new System.Drawing.Size(98, 17);
            this.ckInvertCheckedMbrs.TabIndex = 40;
            this.ckInvertCheckedMbrs.Text = "Invert checked";
            this.ckInvertCheckedMbrs.UseVisualStyleBackColor = true;
            this.ckInvertCheckedMbrs.CheckedChanged += new System.EventHandler(this.ckInvertCheckedMbrs_CheckedChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.gbMemberNameCode, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btCopyAttributesListClipboard, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lstAttributes, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lstMembers, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(670, 448);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btCopyMembersListClipboard);
            this.panel1.Controls.Add(this.ckInvertCheckedMbrs);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(338, 411);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(329, 34);
            this.panel1.TabIndex = 41;
            // 
            // ucManageMembers
            // 
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.gbMembersFiltering);
            this.Name = "ucManageMembers";
            this.Size = new System.Drawing.Size(670, 550);
            this.gbMemberNameCode.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.gbMembersFiltering.ResumeLayout(false);
            this.gbMembersFiltering.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void gbMembersFiltering_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

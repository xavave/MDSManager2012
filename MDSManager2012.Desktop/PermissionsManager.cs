// Type: MDSManager.PermissionsManager
// Assembly: MDSManager, Version=1.0.7.2, Culture=neutral, PublicKeyToken=null
// Assembly location: C:\Users\Xavier\Documents\Visual Studio 2010\Projects\MDSManager\MDSManager.exe

using Common;
using Common.Exceptions;
using Common.MDSService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.IO;
using Common.Model;
using MDSManager2012.Desktop.AppLogic;

namespace MDSManager2012.Desktop
{
    public class PermissionsManager : Form
    {
        private IContainer components = (IContainer)null;
        private ToolTip toolTip1;
        private FolderBrowserDialog folderBrowserDialog1;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        //The business rules associated to the first grid view.
        private BusinessRules businessRules1;
        private SplitContainer splitContainer1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button bTCopyBR;
        private ToolStrip toolStrip1;
        private ToolStripComboBox cbConnection;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripSplitButton btExport;
        private ToolStripMenuItem btExportXML;
        private ToolStripMenuItem btExportCSV;
        private Label lbBusinessRules;
        private CheckBox ckSelectAll;
        private DataGridView dgRules;
        private Label label1;
        private CheckBox checkBox1;
        private DataGridView dgRules2;
        private ToolStrip toolStrip2;
        private ToolStripComboBox cbConnection2;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSplitButton btExport2;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        //The business rules associated to the second grid view.
        private BusinessRules businessRules2;
        public PermissionsManager()
        {
            this.InitializeComponent();
        }



        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PermissionsManager));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.cbConnection2 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btExport2 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.dgRules2 = new System.Windows.Forms.DataGridView();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgRules = new System.Windows.Forms.DataGridView();
            this.ckSelectAll = new System.Windows.Forms.CheckBox();
            this.lbBusinessRules = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cbConnection = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btExport = new System.Windows.Forms.ToolStripSplitButton();
            this.btExportXML = new System.Windows.Forms.ToolStripMenuItem();
            this.btExportCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.bTCopyBR = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRules2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRules)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "XML files|*.xml";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.splitContainer1, 2);
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.bTCopyBR);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainer1.Panel1.Controls.Add(this.lbBusinessRules);
            this.splitContainer1.Panel1.Controls.Add(this.ckSelectAll);
            this.splitContainer1.Panel1.Controls.Add(this.dgRules);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(6);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.checkBox1);
            this.splitContainer1.Panel2.Controls.Add(this.dgRules2);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip2);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(3);
            this.splitContainer1.Size = new System.Drawing.Size(1264, 627);
            this.splitContainer1.SplitterDistance = 626;
            this.splitContainer1.TabIndex = 64;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbConnection2,
            this.toolStripSeparator2,
            this.btExport2});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(626, 28);
            this.toolStrip2.TabIndex = 63;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // cbConnection2
            // 
            this.cbConnection2.Name = "cbConnection2";
            this.cbConnection2.Size = new System.Drawing.Size(200, 28);
            this.cbConnection2.Text = "Connection";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // btExport2
            // 
            this.btExport2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btExport2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.btExport2.Enabled = false;
            this.btExport2.Image = ((System.Drawing.Image)(resources.GetObject("btExport2.Image")));
            this.btExport2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btExport2.Name = "btExport2";
            this.btExport2.Size = new System.Drawing.Size(68, 25);
            this.btExport2.Text = "Export";
            this.btExport2.ToolTipText = "Export all business rules to XML";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(107, 24);
            this.toolStripMenuItem1.Text = "XML";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(107, 24);
            this.toolStripMenuItem2.Text = "CSV";
            // 
            // dgRules2
            // 
            this.dgRules2.AllowUserToAddRows = false;
            this.dgRules2.AllowUserToDeleteRows = false;
            this.dgRules2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgRules2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgRules2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRules2.Location = new System.Drawing.Point(3, 78);
            this.dgRules2.Name = "dgRules2";
            this.dgRules2.ReadOnly = true;
            this.dgRules2.RowTemplate.Height = 24;
            this.dgRules2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgRules2.Size = new System.Drawing.Size(626, 502);
            this.dgRules2.TabIndex = 64;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.Location = new System.Drawing.Point(482, 50);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(147, 21);
            this.checkBox1.TabIndex = 65;
            this.checkBox1.Text = "Select/Unselect All";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 17);
            this.label1.TabIndex = 64;
            this.label1.Text = "Business Rules";
            // 
            // dgRules
            // 
            this.dgRules.AllowUserToAddRows = false;
            this.dgRules.AllowUserToDeleteRows = false;
            this.dgRules.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgRules.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgRules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRules.Location = new System.Drawing.Point(6, 78);
            this.dgRules.Name = "dgRules";
            this.dgRules.ReadOnly = true;
            this.dgRules.RowTemplate.Height = 24;
            this.dgRules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgRules.Size = new System.Drawing.Size(612, 502);
            this.dgRules.TabIndex = 63;
            this.dgRules.SelectionChanged += new System.EventHandler(this.dgRules_SelectionChanged);
            // 
            // ckSelectAll
            // 
            this.ckSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckSelectAll.AutoSize = true;
            this.ckSelectAll.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckSelectAll.Location = new System.Drawing.Point(471, 51);
            this.ckSelectAll.Name = "ckSelectAll";
            this.ckSelectAll.Size = new System.Drawing.Size(147, 21);
            this.ckSelectAll.TabIndex = 59;
            this.ckSelectAll.Text = "Select/Unselect All";
            this.ckSelectAll.UseVisualStyleBackColor = true;
            this.ckSelectAll.CheckedChanged += new System.EventHandler(this.ckSelectAll_CheckedChanged);
            // 
            // lbBusinessRules
            // 
            this.lbBusinessRules.AutoSize = true;
            this.lbBusinessRules.Location = new System.Drawing.Point(9, 55);
            this.lbBusinessRules.Name = "lbBusinessRules";
            this.lbBusinessRules.Size = new System.Drawing.Size(84, 17);
            this.lbBusinessRules.TabIndex = 54;
            this.lbBusinessRules.Text = "Permissions";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbConnection,
            this.toolStripSeparator5,
            this.btExport});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(6, 6);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(612, 28);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 62;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // cbConnection
            // 
            this.cbConnection.Name = "cbConnection";
            this.cbConnection.Size = new System.Drawing.Size(200, 28);
            this.cbConnection.Text = "Select Connection";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 28);
            // 
            // btExport
            // 
            this.btExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btExportXML,
            this.btExportCSV});
            this.btExport.Enabled = false;
            this.btExport.Image = ((System.Drawing.Image)(resources.GetObject("btExport.Image")));
            this.btExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(68, 25);
            this.btExport.Text = "Export";
            this.btExport.ToolTipText = "Export all business rules to XML";
            // 
            // btExportXML
            // 
            this.btExportXML.Name = "btExportXML";
            this.btExportXML.Size = new System.Drawing.Size(107, 24);
            this.btExportXML.Text = "XML";
            this.btExportXML.Click += new System.EventHandler(this.btExportXML_Click);
            // 
            // btExportCSV
            // 
            this.btExportCSV.Name = "btExportCSV";
            this.btExportCSV.Size = new System.Drawing.Size(107, 24);
            this.btExportCSV.Text = "CSV";
            this.btExportCSV.Click += new System.EventHandler(this.btExportCSV_Click);
            // 
            // bTCopyBR
            // 
            this.bTCopyBR.Enabled = false;
            this.bTCopyBR.Location = new System.Drawing.Point(452, 586);
            this.bTCopyBR.Name = "bTCopyBR";
            this.bTCopyBR.Size = new System.Drawing.Size(166, 30);
            this.bTCopyBR.TabIndex = 64;
            this.bTCopyBR.Text = "Copy to >>>>";
            this.bTCopyBR.UseVisualStyleBackColor = true;
            this.bTCopyBR.Click += new System.EventHandler(this.bTCopyBR_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.79578F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1270, 633);
            this.tableLayoutPanel1.TabIndex = 39;
            // 
            // PermissionsManager
            // 
            this.ClientSize = new System.Drawing.Size(1282, 645);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PermissionsManager";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Text = "Permissions Manager";
            this.Load += new System.EventHandler(this.PermissionsManager_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRules2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgRules)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void PermissionsManager_Load(object sender, EventArgs e)
        {
          
            try
            {
                cbConnection.ComboBox.SelectionChangeCommitted += cbConnection_SelectedIndexChanged;
                cbConnection2.ComboBox.SelectionChangeCommitted += cbConnection_SelectedIndexChanged;
                var configValues = MainConfiguration.GetConfigValues();
                configValues.Add(new ConfigValue("XML_File", ""));


                configValues.ForEach(cf => cbConnection.ComboBox.Items.Add(cf));
                configValues.ForEach(cf => cbConnection2.ComboBox.Items.Add(cf));

                // cbConnection.ComboBox.DataSource = dataSource;
                cbConnection.ComboBox.DisplayMember = "ConfigName";
                //cbConnection2.ComboBox.DataSource = dataSource;
                cbConnection2.ComboBox.DisplayMember = "ConfigName";
            }
            catch (Exception exc)
            {
                UIHelper.TreatException(exc);
            }
        }

        


        private void RefreshPermissionsList(object sender)
        {
            try
            {
               
                DataGridView ruleDataGrid = null;
                if (sender == cbConnection.ComboBox)
                {
                    ruleDataGrid = dgRules;
                }

                if (sender == cbConnection2.ComboBox)
                {
                    ruleDataGrid = dgRules2;
                }

                Cursor.Current = Cursors.WaitCursor;
                var dataSet = MDSDataUtils.NewPermissionDataTable();

                var users = MDSWrapper.UserSecurityPrincipalsGet();
                
                foreach (var user in users.Users)
                {
                    foreach (var modelPrivilege in user.SecurityPrivilege.ModelPrivileges)
                    {
                        MDSDataUtils.NewPermissionDataRow(dataSet, user.Identifier, modelPrivilege);
                    }
                    foreach (var hierarchPrivilege in user.SecurityPrivilege.HierarchyMemberPrivileges)
                    {
                        MDSDataUtils.NewPermissionDataRow(dataSet, user.Identifier, hierarchPrivilege);
                    }
                }

                var groups = MDSWrapper.GroupSecurityPrincipalsGet();

                foreach (var group in groups.Groups)
                {
                    foreach (var modelPrivilege in group.SecurityPrivilege.ModelPrivileges)
                    {
                        MDSDataUtils.NewPermissionDataRow(dataSet, group.Identifier, modelPrivilege);
                    }
                    foreach (var hierarchPrivilege in group.SecurityPrivilege.HierarchyMemberPrivileges)
                    {
                        MDSDataUtils.NewPermissionDataRow(dataSet, group.Identifier, hierarchPrivilege);
                    }
                }
               
                ruleDataGrid.DataSource = dataSet;
                //hiding the column ID
                ruleDataGrid.Columns[0].Visible = false;

                btExport.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }



        private void btCopyBRListClipboard_Click(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int num1 = 0;
            foreach (object obj in dgRules.Rows)
            {
                stringBuilder.AppendLine(obj.ToString());
                ++num1;
            }
            if (stringBuilder.Length <= 0)
                return;
            Clipboard.SetText((stringBuilder).ToString());
            MessageBox.Show(num1.ToString() + " business rule(s) name(s) copied to clipboard!");
        }



        private void ckSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            bool @checked = this.ckSelectAll.Checked;
            for (int index = 0; index < dgRules.Rows.Count; ++index)
                dgRules.Rows[index].Selected = @checked;
        }
        

        
        #region UI Events

        


        private void btExportXML_Click(object sender, EventArgs e)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                saveFileDialog1.Filter = "XML files|*.xml";
               
                if (this.saveFileDialog1.ShowDialog() != DialogResult.OK)
                    return;

                var users = MDSWrapper.UserSecurityPrincipalsGet();
                var groups = MDSWrapper.GroupSecurityPrincipalsGet();
                var securityinfo = new SecurityInformation(users.Users, groups.Groups);


                MDSWrapper.SecurityPrincipalsExport(this.saveFileDialog1.FileName, securityinfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }

        private void btExportCSV_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                saveFileDialog1.Filter = "CSV files|*.csv";
             
                if (this.saveFileDialog1.ShowDialog() != DialogResult.OK)
                    return;

             

                using (var csvFileWriter = new StreamWriter(saveFileDialog1.FileName, false))
                {
                    var headers = dgRules.Columns.Cast<DataGridViewColumn>();
                    var sep = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator;

                    csvFileWriter.WriteLine(string.Join(sep, headers.Select(column => "\"" + column.HeaderText + "\"")));


                    foreach (DataGridViewRow row in dgRules.Rows)
                    {
                        var cells = row.Cells.Cast<DataGridViewCell>();
                        csvFileWriter.WriteLine(string.Join(sep, cells.Select(cell => "\"" + cell.Value + "\"")));

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }

        private void cbConnection_SelectedIndexChanged(object sender, EventArgs e)
        {
            var config = (sender as ComboBox).SelectedItem as ConfigValue;

            if (config != null)
            {
                //using a hack to open the XML file instead of the connection.
                if (String.IsNullOrEmpty(config.EndpointAddress))
                {

                    if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        BusinessRules businessRules;

                        try
                        {
                            businessRules = MDSWrapper.BusinessRuleDeserialize(openFileDialog1.FileName);
                        }
                        catch (MDSManagerException exc)
                        {
                            MessageBox.Show(exc.Message);
                            return;
                        }
                        var dataSet = MDSDataUtils.NewBusinessRuleDataTable();
                        foreach (BusinessRule businessRule in businessRules.BusinessRulesMember)
                        {
                            MDSDataUtils.NewBRDataRow(dataSet, businessRule);
                        }
                        if ((sender as ComboBox) == cbConnection.ComboBox)
                        {


                            dgRules.DataSource = dataSet;
                        }
                        if ((sender as ComboBox) == cbConnection2.ComboBox)
                        {
                            businessRules2 = businessRules;
                           
                            dgRules2.DataSource = dataSet;
                           
                        }

                    }
                }
                else
                {
                    MDSWrapper.Configuration = config;
                    RefreshPermissionsList(sender);
                }
               
            }
        }
        private void bTCopyBR_Click(object sender, EventArgs e)
        {

            if (dgRules.SelectedRows.Count == 0)
            {
                MessageBox.Show("No business rules selected");
                return;
            }
            var businessRuleToCopy = new BusinessRules()
            {
                BRActions = new List<BRAction>(),
                BRConditions = new List<BRCondition>(),
                BRConditionTreeNodes = new List<BRConditionTreeNode>(),
                BusinessRulesMember = new List<BusinessRule>()
            };



            foreach (DataGridViewRow row in dgRules.SelectedRows)
            {
                var brIdString = row.Cells["ID"].Value as string;

                var id = new Guid(brIdString);

                var br = businessRules1.BusinessRulesMember.First(oBr => oBr.Identifier.Id == id);
                if (br != null)
                    businessRuleToCopy.BusinessRulesMember.Add(br);

            }

            businessRuleToCopy.ExtensionData = businessRules1.ExtensionData;

            if (!businessRuleToCopy.BusinessRulesMember.Any())
            {
                MessageBox.Show("No business rules selected!");

                return;
            }

            

        }

        private void dgRules_SelectionChanged(object sender, EventArgs e)
        {
            if (dgRules.SelectedRows.Count > 0)
            {
                if (cbConnection2.SelectedItem != null)
                    bTCopyBR.Enabled = true;
            }
        }



        #endregion
    









    }
}

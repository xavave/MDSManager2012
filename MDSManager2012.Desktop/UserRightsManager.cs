// Type: MDSManager.UserRightsManager
// Assembly: MDSManager, Version=1.0.7.2, Culture=neutral, PublicKeyToken=null
// Assembly location: C:\Users\Xavier\Documents\Visual Studio 2010\Projects\MDSManager\MDSManager.exe

using Common;
using Common.MDSService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using MDSManager2012.Desktop.AppLogic;
using System.Runtime.InteropServices;
using Common.Model;

namespace MDSManager2012.Desktop
{
    public class UserRightsManager : BaseForm
    {
        private IContainer components = (IContainer)null;
        private Label label5;
        private ListBox lstUsers;
        private ComboBox cbModel;
        private Label label3;
        private ListBox lstGroups;
        private FolderBrowserDialog folderBrowserDialog1;
        private ToolTip toolTip1;
        private OpenFileDialog openFileDialog1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private TableLayoutPanel tableLayoutPanel1;


        private SecurityPrincipals _usersAndGroups;
        private const int EM_SETCUEBANNER = 0x1501;
        private Panel panel2;
        private Button btExportGroups;
        private Button btImportGroups;
        private Panel panel1;
        private Button btExportUsers;
        private Button btImportUsers;
        private Panel panel4;
        private Button btUserPrivilegesExport;
        private Button btUserPrivilegesImport;
        private Panel panel3;
        private Button btExportGroupPrivileges;
        private Button btImportGroupPrivileges;
        private GroupBox groupBox1;
        private CheckBox checkBox1;
        private const int EM_GETCUEBANNER = 0x1502;
        private GroupBox groupBox2;
        private ComboBox cbEndPointAddress;
       
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessageW(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        public UserRightsManager()
        {
            this.InitializeComponent();
        }

        private void UserRightsManager_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                var errorMessage = String.Empty;
                CheckIfServiceUp();
            }
            catch (Exception ex)
            {
                statusStrip1.Text = ex.Message;
                //throw ex;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public override void CheckIfServiceUpCompleted(ServiceCheckCompletedEventArgs e)
        {
            
            Tools.HandleErrors(e.Error, true);
            GetModels();
            LoadSecurityPrincipals();
            LoadConfigurations();
            //TODO This code requires updates to work with combobox. Check http://www.ageektrapped.com/blog/the-missing-net-1-cue-banners-in-windows-forms-em_setcuebanner-text-prompt/
            SendMessageW(cbModel.Handle, EM_SETCUEBANNER, 0, "Select a model");
        }

        private void LoadConfigurations()
        {
            cbEndPointAddress.DataSource = MainConfiguration.GetConfigValues();
            cbEndPointAddress.DisplayMember = "ConfigName";

        }

        public void GetModels()
        {
            try
            {
                List<Model> modelList = MDSWrapper.ModelGet();
                this.cbModel.Items.Clear();
                if (modelList != null && modelList.Count > 0)
                {
                    foreach (MdmDataContractOfIdentifier contractOfIdentifier in modelList)
                        this.cbModel.Items.Add((object)contractOfIdentifier.Identifier);
                    this.cbModel.DisplayMember = "Name";
                }
                else

                    statusStrip1.Text = "can't retrieve models or no models to display";
            }
            catch (Exception exc)
            {
                statusStrip1.Text = exc.Message;
            }


        }


        private void LoadSecurityPrincipals()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var users = MDSWrapper.UserSecurityPrincipalsGet();
                lstUsers.Items.Clear();
                foreach (User u in users.Users)
                    this.lstUsers.Items.Add(new CustomUser(u));

                //Note the security principals are server-level objects, not model specific
                var groups = MDSWrapper.GroupSecurityPrincipalsGet();
                lstGroups.Items.Clear();
                foreach (Group group in groups.Groups)
                    this.lstGroups.Items.Add(new CustomGroup(group));
            }
            catch (Exception ex)
            {
                statusStrip1.Text = ex.Message;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btImportUR_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (this.openFileDialog1.ShowDialog() != DialogResult.OK)
                    return;

                MDSWrapper.SecurityPrincipalsImport(openFileDialog1.FileName, PrincipalType.UserAccount, SecurityPrincipalsOptions.ExcludeAllPrivileges, false);

            }
            catch (Exception ex)
            {
                statusStrip1.Text = ex.Message;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btExportUR_Click(object sender, EventArgs e)
        {

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
            this.label5 = new System.Windows.Forms.Label();
            this.lstUsers = new System.Windows.Forms.ListBox();
            this.cbModel = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lstGroups = new System.Windows.Forms.ListBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btExportUsers = new System.Windows.Forms.Button();
            this.btImportUsers = new System.Windows.Forms.Button();
            this.btExportGroups = new System.Windows.Forms.Button();
            this.btImportGroups = new System.Windows.Forms.Button();
            this.btExportGroupPrivileges = new System.Windows.Forms.Button();
            this.btImportGroupPrivileges = new System.Windows.Forms.Button();
            this.btUserPrivilegesExport = new System.Windows.Forms.Button();
            this.btUserPrivilegesImport = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbEndPointAddress = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(304, 26);
            this.label5.TabIndex = 64;
            this.label5.Text = "Users";
            // 
            // lstUsers
            // 
            this.lstUsers.DisplayMember = "Name";
            this.lstUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.ItemHeight = 16;
            this.lstUsers.Location = new System.Drawing.Point(3, 29);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstUsers.Size = new System.Drawing.Size(304, 212);
            this.lstUsers.TabIndex = 63;
            // 
            // cbModel
            // 
            this.cbModel.FormattingEnabled = true;
            this.cbModel.Location = new System.Drawing.Point(9, 19);
            this.cbModel.Name = "cbModel";
            this.cbModel.Size = new System.Drawing.Size(289, 24);
            this.cbModel.TabIndex = 61;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(313, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(305, 19);
            this.label3.TabIndex = 68;
            this.label3.Text = "Groups";
            // 
            // lstGroups
            // 
            this.lstGroups.DisplayMember = "Name";
            this.lstGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstGroups.FormattingEnabled = true;
            this.lstGroups.ItemHeight = 16;
            this.lstGroups.Location = new System.Drawing.Point(313, 29);
            this.lstGroups.Name = "lstGroups";
            this.lstGroups.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstGroups.Size = new System.Drawing.Size(305, 212);
            this.lstGroups.TabIndex = 67;
            // 
            // btExportUsers
            // 
            this.btExportUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btExportUsers.BackgroundImage = global::MDSManager2012.Desktop.Properties.Resources.export_icon;
            this.btExportUsers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btExportUsers.Location = new System.Drawing.Point(265, 0);
            this.btExportUsers.Name = "btExportUsers";
            this.btExportUsers.Size = new System.Drawing.Size(36, 36);
            this.btExportUsers.TabIndex = 69;
            this.toolTip1.SetToolTip(this.btExportUsers, "Export Users Principals");
            this.btExportUsers.UseVisualStyleBackColor = true;
            this.btExportUsers.Click += new System.EventHandler(this.btExportUsers_Click);
            // 
            // btImportUsers
            // 
            this.btImportUsers.AutoSize = true;
            this.btImportUsers.BackgroundImage = global::MDSManager2012.Desktop.Properties.Resources.import_icon;
            this.btImportUsers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btImportUsers.Location = new System.Drawing.Point(3, 0);
            this.btImportUsers.Name = "btImportUsers";
            this.btImportUsers.Size = new System.Drawing.Size(36, 36);
            this.btImportUsers.TabIndex = 70;
            this.toolTip1.SetToolTip(this.btImportUsers, "Import from selected folder containing User and group Rights XML files");
            this.btImportUsers.UseVisualStyleBackColor = true;
            // 
            // btExportGroups
            // 
            this.btExportGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btExportGroups.BackgroundImage = global::MDSManager2012.Desktop.Properties.Resources.export_icon;
            this.btExportGroups.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btExportGroups.Location = new System.Drawing.Point(266, 0);
            this.btExportGroups.Name = "btExportGroups";
            this.btExportGroups.Size = new System.Drawing.Size(36, 36);
            this.btExportGroups.TabIndex = 69;
            this.toolTip1.SetToolTip(this.btExportGroups, "Export Users Principals");
            this.btExportGroups.UseVisualStyleBackColor = true;
            this.btExportGroups.Click += new System.EventHandler(this.btExportGroups_Click);
            // 
            // btImportGroups
            // 
            this.btImportGroups.AutoSize = true;
            this.btImportGroups.BackgroundImage = global::MDSManager2012.Desktop.Properties.Resources.import_icon;
            this.btImportGroups.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btImportGroups.Location = new System.Drawing.Point(3, 0);
            this.btImportGroups.Name = "btImportGroups";
            this.btImportGroups.Size = new System.Drawing.Size(36, 36);
            this.btImportGroups.TabIndex = 70;
            this.toolTip1.SetToolTip(this.btImportGroups, "Import from selected folder containing User and group Rights XML files");
            this.btImportGroups.UseVisualStyleBackColor = true;
            // 
            // btExportGroupPrivileges
            // 
            this.btExportGroupPrivileges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btExportGroupPrivileges.BackgroundImage = global::MDSManager2012.Desktop.Properties.Resources.export_icon;
            this.btExportGroupPrivileges.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btExportGroupPrivileges.Location = new System.Drawing.Point(241, 0);
            this.btExportGroupPrivileges.Name = "btExportGroupPrivileges";
            this.btExportGroupPrivileges.Size = new System.Drawing.Size(36, 36);
            this.btExportGroupPrivileges.TabIndex = 69;
            this.toolTip1.SetToolTip(this.btExportGroupPrivileges, "Export Group Privileges");
            this.btExportGroupPrivileges.UseVisualStyleBackColor = true;
            this.btExportGroupPrivileges.Click += new System.EventHandler(this.btExportGroupPrivileges_Click);
            // 
            // btImportGroupPrivileges
            // 
            this.btImportGroupPrivileges.AutoSize = true;
            this.btImportGroupPrivileges.BackgroundImage = global::MDSManager2012.Desktop.Properties.Resources.import_icon;
            this.btImportGroupPrivileges.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btImportGroupPrivileges.Location = new System.Drawing.Point(3, 0);
            this.btImportGroupPrivileges.Name = "btImportGroupPrivileges";
            this.btImportGroupPrivileges.Size = new System.Drawing.Size(36, 36);
            this.btImportGroupPrivileges.TabIndex = 70;
            this.toolTip1.SetToolTip(this.btImportGroupPrivileges, "Import from selected folder containing User and group Rights XML files");
            this.btImportGroupPrivileges.UseVisualStyleBackColor = true;
            // 
            // btUserPrivilegesExport
            // 
            this.btUserPrivilegesExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btUserPrivilegesExport.BackgroundImage = global::MDSManager2012.Desktop.Properties.Resources.export_icon;
            this.btUserPrivilegesExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btUserPrivilegesExport.Location = new System.Drawing.Point(250, 0);
            this.btUserPrivilegesExport.Name = "btUserPrivilegesExport";
            this.btUserPrivilegesExport.Size = new System.Drawing.Size(36, 36);
            this.btUserPrivilegesExport.TabIndex = 69;
            this.toolTip1.SetToolTip(this.btUserPrivilegesExport, "Export Users Privileges");
            this.btUserPrivilegesExport.UseVisualStyleBackColor = true;
            this.btUserPrivilegesExport.Click += new System.EventHandler(this.btUserPrivilegesExport_Click);
            // 
            // btUserPrivilegesImport
            // 
            this.btUserPrivilegesImport.AutoSize = true;
            this.btUserPrivilegesImport.BackgroundImage = global::MDSManager2012.Desktop.Properties.Resources.import_icon;
            this.btUserPrivilegesImport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btUserPrivilegesImport.Location = new System.Drawing.Point(263, 58);
            this.btUserPrivilegesImport.Name = "btUserPrivilegesImport";
            this.btUserPrivilegesImport.Size = new System.Drawing.Size(36, 36);
            this.btUserPrivilegesImport.TabIndex = 70;
            this.toolTip1.SetToolTip(this.btUserPrivilegesImport, "Import from selected folder containing User and group Rights XML files");
            this.btUserPrivilegesImport.UseVisualStyleBackColor = true;
            this.btUserPrivilegesImport.Click += new System.EventHandler(this.btUserPrivilegesImport_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 498);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(621, 25);
            this.statusStrip1.TabIndex = 69;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(49, 20);
            this.toolStripStatusLabel1.Text = "Status";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lstUsers, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lstGroups, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 218F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(621, 498);
            this.tableLayoutPanel1.TabIndex = 70;
            
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.btExportGroups);
            this.panel2.Controls.Add(this.btImportGroups);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(313, 247);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(305, 36);
            this.panel2.TabIndex = 72;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.btExportUsers);
            this.panel1.Controls.Add(this.btImportUsers);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 247);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(304, 36);
            this.panel1.TabIndex = 71;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel4);
            this.groupBox2.Controls.Add(this.cbModel);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 289);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(304, 100);
            this.groupBox2.TabIndex = 78;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Security Privileges Export";
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel4.Controls.Add(this.btUserPrivilegesExport);
            this.panel4.Location = new System.Drawing.Point(9, 55);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(289, 39);
            this.panel4.TabIndex = 76;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel3.Controls.Add(this.btExportGroupPrivileges);
            this.panel3.Controls.Add(this.btImportGroupPrivileges);
            this.panel3.Location = new System.Drawing.Point(325, 456);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(280, 39);
            this.panel3.TabIndex = 75;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbEndPointAddress);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.btUserPrivilegesImport);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 395);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 100);
            this.groupBox1.TabIndex = 77;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Security Privileges Import";
            // 
            // cbEndPointAddress
            // 
            this.cbEndPointAddress.FormattingEnabled = true;
            this.cbEndPointAddress.Location = new System.Drawing.Point(7, 19);
            this.cbEndPointAddress.Name = "cbEndPointAddress";
            this.cbEndPointAddress.Size = new System.Drawing.Size(292, 24);
            this.cbEndPointAddress.TabIndex = 73;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 70);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(98, 21);
            this.checkBox1.TabIndex = 72;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // UserRightsManager
            // 
            this.ClientSize = new System.Drawing.Size(621, 523);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "UserRightsManager";
            this.Text = "User Rights";
            this.Load += new System.EventHandler(this.UserRightsManager_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

      
        private void btExportUsers_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (this.cbModel.SelectedItem != null)
                {
                    if (this.folderBrowserDialog1.ShowDialog() != DialogResult.OK)
                        return;

                    var modelId = this.cbModel.SelectedItem as Identifier;
                    var path = this.folderBrowserDialog1.SelectedPath;
                    MDSWrapper.SecurityPrincipalsExport(Path.Combine(path, String.Format(Constants.StringFormatUserPrincipals, modelId.Name)), PrincipalType.UserAccount);


                    if (MessageBox.Show("User principals successfully exported to " + path.Replace("\\\\", "\\") + "\r\nDo you want to open the destination folder ?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        Process.Start("explorer.exe", path);
                    }

                }
                else
                {
                    MessageBox.Show("Please select a model first");
                }
            }
            catch (Exception ex)
            {
                statusStrip1.Text = ex.Message;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btExportGroups_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (cbModel.SelectedItem != null)
                {
                    if (folderBrowserDialog1.ShowDialog() != DialogResult.OK)
                        return;

                    //SecurityPrincipals are instance-level
                    //var modelId = this.cbModel.SelectedItem as Identifier;
                    var path = folderBrowserDialog1.SelectedPath;

                    MDSWrapper.SecurityPrincipalsExport(Path.Combine(path,String.Format(Constants.StringFormatGroupPrincipals, MDSWrapper.Configuration.ConfigName.Replace(' ', '_'))), PrincipalType.Group);

                    if (MessageBox.Show("Group principals successfully exported to " + path.Replace("\\\\", "\\") + "\r\nDo you want to open the destination folder ?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        Process.Start("explorer.exe", path);
                    }

                }
                else
                {
                    MessageBox.Show("Please select a model first");
                }
            }
            catch (Exception ex)
            {
                statusStrip1.Text = ex.Message;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }



        private void btUserPrivilegesExport_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (this.cbModel.SelectedItem == null)
                {
                    MessageBox.Show("Please select a model first.");
                    return;
                }
                if (lstUsers.SelectedItem == null)
                {
                    MessageBox.Show("Please select a user.");
                    return;
                }

                if (this.folderBrowserDialog1.ShowDialog() != DialogResult.OK)
                    return;

                var modelId = this.cbModel.SelectedItem as Identifier;
                var path = this.folderBrowserDialog1.SelectedPath;

                if (lstUsers.SelectedItem == null)
                    return;

                var user = (CustomUser)lstUsers.SelectedItem;
                MDSWrapper.SecurityPrivilegesExport(modelId, path, String.Format(Constants.StringFormatUserPrivileges, user.Identifier.InternalId), user);

                if (MessageBox.Show("User privileges for " + user.Identifier.Name + " successfully exported to " + path.Replace("\\\\", "\\") + "\r\nDo you want to open the destination folder ?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    Process.Start("explorer.exe", path);
                }


            }
            catch (Exception ex)
            {
                statusStrip1.Text = ex.Message;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btExportGroupPrivileges_Click(object sender, EventArgs e)
        {
            MDSWrapper mdsWrapper = null;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (this.cbModel.SelectedItem != null)
                {
                    if (this.folderBrowserDialog1.ShowDialog() != DialogResult.OK)
                        return;

                    var modelId = this.cbModel.SelectedItem as Identifier;
                    var path = this.folderBrowserDialog1.SelectedPath;

                    if (lstGroups.SelectedItem != null)
                    {
                        var fileName = String.Format(Constants.StringFormatGroupPrivileges, (lstGroups.SelectedItem as Group).Identifier.InternalId);
                        MDSWrapper.SecurityPrivilegesExport(modelId, path, fileName, lstGroups.SelectedItem as Group);
                    }

                    if (MessageBox.Show("Group principals successfully exported to " + path.Replace("\\\\", "\\") + "\r\nDo you want to open the destination folder ?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        Process.Start("explorer.exe", path);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a model first");
                }
            }
            catch (Exception ex)
            {
                statusStrip1.Text = ex.Message;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                if (mdsWrapper != null) mdsWrapper.Dispose();
            }
        }

        private void btUserPrivilegesImport_Click(object sender, EventArgs e)
        {

        }



      
    }
}

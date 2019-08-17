using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System;
namespace MDSManager2012.Desktop
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
       // private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
       

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lstModels = new System.Windows.Forms.ListBox();
            this.lstExportViews = new System.Windows.Forms.ListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lstVersions = new System.Windows.Forms.ListBox();
            this.lstFlags = new System.Windows.Forms.ListBox();
            this.gbImportViewMode = new System.Windows.Forms.GroupBox();
            this.rbImportViewManual = new System.Windows.Forms.RadioButton();
            this.rbImportViewAuto = new System.Windows.Forms.RadioButton();
            this.txtAppendToViewName = new System.Windows.Forms.TextBox();
            this.rbBasedOnFlag = new System.Windows.Forms.RadioButton();
            this.rbBasedOnVersion = new System.Windows.Forms.RadioButton();
            this.gbAppendViewName = new System.Windows.Forms.GroupBox();
            this.chkAppendToViewName = new System.Windows.Forms.CheckBox();
            this.gbBasedOn = new System.Windows.Forms.GroupBox();
            this.btRefreshConnection = new System.Windows.Forms.Button();
            this.btEntityManager = new System.Windows.Forms.Button();
            this.btBusinessRulesManager = new System.Windows.Forms.Button();
            this.btModelDiagramManager = new System.Windows.Forms.Button();
            this.btUserRightsManager = new System.Windows.Forms.Button();
            this.btPackageDeploy = new System.Windows.Forms.Button();
            this.btConnManager = new System.Windows.Forms.Button();
            this.btTest = new System.Windows.Forms.Button();
            this.btTest2 = new System.Windows.Forms.Button();
            this.gbSubscriptionViews = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.btDeleteViews = new System.Windows.Forms.Button();
            this.btImportViews = new System.Windows.Forms.Button();
            this.btExport = new System.Windows.Forms.Button();
            this.gbMembers = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gbAttributes = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btValidateMember = new System.Windows.Forms.Button();
            this.btUpdateMember = new System.Windows.Forms.Button();
            this.btAddMember = new System.Windows.Forms.Button();
            this.btDeleteMemberAttribute = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txtValidationStatus = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAttributeType = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAttributeName = new System.Windows.Forms.TextBox();
            this.txtAttributeValue = new System.Windows.Forms.TextBox();
            this.ucManageMembers1 = new MDSManager2012.Desktop.ucManageMembers();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btDeleteAllMembersFromAllEntities = new System.Windows.Forms.Button();
            this.btnDeleteAllMembers = new System.Windows.Forms.Button();
            this.gbConnection = new System.Windows.Forms.GroupBox();
            this.cbEndPointAddress = new System.Windows.Forms.ComboBox();
            this.groupBoxVersions = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btDeleteVersion = new System.Windows.Forms.Button();
            this.btVersionCopy = new System.Windows.Forms.Button();
            this.btValidateVersion = new System.Windows.Forms.Button();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btRefreshVersionAndFlagLists = new System.Windows.Forms.Button();
            this.btDeleteFlag = new System.Windows.Forms.Button();
            this.groupBoxModels = new System.Windows.Forms.GroupBox();
            this.btRefreshModels = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.btTestExportViewUpdate = new System.Windows.Forms.Button();
            this.pictureBoxInfo = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBoxEntities = new System.Windows.Forms.GroupBox();
            this.ucManageEntities1 = new MDSManager2012.Desktop.ucManageEntities();
            this.pnMiddle = new System.Windows.Forms.Panel();
            this.pnRight = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.progressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelMainContent = new System.Windows.Forms.Panel();
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.gbImportViewMode.SuspendLayout();
            this.gbAppendViewName.SuspendLayout();
            this.gbBasedOn.SuspendLayout();
            this.gbSubscriptionViews.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.gbMembers.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbAttributes.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbConnection.SuspendLayout();
            this.groupBoxVersions.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.groupBoxModels.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInfo)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBoxEntities.SuspendLayout();
            this.pnMiddle.SuspendLayout();
            this.pnRight.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panelMainContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstModels
            // 
            this.lstModels.Dock = System.Windows.Forms.DockStyle.Top;
            this.lstModels.FormattingEnabled = true;
            this.lstModels.Location = new System.Drawing.Point(3, 16);
            this.lstModels.Name = "lstModels";
            this.lstModels.Size = new System.Drawing.Size(311, 95);
            this.lstModels.TabIndex = 0;
            this.lstModels.SelectedIndexChanged += new System.EventHandler(this.lstModels_SelectedIndexChanged);
            // 
            // lstExportViews
            // 
            this.lstExportViews.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstExportViews.FormattingEnabled = true;
            this.lstExportViews.Location = new System.Drawing.Point(10, 53);
            this.lstExportViews.Name = "lstExportViews";
            this.lstExportViews.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstExportViews.Size = new System.Drawing.Size(285, 95);
            this.lstExportViews.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lstVersions
            // 
            this.lstVersions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstVersions.FormattingEnabled = true;
            this.lstVersions.Location = new System.Drawing.Point(0, 29);
            this.lstVersions.Margin = new System.Windows.Forms.Padding(0);
            this.lstVersions.Name = "lstVersions";
            this.lstVersions.Size = new System.Drawing.Size(155, 80);
            this.lstVersions.TabIndex = 9;
            this.lstVersions.SelectedIndexChanged += new System.EventHandler(this.lstVersions_SelectedIndexChanged);
            // 
            // lstFlags
            // 
            this.lstFlags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFlags.FormattingEnabled = true;
            this.lstFlags.Location = new System.Drawing.Point(155, 29);
            this.lstFlags.Margin = new System.Windows.Forms.Padding(0);
            this.lstFlags.Name = "lstFlags";
            this.lstFlags.Size = new System.Drawing.Size(156, 80);
            this.lstFlags.TabIndex = 21;
            // 
            // gbImportViewMode
            // 
            this.gbImportViewMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbImportViewMode.Controls.Add(this.rbImportViewManual);
            this.gbImportViewMode.Controls.Add(this.rbImportViewAuto);
            this.gbImportViewMode.Location = new System.Drawing.Point(301, 13);
            this.gbImportViewMode.Name = "gbImportViewMode";
            this.gbImportViewMode.Size = new System.Drawing.Size(232, 42);
            this.gbImportViewMode.TabIndex = 25;
            this.gbImportViewMode.TabStop = false;
            this.gbImportViewMode.Tag = "";
            this.gbImportViewMode.Text = "Import View to Model/Version";
            // 
            // rbImportViewManual
            // 
            this.rbImportViewManual.AutoSize = true;
            this.rbImportViewManual.Checked = true;
            this.rbImportViewManual.Location = new System.Drawing.Point(151, 18);
            this.rbImportViewManual.Name = "rbImportViewManual";
            this.rbImportViewManual.Size = new System.Drawing.Size(60, 17);
            this.rbImportViewManual.TabIndex = 1;
            this.rbImportViewManual.TabStop = true;
            this.rbImportViewManual.Text = "Manual";
            this.rbImportViewManual.UseVisualStyleBackColor = true;
            this.rbImportViewManual.CheckedChanged += new System.EventHandler(this.rbImportViewManual_CheckedChanged);
            // 
            // rbImportViewAuto
            // 
            this.rbImportViewAuto.AutoSize = true;
            this.rbImportViewAuto.Location = new System.Drawing.Point(6, 18);
            this.rbImportViewAuto.Name = "rbImportViewAuto";
            this.rbImportViewAuto.Size = new System.Drawing.Size(102, 17);
            this.rbImportViewAuto.TabIndex = 0;
            this.rbImportViewAuto.Text = "Same as original";
            this.rbImportViewAuto.UseVisualStyleBackColor = true;
            // 
            // txtAppendToViewName
            // 
            this.txtAppendToViewName.Location = new System.Drawing.Point(32, 21);
            this.txtAppendToViewName.Name = "txtAppendToViewName";
            this.txtAppendToViewName.Size = new System.Drawing.Size(143, 20);
            this.txtAppendToViewName.TabIndex = 27;
            this.txtAppendToViewName.Text = "_new";
            // 
            // rbBasedOnFlag
            // 
            this.rbBasedOnFlag.AutoSize = true;
            this.rbBasedOnFlag.Location = new System.Drawing.Point(111, 16);
            this.rbBasedOnFlag.Name = "rbBasedOnFlag";
            this.rbBasedOnFlag.Size = new System.Drawing.Size(45, 17);
            this.rbBasedOnFlag.TabIndex = 1;
            this.rbBasedOnFlag.Text = "Flag";
            this.rbBasedOnFlag.UseVisualStyleBackColor = true;
            // 
            // rbBasedOnVersion
            // 
            this.rbBasedOnVersion.AutoSize = true;
            this.rbBasedOnVersion.Checked = true;
            this.rbBasedOnVersion.Location = new System.Drawing.Point(7, 16);
            this.rbBasedOnVersion.Name = "rbBasedOnVersion";
            this.rbBasedOnVersion.Size = new System.Drawing.Size(60, 17);
            this.rbBasedOnVersion.TabIndex = 0;
            this.rbBasedOnVersion.TabStop = true;
            this.rbBasedOnVersion.Text = "Version";
            this.rbBasedOnVersion.UseVisualStyleBackColor = true;
            // 
            // gbAppendViewName
            // 
            this.gbAppendViewName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbAppendViewName.Controls.Add(this.txtAppendToViewName);
            this.gbAppendViewName.Controls.Add(this.chkAppendToViewName);
            this.gbAppendViewName.Location = new System.Drawing.Point(301, 102);
            this.gbAppendViewName.Name = "gbAppendViewName";
            this.gbAppendViewName.Size = new System.Drawing.Size(232, 53);
            this.gbAppendViewName.TabIndex = 26;
            this.gbAppendViewName.TabStop = false;
            this.gbAppendViewName.Tag = "";
            this.gbAppendViewName.Text = "Append to Imported View Name";
            // 
            // chkAppendToViewName
            // 
            this.chkAppendToViewName.AutoSize = true;
            this.chkAppendToViewName.Location = new System.Drawing.Point(11, 24);
            this.chkAppendToViewName.Name = "chkAppendToViewName";
            this.chkAppendToViewName.Size = new System.Drawing.Size(15, 14);
            this.chkAppendToViewName.TabIndex = 0;
            this.chkAppendToViewName.UseVisualStyleBackColor = true;
            // 
            // gbBasedOn
            // 
            this.gbBasedOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBasedOn.Controls.Add(this.rbBasedOnFlag);
            this.gbBasedOn.Controls.Add(this.rbBasedOnVersion);
            this.gbBasedOn.Location = new System.Drawing.Point(301, 58);
            this.gbBasedOn.Name = "gbBasedOn";
            this.gbBasedOn.Size = new System.Drawing.Size(232, 43);
            this.gbBasedOn.TabIndex = 26;
            this.gbBasedOn.TabStop = false;
            this.gbBasedOn.Tag = "";
            this.gbBasedOn.Text = "Based on the selected";
            // 
            // btRefreshConnection
            // 
            this.btRefreshConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRefreshConnection.Location = new System.Drawing.Point(383, 21);
            this.btRefreshConnection.Name = "btRefreshConnection";
            this.btRefreshConnection.Size = new System.Drawing.Size(80, 26);
            this.btRefreshConnection.TabIndex = 31;
            this.btRefreshConnection.Text = "Connect!";
            this.btRefreshConnection.UseVisualStyleBackColor = true;
            this.btRefreshConnection.Click += new System.EventHandler(this.btRefreshConnection_Click);
            // 
            // btEntityManager
            // 
            this.btEntityManager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btEntityManager.Location = new System.Drawing.Point(6, 3);
            this.btEntityManager.Name = "btEntityManager";
            this.btEntityManager.Size = new System.Drawing.Size(140, 26);
            this.btEntityManager.TabIndex = 46;
            this.btEntityManager.Text = "Entity Manager";
            this.btEntityManager.UseVisualStyleBackColor = true;
            this.btEntityManager.Click += new System.EventHandler(this.btEntityManager_Click);
            // 
            // btBusinessRulesManager
            // 
            this.btBusinessRulesManager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btBusinessRulesManager.Location = new System.Drawing.Point(6, 30);
            this.btBusinessRulesManager.Name = "btBusinessRulesManager";
            this.btBusinessRulesManager.Size = new System.Drawing.Size(140, 26);
            this.btBusinessRulesManager.TabIndex = 47;
            this.btBusinessRulesManager.Text = "Business Rules Manager";
            this.btBusinessRulesManager.UseVisualStyleBackColor = true;
            this.btBusinessRulesManager.Click += new System.EventHandler(this.btBusinessRulesManager_Click);
            // 
            // btModelDiagramManager
            // 
            this.btModelDiagramManager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btModelDiagramManager.Location = new System.Drawing.Point(6, 57);
            this.btModelDiagramManager.Name = "btModelDiagramManager";
            this.btModelDiagramManager.Size = new System.Drawing.Size(140, 26);
            this.btModelDiagramManager.TabIndex = 49;
            this.btModelDiagramManager.Text = "Model Diagram Manager";
            this.btModelDiagramManager.UseVisualStyleBackColor = true;
            this.btModelDiagramManager.Click += new System.EventHandler(this.btModelDiagramManager_Click);
            // 
            // btUserRightsManager
            // 
            this.btUserRightsManager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btUserRightsManager.Location = new System.Drawing.Point(6, 86);
            this.btUserRightsManager.Name = "btUserRightsManager";
            this.btUserRightsManager.Size = new System.Drawing.Size(140, 26);
            this.btUserRightsManager.TabIndex = 50;
            this.btUserRightsManager.Text = "User Rights Manager";
            this.btUserRightsManager.UseVisualStyleBackColor = true;
            this.btUserRightsManager.Click += new System.EventHandler(this.btUserRightsManager_Click);
            // 
            // btPackageDeploy
            // 
            this.btPackageDeploy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPackageDeploy.Location = new System.Drawing.Point(6, 114);
            this.btPackageDeploy.Name = "btPackageDeploy";
            this.btPackageDeploy.Size = new System.Drawing.Size(140, 26);
            this.btPackageDeploy.TabIndex = 51;
            this.btPackageDeploy.Text = "Package Deployment (beta)";
            this.btPackageDeploy.UseVisualStyleBackColor = true;
            this.btPackageDeploy.Click += new System.EventHandler(this.btPackageDeploy_Click);
            // 
            // btConnManager
            // 
            this.btConnManager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btConnManager.Location = new System.Drawing.Point(469, 21);
            this.btConnManager.Name = "btConnManager";
            this.btConnManager.Size = new System.Drawing.Size(68, 26);
            this.btConnManager.TabIndex = 50;
            this.btConnManager.Text = "Manage";
            this.btConnManager.UseVisualStyleBackColor = true;
            this.btConnManager.Click += new System.EventHandler(this.btConnManager_Click);
            // 
            // btTest
            // 
            this.btTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btTest.Enabled = false;
            this.btTest.Location = new System.Drawing.Point(31, 184);
            this.btTest.Name = "btTest";
            this.btTest.Size = new System.Drawing.Size(34, 23);
            this.btTest.TabIndex = 44;
            this.btTest.Text = "test";
            this.btTest.UseVisualStyleBackColor = true;
            this.btTest.Visible = false;
            this.btTest.Click += new System.EventHandler(this.btTest_Click);
            // 
            // btTest2
            // 
            this.btTest2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btTest2.Enabled = false;
            this.btTest2.Location = new System.Drawing.Point(66, 184);
            this.btTest2.Name = "btTest2";
            this.btTest2.Size = new System.Drawing.Size(38, 23);
            this.btTest2.TabIndex = 45;
            this.btTest2.Text = "test2";
            this.btTest2.UseVisualStyleBackColor = true;
            this.btTest2.Visible = false;
            this.btTest2.Click += new System.EventHandler(this.btTest2_Click);
            // 
            // gbSubscriptionViews
            // 
            this.gbSubscriptionViews.Controls.Add(this.flowLayoutPanel4);
            this.gbSubscriptionViews.Controls.Add(this.gbBasedOn);
            this.gbSubscriptionViews.Controls.Add(this.lstExportViews);
            this.gbSubscriptionViews.Controls.Add(this.gbAppendViewName);
            this.gbSubscriptionViews.Controls.Add(this.gbImportViewMode);
            this.gbSubscriptionViews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSubscriptionViews.Location = new System.Drawing.Point(0, 55);
            this.gbSubscriptionViews.Name = "gbSubscriptionViews";
            this.gbSubscriptionViews.Padding = new System.Windows.Forms.Padding(6);
            this.gbSubscriptionViews.Size = new System.Drawing.Size(543, 164);
            this.gbSubscriptionViews.TabIndex = 28;
            this.gbSubscriptionViews.TabStop = false;
            this.gbSubscriptionViews.Text = "Subscription Views";
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.btDeleteViews);
            this.flowLayoutPanel4.Controls.Add(this.btImportViews);
            this.flowLayoutPanel4.Controls.Add(this.btExport);
            this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(10, 19);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(285, 28);
            this.flowLayoutPanel4.TabIndex = 27;
            // 
            // btDeleteViews
            // 
            this.btDeleteViews.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDeleteViews.BackgroundImage = global::MDSManager2012.Desktop.Properties.Resources.delete_icon;
            this.btDeleteViews.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btDeleteViews.Location = new System.Drawing.Point(257, 3);
            this.btDeleteViews.Name = "btDeleteViews";
            this.btDeleteViews.Size = new System.Drawing.Size(25, 25);
            this.btDeleteViews.TabIndex = 6;
            this.toolTip2.SetToolTip(this.btDeleteViews, "Delete subscription views");
            this.btDeleteViews.UseVisualStyleBackColor = true;
            this.btDeleteViews.Click += new System.EventHandler(this.btDeleteViews_Click);
            // 
            // btImportViews
            // 
            this.btImportViews.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btImportViews.BackgroundImage = global::MDSManager2012.Desktop.Properties.Resources.import_icon;
            this.btImportViews.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btImportViews.Location = new System.Drawing.Point(226, 3);
            this.btImportViews.Name = "btImportViews";
            this.btImportViews.Size = new System.Drawing.Size(25, 25);
            this.btImportViews.TabIndex = 5;
            this.toolTip2.SetToolTip(this.btImportViews, "Import views");
            this.btImportViews.UseVisualStyleBackColor = true;
            this.btImportViews.Click += new System.EventHandler(this.btImportViews_Click);
            // 
            // btExport
            // 
            this.btExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btExport.BackgroundImage = global::MDSManager2012.Desktop.Properties.Resources.export_icon;
            this.btExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btExport.Location = new System.Drawing.Point(195, 3);
            this.btExport.Name = "btExport";
            this.btExport.Size = new System.Drawing.Size(25, 25);
            this.btExport.TabIndex = 4;
            this.toolTip2.SetToolTip(this.btExport, "Export subscription views");
            this.btExport.UseVisualStyleBackColor = true;
            this.btExport.Click += new System.EventHandler(this.btExportViews_Click);
            // 
            // gbMembers
            // 
            this.gbMembers.Controls.Add(this.tableLayoutPanel1);
            this.gbMembers.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbMembers.Location = new System.Drawing.Point(0, 219);
            this.gbMembers.Name = "gbMembers";
            this.gbMembers.Size = new System.Drawing.Size(543, 452);
            this.gbMembers.TabIndex = 29;
            this.gbMembers.TabStop = false;
            this.gbMembers.Text = "Members / Attributes";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.43948F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.56052F));
            this.tableLayoutPanel1.Controls.Add(this.gbAttributes, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ucManageMembers1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(537, 433);
            this.tableLayoutPanel1.TabIndex = 36;
            // 
            // gbAttributes
            // 
            this.gbAttributes.Controls.Add(this.flowLayoutPanel2);
            this.gbAttributes.Controls.Add(this.label13);
            this.gbAttributes.Controls.Add(this.txtValidationStatus);
            this.gbAttributes.Controls.Add(this.label10);
            this.gbAttributes.Controls.Add(this.txtAttributeType);
            this.gbAttributes.Controls.Add(this.label2);
            this.gbAttributes.Controls.Add(this.label4);
            this.gbAttributes.Controls.Add(this.txtAttributeName);
            this.gbAttributes.Controls.Add(this.txtAttributeValue);
            this.gbAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAttributes.Location = new System.Drawing.Point(3, 3);
            this.gbAttributes.Name = "gbAttributes";
            this.gbAttributes.Size = new System.Drawing.Size(383, 104);
            this.gbAttributes.TabIndex = 26;
            this.gbAttributes.TabStop = false;
            this.gbAttributes.Text = "Edit Member Attribute";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.Controls.Add(this.btValidateMember);
            this.flowLayoutPanel2.Controls.Add(this.btUpdateMember);
            this.flowLayoutPanel2.Controls.Add(this.btAddMember);
            this.flowLayoutPanel2.Controls.Add(this.btDeleteMemberAttribute);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(316, 17);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(61, 73);
            this.flowLayoutPanel2.TabIndex = 30;
            // 
            // btValidateMember
            // 
            this.btValidateMember.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btValidateMember.BackgroundImage = global::MDSManager2012.Desktop.Properties.Resources.validate_icon;
            this.btValidateMember.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btValidateMember.Location = new System.Drawing.Point(3, 3);
            this.btValidateMember.Name = "btValidateMember";
            this.btValidateMember.Size = new System.Drawing.Size(25, 25);
            this.btValidateMember.TabIndex = 27;
            this.toolTip2.SetToolTip(this.btValidateMember, "Validate member");
            this.btValidateMember.UseVisualStyleBackColor = true;
            this.btValidateMember.Click += new System.EventHandler(this.btValidateMember_Click);
            // 
            // btUpdateMember
            // 
            this.btUpdateMember.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btUpdateMember.Image = global::MDSManager2012.Desktop.Properties.Resources.edit_icon;
            this.btUpdateMember.Location = new System.Drawing.Point(3, 34);
            this.btUpdateMember.Name = "btUpdateMember";
            this.btUpdateMember.Size = new System.Drawing.Size(25, 25);
            this.btUpdateMember.TabIndex = 24;
            this.toolTip2.SetToolTip(this.btUpdateMember, "Update member");
            this.btUpdateMember.UseVisualStyleBackColor = true;
            this.btUpdateMember.Click += new System.EventHandler(this.btUpdateMember_Click);
            // 
            // btAddMember
            // 
            this.btAddMember.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAddMember.BackgroundImage = global::MDSManager2012.Desktop.Properties.Resources.add_1_icon;
            this.btAddMember.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btAddMember.Location = new System.Drawing.Point(34, 3);
            this.btAddMember.Name = "btAddMember";
            this.btAddMember.Size = new System.Drawing.Size(25, 25);
            this.btAddMember.TabIndex = 13;
            this.toolTip2.SetToolTip(this.btAddMember, "Add member");
            this.btAddMember.UseVisualStyleBackColor = true;
            this.btAddMember.Click += new System.EventHandler(this.btnAddMember_Click);
            // 
            // btDeleteMemberAttribute
            // 
            this.btDeleteMemberAttribute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDeleteMemberAttribute.BackgroundImage = global::MDSManager2012.Desktop.Properties.Resources.delete_icon;
            this.btDeleteMemberAttribute.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btDeleteMemberAttribute.Location = new System.Drawing.Point(34, 34);
            this.btDeleteMemberAttribute.Name = "btDeleteMemberAttribute";
            this.btDeleteMemberAttribute.Size = new System.Drawing.Size(25, 25);
            this.btDeleteMemberAttribute.TabIndex = 23;
            this.toolTip2.SetToolTip(this.btDeleteMemberAttribute, "Delete member");
            this.btDeleteMemberAttribute.UseVisualStyleBackColor = true;
            this.btDeleteMemberAttribute.Click += new System.EventHandler(this.btDeleteMember_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(126, 70);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "Status";
            // 
            // txtValidationStatus
            // 
            this.txtValidationStatus.Location = new System.Drawing.Point(176, 68);
            this.txtValidationStatus.Name = "txtValidationStatus";
            this.txtValidationStatus.ReadOnly = true;
            this.txtValidationStatus.Size = new System.Drawing.Size(134, 20);
            this.txtValidationStatus.TabIndex = 28;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Type";
            // 
            // txtAttributeType
            // 
            this.txtAttributeType.Location = new System.Drawing.Point(51, 67);
            this.txtAttributeType.Name = "txtAttributeType";
            this.txtAttributeType.ReadOnly = true;
            this.txtAttributeType.Size = new System.Drawing.Size(67, 20);
            this.txtAttributeType.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Value";
            // 
            // txtAttributeName
            // 
            this.txtAttributeName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAttributeName.Location = new System.Drawing.Point(51, 17);
            this.txtAttributeName.Name = "txtAttributeName";
            this.txtAttributeName.Size = new System.Drawing.Size(265, 20);
            this.txtAttributeName.TabIndex = 14;
            // 
            // txtAttributeValue
            // 
            this.txtAttributeValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAttributeValue.Location = new System.Drawing.Point(51, 41);
            this.txtAttributeValue.Name = "txtAttributeValue";
            this.txtAttributeValue.Size = new System.Drawing.Size(265, 20);
            this.txtAttributeValue.TabIndex = 15;
            // 
            // ucManageMembers1
            // 
            this.ucManageMembers1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.ucManageMembers1, 2);
            this.ucManageMembers1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucManageMembers1.Location = new System.Drawing.Point(3, 113);
            this.ucManageMembers1.Name = "ucManageMembers1";
            this.ucManageMembers1.Size = new System.Drawing.Size(531, 317);
            this.ucManageMembers1.TabIndex = 35;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.btDeleteAllMembersFromAllEntities);
            this.groupBox1.Controls.Add(this.btnDeleteAllMembers);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(392, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(142, 104);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Delete all members";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(39, 54);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 13);
            this.label12.TabIndex = 29;
            this.label12.Text = "From model";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(39, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "From entity";
            // 
            // btDeleteAllMembersFromAllEntities
            // 
            this.btDeleteAllMembersFromAllEntities.BackgroundImage = global::MDSManager2012.Desktop.Properties.Resources.delete_icon;
            this.btDeleteAllMembersFromAllEntities.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btDeleteAllMembersFromAllEntities.Location = new System.Drawing.Point(8, 50);
            this.btDeleteAllMembersFromAllEntities.Name = "btDeleteAllMembersFromAllEntities";
            this.btDeleteAllMembersFromAllEntities.Size = new System.Drawing.Size(25, 25);
            this.btDeleteAllMembersFromAllEntities.TabIndex = 27;
            this.btDeleteAllMembersFromAllEntities.UseVisualStyleBackColor = true;
            this.btDeleteAllMembersFromAllEntities.Click += new System.EventHandler(this.btDeleteAllMembersFromAllEntities_Click);
            // 
            // btnDeleteAllMembers
            // 
            this.btnDeleteAllMembers.BackgroundImage = global::MDSManager2012.Desktop.Properties.Resources.delete_icon;
            this.btnDeleteAllMembers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDeleteAllMembers.Location = new System.Drawing.Point(8, 24);
            this.btnDeleteAllMembers.Name = "btnDeleteAllMembers";
            this.btnDeleteAllMembers.Size = new System.Drawing.Size(25, 25);
            this.btnDeleteAllMembers.TabIndex = 26;
            this.btnDeleteAllMembers.UseVisualStyleBackColor = true;
            this.btnDeleteAllMembers.Click += new System.EventHandler(this.btnDeleteAllMembers_Click);
            // 
            // gbConnection
            // 
            this.gbConnection.Controls.Add(this.btConnManager);
            this.gbConnection.Controls.Add(this.cbEndPointAddress);
            this.gbConnection.Controls.Add(this.btRefreshConnection);
            this.gbConnection.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbConnection.Location = new System.Drawing.Point(0, 0);
            this.gbConnection.MinimumSize = new System.Drawing.Size(0, 55);
            this.gbConnection.Name = "gbConnection";
            this.gbConnection.Size = new System.Drawing.Size(543, 55);
            this.gbConnection.TabIndex = 27;
            this.gbConnection.TabStop = false;
            this.gbConnection.Text = "Select Connection Configuration";
            // 
            // cbEndPointAddress
            // 
            this.cbEndPointAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbEndPointAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEndPointAddress.FormattingEnabled = true;
            this.cbEndPointAddress.Location = new System.Drawing.Point(7, 21);
            this.cbEndPointAddress.Name = "cbEndPointAddress";
            this.cbEndPointAddress.Size = new System.Drawing.Size(370, 21);
            this.cbEndPointAddress.TabIndex = 32;
            this.cbEndPointAddress.SelectionChangeCommitted += new System.EventHandler(this.cbEndPointAddress_SelectionChangeCommitted);
            // 
            // groupBoxVersions
            // 
            this.groupBoxVersions.Controls.Add(this.tableLayoutPanel3);
            this.groupBoxVersions.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxVersions.Location = new System.Drawing.Point(0, 151);
            this.groupBoxVersions.Name = "groupBoxVersions";
            this.groupBoxVersions.Size = new System.Drawing.Size(317, 128);
            this.groupBoxVersions.TabIndex = 39;
            this.groupBoxVersions.TabStop = false;
            this.groupBoxVersions.Text = "Versions";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lstFlags, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.lstVersions, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanel3, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.1028F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 72.89719F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(311, 109);
            this.tableLayoutPanel3.TabIndex = 42;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btDeleteVersion);
            this.flowLayoutPanel1.Controls.Add(this.btVersionCopy);
            this.flowLayoutPanel1.Controls.Add(this.btValidateVersion);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(155, 29);
            this.flowLayoutPanel1.TabIndex = 41;
            // 
            // btDeleteVersion
            // 
            this.btDeleteVersion.AutoSize = true;
            this.btDeleteVersion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btDeleteVersion.Image = global::MDSManager2012.Desktop.Properties.Resources.delete_icon;
            this.btDeleteVersion.Location = new System.Drawing.Point(3, 3);
            this.btDeleteVersion.Name = "btDeleteVersion";
            this.btDeleteVersion.Size = new System.Drawing.Size(25, 25);
            this.btDeleteVersion.TabIndex = 32;
            this.toolTip2.SetToolTip(this.btDeleteVersion, "Delete version");
            this.btDeleteVersion.UseVisualStyleBackColor = true;
            this.btDeleteVersion.Click += new System.EventHandler(this.btDeleteVersion_Click);
            // 
            // btVersionCopy
            // 
            this.btVersionCopy.BackgroundImage = global::MDSManager2012.Desktop.Properties.Resources.pn_add_source_copy;
            this.btVersionCopy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btVersionCopy.Location = new System.Drawing.Point(34, 3);
            this.btVersionCopy.Name = "btVersionCopy";
            this.btVersionCopy.Size = new System.Drawing.Size(25, 25);
            this.btVersionCopy.TabIndex = 34;
            this.btVersionCopy.UseVisualStyleBackColor = true;
            this.btVersionCopy.Click += new System.EventHandler(this.btVersionCopy_Click);
            // 
            // btValidateVersion
            // 
            this.btValidateVersion.AutoSize = true;
            this.btValidateVersion.BackgroundImage = global::MDSManager2012.Desktop.Properties.Resources.validate_icon;
            this.btValidateVersion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btValidateVersion.Location = new System.Drawing.Point(65, 3);
            this.btValidateVersion.Name = "btValidateVersion";
            this.btValidateVersion.Size = new System.Drawing.Size(25, 25);
            this.btValidateVersion.TabIndex = 35;
            this.btValidateVersion.UseVisualStyleBackColor = true;
            this.btValidateVersion.Click += new System.EventHandler(this.btValidateVersion_Click);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.btRefreshVersionAndFlagLists);
            this.flowLayoutPanel3.Controls.Add(this.btDeleteFlag);
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(155, 0);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(156, 29);
            this.flowLayoutPanel3.TabIndex = 42;
            // 
            // btRefreshVersionAndFlagLists
            // 
            this.btRefreshVersionAndFlagLists.AutoSize = true;
            this.btRefreshVersionAndFlagLists.BackgroundImage = global::MDSManager2012.Desktop.Properties.Resources.validate_icon;
            this.btRefreshVersionAndFlagLists.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btRefreshVersionAndFlagLists.Location = new System.Drawing.Point(128, 3);
            this.btRefreshVersionAndFlagLists.Name = "btRefreshVersionAndFlagLists";
            this.btRefreshVersionAndFlagLists.Size = new System.Drawing.Size(25, 25);
            this.btRefreshVersionAndFlagLists.TabIndex = 31;
            this.btRefreshVersionAndFlagLists.UseVisualStyleBackColor = true;
            this.btRefreshVersionAndFlagLists.Click += new System.EventHandler(this.btRefreshVersionAndFlagLists_Click);
            // 
            // btDeleteFlag
            // 
            this.btDeleteFlag.BackgroundImage = global::MDSManager2012.Desktop.Properties.Resources.delete_icon;
            this.btDeleteFlag.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btDeleteFlag.Location = new System.Drawing.Point(97, 3);
            this.btDeleteFlag.Name = "btDeleteFlag";
            this.btDeleteFlag.Size = new System.Drawing.Size(25, 25);
            this.btDeleteFlag.TabIndex = 33;
            this.btDeleteFlag.UseVisualStyleBackColor = true;
            this.btDeleteFlag.Click += new System.EventHandler(this.btDeleteFlag_Click);
            // 
            // groupBoxModels
            // 
            this.groupBoxModels.Controls.Add(this.btRefreshModels);
            this.groupBoxModels.Controls.Add(this.lstModels);
            this.groupBoxModels.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxModels.Location = new System.Drawing.Point(0, 0);
            this.groupBoxModels.Name = "groupBoxModels";
            this.groupBoxModels.Size = new System.Drawing.Size(317, 151);
            this.groupBoxModels.TabIndex = 38;
            this.groupBoxModels.TabStop = false;
            this.groupBoxModels.Text = "Models";
            // 
            // btRefreshModels
            // 
            this.btRefreshModels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRefreshModels.BackgroundImage = global::MDSManager2012.Desktop.Properties.Resources.Button_Refresh_icon;
            this.btRefreshModels.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btRefreshModels.Location = new System.Drawing.Point(287, 120);
            this.btRefreshModels.Name = "btRefreshModels";
            this.btRefreshModels.Size = new System.Drawing.Size(25, 25);
            this.btRefreshModels.TabIndex = 30;
            this.toolTip2.SetToolTip(this.btRefreshModels, "Refresh models");
            this.btRefreshModels.UseVisualStyleBackColor = true;
            this.btRefreshModels.Click += new System.EventHandler(this.btRefreshModels_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialog1.SelectedPath = "C:\\";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(26, 213);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 23);
            this.button1.TabIndex = 52;
            this.button1.Text = "test CreateBR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btTestExportViewUpdate
            // 
            this.btTestExportViewUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btTestExportViewUpdate.Location = new System.Drawing.Point(11, 242);
            this.btTestExportViewUpdate.Name = "btTestExportViewUpdate";
            this.btTestExportViewUpdate.Size = new System.Drawing.Size(133, 23);
            this.btTestExportViewUpdate.TabIndex = 53;
            this.btTestExportViewUpdate.Text = "test ExportViewUpdate";
            this.btTestExportViewUpdate.UseVisualStyleBackColor = true;
            this.btTestExportViewUpdate.Visible = false;
            this.btTestExportViewUpdate.Click += new System.EventHandler(this.btTestExportViewUpdate_Click);
            // 
            // pictureBoxInfo
            // 
            this.pictureBoxInfo.BackgroundImage = global::MDSManager2012.Desktop.Properties.Resources.info_icon;
            this.pictureBoxInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxInfo.Location = new System.Drawing.Point(993, 620);
            this.pictureBoxInfo.Name = "pictureBoxInfo";
            this.pictureBoxInfo.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxInfo.TabIndex = 34;
            this.pictureBoxInfo.TabStop = false;
            this.pictureBoxInfo.Click += new System.EventHandler(this.pictureBoxInfo_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.06564F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.93436F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 157F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.pnMiddle, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.pnRight, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1030, 697);
            this.tableLayoutPanel2.TabIndex = 54;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBoxEntities);
            this.panel2.Controls.Add(this.groupBoxVersions);
            this.panel2.Controls.Add(this.groupBoxModels);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(317, 671);
            this.panel2.TabIndex = 31;
            // 
            // groupBoxEntities
            // 
            this.groupBoxEntities.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxEntities.Controls.Add(this.ucManageEntities1);
            this.groupBoxEntities.Location = new System.Drawing.Point(0, 281);
            this.groupBoxEntities.Name = "groupBoxEntities";
            this.groupBoxEntities.Size = new System.Drawing.Size(314, 390);
            this.groupBoxEntities.TabIndex = 40;
            this.groupBoxEntities.TabStop = false;
            this.groupBoxEntities.Text = "Entities";
            // 
            // ucManageEntities1
            // 
            this.ucManageEntities1.AutoSize = true;
            this.ucManageEntities1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucManageEntities1.Location = new System.Drawing.Point(3, 16);
            this.ucManageEntities1.Name = "ucManageEntities1";
            this.ucManageEntities1.Size = new System.Drawing.Size(308, 371);
            this.ucManageEntities1.TabIndex = 36;
            // 
            // pnMiddle
            // 
            this.pnMiddle.Controls.Add(this.gbSubscriptionViews);
            this.pnMiddle.Controls.Add(this.gbConnection);
            this.pnMiddle.Controls.Add(this.gbMembers);
            this.pnMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMiddle.Location = new System.Drawing.Point(326, 3);
            this.pnMiddle.Name = "pnMiddle";
            this.pnMiddle.Size = new System.Drawing.Size(543, 671);
            this.pnMiddle.TabIndex = 32;
            // 
            // pnRight
            // 
            this.pnRight.Controls.Add(this.btEntityManager);
            this.pnRight.Controls.Add(this.btBusinessRulesManager);
            this.pnRight.Controls.Add(this.btTestExportViewUpdate);
            this.pnRight.Controls.Add(this.btModelDiagramManager);
            this.pnRight.Controls.Add(this.button1);
            this.pnRight.Controls.Add(this.btPackageDeploy);
            this.pnRight.Controls.Add(this.btUserRightsManager);
            this.pnRight.Controls.Add(this.btTest);
            this.pnRight.Controls.Add(this.btTest2);
            this.pnRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnRight.Location = new System.Drawing.Point(875, 3);
            this.pnRight.Name = "pnRight";
            this.pnRight.Size = new System.Drawing.Size(152, 671);
            this.pnRight.TabIndex = 33;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 697);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1030, 25);
            this.statusStrip1.TabIndex = 55;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // progressBar1
            // 
            this.progressBar1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 19);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 20);
            this.toolStripStatusLabel1.Text = "Status";
            // 
            // panelMainContent
            // 
            this.panelMainContent.Controls.Add(this.tableLayoutPanel2);
            this.panelMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainContent.Location = new System.Drawing.Point(0, 0);
            this.panelMainContent.Name = "panelMainContent";
            this.panelMainContent.Size = new System.Drawing.Size(1030, 697);
            this.panelMainContent.TabIndex = 51;
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1030, 722);
            this.Controls.Add(this.panelMainContent);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pictureBoxInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "MDS Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.gbImportViewMode.ResumeLayout(false);
            this.gbImportViewMode.PerformLayout();
            this.gbAppendViewName.ResumeLayout(false);
            this.gbAppendViewName.PerformLayout();
            this.gbBasedOn.ResumeLayout(false);
            this.gbBasedOn.PerformLayout();
            this.gbSubscriptionViews.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.gbMembers.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.gbAttributes.ResumeLayout(false);
            this.gbAttributes.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbConnection.ResumeLayout(false);
            this.groupBoxVersions.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.groupBoxModels.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInfo)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBoxEntities.ResumeLayout(false);
            this.groupBoxEntities.PerformLayout();
            this.pnMiddle.ResumeLayout(false);
            this.pnRight.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelMainContent.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

      
        private Button button1;
        private Button btTestExportViewUpdate;
        private GroupBox groupBoxVersions;
        private GroupBox groupBoxModels;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel pnMiddle;
        private Panel pnRight;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripProgressBar progressBar1;
        private Panel panelMainContent;
        private Panel panel2;
        private GroupBox groupBoxEntities;
        private ToolTip toolTip2;
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel3;
        private FlowLayoutPanel flowLayoutPanel3;
        private FlowLayoutPanel flowLayoutPanel4;
    }
}


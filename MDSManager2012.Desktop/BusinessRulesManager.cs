// Type: MDSManager.BusinessRulesManager
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
using MDSManager2012.Desktop.AppLogic;

namespace MDSManager2012.Desktop
{
    public class BusinessRulesManager : Form
    {
        private IContainer components = (IContainer)null;
        private ToolTip toolTip1;
        private GroupBox groupBox2;
        private Label lbBusinessRules;
        private Button btCopyBRListClipboard;
        private CheckBox ckSelectAll;
        private FolderBrowserDialog folderBrowserDialog1;
        private OpenFileDialog openFileDialog1;
        private Button btBRvalidate;
        private ToolStrip toolStrip1;
        private ToolStripComboBox cbModel;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btDeleteAll;
        private ToolStripButton btPublishAll;
        private ToolStripComboBox cbVersion;
        private DataGridView dgRules;
        private ToolStripSplitButton btExport;
        private ToolStripMenuItem btExportXML;
        private ToolStripMenuItem btExportCSV;
        private ToolStripComboBox cbConnection;
        private SplitContainer splitContainer1;
        private ToolStrip toolStrip2;
        private ToolStripComboBox cbConnection2;
        private ToolStripComboBox cbModel2;
        private ToolStripComboBox cbVersion2;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSplitButton btExport2;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private CheckBox checkBox1;
        private DataGridView dgRules2;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripSeparator toolStripSeparator3;
        private Button bTCopyBR;
        private SaveFileDialog saveFileDialog1;
        //The business rules associated to the first grid view.
        private BusinessRules businessRules1;
        //The business rules associated to the second grid view.
        private BusinessRules businessRules2;
        public BusinessRulesManager()
        {
            this.InitializeComponent();
        }



        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BusinessRulesManager));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btBRvalidate = new System.Windows.Forms.Button();
            this.btCopyBRListClipboard = new System.Windows.Forms.Button();
            this.lbBusinessRules = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ckSelectAll = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cbConnection = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.cbModel = new System.Windows.Forms.ToolStripComboBox();
            this.cbVersion = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btExport = new System.Windows.Forms.ToolStripSplitButton();
            this.btExportXML = new System.Windows.Forms.ToolStripMenuItem();
            this.btExportCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.btDeleteAll = new System.Windows.Forms.ToolStripButton();
            this.btPublishAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.dgRules = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.bTCopyBR = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.dgRules2 = new System.Windows.Forms.DataGridView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.cbConnection2 = new System.Windows.Forms.ToolStripComboBox();
            this.cbModel2 = new System.Windows.Forms.ToolStripComboBox();
            this.cbVersion2 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btExport2 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRules2)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox2, 2);
            this.groupBox2.Controls.Add(this.btBRvalidate);
            this.groupBox2.Controls.Add(this.btCopyBRListClipboard);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 568);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1264, 62);
            this.groupBox2.TabIndex = 57;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Actions";
            // 
            // btBRvalidate
            // 
            this.btBRvalidate.Location = new System.Drawing.Point(164, 21);
            this.btBRvalidate.Name = "btBRvalidate";
            this.btBRvalidate.Size = new System.Drawing.Size(72, 26);
            this.btBRvalidate.TabIndex = 41;
            this.btBRvalidate.Text = "Validate";
            this.btBRvalidate.UseVisualStyleBackColor = true;
            // 
            // btCopyBRListClipboard
            // 
            this.btCopyBRListClipboard.Location = new System.Drawing.Point(6, 21);
            this.btCopyBRListClipboard.Name = "btCopyBRListClipboard";
            this.btCopyBRListClipboard.Size = new System.Drawing.Size(142, 26);
            this.btCopyBRListClipboard.TabIndex = 39;
            this.btCopyBRListClipboard.Text = "Copy to clipboard";
            this.toolTip1.SetToolTip(this.btCopyBRListClipboard, "Copy business rules names to clipboard");
            this.btCopyBRListClipboard.UseVisualStyleBackColor = true;
            this.btCopyBRListClipboard.Click += new System.EventHandler(this.btCopyBRListClipboard_Click);
            // 
            // lbBusinessRules
            // 
            this.lbBusinessRules.AutoSize = true;
            this.lbBusinessRules.Location = new System.Drawing.Point(9, 55);
            this.lbBusinessRules.Name = "lbBusinessRules";
            this.lbBusinessRules.Size = new System.Drawing.Size(105, 17);
            this.lbBusinessRules.TabIndex = 54;
            this.lbBusinessRules.Text = "Business Rules";
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
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
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "XML files|*.xml";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbConnection,
            this.toolStripSeparator5,
            this.cbModel,
            this.cbVersion,
            this.toolStripSeparator1,
            this.btExport,
            this.btDeleteAll,
            this.btPublishAll,
            this.toolStripSeparator3});
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
            this.cbConnection.Click += new System.EventHandler(this.cbConnection_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 28);
            // 
            // cbModel
            // 
            this.cbModel.Enabled = false;
            this.cbModel.Name = "cbModel";
            this.cbModel.Size = new System.Drawing.Size(150, 28);
            this.cbModel.Text = "Select a model";
            this.cbModel.ToolTipText = "Model";
            this.cbModel.SelectedIndexChanged += new System.EventHandler(this.cbModel_SelectedIndexChanged);
            // 
            // cbVersion
            // 
            this.cbVersion.Enabled = false;
            this.cbVersion.Name = "cbVersion";
            this.cbVersion.Size = new System.Drawing.Size(130, 28);
            this.cbVersion.Text = "Select a version";
            this.cbVersion.ToolTipText = "Model versions";
            this.cbVersion.SelectedIndexChanged += new System.EventHandler(this.cbVersion_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
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
            // btDeleteAll
            // 
            this.btDeleteAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btDeleteAll.Image = ((System.Drawing.Image)(resources.GetObject("btDeleteAll.Image")));
            this.btDeleteAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btDeleteAll.Name = "btDeleteAll";
            this.btDeleteAll.Size = new System.Drawing.Size(77, 24);
            this.btDeleteAll.Text = "Delete all";
            this.btDeleteAll.Click += new System.EventHandler(this.btDeleteAll_Click);
            // 
            // btPublishAll
            // 
            this.btPublishAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btPublishAll.Image = ((System.Drawing.Image)(resources.GetObject("btPublishAll.Image")));
            this.btPublishAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btPublishAll.Name = "btPublishAll";
            this.btPublishAll.Size = new System.Drawing.Size(60, 24);
            this.btPublishAll.Text = "Publish";
            this.btPublishAll.Click += new System.EventHandler(this.btPublishAll_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 28);
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
            this.dgRules.Size = new System.Drawing.Size(612, 434);
            this.dgRules.TabIndex = 63;
            this.dgRules.SelectionChanged += new System.EventHandler(this.dgRules_SelectionChanged);
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
            this.splitContainer1.Size = new System.Drawing.Size(1264, 559);
            this.splitContainer1.SplitterDistance = 626;
            this.splitContainer1.TabIndex = 64;
            // 
            // bTCopyBR
            // 
            this.bTCopyBR.Enabled = false;
            this.bTCopyBR.Location = new System.Drawing.Point(452, 518);
            this.bTCopyBR.Name = "bTCopyBR";
            this.bTCopyBR.Size = new System.Drawing.Size(166, 30);
            this.bTCopyBR.TabIndex = 64;
            this.bTCopyBR.Text = "Copy to >>>>";
            this.bTCopyBR.UseVisualStyleBackColor = true;
            this.bTCopyBR.Click += new System.EventHandler(this.bTCopyBR_Click);
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
            this.dgRules2.Size = new System.Drawing.Size(626, 434);
            this.dgRules2.TabIndex = 64;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbConnection2,
            this.cbModel2,
            this.cbVersion2,
            this.toolStripSeparator2,
            this.btExport2,
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(626, 28);
            this.toolStrip2.TabIndex = 63;
            this.toolStrip2.Text = "toolStrip2";
            this.toolStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip2_ItemClicked);
            // 
            // cbConnection2
            // 
            this.cbConnection2.Name = "cbConnection2";
            this.cbConnection2.Size = new System.Drawing.Size(200, 28);
            this.cbConnection2.Text = "Connection";
            // 
            // cbModel2
            // 
            this.cbModel2.Enabled = false;
            this.cbModel2.Name = "cbModel2";
            this.cbModel2.Size = new System.Drawing.Size(150, 28);
            this.cbModel2.Text = "Select a model";
            this.cbModel2.ToolTipText = "Model";
            this.cbModel2.SelectedIndexChanged += new System.EventHandler(this.cbModel_SelectedIndexChanged);
            // 
            // cbVersion2
            // 
            this.cbVersion2.Enabled = false;
            this.cbVersion2.Name = "cbVersion2";
            this.cbVersion2.Size = new System.Drawing.Size(130, 28);
            this.cbVersion2.Text = "Select a version";
            this.cbVersion2.ToolTipText = "Model versions";
            this.cbVersion2.SelectedIndexChanged += new System.EventHandler(this.cbVersion_SelectedIndexChanged);
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
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(77, 24);
            this.toolStripButton1.Text = "Delete all";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(60, 24);
            this.toolStripButton2.Text = "Publish";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.79578F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1270, 633);
            this.tableLayoutPanel1.TabIndex = 39;
            // 
            // BusinessRulesManager
            // 
            this.ClientSize = new System.Drawing.Size(1282, 645);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "BusinessRulesManager";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Text = "Business Rules Manager";
            this.Load += new System.EventHandler(this.BusinessRulesManager_Load);
            this.groupBox2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRules)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgRules2)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void BusinessRulesManager_Load(object sender, EventArgs e)
        {
            cbModel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
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



        public void GetModels(object sender)
        {
            try
            {
                var cbConnectionSender = sender as ComboBox;
                ComboBox cbModels = null;

                if (cbConnectionSender == cbConnection.ComboBox)
                    cbModels = cbModel.ComboBox;
                else if (cbConnectionSender == cbConnection2.ComboBox)
                    cbModels = cbModel2.ComboBox;

                if (cbModels == null)
                    throw new ArgumentException("sender");


                Cursor.Current = Cursors.WaitCursor;
                cbModel.Enabled = false;
                MDSWrapper.Configuration = cbConnectionSender.SelectedItem as ConfigValue;
                var modelList = MDSWrapper.ModelGet();

                cbModels.Items.Clear();

                if (modelList != null && modelList.Count > 0)
                {
                    foreach (Model model in modelList)
                    {
                        cbModels.Items.Add(model.Identifier);

                    }
                    cbModels.Enabled = true;
                    cbModels.DisplayMember = "Name";

                }
                else
                    MessageBox.Show("It was not possible to retrieve models or no models to display.");
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

        public void GetVersions(object sender, ComboBox versionsComboBox)
        {
            try
            {
                var modelId = (sender as ToolStripComboBox).SelectedItem as Identifier;
                Cursor.Current = Cursors.WaitCursor;
                var versions = MDSWrapper.GetVersionsAndFlagsInMetaData(modelId);
                versionsComboBox.Items.Clear();

                if (versions != null && versions.Versions.Any())
                {
                    versionsComboBox.Text = "Select Version";
                    foreach (var version in versions.Versions)
                    {
                        versionsComboBox.Items.Add(version.Identifier);

                    }
                    versionsComboBox.DisplayMember = "Name";

                }
                else
                    MessageBox.Show("It was not possible to retrieve versions or no versions to display.");
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



        private void RefreshBRList(object sender)
        {
            try
            {
                Identifier modelId = null;
                DataGridView ruleDataGrid = null;

                if (sender == cbVersion)
                {
                    modelId = cbModel.SelectedItem as Identifier;
                    ruleDataGrid = dgRules;
                }

                if (sender == cbVersion2)
                {
                    modelId = cbModel2.SelectedItem as Identifier;
                    ruleDataGrid = dgRules2;
                }

                if (modelId == null)
                    throw new ArgumentException("sender");

                Cursor.Current = Cursors.WaitCursor;

                BRGetCriteria GetCriteria = new BRGetCriteria()
                {
                    ModelId = modelId,
                    MemberType = BREntityMemberType.Leaf
                };
                BRResultOptions ResultOptions = new BRResultOptions { BusinessRules = ResultType.Details };
                OperationResult OperationResult;

                var dataSet = MDSDataUtils.NewBusinessRuleDataTable();

                var businessRules = MDSWrapper.ServiceClient.BusinessRulesGet(new International(), GetCriteria, ResultOptions, out OperationResult);

                foreach (BusinessRule businessRule in businessRules.BusinessRulesMember)
                {
                    MDSDataUtils.NewBRDataRow(dataSet, businessRule);

                }
                if (sender == cbVersion)
                {
                    businessRules1 = businessRules;
                }
                else
                {
                    businessRules2 = businessRules;
                }
                ruleDataGrid.DataSource = dataSet;
                //hiding the column ID
                ruleDataGrid.Columns[0].Visible = false;

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

        [Obsolete]
        private void btBRCopy_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
            try
            {
                //StringBuilder stringBuilder = new StringBuilder();
                //Cursor.Current = Cursors.WaitCursor;
                //Identifier SourceModelId = this.cbModel.SelectedItem as Identifier;
                //BusinessRules businessRules = MDSWrapper.BusinessRulesGet(SourceModelId);
                //string text = MDSWrapper.BusinessRulesClone(businessRules, SourceModelId, identifier);
                //if (!string.IsNullOrEmpty(text))
                //{
                //    MessageBox.Show(text);
                //}
                //if (stringBuilder.Length > 0)
                //{
                //    MessageBox.Show(((object)stringBuilder).ToString());
                //}
                //else
                //{
                //    MessageBox.Show("DONE!");
                //}
                //RefreshBRList();
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



        private void btImportBR_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                Cursor.Current = Cursors.WaitCursor;
                if (cbModel.SelectedItem == null)
                {
                    MessageBox.Show("You must select a model where to import business rules file!");
                    return;
                }
                Identifier targetModelId = this.cbModel.SelectedItem as Identifier;
                Cursor.Current = Cursors.WaitCursor;

                BusinessRules businessRules = MDSWrapper.BusinessRuleDeserialize(openFileDialog1.FileName);
                stringBuilder.Append(MDSWrapper.BusinessRulesClone(businessRules, targetModelId));
                if (stringBuilder.Length > 0)
                {
                    MessageBox.Show(stringBuilder.ToString());
                }
                else
                {
                    MessageBox.Show("DONE!");
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


        private void btBRvalidate_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //EntityMembers entityMembers = new EntityMembers();
                //entityMembers.EntityId = new Identifier() { Name = "TestEntity" };
                //entityMembers.ModelId = new Identifier() { Name = "TestModel" };
                //entityMembers.VersionId = new Identifier() { Name = "VERSION_1" };
                //entityMembers.MemberType = new MemberType?(MemberType.NotSpecified);
                //entityMembers.MemberType = new MemberType?(MemberType.Leaf);
                //entityMembers.Members = new List<Common.MDSService.Member>();


                ValidationProcessCriteria ValidationProcessCriteria = new ValidationProcessCriteria();
                ValidationProcessCriteria.EntityId = new Identifier() { Name = "TestEntity" };
                //ValidationProcessCriteria.Members = entityMembers.Members.Select(x => x.MemberId).ToList();
                ValidationProcessCriteria.ModelId = cbModel.SelectedItem as Identifier;
                ValidationProcessCriteria.VersionId = new Identifier() { Name = "VERSION_1" };
                var ValidationProcessOptions = new ValidationProcessOptions();
                ValidationProcessOptions.CommitVersion = false;
                ValidationProcessOptions.ReturnValidationResults = true;
                List<ValidationIssue> ValidationIssueList = new List<ValidationIssue>();
                ValidationProcessResult ValidationProcessResult = new ValidationProcessResult();
                OperationResult operationResult = MDSWrapper.ServiceClient.ValidationProcess(new International(), ValidationProcessCriteria, ValidationProcessOptions, out ValidationIssueList, out ValidationProcessResult);
                StringBuilder stringBuilder1 = new StringBuilder();
                if (operationResult.Errors != null && operationResult.Errors.Count > 0)
                {
                    foreach (Common.MDSService.Error error in operationResult.Errors)
                        stringBuilder1.AppendLine(error.Code + " -- " + error.Description);
                }
                stringBuilder1.AppendLine("MembersInvalidCount=" + ValidationProcessResult.MembersInvalidCount.ToString());
                StringBuilder stringBuilder2 = stringBuilder1;
                string str1 = "MembersValidatedCount=";
                int num1 = ValidationProcessResult.MembersValidatedCount;
                string str2 = num1.ToString();
                string str3 = str1 + str2;
                stringBuilder2.AppendLine(str3);
                StringBuilder stringBuilder3 = stringBuilder1;
                string str4 = "MembersValidCount=";
                num1 = ValidationProcessResult.MembersValidCount;
                string str5 = num1.ToString();
                string str6 = str4 + str5;
                stringBuilder3.AppendLine(str6);
                MessageBox.Show(stringBuilder1.ToString(), "Information & Errors");
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


        private void btDeleteAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure that you want to delete all business rules?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                BusinessRules businessRules = MDSWrapper.BusinessRulesGet(cbModel.SelectedItem as Identifier);

                var deleteCriteria = new BRDeleteCriteria
                {
                    BusinessRules = new List<Guid>(),
                    BRItems = new List<Guid>(),
                    BRConditionTreeNodes = new List<Guid>()
                };
                foreach (BusinessRule businessRule in businessRules.BusinessRulesMember)
                    deleteCriteria.BusinessRules.Add(businessRule.Identifier.Id);
                foreach (BRConditionTreeNode conditionTreeNode in businessRules.BRConditionTreeNodes)
                    deleteCriteria.BRConditionTreeNodes.Add(conditionTreeNode.Identifier.Id);
                OperationResult operationResult = MDSWrapper.ServiceClient.BusinessRulesDelete(new International(), deleteCriteria);

                Tools.HandleErrors(operationResult, true);
                MessageBox.Show("Operation completed!");
                RefreshBRList(cbModel);

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


        private void btPublishAll_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                BRPublishCriteria BRPublishCriteria = new BRPublishCriteria()
                {
                    ModelId = this.cbModel.SelectedItem as Identifier,
                    MemberType = BREntityMemberType.Leaf
                };
                OperationResult operationResult = MDSWrapper.ServiceClient.BusinessRulesPublish(new International(), BRPublishCriteria);
                if (operationResult != null && operationResult.Errors.Count > 0)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (Common.MDSService.Error error in operationResult.Errors)
                        stringBuilder.AppendFormat("{0}" + Environment.NewLine, (object)(error.Code + " - " + error.Description));
                    MessageBox.Show(((object)stringBuilder).ToString());
                }
                else
                {
                    MessageBox.Show("Business rules published!");
                }

                this.RefreshBRList(cbModel);
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



        private void cbVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshBRList(sender);
            btExport.Enabled = true;
        }



        private void btExportXML_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                saveFileDialog1.Filter = "XML files|*.xml";
                if (this.cbModel.SelectedItem == null)
                {
                    MessageBox.Show("Please select a source model first!");
                    return;
                }
                if (this.saveFileDialog1.ShowDialog() != DialogResult.OK)
                    return;

                BusinessRules businessRules = MDSWrapper.BusinessRulesGet(cbModel.SelectedItem as Identifier);
                MDSWrapper.BusinessRulesExport(this.saveFileDialog1.FileName, businessRules);
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
                if (this.cbModel.SelectedItem == null)
                {
                    MessageBox.Show("Please select a source model first!");
                    return;
                }
                if (this.saveFileDialog1.ShowDialog() != DialogResult.OK)
                    return;

                BusinessRules businessRules = MDSWrapper.BusinessRulesGet(this.cbModel.SelectedItem as Identifier);

                using (StreamWriter csvFileWriter = new StreamWriter(saveFileDialog1.FileName, false))
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
                            //user selected "XML File", therefore blocking the other controls and opening the file dialog
                            cbModel.Items.Clear();
                            cbModel.Enabled = false;
                            cbVersion.Items.Clear();
                            cbVersion.Enabled = false;
                            cbModel.Enabled = false;
                            cbVersion.Enabled = false;

                            if (businessRules.BusinessRulesMember.Any())
                            {
                                businessRules1 = businessRules;
                                var br = businessRules.BusinessRulesMember.FirstOrDefault();
                                if (br != null)
                                {
                                    cbModel.Text = br.Identifier.ModelId.Name;
                                }
                            }

                            dgRules.DataSource = dataSet;
                        }
                        if ((sender as ComboBox) == cbConnection2.ComboBox)
                        {
                            businessRules2 = businessRules;
                            cbModel2.Items.Clear();
                            cbModel2.Enabled = false;
                            cbVersion2.Enabled = false;
                            dgRules2.DataSource = dataSet;

                            if (businessRules.BusinessRulesMember.Any())
                            {
                                var br = businessRules.BusinessRulesMember.FirstOrDefault();
                                if (br != null)
                                {

                                    cbModel2.Items.Add(br.Identifier.ModelId);
                                    cbModel2.SelectedIndex = 0;
                                }
                            }
                        }

                    }
                }
                else
                    GetModels(sender);
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




            var msg = MDSWrapper.BusinessRulesClone(businessRuleToCopy, cbModel2.SelectedItem as Identifier);

            MessageBox.Show(msg);
        }

        private void dgRules_SelectionChanged(object sender, EventArgs e)
        {
            if (dgRules.SelectedRows.Count > 0)
            {
                if (cbConnection2.SelectedItem != null && cbModel2.SelectedItem != null)
                    bTCopyBR.Enabled = true;
            }
        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {


        }

        private void cbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender == cbModel)
            {
                cbVersion.Enabled = true;
                GetVersions(sender, cbVersion.ComboBox);
            }
            else
                if (sender == cbModel2)
                {
                    cbVersion2.Enabled = true;
                    GetVersions(sender, cbVersion2.ComboBox);
                }
        }

        private void cbConnection_Click(object sender, EventArgs e)
        {

        }









    }
}

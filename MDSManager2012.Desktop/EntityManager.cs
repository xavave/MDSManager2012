// Type: MDSManager.EntityManager
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
    public class EntityManager : Form
    {
        private IContainer components = (IContainer)null;
        private ListBox lstAttributes;
        private TextBox txtAttributeName;
        private Button btAddAttribute;
        private Label label3;
        private Label lblError;
        private Label label4;
        private TextBox txtEntityName;
        private Button btAddEntity;
        private ListBox lstEntities;
        private Label label5;
        private Label label6;
        private GroupBox groupBox1;
        private RadioButton rbdateTime;
        private RadioButton rbNumber;
        private RadioButton rbText;
        private Button btEntityCopy;
        private ToolTip toolTip1;
        private Label label7;
        private Label label8;
        private ComboBox cbCopyToVersion;
        private ComboBox cbCopyToModel;
        private GroupBox groupBox2;
        private Label label9;
        private TextBox txtNewEntityName;
        private ComboBox cbModel;
        private ComboBox cbVersion;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox3;
        private Label label11;
        private Button btCopyAttributes;
        private Label label12;
        private ComboBox cbCpAttToModel;
        private ComboBox cbCpAttToVersion;
        private ComboBox cbCpAttToEntity;
        private Label label13;
        private Label label2;

        public EntityManager()
        {
            this.InitializeComponent();
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
            this.txtAttributeName = new System.Windows.Forms.TextBox();
            this.btAddAttribute = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEntityName = new System.Windows.Forms.TextBox();
            this.btAddEntity = new System.Windows.Forms.Button();
            this.lstEntities = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbdateTime = new System.Windows.Forms.RadioButton();
            this.rbNumber = new System.Windows.Forms.RadioButton();
            this.rbText = new System.Windows.Forms.RadioButton();
            this.btEntityCopy = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbCopyToVersion = new System.Windows.Forms.ComboBox();
            this.cbCopyToModel = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNewEntityName = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btCopyAttributes = new System.Windows.Forms.Button();
            this.cbModel = new System.Windows.Forms.ComboBox();
            this.cbVersion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbCpAttToEntity = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cbCpAttToModel = new System.Windows.Forms.ComboBox();
            this.cbCpAttToVersion = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstAttributes
            // 
            this.lstAttributes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAttributes.FormattingEnabled = true;
            this.lstAttributes.ItemHeight = 16;
            this.lstAttributes.Location = new System.Drawing.Point(371, 23);
            this.lstAttributes.Name = "lstAttributes";
            this.lstAttributes.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstAttributes.Size = new System.Drawing.Size(362, 164);
            this.lstAttributes.TabIndex = 4;
            this.lstAttributes.SelectedIndexChanged += new System.EventHandler(this.lstAttributes_SelectedIndexChanged);
            // 
            // txtAttributeName
            // 
            this.txtAttributeName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAttributeName.Location = new System.Drawing.Point(115, 106);
            this.txtAttributeName.Name = "txtAttributeName";
            this.txtAttributeName.Size = new System.Drawing.Size(600, 22);
            this.txtAttributeName.TabIndex = 5;
            // 
            // btAddAttribute
            // 
            this.btAddAttribute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAddAttribute.Location = new System.Drawing.Point(719, 106);
            this.btAddAttribute.Name = "btAddAttribute";
            this.btAddAttribute.Size = new System.Drawing.Size(20, 20);
            this.btAddAttribute.TabIndex = 14;
            this.btAddAttribute.Text = "+";
            this.toolTip1.SetToolTip(this.btAddAttribute, "Add attribute");
            this.btAddAttribute.UseVisualStyleBackColor = true;
            this.btAddAttribute.Click += new System.EventHandler(this.btAddAttribute_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Attribute Name";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(9, 134);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 17);
            this.lblError.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "Entity Name";
            // 
            // txtEntityName
            // 
            this.txtEntityName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEntityName.Location = new System.Drawing.Point(115, 80);
            this.txtEntityName.Name = "txtEntityName";
            this.txtEntityName.Size = new System.Drawing.Size(600, 22);
            this.txtEntityName.TabIndex = 17;
            // 
            // btAddEntity
            // 
            this.btAddEntity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAddEntity.Location = new System.Drawing.Point(719, 80);
            this.btAddEntity.Name = "btAddEntity";
            this.btAddEntity.Size = new System.Drawing.Size(20, 20);
            this.btAddEntity.TabIndex = 19;
            this.btAddEntity.Text = "+";
            this.toolTip1.SetToolTip(this.btAddEntity, "Create entity");
            this.btAddEntity.UseVisualStyleBackColor = true;
            this.btAddEntity.Click += new System.EventHandler(this.btAddEntity_Click);
            // 
            // lstEntities
            // 
            this.lstEntities.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstEntities.FormattingEnabled = true;
            this.lstEntities.ItemHeight = 16;
            this.lstEntities.Location = new System.Drawing.Point(3, 23);
            this.lstEntities.Name = "lstEntities";
            this.lstEntities.Size = new System.Drawing.Size(362, 164);
            this.lstEntities.TabIndex = 20;
            this.lstEntities.SelectedIndexChanged += new System.EventHandler(this.lstEntities_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = "Entity list";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(371, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 17);
            this.label6.TabIndex = 22;
            this.label6.Text = "Attribute list";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rbdateTime);
            this.groupBox1.Controls.Add(this.rbNumber);
            this.groupBox1.Controls.Add(this.rbText);
            this.groupBox1.Location = new System.Drawing.Point(3, 136);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(736, 42);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Attribute data type";
            // 
            // rbdateTime
            // 
            this.rbdateTime.AutoSize = true;
            this.rbdateTime.Location = new System.Drawing.Point(151, 19);
            this.rbdateTime.Name = "rbdateTime";
            this.rbdateTime.Size = new System.Drawing.Size(90, 21);
            this.rbdateTime.TabIndex = 2;
            this.rbdateTime.Text = "DateTime";
            this.rbdateTime.UseVisualStyleBackColor = true;
            // 
            // rbNumber
            // 
            this.rbNumber.AutoSize = true;
            this.rbNumber.Location = new System.Drawing.Point(68, 19);
            this.rbNumber.Name = "rbNumber";
            this.rbNumber.Size = new System.Drawing.Size(79, 21);
            this.rbNumber.TabIndex = 1;
            this.rbNumber.Text = "Number";
            this.rbNumber.UseVisualStyleBackColor = true;
            // 
            // rbText
            // 
            this.rbText.AutoSize = true;
            this.rbText.Checked = true;
            this.rbText.Location = new System.Drawing.Point(6, 19);
            this.rbText.Name = "rbText";
            this.rbText.Size = new System.Drawing.Size(56, 21);
            this.rbText.TabIndex = 0;
            this.rbText.TabStop = true;
            this.rbText.Text = "Text";
            this.rbText.UseVisualStyleBackColor = true;
            // 
            // btEntityCopy
            // 
            this.btEntityCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btEntityCopy.Location = new System.Drawing.Point(119, 130);
            this.btEntityCopy.Name = "btEntityCopy";
            this.btEntityCopy.Size = new System.Drawing.Size(141, 29);
            this.btEntityCopy.TabIndex = 35;
            this.btEntityCopy.Text = "Copy entity";
            this.toolTip1.SetToolTip(this.btEntityCopy, "Copy Entity");
            this.btEntityCopy.UseVisualStyleBackColor = true;
            this.btEntityCopy.Click += new System.EventHandler(this.btEntityCopy_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(50, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 17);
            this.label7.TabIndex = 39;
            this.label7.Text = "Version";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(56, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 17);
            this.label8.TabIndex = 38;
            this.label8.Text = "Model";
            // 
            // cbCopyToVersion
            // 
            this.cbCopyToVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCopyToVersion.FormattingEnabled = true;
            this.cbCopyToVersion.Location = new System.Drawing.Point(119, 48);
            this.cbCopyToVersion.Name = "cbCopyToVersion";
            this.cbCopyToVersion.Size = new System.Drawing.Size(237, 24);
            this.cbCopyToVersion.TabIndex = 37;
            this.cbCopyToVersion.SelectedIndexChanged += new System.EventHandler(this.cbVersion_SelectedIndexChanged);
            // 
            // cbCopyToModel
            // 
            this.cbCopyToModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCopyToModel.FormattingEnabled = true;
            this.cbCopyToModel.Location = new System.Drawing.Point(119, 21);
            this.cbCopyToModel.Name = "cbCopyToModel";
            this.cbCopyToModel.Size = new System.Drawing.Size(237, 24);
            this.cbCopyToModel.TabIndex = 36;
            this.cbCopyToModel.SelectedIndexChanged += new System.EventHandler(this.cbModel_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtNewEntityName);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btEntityCopy);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cbCopyToModel);
            this.groupBox2.Controls.Add(this.cbCopyToVersion);
            this.groupBox2.Location = new System.Drawing.Point(6, 386);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(362, 160);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Copy Selected Entity to";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 17);
            this.label9.TabIndex = 41;
            this.label9.Text = "New Entity name";
            // 
            // txtNewEntityName
            // 
            this.txtNewEntityName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewEntityName.Location = new System.Drawing.Point(119, 78);
            this.txtNewEntityName.Name = "txtNewEntityName";
            this.txtNewEntityName.Size = new System.Drawing.Size(237, 22);
            this.txtNewEntityName.TabIndex = 40;
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // btCopyAttributes
            // 
            this.btCopyAttributes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCopyAttributes.Location = new System.Drawing.Point(119, 130);
            this.btCopyAttributes.Name = "btCopyAttributes";
            this.btCopyAttributes.Size = new System.Drawing.Size(141, 29);
            this.btCopyAttributes.TabIndex = 35;
            this.btCopyAttributes.Text = "Copy attributes";
            this.toolTip1.SetToolTip(this.btCopyAttributes, "Copy Entity");
            this.btCopyAttributes.UseVisualStyleBackColor = true;
            this.btCopyAttributes.Click += new System.EventHandler(this.btCopyAttributes_Click);
            // 
            // cbModel
            // 
            this.cbModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbModel.FormattingEnabled = true;
            this.cbModel.Location = new System.Drawing.Point(114, 18);
            this.cbModel.Name = "cbModel";
            this.cbModel.Size = new System.Drawing.Size(625, 24);
            this.cbModel.TabIndex = 0;
            this.cbModel.SelectedIndexChanged += new System.EventHandler(this.cbModel_SelectedIndexChanged);
            // 
            // cbVersion
            // 
            this.cbVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbVersion.FormattingEnabled = true;
            this.cbVersion.Location = new System.Drawing.Point(114, 45);
            this.cbVersion.Name = "cbVersion";
            this.cbVersion.Size = new System.Drawing.Size(625, 24);
            this.cbVersion.TabIndex = 1;
            this.cbVersion.SelectedIndexChanged += new System.EventHandler(this.cbVersion_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Model";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Version";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lstAttributes, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lstEntities, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 184);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(736, 193);
            this.tableLayoutPanel1.TabIndex = 41;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbCpAttToEntity);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.btCopyAttributes);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.cbCpAttToModel);
            this.groupBox3.Controls.Add(this.cbCpAttToVersion);
            this.groupBox3.Location = new System.Drawing.Point(377, 386);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(362, 160);
            this.groupBox3.TabIndex = 42;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Copy Selected Attributes to";
            // 
            // cbCpAttToEntity
            // 
            this.cbCpAttToEntity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCpAttToEntity.FormattingEnabled = true;
            this.cbCpAttToEntity.Location = new System.Drawing.Point(119, 78);
            this.cbCpAttToEntity.Name = "cbCpAttToEntity";
            this.cbCpAttToEntity.Size = new System.Drawing.Size(237, 24);
            this.cbCpAttToEntity.TabIndex = 44;
            this.cbCpAttToEntity.SelectedIndexChanged += new System.EventHandler(this.cbCpAttToEntity_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(41, 79);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 17);
            this.label13.TabIndex = 43;
            this.label13.Text = "Entity";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(41, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 17);
            this.label11.TabIndex = 38;
            this.label11.Text = "Model";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(35, 51);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 17);
            this.label12.TabIndex = 39;
            this.label12.Text = "Version";
            // 
            // cbCpAttToModel
            // 
            this.cbCpAttToModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCpAttToModel.FormattingEnabled = true;
            this.cbCpAttToModel.Location = new System.Drawing.Point(119, 21);
            this.cbCpAttToModel.Name = "cbCpAttToModel";
            this.cbCpAttToModel.Size = new System.Drawing.Size(237, 24);
            this.cbCpAttToModel.TabIndex = 36;
            this.cbCpAttToModel.SelectedIndexChanged += new System.EventHandler(this.cbModel_SelectedIndexChanged);
            // 
            // cbCpAttToVersion
            // 
            this.cbCpAttToVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCpAttToVersion.FormattingEnabled = true;
            this.cbCpAttToVersion.Location = new System.Drawing.Point(119, 48);
            this.cbCpAttToVersion.Name = "cbCpAttToVersion";
            this.cbCpAttToVersion.Size = new System.Drawing.Size(237, 24);
            this.cbCpAttToVersion.TabIndex = 37;
            this.cbCpAttToVersion.SelectedIndexChanged += new System.EventHandler(this.cbVersion_SelectedIndexChanged);
            // 
            // EntityManager
            // 
            this.ClientSize = new System.Drawing.Size(745, 548);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btAddEntity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEntityName);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btAddAttribute);
            this.Controls.Add(this.txtAttributeName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbVersion);
            this.Controls.Add(this.cbModel);
            this.Name = "EntityManager";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Text = "MDS EntityManager";
            this.toolTip1.SetToolTip(this, "Create entity");
            this.Load += new System.EventHandler(this.EntityManager_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void EntityManager_Load(object sender, EventArgs e)
        {
            try
            {
                GetModels();
            }
            catch (Exception)
            {
                this.lblError.Text = "error in getting model list";
            }
        }

        public void GetModels()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                List<Model> modelList = MDSWrapper.ModelGet();
                this.cbModel.Items.Clear();
                this.cbCopyToModel.Items.Clear();
                this.cbCpAttToModel.Items.Clear();
                if (modelList != null && modelList.Count > 0)
                {
                    foreach (Model model in modelList)
                    {
                        this.cbModel.Items.Add(model.Identifier);
                        this.cbCopyToModel.Items.Add(model.Identifier);
                        this.cbCpAttToModel.Items.Add(model.Identifier);
                    }
                    this.cbModel.DisplayMember = "Name";
                    this.cbCopyToModel.DisplayMember = "Name";
                    this.cbCpAttToModel.DisplayMember = "Name";
                }
                else
                    this.lblError.Text = "can't retrieve models or no models to display";
            }
            catch (Exception ex)
            {
                this.lblError.Text = ex.Message;
                throw ex;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void cbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;
            else
            {
                OperationResult or = new OperationResult();
                this.DisplayVersions(cb, MDSWrapper.GetMetaData(new International(), ref or, cb.SelectedItem as Identifier, (Identifier)null, (Identifier)null, MDAction.VersionsOnly));
            }
        }

        private void DisplayVersions(ComboBox cb, Metadata md)
        {
            try
            {
                ComboBox cbTarget;
                switch (cb.Name)
                {
                    case "cbModel": cbTarget = cbVersion; break;
                    case "cbCopyToModel": cbTarget = cbCopyToVersion; break;
                    case "cbCpAttToModel": cbTarget = cbCpAttToVersion; break;
                    default: return;
                }

                cbTarget.Items.Clear();

                foreach (Common.MDSService.Version v in md.Versions)
                {
                    if (v.Identifier.ModelId.Id == ((Identifier)cb.SelectedItem).Id)
                    {
                        cbTarget.Items.Add(new CustomVersion(v));

                    }
                }
                cbTarget.DisplayMember = "Name";

                if (cbTarget.Items.Count <= 0)
                    return;
                else
                    cbTarget.SelectedIndex = 0;
                if (cbTarget.Name == "cbVersion")
                    this.DisplayEntities((Identifier)cb.SelectedItem, (CustomVersion)null);
            }
            catch (Exception ex)
            {
                this.lblError.Text = ex.Message;
                throw;
            }
        }


        public void DisplayAttributes(Identifier model, CustomEntity customEntity, CustomVersion version)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                OperationResult or = new OperationResult();

                if (customEntity == null || customEntity.entityId == null)
                    return;

                Metadata metaData = MDSWrapper.GetMetaData(new International(), ref or, model, version.Identifier, customEntity.ent.Identifier, MDAction.AttributesOnly);
                object selectedItem = this.lstAttributes.SelectedItem;
                int selectedIndex = this.lstAttributes.SelectedIndex;
               
                foreach (MetadataAttribute attribute in metaData.Attributes)
                {
                   // this.cbCpAttToMember.Items.Add((object)new CustomMetaDataAttribute(attribute));

                }

              //  this.cbCpAttToMember.DisplayMember = "Name";



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

        private void cbCpAttToEntity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbCpAttToEntity.SelectedIndex <= -1)
                return;

            this.DisplayAttributes(cbCpAttToModel.SelectedItem as Identifier, cbCpAttToEntity.SelectedItem as CustomEntity, cbCpAttToVersion.SelectedItem as CustomVersion);
        }
        public void CbDisplayEntities(Identifier modelId, CustomVersion custVersionId = null)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Metadata metadata = new Metadata();
                OperationResult or = new OperationResult();

                {
                    Metadata metaData = MDSWrapper.GetMetaData(new International(), ref or, modelId, (Identifier)null, (Identifier)null, MDAction.EntitiesOnly);
                    if (metaData == null)
                        return;
                    this.cbCpAttToEntity.Items.Clear();
                    foreach (Entity e in metaData.Entities)
                        this.cbCpAttToEntity.Items.Add((object)new CustomEntity(e, custVersionId != null ? custVersionId.Identifier : (Identifier)null));
                    this.cbCpAttToEntity.DisplayMember = "Name";
                }
            }
            catch (Exception ex)
            {
                this.lblError.Text = ex.Message;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        public void DisplayEntities(Identifier modelId, CustomVersion custVersionId = null)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Metadata metadata = new Metadata();
                OperationResult or = new OperationResult();

                {
                    Metadata metaData = MDSWrapper.GetMetaData(new International(), ref or, modelId, (Identifier)null, (Identifier)null, MDAction.EntitiesOnly);
                    if (metaData == null)
                        return;
                    this.lstEntities.Items.Clear();
                    foreach (Entity e in metaData.Entities)
                        this.lstEntities.Items.Add((object)new CustomEntity(e, custVersionId != null ? custVersionId.Identifier : (Identifier)null));
                    this.lstEntities.DisplayMember = "Name";
                }
            }
            catch (Exception ex)
            {
                this.lblError.Text = ex.Message;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public void DisplayAttributes()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                OperationResult or = new OperationResult();
                CustomEntity customEntity = this.lstEntities.SelectedItem as CustomEntity;
                if (customEntity == null || customEntity.entityId == null)
                    return;

                Metadata metaData = MDSWrapper.GetMetaData(new International(), ref or, (Identifier)this.cbModel.SelectedItem, ((CustomVersion)this.cbVersion.SelectedItem).Identifier, (Identifier)customEntity.entityId, MDAction.AttributesOnly);
                object selectedItem = this.lstAttributes.SelectedItem;
                int selectedIndex = this.lstAttributes.SelectedIndex;
                this.lstAttributes.Items.Clear();
                foreach (MetadataAttribute attribute in metaData.Attributes)
                    this.lstAttributes.Items.Add((object)new CustomMetaDataAttribute(attribute));
                this.lstAttributes.DisplayMember = "NameType";
                if (this.lstAttributes.Items.Count > 0)
                {
                    this.lstAttributes.SelectedIndex = 0;
                    this.setRbDataType(this.lstAttributes.SelectedItem as CustomMetaDataAttribute);
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

        private void cbVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as ComboBox).Name == "cbCpAttToVersion")
            {
                this.CbDisplayEntities(this.cbCpAttToModel.SelectedItem as Identifier, this.cbCpAttToModel.SelectedItem as CustomVersion);
            }
            else
                this.DisplayEntities(this.cbModel.SelectedItem as Identifier, this.cbVersion.SelectedItem as CustomVersion);


        }

        private void lstEntities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstEntities.SelectedIndex <= -1)
                return;
            this.txtEntityName.Text = ((CustomEntity)this.lstEntities.SelectedItem).Name;
            this.txtNewEntityName.Text = ((CustomEntity)this.lstEntities.SelectedItem).Name;
            this.DisplayAttributes();
        }

        private void btAddAttribute_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (this.AddAttribute() == null)
                    return;
                this.DisplayAttributes();
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

        private OperationResult CopyEntityAttributes(Identifier newModelId, Entity sourceEntity, Entity destinationEntity)
        {
            throw new NotImplementedException();
            //TODO Implement
            OperationResult operationResult = (OperationResult)null;
            Metadata metadata1 = new Metadata();
            Metadata metadata2 = new Metadata();
            if (destinationEntity == null)
            { //TODO
            }
            return operationResult;
        }

        private OperationResult AddAttribute()
        {
            try
            {
                OperationResult OperationResult = (OperationResult)null;
                CustomEntity customEntity = this.lstEntities.SelectedItem as CustomEntity;
                Identifier identifier = this.cbModel.SelectedItem as Identifier;
                Metadata metadata = new Metadata();
                if (customEntity != null && customEntity.entityId != null)
                {
                    OperationResult = new OperationResult();

                    Metadata metaData = MDSWrapper.GetMetaData(new International(), ref OperationResult, (Identifier)this.cbModel.SelectedItem, ((CustomVersion)this.cbVersion.SelectedItem).Identifier, (Identifier)customEntity.entityId, MDAction.AttributesOnly);
                    MetadataAttribute metadataAttribute1 = new MetadataAttribute();
                    metadataAttribute1.AttributeType = new AttributeType?(AttributeType.FreeForm);
                    MetadataAttribute metadataAttribute2 = metadataAttribute1;
                    MemberTypeContextIdentifier contextIdentifier1 = new MemberTypeContextIdentifier();
                    contextIdentifier1.EntityId = (Identifier)customEntity.entityId;
                    contextIdentifier1.ModelId = identifier;
                    contextIdentifier1.MemberType = MemberType.Leaf;
                    contextIdentifier1.Name = this.txtAttributeName.Text;
                    MemberTypeContextIdentifier contextIdentifier2 = contextIdentifier1;
                    metadataAttribute2.Identifier = contextIdentifier2;
                    metadataAttribute1.DataType = this.getRbDataType();
                    MetadataAttribute metadataAttribute3 = metadataAttribute1;
                    metaData.Attributes.Add(metadataAttribute3);
                    MDSWrapper.ServiceClient.MetadataCreate(new International(), metaData, true, out OperationResult);

                }
                return OperationResult;
            }
            catch (Exception ex)
            {
                this.lblError.Text = ex.Message;
                return (OperationResult)null;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void lstAttributes_SelectedIndexChanged(object sender, EventArgs e)
        {
            CustomMetaDataAttribute cma = this.lstAttributes.SelectedItem as CustomMetaDataAttribute;
            if (cma == null)
                return;
            this.setRbDataType(cma);
        }

        private AttributeDataType getRbDataType()
        {
            if (this.rbText.Checked)
                return AttributeDataType.Text;
            if (this.rbNumber.Checked)
                return AttributeDataType.Number;
            return this.rbdateTime.Checked ? AttributeDataType.DateTime : AttributeDataType.NotSpecified;
        }

        private void setRbDataType(CustomMetaDataAttribute cma)
        {
            if (cma.attribute.DataType == AttributeDataType.Text)
            {
                this.rbText.Checked = true;
                this.rbNumber.Checked = false;
                this.rbdateTime.Checked = false;
            }
            if (cma.attribute.DataType == AttributeDataType.Number)
            {
                this.rbText.Checked = false;
                this.rbNumber.Checked = true;
                this.rbdateTime.Checked = false;
            }
            if (cma.attribute.DataType != AttributeDataType.DateTime)
                return;
            this.rbText.Checked = false;
            this.rbNumber.Checked = false;
            this.rbdateTime.Checked = true;
        }

        private void btAddEntity_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.txtEntityName.Text))
                {
                    Cursor.Current = Cursors.WaitCursor;
                    this.DisplayEntities(this.AddNewEntity(), this.cbVersion.SelectedItem as CustomVersion);
                }
                else
                    this.lblError.Text = "Entity name cannot be empty!";
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

        private Identifier AddNewEntity()
        {
            return this.AddEntity(this.cbModel.SelectedItem as Identifier, (this.cbVersion.SelectedItem as CustomVersion).Identifier, this.txtEntityName.Text);
        }

        private Identifier AddEntity(Identifier modelId, Identifier versionId, string txtEntityName)
        {
            OperationResult OperationResult = new OperationResult();
            Metadata Metadata = new Metadata();
            Metadata.Entities = new List<Entity>();
            List<Entity> entities = Metadata.Entities;
            Entity entity1 = new Entity();
            Entity entity2 = entity1;
            ModelContextIdentifier contextIdentifier1 = new ModelContextIdentifier();
            contextIdentifier1.ModelId = modelId;
            contextIdentifier1.Name = txtEntityName;
            ModelContextIdentifier contextIdentifier2 = contextIdentifier1;
            entity2.Identifier = contextIdentifier2;
            Entity entity3 = entity1;
            entities.Add(entity3);

            MDSWrapper.ServiceClient.MetadataCreate(new International(), Metadata, true, out OperationResult);
            return modelId;
        }
        private void CopyEntity(Identifier newModelId, Identifier versionId, Entity EntityToCopy)
        {
            OperationResult OperationResult = new OperationResult();
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Guid guid = Guid.NewGuid();
                Metadata Metadata1 = new Metadata();
                Metadata1.Entities = new List<Entity>();
                List<Entity> entities = Metadata1.Entities;
                Entity entity1 = new Entity();

                ModelContextIdentifier contextIdentifier = new ModelContextIdentifier();
                contextIdentifier.ModelId = newModelId;
                contextIdentifier.Name = !string.IsNullOrEmpty(this.txtNewEntityName.Text) ? this.txtNewEntityName.Text : EntityToCopy.Identifier.Name;
                contextIdentifier.Id = guid;

                entity1.Identifier = contextIdentifier;
                entity1.AuditInfo = EntityToCopy.AuditInfo;
                entity1.ExtensionData = EntityToCopy.ExtensionData;
                entity1.ExplicitHierarchies = EntityToCopy.ExplicitHierarchies;
                entity1.IsBase = EntityToCopy.IsBase;
                entity1.IsFlat = EntityToCopy.IsFlat;
                entity1.IsSystem = EntityToCopy.IsSystem;
                entity1.MemberTypes = EntityToCopy.MemberTypes;

                entities.Add(entity1);

                {
                    Metadata metadata = MDSWrapper.ServiceClient.MetadataCreate(new International(), Metadata1, true, out OperationResult);
                    Metadata metaData = MDSWrapper.GetMetaData(new International(), ref OperationResult, (Identifier)this.cbModel.SelectedItem, ((CustomVersion)this.cbVersion.SelectedItem).Identifier, (Identifier)EntityToCopy.Identifier, MDAction.AttributesDetails);
                    Metadata Metadata2 = new Metadata();
                    Metadata2.Attributes = new List<MetadataAttribute>();
                    foreach (MetadataAttribute metadataAttribute1 in metaData.Attributes)
                    {
                        MetadataAttribute metadataAttribute2 = new MetadataAttribute();
                        metadataAttribute2.AttributeType = metadataAttribute1.AttributeType;
                        MetadataAttribute metadataAttribute3 = metadataAttribute2;
                        MemberTypeContextIdentifier contextIdentifier3 = new MemberTypeContextIdentifier();
                        contextIdentifier3.EntityId = (Identifier)Enumerable.First<Entity>((IEnumerable<Entity>)metadata.Entities).Identifier;
                        contextIdentifier3.Id = Enumerable.First<Entity>((IEnumerable<Entity>)metadata.Entities).Identifier.Id;
                        contextIdentifier3.InternalId = Enumerable.First<Entity>((IEnumerable<Entity>)metadata.Entities).Identifier.InternalId;
                        contextIdentifier3.ModelId = newModelId;
                        contextIdentifier3.MemberType = metadataAttribute1.Identifier.MemberType;
                        contextIdentifier3.Name = metadataAttribute1.Identifier.Name;

                        metadataAttribute3.Identifier = contextIdentifier3;
                        metadataAttribute2.DataType = metadataAttribute1.DataType;
                        metadataAttribute2.DataTypeInformation = metadataAttribute1.DataTypeInformation;
                        metadataAttribute2.AuditInfo = metadataAttribute1.AuditInfo;
                        metadataAttribute2.ChangeTrackingGroup = metadataAttribute1.ChangeTrackingGroup;
                        metadataAttribute2.DisplayWidth = metadataAttribute1.DisplayWidth;
                        metadataAttribute2.ExtensionData = metadataAttribute1.ExtensionData;
                        metadataAttribute2.InputMaskId = metadataAttribute1.InputMaskId;
                        metadataAttribute2.IsCode = metadataAttribute1.IsCode;
                        metadataAttribute2.IsName = metadataAttribute1.IsName;
                        metadataAttribute2.IsReadOnly = metadataAttribute1.IsReadOnly;
                        metadataAttribute2.IsSystem = metadataAttribute1.IsSystem;
                        metadataAttribute2.Permission = metadataAttribute1.Permission;
                        metadataAttribute2.SortOrder = metadataAttribute1.SortOrder;

                        Metadata2.Attributes.Add(metadataAttribute2);
                    }
                    MDSWrapper.ServiceClient.MetadataCreate(new International(), Metadata2, true, out OperationResult);
                }
                if (OperationResult == null || OperationResult.Errors.Count != 0)
                    return;
                MessageBox.Show("DONE!");
            }
            catch (Exception)
            {
                StringBuilder stringBuilder = new StringBuilder();
                if (OperationResult != null && OperationResult.Errors.Count > 0)
                {
                    foreach (Common.MDSService.Error error in OperationResult.Errors)
                        stringBuilder.AppendFormat("{0}" + Environment.NewLine, (object)(error.Code + " - " + error.Description));
                }
                if (stringBuilder.Length > 0)
                    throw new Exception(((object)stringBuilder).ToString());
                else
                    throw;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btEntityCopy_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (this.lstEntities.SelectedItem == null || this.cbCopyToModel.SelectedItem == null || this.cbCopyToVersion.SelectedItem == null || string.IsNullOrEmpty(this.txtNewEntityName.Text))
                    return;
                this.CopyEntity(this.cbCopyToModel.SelectedItem as Identifier, (this.cbCopyToVersion.SelectedItem as CustomVersion).Identifier, (this.lstEntities.SelectedItem as CustomEntity).ent);
            }
            catch (Exception ex)
            {
                this.lblError.Text = ex.Message;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btCopyAttributes_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Dev In Progress");
                return;
                Cursor.Current = Cursors.WaitCursor;
                if (this.lstAttributes.SelectedItems.Count == 0)
                    return;
                var selAttributes = new List<CustomMetaDataAttribute>();
                foreach (var itm in lstAttributes.SelectedItems)
                {
                    var att = itm as CustomMetaDataAttribute;
                    if (att != null)
                        selAttributes.Add(att);
                }
                MDSWrapper.CopyAttributes(this.cbCpAttToModel.SelectedItem as Identifier, cbCpAttToEntity.SelectedItem as CustomEntity, this.cbCopyToVersion.SelectedItem as CustomVersion,  selAttributes);
            }
            catch (Exception ex)
            {
                this.lblError.Text = ex.Message;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }




    }
}

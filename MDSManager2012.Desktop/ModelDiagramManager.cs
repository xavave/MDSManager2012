// Type: MDSManager.ModelDiagramManager
// Assembly: MDSManager, Version=1.0.7.2, Culture=neutral, PublicKeyToken=null
// Assembly location: C:\Users\Xavier\Documents\Visual Studio 2010\Projects\MDSManager\MDSManager.exe

using Common;
using Common.MDSService;

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Common.Model;

namespace MDSManager2012.Desktop
{
    public class ModelDiagramManager : Form
    {
        private IContainer components = (IContainer)null;
        private GroupBox groupBox2;
        private ComboBox cbInitialCatalog;
        private ComboBox cbDataSource;
        private CheckBox chkDropExistingDB;
        private Label label9;
        public TextBox txtDefaultSchema;
        private Label label8;
        public TextBox txtModellingDb;
        private Button btExportDiagram;
        private Label label7;
        private Label label5;
        private Button btDrawTreeView;
        private TreeView treeView1;
        private Label label2;
        private Label label1;
        private ComboBox cbVersion;
        private ComboBox cbModel;
        private Label lblError;
        private ucManageEntities ucManageEntities1;
        private Label label3;
        private Label label4;
        public TextBox txtAttachDbFilename;
        private RadioButton rbUseSingleConString;
        private RadioButton rbUseConStringElements;
        private GroupBox groupBox3;
        private ComboBox txtSingleConString;
        private GroupBox groupBox1;
        private Label label10;
        public TextBox txtPass;
        private Label label6;
        public TextBox txtUser;
        private HelpProvider helpProvider1;
        private Button btHelp;
        private CheckBox ckCreateDb;
        private ToolTip toolTip1;


        public ModelDiagramManager()
        {
            this.InitializeComponent();
            this.ucManageEntities1.DHvisible(false);
        }



        private void ModelDiagramManager_Load(object sender, EventArgs e)
        {
            var errorMessage = String.Empty;
            try
            {
                GetModels();
            }
            catch (Exception exc)
            {

                this.lblError.Text = exc.Message;
                return;
            }
            List<string> conStrings = MDSModelling.GetConnectionStrings(Application.ExecutablePath);
            if (conStrings.Count > 0)
            {
                // txtSingleConString.Text = conStrings.First();

                foreach (string conStr in conStrings)
                {
                    string[] separator = new string[1] { ";" };
                    int num = 0;
                    foreach (string ConStringElement in conStr.Split(separator, (StringSplitOptions)num))
                    {
                        if (ConStringElement.ToLower().Contains("source"))
                        {
                            string substr = ConStringElement.Substring(ConStringElement.IndexOf('=') + 1);
                            if (!this.cbDataSource.Items.Contains((object)substr))
                                this.cbDataSource.Items.Add((object)substr);
                        }
                        else
                            if (ConStringElement.ToLower().Contains("catalog"))
                            {
                                string substr = ConStringElement.Substring(ConStringElement.IndexOf('=') + 1);
                                if (!this.cbInitialCatalog.Items.Contains((object)substr))
                                    this.cbInitialCatalog.Items.Add((object)substr);
                            }
                            else
                                if (ConStringElement.ToLower().Contains("attachdbfilename"))
                                {
                                    this.txtAttachDbFilename.Text = ConStringElement.Substring(ConStringElement.IndexOf('=') + 1);

                                }
                    }
                }
            }
        }

        public void GetModels()
        {
            Cursor.Current = Cursors.WaitCursor;
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
            if (this.cbModel.SelectedItem == null)
                return;
            OperationResult or = new OperationResult();

            this.DisplayVersions(MDSWrapper.GetMetaData(new International(), ref or, this.cbModel.SelectedItem as Identifier, (Identifier)null, (Identifier)null, MDAction.VersionsOnly));
        }

        private void DisplayVersions(Metadata md)
        {
            try
            {
                this.cbVersion.Items.Clear();
                foreach (Common.MDSService.Version v in md.Versions)
                {
                    if (v.Identifier.ModelId.Id == ((Identifier)this.cbModel.SelectedItem).Id)
                        this.cbVersion.Items.Add((object)new CustomVersion(v));
                }
                this.cbVersion.DisplayMember = "Name";
                if (this.cbVersion.Items.Count <= 0)
                    return;
                this.cbVersion.SelectedIndex = 0;
                this.ucManageEntities1.DisplayEntities((Identifier)this.cbModel.SelectedItem, (Identifier)null);
            }
            catch (Exception ex)
            {
                this.lblError.Text = ex.Message;
                throw;
            }
        }

        private void btDrawTreeView_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cbModel.SelectedItem != null && this.cbVersion.SelectedItem != null)
                {
                    this.treeView1.Nodes.Clear();
                    Cursor.Current = Cursors.WaitCursor;
                    Identifier modelId = this.cbModel.SelectedItem as Identifier;
                    Identifier identifier1 = (this.cbVersion.SelectedItem as CustomVersion).Identifier;
                    OperationResult operationResult = new OperationResult();
                    List<CustomNode> list = new List<CustomNode>();
                    foreach (CustomEntity mci in ucManageEntities1.lstEntities.Items)
                    {
                        bool flag = false;
                        foreach (Identifier identifier2 in CustomEntity.GetDBAEntities(modelId, identifier1, mci.ent))
                        {
                            CustomNode customNode = new CustomNode(mci, identifier2.Name, mci.Name);
                            if (!list.Contains(customNode))
                            {
                                list.Add(customNode);
                                flag = true;
                            }
                        }
                        if (!flag)
                        {
                            CustomNode customNode = new CustomNode(mci, mci.Name, "root");
                            if (Enumerable.Count<CustomNode>((IEnumerable<CustomNode>)list, (Func<CustomNode, bool>)(x => x.Ent == mci)) == 0)
                                list.Add(customNode);
                        }
                    }


                    TreeNode currentNode = new TreeNode("root");
                    currentNode.Text = currentNode.Name = "root";
                    this.BindTree(list, currentNode, Enumerable.First<CustomNode>((IEnumerable<CustomNode>)list).Ent);
                }
                else
                    this.lblError.Text = "You must select a model and a version";
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

        private void BindTree(List<CustomNode> list, TreeNode currentNode, CustomEntity startEnt)
        {
            foreach (CustomNode customNode in Enumerable.ToList<CustomNode>(Enumerable.Where<CustomNode>((IEnumerable<CustomNode>)list, (Func<CustomNode, bool>)(x => currentNode.Nodes.Count > 0 ? x.Name == currentNode.Nodes[0].Name : x.Name == currentNode.Name))))
            {
                TreeNode treeNode = new TreeNode(customNode.ChildName);
                treeNode.Name = customNode.ChildName;
                treeNode.Text = customNode.ChildName;
                if (treeNode.Nodes.Count == 0)
                {
                    this.treeView1.Nodes.Add(treeNode);
                    this.lblError.Text = "adding : " + treeNode.Name + " to Root Node";
                }
                else
                {
                    currentNode.Nodes.Add(treeNode);
                    this.lblError.Text = "adding : " + treeNode.Name + " to " + currentNode.Name;
                }
                this.lblError.Refresh();
                this.BindTree(list, treeNode, (CustomEntity)null);
            }
        }

        private void btExportDiagram_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                System.Data.SqlClient.SqlConnectionStringBuilder builder = null;
                if (rbUseSingleConString.Checked && !string.IsNullOrWhiteSpace(txtSingleConString.Text))
                {
                    builder = new System.Data.SqlClient.SqlConnectionStringBuilder(txtSingleConString.Text);


                    this.cbDataSource.Text = builder.DataSource;
                    this.cbInitialCatalog.Text = builder.InitialCatalog;
                    this.txtAttachDbFilename.Text = builder.AttachDBFilename;
                }
                else
                    if (rbUseConStringElements.Checked)
                    {
                        builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
                        builder.AttachDBFilename = txtAttachDbFilename.Text;
                        builder.DataSource = cbDataSource.Text;
                        builder.InitialCatalog = cbInitialCatalog.Text;

                        this.txtSingleConString.Text = builder.ConnectionString;
                    }

                if (!string.IsNullOrEmpty(this.cbDataSource.Text) && !string.IsNullOrEmpty(this.txtModellingDb.Text))
                {

                    if (this.cbModel.SelectedItem != null)
                    {
                        this.txtDefaultSchema.Text = string.IsNullOrEmpty(this.txtDefaultSchema.Text) ? "dbo" : this.txtDefaultSchema.Text;
                        if (this.chkDropExistingDB.Checked)
                        {
                            try
                            {
                                MDSModelling.DropExistingDb(txtSingleConString.Text, txtModellingDb.Text);

                            }
                            catch (Exception ex)
                            {
                                this.lblError.Text = ex.Message + ";" + ex.InnerException != null ? ex.InnerException.Message : "";
                            }
                        }
                        if (this.ckCreateDb.Checked)
                        {
                            try
                            {

                                MDSModelling.CreateNewDb(txtSingleConString.Text, txtModellingDb.Text);
                            }
                            catch (Exception ex)
                            {
                                this.lblError.Text = ex.Message + ";" + ex.InnerException != null ? ex.InnerException.Message : "";
                            }
                        }
                        foreach (CustomEntity customEntity in this.ucManageEntities1.lstEntities.Items)
                            MDSModelling.CreateTable(txtSingleConString.Text, customEntity.Name, txtAttachDbFilename.Text, txtModellingDb.Text, this.txtDefaultSchema.Text);

                        foreach (CustomEntity customEntity in this.ucManageEntities1.lstEntities.Items)
                        {
                            OperationResult or = new OperationResult();
                            Metadata metaData = MDSWrapper.GetMetaData(new International(), ref or, (Identifier)this.cbModel.SelectedItem, ((CustomVersion)this.cbVersion.SelectedItem).Identifier, (Identifier)customEntity.entityId, MDAction.AttributesOnly);
                            if (metaData != null)
                            {
                                foreach (MetadataAttribute att in metaData.Attributes)
                                {
                                    AttributeType? attributeType = att.AttributeType;
                                    if ((attributeType.GetValueOrDefault() != AttributeType.Domain ? 0 : (attributeType.HasValue ? 1 : 0)) != 0)
                                        MDSModelling.CreateRelationShips(this.cbDataSource.Text, this.cbInitialCatalog.Text, this.txtModellingDb.Text, att.DomainEntityId.Name, att.Identifier.EntityId.Name);
                                    else
                                        MDSModelling.AddColumn(txtSingleConString.Text, this.txtModellingDb.Text, customEntity.Name, att);
                                }
                            }
                        }

                    }
                    else
                        this.lblError.Text = "You must select a model first!";
                }
                else

                    this.lblError.Text = "You must enter a data source, an initial catalog and a modelling database name or a connection string!";


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

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbInitialCatalog = new System.Windows.Forms.ComboBox();
            this.cbDataSource = new System.Windows.Forms.ComboBox();
            this.chkDropExistingDB = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDefaultSchema = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtModellingDb = new System.Windows.Forms.TextBox();
            this.btExportDiagram = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btDrawTreeView = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbVersion = new System.Windows.Forms.ComboBox();
            this.cbModel = new System.Windows.Forms.ComboBox();
            this.lblError = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtAttachDbFilename = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtSingleConString = new System.Windows.Forms.ComboBox();
            this.rbUseConStringElements = new System.Windows.Forms.RadioButton();
            this.rbUseSingleConString = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.btHelp = new System.Windows.Forms.Button();
            this.ckCreateDb = new System.Windows.Forms.CheckBox();
            this.ucManageEntities1 = new MDSManager2012.Desktop.ucManageEntities();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ckCreateDb);
            this.groupBox2.Controls.Add(this.rbUseSingleConString);
            this.groupBox2.Controls.Add(this.rbUseConStringElements);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.chkDropExistingDB);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtDefaultSchema);
            this.groupBox2.Location = new System.Drawing.Point(4, 60);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(276, 299);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Model Diagram";
            // 
            // cbInitialCatalog
            // 
            this.cbInitialCatalog.FormattingEnabled = true;
            this.cbInitialCatalog.Location = new System.Drawing.Point(95, 43);
            this.cbInitialCatalog.Name = "cbInitialCatalog";
            this.cbInitialCatalog.Size = new System.Drawing.Size(147, 21);
            this.cbInitialCatalog.TabIndex = 28;
            // 
            // cbDataSource
            // 
            this.cbDataSource.FormattingEnabled = true;
            this.cbDataSource.Location = new System.Drawing.Point(95, 19);
            this.cbDataSource.Name = "cbDataSource";
            this.cbDataSource.Size = new System.Drawing.Size(147, 21);
            this.cbDataSource.TabIndex = 27;
            // 
            // chkDropExistingDB
            // 
            this.chkDropExistingDB.AutoSize = true;
            this.chkDropExistingDB.Location = new System.Drawing.Point(3, 253);
            this.chkDropExistingDB.Name = "chkDropExistingDB";
            this.chkDropExistingDB.Size = new System.Drawing.Size(138, 17);
            this.chkDropExistingDB.TabIndex = 26;
            this.chkDropExistingDB.Text = "Drop Existing DataBase";
            this.chkDropExistingDB.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 228);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Default Schema";
            // 
            // txtDefaultSchema
            // 
            this.txtDefaultSchema.Location = new System.Drawing.Point(90, 225);
            this.txtDefaultSchema.Name = "txtDefaultSchema";
            this.txtDefaultSchema.Size = new System.Drawing.Size(147, 20);
            this.txtDefaultSchema.TabIndex = 24;
            this.txtDefaultSchema.Text = "dbo";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Modelling DB";
            // 
            // txtModellingDb
            // 
            this.txtModellingDb.Location = new System.Drawing.Point(95, 67);
            this.txtModellingDb.Name = "txtModellingDb";
            this.txtModellingDb.Size = new System.Drawing.Size(147, 20);
            this.txtModellingDb.TabIndex = 22;
            this.txtModellingDb.Text = "MDSmodelling";
            // 
            // btExportDiagram
            // 
            this.btExportDiagram.BackgroundImage = global::MDSManager2012.Desktop.Properties.Resources.export_icon;
            this.btExportDiagram.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btExportDiagram.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btExportDiagram.Location = new System.Drawing.Point(286, 314);
            this.btExportDiagram.Name = "btExportDiagram";
            this.btExportDiagram.Size = new System.Drawing.Size(20, 20);
            this.btExportDiagram.TabIndex = 21;
            this.toolTip1.SetToolTip(this.btExportDiagram, "Export Diagram");
            this.btExportDiagram.UseVisualStyleBackColor = true;
            this.btExportDiagram.Click += new System.EventHandler(this.btExportDiagram_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Initial Catalog";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Data Source";
            // 
            // btDrawTreeView
            // 
            this.btDrawTreeView.BackgroundImage = global::MDSManager2012.Desktop.Properties.Resources.validate_icon;
            this.btDrawTreeView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btDrawTreeView.Location = new System.Drawing.Point(163, 365);
            this.btDrawTreeView.Name = "btDrawTreeView";
            this.btDrawTreeView.Size = new System.Drawing.Size(19, 19);
            this.btDrawTreeView.TabIndex = 37;
            this.toolTip1.SetToolTip(this.btDrawTreeView, "Draw TreeView");
            this.btDrawTreeView.UseVisualStyleBackColor = true;
            this.btDrawTreeView.Click += new System.EventHandler(this.btDrawTreeView_Click);
            // 
            // treeView1
            // 
            this.treeView1.FullRowSelect = true;
            this.treeView1.Location = new System.Drawing.Point(12, 390);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(558, 117);
            this.treeView1.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "Version";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Model";
            // 
            // cbVersion
            // 
            this.cbVersion.FormattingEnabled = true;
            this.cbVersion.Location = new System.Drawing.Point(63, 33);
            this.cbVersion.Name = "cbVersion";
            this.cbVersion.Size = new System.Drawing.Size(217, 21);
            this.cbVersion.TabIndex = 40;
            // 
            // cbModel
            // 
            this.cbModel.FormattingEnabled = true;
            this.cbModel.Location = new System.Drawing.Point(63, 6);
            this.cbModel.Name = "cbModel";
            this.cbModel.Size = new System.Drawing.Size(217, 21);
            this.cbModel.TabIndex = 39;
            this.cbModel.SelectedIndexChanged += new System.EventHandler(this.cbModel_SelectedIndexChanged);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(17, 446);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 43;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 368);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = "TreeView Generator (Beta)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-2, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "AttachDB filename";
            // 
            // txtAttachDbFilename
            // 
            this.txtAttachDbFilename.Location = new System.Drawing.Point(95, 90);
            this.txtAttachDbFilename.Name = "txtAttachDbFilename";
            this.txtAttachDbFilename.Size = new System.Drawing.Size(147, 20);
            this.txtAttachDbFilename.TabIndex = 29;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtPass);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtUser);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtAttachDbFilename);
            this.groupBox1.Controls.Add(this.txtModellingDb);
            this.groupBox1.Controls.Add(this.cbInitialCatalog);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbDataSource);
            this.groupBox1.Location = new System.Drawing.Point(4, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 162);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection string elements";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtSingleConString);
            this.groupBox3.Location = new System.Drawing.Point(4, 183);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(266, 37);
            this.groupBox3.TabIndex = 32;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Single connection string";
            // 
            // txtSingleConString
            // 
            this.txtSingleConString.FormattingEnabled = true;
            this.txtSingleConString.Location = new System.Drawing.Point(6, 14);
            this.txtSingleConString.Name = "txtSingleConString";
            this.txtSingleConString.Size = new System.Drawing.Size(254, 21);
            this.txtSingleConString.TabIndex = 28;
            this.txtSingleConString.Text = "data source=(local);Integrated Security=True;initial catalog=MDS";
            // 
            // rbUseConStringElements
            // 
            this.rbUseConStringElements.AutoSize = true;
            this.rbUseConStringElements.Location = new System.Drawing.Point(3, 276);
            this.rbUseConStringElements.Name = "rbUseConStringElements";
            this.rbUseConStringElements.Size = new System.Drawing.Size(136, 17);
            this.rbUseConStringElements.TabIndex = 33;
            this.rbUseConStringElements.Text = "use con.string elements";
            this.rbUseConStringElements.UseVisualStyleBackColor = true;
            // 
            // rbUseSingleConString
            // 
            this.rbUseSingleConString.AutoSize = true;
            this.rbUseSingleConString.Checked = true;
            this.rbUseSingleConString.Location = new System.Drawing.Point(149, 276);
            this.rbUseSingleConString.Name = "rbUseSingleConString";
            this.rbUseSingleConString.Size = new System.Drawing.Size(121, 17);
            this.rbUseSingleConString.TabIndex = 34;
            this.rbUseSingleConString.TabStop = true;
            this.rbUseSingleConString.Text = "use single con.string";
            this.rbUseSingleConString.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(62, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "user";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(95, 116);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(147, 20);
            this.txtUser.TabIndex = 31;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(36, 145);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 34;
            this.label10.Text = "Password";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(95, 142);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(147, 20);
            this.txtPass.TabIndex = 33;
            // 
            // btHelp
            // 
            this.btHelp.Location = new System.Drawing.Point(286, 336);
            this.btHelp.Name = "btHelp";
            this.btHelp.Size = new System.Drawing.Size(123, 23);
            this.btHelp.TabIndex = 46;
            this.btHelp.Text = "Help";
            this.btHelp.UseVisualStyleBackColor = true;
            this.btHelp.Click += new System.EventHandler(this.btHelp_Click);
            // 
            // ckCreateDb
            // 
            this.ckCreateDb.AutoSize = true;
            this.ckCreateDb.Enabled = false;
            this.ckCreateDb.Location = new System.Drawing.Point(134, 253);
            this.ckCreateDb.Name = "ckCreateDb";
            this.ckCreateDb.Size = new System.Drawing.Size(142, 17);
            this.ckCreateDb.TabIndex = 35;
            this.ckCreateDb.Text = "Create new modelling db";
            this.ckCreateDb.UseVisualStyleBackColor = true;
            // 
            // ucManageEntities1
            // 
            this.ucManageEntities1.AutoSize = true;
            this.ucManageEntities1.Location = new System.Drawing.Point(286, 9);
            this.ucManageEntities1.Name = "ucManageEntities1";
            this.ucManageEntities1.Size = new System.Drawing.Size(284, 299);
            this.ucManageEntities1.TabIndex = 44;
            // 
            // ModelDiagramManager
            // 
            this.ClientSize = new System.Drawing.Size(570, 518);
            this.Controls.Add(this.btHelp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ucManageEntities1);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btExportDiagram);
            this.Controls.Add(this.cbVersion);
            this.Controls.Add(this.cbModel);
            this.Controls.Add(this.btDrawTreeView);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.groupBox2);
            this.MaximumSize = new System.Drawing.Size(586, 557);
            this.Name = "ModelDiagramManager";
            this.Text = "Model Diagram Manager";
            this.Load += new System.EventHandler(this.ModelDiagramManager_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btHelp_Click(object sender, EventArgs e)
        {
            string mess = @"How to use model diagram Manager ?
- be sure that your connection string is valid : e.g. if you use option 'use single con.string', 
you just have to put your mds database name after initial catalog, in 'single connection string' textbox
(and it should work if you use integrated security for your db in sql server) 

- using SSMS (SQL server management studio) :(drop and) create a new DB and name it MDSmodelling

- go back to MDS Manager and press red arrow button
- if no error, you should have some tables created in MDSmodelling Db : just generate a model diagram of MDSmodelling with SSMS and you will see your graphical MDS model

-db tables generation can last a few minutes
";


            MessageBox.Show(mess);
        }


    }
}

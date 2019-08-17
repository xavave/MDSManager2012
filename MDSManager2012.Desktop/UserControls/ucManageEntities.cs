using Common;
using Common.MDSService;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Common.Model;


namespace MDSManager2012.Desktop
{
    public class ucManageEntities : UserControl
    {
        private IContainer components = (IContainer)null;
        public ListBox lstEntities;
        public ListBox lstDerivedHierarchies;
        private List<CustomEntity> initialEntitylist;
        private List<Identifier> initialDHlist;
        private Button btCopyDHClipboard;
        private Button btCopyEntitiesClipboard;
        private ToolTip toolTip1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem copyEntityNamesToClipboardToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem displayDerivedHierarchyNamesListInANewWindowToolStripMenuItem;
        private ToolStripMenuItem copyDerivedHierarchyNameToolStripMenuItem;
        public TextBox txtEntityFilter;
        public TextBox txtFilterDH;
        private GroupBox gbDH;
        private Label lblError;

        private const int EM_SETCUEBANNER = 0x1501;
        private const int EM_GETCUEBANNER = 0x1502;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessageW(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);


        public ucManageEntities()
        {
            this.InitializeComponent();
            SendMessageW(txtEntityFilter.Handle, EM_SETCUEBANNER, 0, "Entity filter");
            SendMessageW(txtFilterDH.Handle, EM_SETCUEBANNER, 0, "Derived hierarchy filter");
          
        }

        public void DisplayEntities(Identifier modelId, Identifier versionId = null)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Metadata metadata = new Metadata();
                OperationResult or = new OperationResult();
              
                Metadata metaData = MDSWrapper.GetMetaData(new International(), ref or, modelId, (Identifier)null, (Identifier)null, MDAction.EntitiesOnly);
                if (metaData == null)
                    return;
                this.lstEntities.Items.Clear();
                Form1 form1 = this.FindForm() as Form1;
                //Using the progress bar requires using the asyncmethods
                //if (form1 != null)
                //{
                //    form1.progressBar1.Maximum = metaData.Entities.Count;
                //    form1.progressBar1.Update();
                //}
                foreach (Entity e in metaData.Entities)
                {
                    this.lstEntities.Items.Add((object)new CustomEntity(e, versionId));
                    //if (form1 != null)
                    //{
                    //    form1.progressBar1.PerformStep();
                    //    form1.progressBar1.Update();
                    //}
                }
                this.lstEntities.DisplayMember = "Name";
                //if (form1 != null)
                //{
                //    form1.progressBar1.Value = 0;
                //    form1.progressBar1.Update();
                //}
                this.initialEntitylist = Enumerable.ToList<CustomEntity>(Enumerable.Cast<CustomEntity>((IEnumerable)this.lstEntities.Items));

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

        public void DHvisible(bool v)
        {
            this.gbDH.Visible = v;
        }

        private void lstEntities_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;
            this.lstEntities.SelectedIndex = this.lstEntities.IndexFromPoint(new Point(e.X, e.Y));
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            this.contextMenuStrip1.Enabled = this.lstEntities.SelectedIndex > -1;
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "toolStripMenuItem1":
                    DisplayList displayList = new DisplayList();
                    displayList.txtDisplayList.Text = string.Join("\r\n", Enumerable.ToArray<string>(Enumerable.Select<CustomEntity, string>(Enumerable.Cast<CustomEntity>((IEnumerable)this.lstEntities.Items), (Func<CustomEntity, string>)(x => x.Name))));
                    displayList.Text = "Entity List (" + Enumerable.Count<string>((IEnumerable<string>)displayList.txtDisplayList.Lines).ToString() + " items)";
                    ((Control)displayList).Show();
                    break;
                case "copyEntityNamesToClipboardToolStripMenuItem":
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine((this.lstEntities.SelectedItem as CustomEntity).Name);
                    if (stringBuilder.Length <= 0)
                        break;
                    Clipboard.SetText(((object)stringBuilder).ToString());
                    break;
            }
        }

        private void lstDerivedHierarchies_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;
            this.lstDerivedHierarchies.SelectedIndex = this.lstDerivedHierarchies.IndexFromPoint(new Point(e.X, e.Y));
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {
            this.contextMenuStrip2.Enabled = this.lstDerivedHierarchies.SelectedIndex > -1;
        }

        private void contextMenuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "displayDerivedHierarchyNamesListInANewWindowToolStripMenuItem":
                    DisplayList displayList = new DisplayList();
                    displayList.txtDisplayList.Text = string.Join("\r\n", Enumerable.ToArray<string>(Enumerable.Select<Identifier, string>(Enumerable.Cast<Identifier>((IEnumerable)this.lstDerivedHierarchies.Items), (Func<Identifier, string>)(x => x.Name))));
                    displayList.Text = "Derived Hierarchy List (" + Enumerable.Count<string>((IEnumerable<string>)displayList.txtDisplayList.Lines).ToString() + " items)";
                    ((Control)displayList).Show();
                    break;
                case "copyDerivedHierarchyNameToolStripMenuItem":
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine((this.lstDerivedHierarchies.SelectedItem as Identifier).Name);
                    if (stringBuilder.Length <= 0)
                        break;
                    Clipboard.SetText(((object)stringBuilder).ToString());
                    break;
            }
        }

        public void DisplayDerivedHierarchies(Identifier modelId)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Metadata metadata = new Metadata();
                OperationResult or = new OperationResult();

                Metadata metaData = MDSWrapper.GetMetaData(new International(), ref or, modelId, (Identifier)null, (Identifier)null, MDAction.DerivedHierarchiesOnly);
                if (metaData == null)
                    return;
                this.lstDerivedHierarchies.Items.Clear();
                (this.FindForm() as Form1).ProgressBar.Maximum = metaData.DerivedHierarchies.Count;
                foreach (MdmDataContractOfModelContextIdentifier contextIdentifier in metaData.DerivedHierarchies)
                {
                    this.lstDerivedHierarchies.Items.Add((object)contextIdentifier.Identifier);
                    (this.FindForm() as Form1).ProgressBar.PerformStep();
                }
                this.lstDerivedHierarchies.DisplayMember = "Name";
                (this.FindForm() as Form1).ProgressBar.Value = 0;
                this.initialDHlist = Enumerable.ToList<Identifier>(Enumerable.Cast<Identifier>((IEnumerable)this.lstDerivedHierarchies.Items));

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

        private void lstEntities_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.RefreshList(sender as Control);
        }

        public void RefreshList(Control ctl)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (ctl.FindForm().Name != "ModelDiagramManager")
            {
                Form1 form1 = (Form1)this.FindForm();
                if (form1 != null && form1.lstVersions.SelectedItem != null)
                {
                    Control control = form1.FilterControlsOne(c => c is ucManageMembers);
                    if (control != null)
                    {
                        ucManageMembers ucManageMembers = (ucManageMembers)control;
                        Form1 form1_2 = (Form1)this.FindForm();
                        if (this.lstEntities.SelectedItem != null && form1_2.lstModels.SelectedItem != null)
                        {
                            ucManageMembers.DisplayMembers((Identifier)form1_2.lstModels.SelectedItem, (CustomVersion)form1_2.lstVersions.SelectedItem, (CustomEntity)this.lstEntities.SelectedItem, string.IsNullOrEmpty(ucManageMembers.txtMemberFilter.Text) ? string.Empty : ucManageMembers.txtMemberFilter.Text);
                            ucManageMembers.DisplayAttributes();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a model Version!");
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void btAddEntity_Click(object sender, EventArgs e)
        {
            ucManageEntities.CreateEntity("testmodel", "mynewentity2");
        }

        public static void CreateEntity(string ModelName, string newEntityName)
        {
            OperationResult OperationResult = new OperationResult();
            Metadata Metadata = new Metadata();
            Identifier identifier = new Identifier()
            {
                Name = ModelName
            };
            Metadata.Entities = new List<Entity>();
            List<Entity> entities = Metadata.Entities;
            Entity entity1 = new Entity();
            Entity entity2 = entity1;
            EntityContextIdentifier contextIdentifier1 = new EntityContextIdentifier();
            contextIdentifier1.Name = newEntityName;
            contextIdentifier1.ModelId = identifier;
            EntityContextIdentifier contextIdentifier2 = contextIdentifier1;
            entity2.Identifier = (ModelContextIdentifier)contextIdentifier2;
            entity1.IsFlat = true;
            Entity entity3 = entity1;
            List<ExplicitHierarchy> collection1 = new List<ExplicitHierarchy>();
            List<ExplicitHierarchy> collection2 = collection1;
            ExplicitHierarchy explicitHierarchy1 = new ExplicitHierarchy();
            ExplicitHierarchy explicitHierarchy2 = explicitHierarchy1;
            EntityContextIdentifier contextIdentifier3 = new EntityContextIdentifier();
            contextIdentifier3.ModelId = identifier;
            contextIdentifier3.Name = newEntityName;
            EntityContextIdentifier contextIdentifier4 = contextIdentifier3;
            explicitHierarchy2.Identifier = contextIdentifier4;
            ExplicitHierarchy explicitHierarchy3 = explicitHierarchy1;
            collection2.Add(explicitHierarchy3);
            List<ExplicitHierarchy> collection3 = collection1;
            entity3.ExplicitHierarchies = collection3;
            Entity entity4 = entity1;
            entities.Add(entity4);

            MDSWrapper.MetadataCreate(Metadata, true);


        }

        private void btCopyEntitiesClipboard_Click(object sender, EventArgs e)
        {
            this.CopyEntitiesListToClipBoard();
        }

        private void CopyEntitiesListToClipBoard()
        {
            StringBuilder stringBuilder = new StringBuilder();
            int num1 = 0;
            foreach (object obj in this.lstEntities.Items)
            {
                stringBuilder.AppendLine((obj as CustomEntity).Name);
                ++num1;
            }
            if (stringBuilder.Length <= 0)
                return;
            Clipboard.SetText(((object)stringBuilder).ToString());
            MessageBox.Show(num1.ToString() + " entity name(s) copied to clipboard!");
        }

        private void btCopyDHClipboard_Click(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int num1 = 0;
            foreach (object obj in this.lstDerivedHierarchies.Items)
            {
                stringBuilder.AppendLine((obj as Identifier).Name);
                ++num1;
            }
            if (stringBuilder.Length <= 0)
                return;
            Clipboard.SetText(((object)stringBuilder).ToString());
            MessageBox.Show(num1.ToString() + " derived hierarchy name(s) copied to clipboard!");
        }

        private void txtEntityFilter_TextChanged(object sender, EventArgs e)
        {
            this.FilterEntityChanged<CustomEntity, CustomEntity>(this.lstEntities, this.initialEntitylist, this.txtEntityFilter.Text);
        }

        private void FilterEntityChanged<TInput, TOutput>(ListBox lst, List<TInput> initialList, string filterTxt) where TInput : TOutput
        {
            if (initialList == null)
                return;
            lst.BeginUpdate();
            lst.Items.Clear();
            List<CustomEntity> list = Tools.FilterEntities(initialList as List<CustomEntity>, filterTxt);
            lst.Items.AddRange((object[])list.ToArray());
            lst.EndUpdate();
        }

        private void FilterDHChanged<TInput, TOutput>(ListBox lst, List<TInput> initialList, string filterTxt) where TInput : TOutput
        {
            if (initialList == null)
                return;
            lst.BeginUpdate();
            lst.Items.Clear();
            List<Identifier> list = Tools.FilterIdentifier(initialList as List<Identifier>, filterTxt);
            lst.Items.AddRange((object[])list.ToArray());
            lst.EndUpdate();
        }

        private void txtEntityFilter_Enter(object sender, EventArgs e)
        {
            this.InitLst<CustomEntity>(this.lstEntities, sender as TextBox, this.initialEntitylist);
        }

        private void InitLst<T>(ListBox lst, TextBox txtBxToClear, List<T> initialList) where T : CustomEntity
        {
            if (initialList == null)
                return;
            txtBxToClear.Text = string.Empty;
            lst.BeginUpdate();
            lst.Items.Clear();
            lst.Items.AddRange((object[])initialList.ToArray());
            lst.EndUpdate();
        }

        private void InitIdentifierLst(ListBox lst, TextBox txtBxToClear, List<Identifier> initialList)
        {
            if (initialList == null)
                return;
            txtBxToClear.Text = string.Empty;
            lst.BeginUpdate();
            lst.Items.Clear();
            lst.Items.AddRange((object[])initialList.ToArray());
            lst.EndUpdate();
        }

        private void txtFilterDH_TextChanged(object sender, EventArgs e)
        {
            this.FilterDHChanged<Identifier, Identifier>(this.lstDerivedHierarchies, this.initialDHlist, this.txtFilterDH.Text);
        }

        private void txtFilterDH_Enter(object sender, EventArgs e)
        {
            this.InitIdentifierLst(this.lstDerivedHierarchies, sender as TextBox, this.initialDHlist);
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
            this.lstEntities = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.copyEntityNamesToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lstDerivedHierarchies = new System.Windows.Forms.ListBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.displayDerivedHierarchyNamesListInANewWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyDerivedHierarchyNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btCopyDHClipboard = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtEntityFilter = new System.Windows.Forms.TextBox();
            this.txtFilterDH = new System.Windows.Forms.TextBox();
            this.btCopyEntitiesClipboard = new System.Windows.Forms.Button();
            this.gbDH = new System.Windows.Forms.GroupBox();
            this.lblError = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.gbDH.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstEntities
            // 
            this.lstEntities.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstEntities.ContextMenuStrip = this.contextMenuStrip1;
            this.lstEntities.FormattingEnabled = true;
            this.lstEntities.ItemHeight = 16;
            this.lstEntities.Location = new System.Drawing.Point(3, 30);
            this.lstEntities.Name = "lstEntities";
            this.lstEntities.Size = new System.Drawing.Size(281, 148);
            this.lstEntities.TabIndex = 0;
            this.lstEntities.SelectedIndexChanged += new System.EventHandler(this.lstEntities_SelectedIndexChanged);
            this.lstEntities.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstEntities_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.copyEntityNamesToClipboardToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(334, 52);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(333, 24);
            this.toolStripMenuItem1.Text = "Display Entity Names in a new window";
            // 
            // copyEntityNamesToClipboardToolStripMenuItem
            // 
            this.copyEntityNamesToClipboardToolStripMenuItem.Name = "copyEntityNamesToClipboardToolStripMenuItem";
            this.copyEntityNamesToClipboardToolStripMenuItem.Size = new System.Drawing.Size(333, 24);
            this.copyEntityNamesToClipboardToolStripMenuItem.Text = "Copy Entity Name";
            // 
            // lstDerivedHierarchies
            // 
            this.lstDerivedHierarchies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstDerivedHierarchies.ContextMenuStrip = this.contextMenuStrip2;
            this.lstDerivedHierarchies.FormattingEnabled = true;
            this.lstDerivedHierarchies.ItemHeight = 16;
            this.lstDerivedHierarchies.Location = new System.Drawing.Point(0, 45);
            this.lstDerivedHierarchies.Name = "lstDerivedHierarchies";
            this.lstDerivedHierarchies.Size = new System.Drawing.Size(287, 132);
            this.lstDerivedHierarchies.TabIndex = 2;
            this.lstDerivedHierarchies.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstDerivedHierarchies_MouseDown);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayDerivedHierarchyNamesListInANewWindowToolStripMenuItem,
            this.copyDerivedHierarchyNameToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(442, 52);
            this.contextMenuStrip2.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip2_Opening);
            this.contextMenuStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip2_ItemClicked);
            // 
            // displayDerivedHierarchyNamesListInANewWindowToolStripMenuItem
            // 
            this.displayDerivedHierarchyNamesListInANewWindowToolStripMenuItem.Name = "displayDerivedHierarchyNamesListInANewWindowToolStripMenuItem";
            this.displayDerivedHierarchyNamesListInANewWindowToolStripMenuItem.Size = new System.Drawing.Size(441, 24);
            this.displayDerivedHierarchyNamesListInANewWindowToolStripMenuItem.Text = "Display Derived Hierarchy Names List in a new window";
            // 
            // copyDerivedHierarchyNameToolStripMenuItem
            // 
            this.copyDerivedHierarchyNameToolStripMenuItem.Name = "copyDerivedHierarchyNameToolStripMenuItem";
            this.copyDerivedHierarchyNameToolStripMenuItem.Size = new System.Drawing.Size(441, 24);
            this.copyDerivedHierarchyNameToolStripMenuItem.Text = "Copy Derived Hierarchy Name";
            // 
            // btCopyDHClipboard
            // 
            this.btCopyDHClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCopyDHClipboard.BackgroundImage = global::MDSManager2012.Desktop.Properties.Resources.pn_add_source_copy;
            this.btCopyDHClipboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btCopyDHClipboard.Location = new System.Drawing.Point(259, 20);
            this.btCopyDHClipboard.Name = "btCopyDHClipboard";
            this.btCopyDHClipboard.Size = new System.Drawing.Size(24, 20);
            this.btCopyDHClipboard.TabIndex = 37;
            this.toolTip1.SetToolTip(this.btCopyDHClipboard, "Copy filtered Derived Hierarchies List to clipboard");
            this.btCopyDHClipboard.UseVisualStyleBackColor = true;
            this.btCopyDHClipboard.Click += new System.EventHandler(this.btCopyDHClipboard_Click);
            // 
            // txtEntityFilter
            // 
            this.txtEntityFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEntityFilter.Location = new System.Drawing.Point(3, 4);
            this.txtEntityFilter.Name = "txtEntityFilter";
            this.txtEntityFilter.Size = new System.Drawing.Size(250, 22);
            this.txtEntityFilter.TabIndex = 39;
            this.toolTip1.SetToolTip(this.txtEntityFilter, "Entities Filter (by name)");
            this.txtEntityFilter.TextChanged += new System.EventHandler(this.txtEntityFilter_TextChanged);
            this.txtEntityFilter.Enter += new System.EventHandler(this.txtEntityFilter_Enter);
            // 
            // txtFilterDH
            // 
            this.txtFilterDH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilterDH.Location = new System.Drawing.Point(4, 20);
            this.txtFilterDH.Name = "txtFilterDH";
            this.txtFilterDH.Size = new System.Drawing.Size(253, 22);
            this.txtFilterDH.TabIndex = 40;
            this.toolTip1.SetToolTip(this.txtFilterDH, "Derived Hierarchies Filter (by name)");
            this.txtFilterDH.TextChanged += new System.EventHandler(this.txtFilterDH_TextChanged);
            this.txtFilterDH.Enter += new System.EventHandler(this.txtFilterDH_Enter);
            // 
            // btCopyEntitiesClipboard
            // 
            this.btCopyEntitiesClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCopyEntitiesClipboard.BackgroundImage = global::MDSManager2012.Desktop.Properties.Resources.pn_add_source_copy;
            this.btCopyEntitiesClipboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btCopyEntitiesClipboard.Location = new System.Drawing.Point(258, 3);
            this.btCopyEntitiesClipboard.Name = "btCopyEntitiesClipboard";
            this.btCopyEntitiesClipboard.Size = new System.Drawing.Size(24, 21);
            this.btCopyEntitiesClipboard.TabIndex = 38;
            this.toolTip1.SetToolTip(this.btCopyEntitiesClipboard, "Copy filtered Entities list to clipboard");
            this.btCopyEntitiesClipboard.UseVisualStyleBackColor = true;
            this.btCopyEntitiesClipboard.Click += new System.EventHandler(this.btCopyEntitiesClipboard_Click);
            // 
            // gbDH
            // 
            this.gbDH.Controls.Add(this.lstDerivedHierarchies);
            this.gbDH.Controls.Add(this.txtFilterDH);
            this.gbDH.Controls.Add(this.btCopyDHClipboard);
            this.gbDH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDH.Location = new System.Drawing.Point(0, 0);
            this.gbDH.Name = "gbDH";
            this.gbDH.Size = new System.Drawing.Size(287, 176);
            this.gbDH.TabIndex = 41;
            this.gbDH.TabStop = false;
            this.gbDH.Text = "Derived Hierarchies";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblError.Location = new System.Drawing.Point(0, 363);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 17);
            this.lblError.TabIndex = 42;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(293, 363);
            this.tableLayoutPanel1.TabIndex = 43;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtEntityFilter);
            this.panel1.Controls.Add(this.btCopyEntitiesClipboard);
            this.panel1.Controls.Add(this.lstEntities);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(287, 175);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gbDH);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 184);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(287, 176);
            this.panel2.TabIndex = 1;
            // 
            // ucManageEntities
            // 
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lblError);
            this.Name = "ucManageEntities";
            this.Size = new System.Drawing.Size(293, 380);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.gbDH.ResumeLayout(false);
            this.gbDH.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Panel panel2;
    }
}

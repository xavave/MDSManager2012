using Common;
using Common.MDSService;

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
//using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using Common.Exceptions;
using System.Runtime.InteropServices;
using MDSManager2012.Desktop.AppLogic;
using Common.Model;
using System.Text.RegularExpressions;


namespace MDSManager2012.Desktop
{
    public partial class Form1 : BaseForm
    {
        private List<Identifier> lstDBA = new List<Identifier>();
        private List<string> deletedEntityMembers = (List<string>)null;
        private IContainer components = (IContainer)null;
        public static Form1 staticMainForm;
        public ListBox lstModels;
        public ListBox lstVersions;
        private MainConfiguration conf;
        private static ConfigurationManager cm;
        private ListBox lstExportViews;
        private Button btExport;
        private Button btImportViews;
        private OpenFileDialog openFileDialog1;
        private Button btDeleteViews;
        private ucManageMembers ucManageMembers1;
        public ListBox lstFlags;
        private GroupBox gbImportViewMode;
        private ToolTip toolTip1;
        private RadioButton rbImportViewManual;
        private RadioButton rbImportViewAuto;
        private GroupBox gbAppendViewName;
        public TextBox txtAppendToViewName;
        private CheckBox chkAppendToViewName;
        private GroupBox gbSubscriptionViews;
        private GroupBox gbMembers;
        private Button btRefreshModels;
        private GroupBox gbAttributes;
        private Label label2;
        private Label label4;
        private Button btAddMember;
        private Button btDeleteMemberAttribute;
        public TextBox txtAttributeName;
        public TextBox txtAttributeValue;
        private Button btUpdateMember;
        private Label label10;
        public TextBox txtAttributeType;
        private GroupBox gbBasedOn;
        private RadioButton rbBasedOnFlag;
        private RadioButton rbBasedOnVersion;
        private Button btRefreshVersionAndFlagLists;
        private GroupBox groupBox1;
        private Button btnDeleteAllMembers;
        private PictureBox pictureBoxInfo;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button btDeleteVersion;
        private Button btDeleteFlag;
        private GroupBox gbConnection;
        private Button btRefreshConnection;
        private Button btVersionCopy;
        private Label label12;
        private Label label11;
        private Button btDeleteAllMembersFromAllEntities;
        private Button btValidateMember;
        private Label label13;
        public TextBox txtValidationStatus;
        private Button btTest;
        private Button btTest2;
        private Button btEntityManager;
        private Button btValidateVersion;
        private ucManageEntities ucManageEntities1;
        private Button btBusinessRulesManager;
        private Button btModelDiagramManager;
        private Button btUserRightsManager;
        private Button btPackageDeploy;
        private Button btConnManager;
        public ComboBox cbEndPointAddress;

        //public ConfigValue _activeConnectionConfig;

        private const int EM_SETCUEBANNER = 0x1501;
        private const int EM_GETCUEBANNER = 0x1502;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessageW(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);


        public Form1()
        {
            this.InitializeComponent();
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception exception;
            if (e.ExceptionObject.GetType() == typeof(Exception))
            {
                exception = ((Exception)e.ExceptionObject).InnerException;
            }
            else
                exception = e.ExceptionObject as Exception;

            toolStripStatusLabel1.Text = exception.Message;
            Cursor.Current = Cursors.Default;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Text = Application.ProductName + " v" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
                EnableForms(false);

                cbEndPointAddress.DataSource = MainConfiguration.GetConfigValues();
                cbEndPointAddress.DisplayMember = "ConfigName";

                Form1.staticMainForm = this;
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "Access is denied or MDS Service is down, or Endpoint Address is not valid! Please verify your user access rights and the Endpoint Address.;" + ex.Message;
                EnableForms(false);
            }

        }



        //Uri.IsWellFormedUriString(cv.EndpointUri, UriKind.RelativeOrAbsolute)
        //toolStripStatusLabel1.Text = "Enpoint Uri is not well formed!";






        /*
        private void GroupSecurityPrincipalsGet()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                SecurityPrincipals usersAndGroups = MDSWrapper.GetUsersAndGroups((Identifier)null);
                this.lstGroups.Items.Clear();
                foreach (Group group in usersAndGroups.Groups)
                    this.lstGroups.Items.Add((object)group.Identifier.Name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }*/

        public void GetModels()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                List<Model> modelList = MDSWrapper.ModelGet();
                this.lstModels.Items.Clear();
                if (modelList != null && modelList.Count > 0)
                {
                    this.progressBar1.Maximum = modelList.Count;
                    this.progressBar1.Step = 1;
                    foreach (MdmDataContractOfIdentifier contractOfIdentifier in modelList)
                    {
                        this.lstModels.Items.Add(contractOfIdentifier.Identifier);
                        this.progressBar1.PerformStep();
                    }
                    this.lstModels.DisplayMember = "Name";
                    this.progressBar1.Value = 0;
                }
                else
                    toolStripStatusLabel1.Text = "can't retrieve models or no models to display";
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = ex.Message;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void lstModels_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DisplayVersionsFlagsEntitiesDerivedHierarchies();
            this.RefreshLstViews();
        }

        private void DisplayVersionsFlagsEntitiesDerivedHierarchies()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (this.lstModels.SelectedItem != null)
                {
                    OperationResult or = new OperationResult();

                    this.DisplayVersions(MDSWrapper.GetMetaData(new International(), ref or, this.lstModels.SelectedItem as Identifier, (Identifier)null, (Identifier)null, MDAction.VersionsOnly));
                    this.DisplayVersionFlags(MDSWrapper.GetMetaData(new International(), ref or, this.lstModels.SelectedItem as Identifier, (Identifier)null, (Identifier)null, MDAction.FlagsOnly));
                    MDSWrapper.GetSubscriptionViewList(out or);
                    this.ucManageEntities1.DHvisible(true);
                    this.ucManageEntities1.DisplayEntities((Identifier)this.lstModels.SelectedItem, ((CustomVersion)this.lstVersions.SelectedItem).Identifier);
                    this.ucManageEntities1.DisplayDerivedHierarchies((Identifier)this.lstModels.SelectedItem);

                }
                this.ucManageEntities1.RefreshList((Control)this);
                this.ucManageMembers1.CleanListBoxes();
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = ex.Message;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void DisplayExportViewList(List<ExportView> colEV)
        {
            lstExportViews.Items.Clear();
            progressBar1.Maximum = colEV.Count;
            foreach (ExportView exportView in colEV)
            {
                if (exportView.ModelId.Id == ((Identifier)this.lstModels.SelectedItem).Id)
                {
                    this.lstExportViews.Items.Add((object)exportView.Identifier);
                    this.progressBar1.PerformStep();
                }
            }
            progressBar1.Value = 0;
            lstExportViews.DisplayMember = "Name";
        }

        private void DisplayVersions(Metadata md)
        {
            try
            {
                this.lstVersions.Items.Clear();
                foreach (Common.MDSService.Version v in md.Versions)
                {
                    if (v.Identifier.ModelId.Id == ((Identifier)this.lstModels.SelectedItem).Id)
                        this.lstVersions.Items.Add((object)new CustomVersion(v));
                }
                this.lstVersions.DisplayMember = "Name";
                if (this.lstVersions.Items.Count > 0)
                {
                    this.lstVersions.SelectedIndex = 0;
                }
                else
                {
                    this.rbBasedOnVersion.Checked = false;
                    this.rbBasedOnVersion.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = ex.Message;
                throw;
            }
        }

        private void DisplayVersionFlags(Metadata md)
        {
            this.lstFlags.Items.Clear();
            foreach (VersionFlag vf in md.VersionFlags)
            {
                if (vf.Identifier.ModelId.Id == ((Identifier)this.lstModels.SelectedItem).Id)
                    this.lstFlags.Items.Add((object)new CustomFlag(vf));
            }
            this.lstFlags.DisplayMember = "Name";
            this.rbBasedOnFlag.Checked = this.lstFlags.Items.Count > 0;
            this.rbBasedOnFlag.Enabled = this.lstFlags.Items.Count > 0;
        }

        private void btExportViews_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (this.lstExportViews.SelectedItems.Count == 0)
                    throw new SubscriptionViewException("No subscription views selected for export!");
                if (this.folderBrowserDialog1.ShowDialog() != DialogResult.OK)
                    return;
                MDSWrapper.ExportSubscriptionViews(this.folderBrowserDialog1.SelectedPath + "\\", Enumerable.ToList<Identifier>(Enumerable.Cast<Identifier>((IEnumerable)this.lstExportViews.SelectedItems)));
                MessageBox.Show("Subscription view(s) successfully exported");
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = ex.Message;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void RefreshLstViews()
        {
            if (this.lstModels.SelectedItem != null)
            {
                OperationResult or;
                this.DisplayExportViewList(MDSWrapper.GetSubscriptionViewList(out or));
            }
            this.lstExportViews.Refresh();
        }

        private void CreateMember()
        {
            EntityMembers entityMembers = new EntityMembers();
        }

        private void btImportViews_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (this.rbImportViewManual.Checked && this.lstModels.SelectedItem == null)
                    throw new SubscriptionViewException("Please select a model and a version or a flag (if existing) to import Views into");
                if (this.lstVersions.SelectedItem == null && this.rbBasedOnVersion.Checked)
                    throw new SubscriptionViewException("You must select a version if you choose to import views \"based on the selected version\"");
                if (this.lstFlags.SelectedItem == null && this.rbBasedOnFlag.Checked)
                    throw new SubscriptionViewException("You must select a flag if you choose to import views \"based on the selected flag\"");
                string folderPath = string.Empty;
                if (!Directory.Exists(folderPath) && this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    folderPath = this.folderBrowserDialog1.SelectedPath;
                Identifier modelId = this.lstModels.SelectedItem as Identifier;
                CustomVersion versionId = this.lstVersions.SelectedItem as CustomVersion;
                CustomFlag customFlag = this.lstFlags.SelectedItem as CustomFlag;
                List<Identifier> derivedHierarchies = new List<Identifier>();
                foreach (object obj in this.ucManageEntities1.lstDerivedHierarchies.Items)
                    derivedHierarchies.Add(obj as Identifier);
                List<CustomEntity> customEntities = new List<CustomEntity>();
                foreach (object obj in this.ucManageEntities1.lstEntities.Items)
                    customEntities.Add(obj as CustomEntity);
                var fileNames = Directory.GetFiles(folderPath, "*.XML");
                var ret = MDSWrapper.ImportSubscriptionViews(fileNames, modelId, versionId, customFlag, chkAppendToViewName.Checked, this.txtAppendToViewName.Text, this.rbImportViewManual.Checked, this.rbBasedOnVersion.Checked, this.rbBasedOnFlag.Checked, derivedHierarchies, customEntities);
                if (!string.IsNullOrEmpty(ret))
                {
                    toolStripStatusLabel1.Text = ret;
                }
                this.RefreshLstViews();
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = ex.Message;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btDeleteViews_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportView));
                foreach (Identifier Identifier in this.lstExportViews.SelectedItems)
                {
                    MDSWrapper.ServiceClient.ExportViewDelete(new International(), Identifier);
                }
                this.RefreshLstViews();
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = ex.Message;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void lstVersions_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ucManageEntities1.RefreshList((Control)this);
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            try
            {
                var attributeName = this.txtAttributeName.Text.Trim();
                if (!string.IsNullOrEmpty(this.txtAttributeValue.Text.Trim()) && !string.IsNullOrEmpty(attributeName))
                {
                    Regex r = new Regex("[^A-Z0-9.$ ]$");
                    if (r.IsMatch(attributeName))
                    {
                        // validation failed
                        toolStripStatusLabel1.Text = "attribute Name contains illegal characters";
                    }
                    else
                    {
                        StringBuilder err = MDSWrapper.ManageMember(Common.MemberAction.AddMember, this.lstModels.SelectedItem as Identifier, this.ucManageEntities1.lstEntities.SelectedItem as CustomEntity, this.lstVersions.SelectedItem as CustomVersion, this.ucManageMembers1.lstMembers.SelectedItem as CustomMember, this.txtAttributeName.Text.Trim(), this.txtAttributeValue.Text.Trim());
                        if (err.Length > 0)
                        {
                            toolStripStatusLabel1.Text = err.ToString();
                        }
                        else
                        {
                            this.RefreshLstMembersAttributes((Identifier)this.lstModels.SelectedItem, (CustomEntity)this.ucManageEntities1.lstEntities.SelectedItem, (CustomVersion)this.lstVersions.SelectedItem);

                        }
                    }
                }
                else
                    toolStripStatusLabel1.Text = "You must fill Member Attributes Name and Value";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Errors");
            }
        }



        public void RefreshLstMembersAttributes(Identifier modelId, CustomEntity entity, CustomVersion versionId)
        {
            try
            {
                if (modelId == null || entity == null || versionId == null)
                    return;
                this.ucManageMembers1.DisplayAttributes();
                string searchTerm = string.Empty;
                if (!string.IsNullOrEmpty(this.ucManageMembers1.txtMemberFilter.Text))
                    searchTerm = string.Format(" {0}  LIKE '{1}'  0.5 1 0.32 ", this.ucManageMembers1.rbSearchByCode.Checked ? (object)"[Code]" : (object)"[Name]", (object)this.ucManageMembers1.txtMemberFilter.Text);
                this.ucManageMembers1.DisplayMembers(modelId, versionId, entity, searchTerm);
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = ex.Message;
            }
        }

        private void btDeleteMember_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtAttributeValue.Text.Trim()))
            {
                var err = MDSWrapper.ManageMember(Common.MemberAction.DeleteMember, this.lstModels.SelectedItem as Identifier, this.ucManageEntities1.lstEntities.SelectedItem as CustomEntity, this.lstVersions.SelectedItem as CustomVersion, this.ucManageMembers1.lstMembers.SelectedItem as CustomMember, this.txtAttributeName.Text.Trim(), this.txtAttributeValue.Text.Trim());
                if (err.Length > 0)
                {
                    toolStripStatusLabel1.Text = err.ToString();
                }
                else
                {
                    this.RefreshLstMembersAttributes((Identifier)this.lstModels.SelectedItem, (CustomEntity)this.ucManageEntities1.lstEntities.SelectedItem, (CustomVersion)this.lstVersions.SelectedItem);

                }
            }
            else
                toolStripStatusLabel1.Text = "You must fill Member Attribute Value";
        }

        private void btUpdateMember_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtAttributeValue.Text.Trim()))
            {
                Regex r = new Regex("[^A-Z0-9.$ ]$");
                if (r.IsMatch(this.txtAttributeValue.Text.Trim()))
                {
                    // validation failed
                    toolStripStatusLabel1.Text = "attribute Name contains illegal characters";
                }
                else
                {
                    var err = MDSWrapper.ManageMember(Common.MemberAction.UpdateMember, this.lstModels.SelectedItem as Identifier, this.ucManageEntities1.lstEntities.SelectedItem as CustomEntity, this.lstVersions.SelectedItem as CustomVersion, this.ucManageMembers1.lstMembers.SelectedItem as CustomMember, this.txtAttributeName.Text.Trim(), this.txtAttributeValue.Text.Trim());
                    if (err.Length > 0)
                    {
                        toolStripStatusLabel1.Text = err.ToString();
                    }
                    else
                    {
                        this.RefreshLstMembersAttributes((Identifier)this.lstModels.SelectedItem, (CustomEntity)this.ucManageEntities1.lstEntities.SelectedItem, (CustomVersion)this.lstVersions.SelectedItem);

                    }
                }
            }
            else
                toolStripStatusLabel1.Text = "You must fill Member Attribute Value";
        }

        private void btRefreshModels_Click(object sender, EventArgs e)
        {
            this.GetModels();
        }

        private void btRefreshConnection_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (cbEndPointAddress.SelectedIndex > -1)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    toolStripStatusLabel1.Text = "trying to connect...";
                    //_activeConnectionConfig = cbEndPointAddress.SelectedValue as ConfigValue;
                    MDSWrapper.Configuration = cbEndPointAddress.SelectedValue as ConfigValue;

                    if (MDSWrapper.Configuration == null)
                    {
                        if (this.cbEndPointAddress.Items.Count > 0)
                            toolStripStatusLabel1.Text = "Please select a connection configuration.";
                        else
                            toolStripStatusLabel1.Text = "Please create a new connection configuration in Connection Manager!";
                        return;
                    }
                    MDSWrapper.ServiceClient.ServiceCheckCompleted += (o, ev) => CheckIfServiceUpCompleted(ev);
                    CheckIfServiceUp();
                   

                }
                else
                {
                    toolStripStatusLabel1.Text = "Please select a connection.";
                    EnableForms(false);
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = ex.Message;
                Cursor.Current = Cursors.Default;

            }

        }

        public override void CheckIfServiceUpCompleted(ServiceCheckCompletedEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                GetModels();
                EnableForms(true);
                toolStripStatusLabel1.Text = "Connected!";
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

        public void EnableForms(bool p)
        {
            //this.btBusinessRulesManager.Enabled = p;
            this.btEntityManager.Enabled = p;
            this.btModelDiagramManager.Enabled = p;
            this.btPackageDeploy.Enabled = p;
        }

        private void rbImportViewManual_CheckedChanged(object sender, EventArgs e)
        {
            this.gbBasedOn.Enabled = this.rbImportViewManual.Checked;
        }

        private void btRefreshVersionAndFlagLists_Click(object sender, EventArgs e)
        {
            this.RefreshVersionAndFlags();
        }

        private void RefreshVersionAndFlags()
        {
            try
            {
                if (this.lstModels.SelectedItem != null)
                {
                    toolStripStatusLabel1.Text = string.Empty;
                    Cursor.Current = Cursors.WaitCursor;
                    OperationResult or = new OperationResult();

                    this.DisplayVersions(MDSWrapper.GetMetaData(new International(), ref or, this.lstModels.SelectedItem as Identifier, (Identifier)null, (Identifier)null, MDAction.VersionsOnly));
                    this.DisplayVersionFlags(MDSWrapper.GetMetaData(new International(), ref or, this.lstModels.SelectedItem as Identifier, (Identifier)null, (Identifier)null, MDAction.FlagsOnly));

                }
                else
                    toolStripStatusLabel1.Text = "You must select a model first!";
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = ex.Message;
                throw;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnDeleteAllMembers_Click(object sender, EventArgs e)
        {
            if (this.ucManageEntities1.lstEntities.SelectedItem != null)
            {
                if (MessageBox.Show("This operation is irreversible. Are you sure you want to delete all members from this entity ?", "Delete all entity members from selected entity", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                    return;
                this.BulkDeleteMembersFromEntity((CustomEntity)this.ucManageEntities1.lstEntities.SelectedItem);
                this.RefreshLstMembersAttributes((Identifier)this.lstModels.SelectedItem, (CustomEntity)this.ucManageEntities1.lstEntities.SelectedItem, (CustomVersion)this.lstVersions.SelectedItem);
            }
            else
            {
                MessageBox.Show("You must select an entity to perform this operation !");
            }
        }

        public void BulkDeleteMembersFromEntity(CustomEntity selectedEntity)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (this.lstModels.SelectedItem == null || this.lstVersions.SelectedItem == null)
                    return;
                string name1 = selectedEntity.Name;
                Identifier identifier1 = (Identifier)selectedEntity.entityId;
                Identifier modelId = this.lstModels.SelectedItem as Identifier;
                string name2 = (this.lstModels.SelectedItem as Identifier).Name;
                Identifier identifier2 = (this.lstVersions.SelectedItem as CustomVersion).Identifier;
                string name3 = (this.lstVersions.SelectedItem as CustomVersion).Name;
                List<Common.MDSService.Member> members = MDSWrapper.GetMembers(modelId, identifier2, selectedEntity, "");
                OperationResult or = new OperationResult();
                List<EntityMembers> modelMembers = new List<EntityMembers>()
        {
          new EntityMembers()
          {
            EntityId = identifier1,
            ModelId = modelId,
            VersionId = identifier2,
            Members = members,
            MemberType = new MemberType?(MemberType.Leaf)
          }
        };
                DateTime now = DateTime.Now;
                List<Identifier> collection = this.ModelMembersBulkDelete(modelMembers);
                this.StagingGet(collection, true, true, true, true, ref or);
                this.ProcessUnbatchedStaging(modelId, identifier2);
                this.ClearBatch(collection);
                TimeSpan timeSpan = DateTime.Now.Subtract(now);
                toolStripStatusLabel1.Text = string.Concat(new object[4]
        {
          (object) "members (bulk) deleted  : ",
          (object) Enumerable.Count<Common.MDSService.Member>((IEnumerable<Common.MDSService.Member>) Enumerable.First<EntityMembers>((IEnumerable<EntityMembers>) modelMembers).Members),
          (object) " --- time elapsed (seconds):",
          (object) timeSpan.TotalSeconds.ToString()
        });
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

        private void ClearBatch(List<Identifier> batches)
        {
            OperationResult OperationResult = new OperationResult();
            int BatchesQueuedToClearCount = 0;
            int MemberRecordsClearedCount = 0;
            int RelationshipRecordsClearedCount = 0;
            MDSWrapper.ServiceClient.StagingClear(new International(), batches, out BatchesQueuedToClearCount, out MemberRecordsClearedCount, out OperationResult, out RelationshipRecordsClearedCount);
            toolStripStatusLabel1.Text = "BatchesQueuedToClearCount:" + BatchesQueuedToClearCount.ToString() + " -- MemberRecordsClearedCount:" + MemberRecordsClearedCount.ToString() + " -- RelationshipRecordsClearedCount:" + RelationshipRecordsClearedCount.ToString() + (Enumerable.FirstOrDefault<Common.MDSService.Error>((IEnumerable<Common.MDSService.Error>)OperationResult.Errors) != null ? Enumerable.First<Common.MDSService.Error>((IEnumerable<Common.MDSService.Error>)OperationResult.Errors).Code + " - " + Enumerable.First<Common.MDSService.Error>((IEnumerable<Common.MDSService.Error>)OperationResult.Errors).Description : string.Empty);
        }

        public void DeleteAllMembersFromSelectedEntity(CustomEntity selectedEntity)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (selectedEntity == null)
                    return;
                Identifier identifier1 = (Identifier)selectedEntity.entityId;
                Identifier modelId = (Identifier)this.lstModels.SelectedItem;
                Identifier identifier2 = ((CustomVersion)this.lstVersions.SelectedItem).Identifier;
                List<Common.MDSService.Member> members = MDSWrapper.GetMembers(modelId, identifier2, selectedEntity, string.Empty);
                this.progressBar1.Value = this.progressBar1.Minimum;
                this.progressBar1.Maximum = members.Count;
                this.progressBar1.Step = 1;
                OperationResult operationResult = new OperationResult();
                this.progressBar1.Value = this.progressBar1.Minimum;
                this.progressBar1.Maximum = members.Count;
                this.progressBar1.Step = 1;
                EntityMembers Members = new EntityMembers();
                Members.ModelId = modelId;
                Members.EntityId = identifier1;
                Members.VersionId = identifier2;
                Members.MemberType = new MemberType?(MemberType.Leaf);
                Members.Members = new List<Common.MDSService.Member>();
                foreach (Common.MDSService.Member member in members)
                {
                    Members.Members.Add(member);
                    this.progressBar1.PerformStep();
                    //this.progressBar1.PerformLayout();
                }

                operationResult = MDSWrapper.ServiceClient.EntityMembersDelete(new International(), Members);
                this.progressBar1.Value = this.progressBar1.Minimum;
                StringBuilder stringBuilder = new StringBuilder();
                if (operationResult.Errors.Count > 0)
                {
                    foreach (Common.MDSService.Error error in operationResult.Errors)
                        stringBuilder.AppendLine(Members.Members[0].MemberId.Code + " - " + error.Code + " - " + error.Description);
                    MessageBox.Show(((object)stringBuilder).ToString(), "Errors");
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

        private void button1_Click(object sender, EventArgs e)
        {
            MDSWrapper.CreateBR2((this.ucManageEntities1.lstEntities.SelectedItem as CustomEntity).Name, "number", (this.lstModels.SelectedItem as Identifier).Name);
        }

        private void pictureBoxInfo_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = string.Empty;
        }

        private void btAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                SecurityPrincipalsCriteria Criteria = new SecurityPrincipalsCriteria();
                Criteria.All = false;
                Criteria.SecurityResolutionType = SecurityResolutionType.Users;
                Criteria.Identifiers = new List<Identifier>()
        {
          new Identifier()
        };
                Criteria.Type = PrincipalType.UserAccount;
                Criteria.ResultType = ResultType.Details;
                Criteria.ModelPrivilege = ResultType.Details;
                Criteria.FunctionPrivilege = ResultType.Details;
                OperationResult operationResult = new OperationResult();
                SecurityPrincipals Principals;

                operationResult = MDSWrapper.ServiceClient.SecurityPrincipalsGet(new International(), Criteria, out Principals);
                if (Enumerable.FirstOrDefault<User>(Enumerable.Where<User>((IEnumerable<User>)Principals.Users, (Func<User, bool>)(u => u.DisplayName == "user de test2"))) != null)
                    return;
                User user = new User();
                SecurityPrincipals securityPrincipals = new SecurityPrincipals();
                securityPrincipals.Users = new List<User>();
                user.DisplayName = "user de test2";
                user.EmailAddress = "emaildetest@test.com";
                user.Identifier = new Identifier()
                {
                    Id = Guid.NewGuid()
                };
                user.Identifier.Name = "nom user de test 2";
                //TODO
                //UserPrincipal byIdentity = UserPrincipal.FindByIdentity(new PrincipalContext(ContextType.Domain), user.Identifier.Name);
                //if (byIdentity != null)
                //    user.SID = byIdentity.Sid.ToString();
                //user.Identifier.Id = Guid.NewGuid();
                //user.Identifier.InternalId = new Random().Next(1000, 10000);
                //user.SecurityPrivilege = new SecurityPrivileges();
                //securityPrincipals.Users.Add(user);
                //using (ServiceClient serviceClient = new ServiceClientWrapper().CreateServiceClient())
                //{
                //    SecuritySet SecuritySet;
                //    operationResult = serviceClient.SecurityPrincipalsCreate(new International(), securityPrincipals, out SecuritySet);
                //    this.GetUserList(securityPrincipals);
                //}
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = ex.Message;
            }
        }

        /*
        private void btDeleteUser_Click(object sender, EventArgs e)
        {
            if (this.lstUsers.SelectedItem == null)
                return;
            MDSWrapper mdsWrapper = new MDSWrapper();
            mdsWrapper.DeleteUser((this.lstUsers.SelectedItem as CustomUser).User);
            this.GetUserList(mdsWrapper.UpdateUsersList());
        }
        */
        private void btDeleteVersion_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (this.lstModels.SelectedItem == null || this.lstVersions.SelectedItem == null || MessageBox.Show("This operation is irreversible. Are you sure you want to delete this version ?", "Delete version", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                    return;
                if (this.lstVersions.Items.Count <= 1)
                {
                    if (MessageBox.Show("Be carefull : if you delete the only version, this model will be useless. It is not recommanded ! Are you sure you want to delete this version ?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        this.DeleteVersion(this.lstVersions.SelectedItem as CustomVersion);
                        this.RefreshVersionAndFlags();
                    }
                }
                else
                {
                    this.DeleteVersion(this.lstVersions.SelectedItem as CustomVersion);
                    this.RefreshVersionAndFlags();
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = ex.Message;
                throw;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void DeleteVersion(CustomVersion cv)
        {
            OperationResult or = new OperationResult();
            MDSWrapper.GetVersionsAndFlagsInMetaData(cv.Version.Identifier.ModelId);
            Metadata Metadata = new Metadata();
            Metadata.Versions = new List<Common.MDSService.Version>();
            Metadata.Versions.Add(cv.Version);


            OperationResult operationResult2 = MDSWrapper.ServiceClient.MetadataDelete(new International(), Metadata);
            if (operationResult2.Errors.Count <= 0)
                return;
            toolStripStatusLabel1.Text = operationResult2.Errors[0].Code + " - " + operationResult2.Errors[0].Description;

        }

        private void btDeleteFlag_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (this.lstModels.SelectedItem == null || this.lstFlags.SelectedItem == null)
                    return;
                this.DeleteFlag(this.lstFlags.SelectedItem as CustomFlag);
                this.RefreshVersionAndFlags();
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = ex.Message;
                throw;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void DeleteFlag(CustomFlag cf)
        {
            MDSWrapper.GetVersionsAndFlagsInMetaData(cf.Flag.Identifier.ModelId);
            Metadata Metadata = new Metadata();
            Metadata.VersionFlags = new List<VersionFlag>();
            Metadata.VersionFlags.Add(cf.Flag);

            OperationResult operationResult2 = MDSWrapper.ServiceClient.MetadataDelete(new International(), Metadata);
            if (operationResult2.Errors.Count <= 0)
                return;
            toolStripStatusLabel1.Text = operationResult2.Errors[0].Code + " - " + operationResult2.Errors[0].Description;

        }

        private void txtMDSurl_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = (IButtonControl)this.btRefreshConnection;
        }

        private void txtMDSurl_Leave(object sender, EventArgs e)
        {
            this.AcceptButton = (IButtonControl)null;
        }

        private void btVersionCopy_Click(object sender, EventArgs e)
        {
            if (this.lstModels.SelectedItem == null || this.lstVersions.SelectedItem == null)
                return;
            this.VersionCopy(this.lstVersions.SelectedItem as CustomVersion);
            this.RefreshVersionAndFlags();
        }

        private void VersionCopy(CustomVersion cv)
        {

            {
                OperationResult operationResult1 = new OperationResult();
                OperationResult operationResult2 = MDSWrapper.ServiceClient.VersionCopy(new International(), cv.Identifier.Id, "Copy of " + cv.Name, "Copy of " + cv.Name);
                if (operationResult2.Errors.Count <= 0)
                    return;
                toolStripStatusLabel1.Text = operationResult2.Errors[0].Code + " - " + operationResult2.Errors[0].Description;
            }
        }

        private string GetDBA(Identifier modelId, Identifier customVersionId, Metadata md)
        {
            foreach (MetadataAttribute metadataAttribute in md.Attributes)
            {
                if (metadataAttribute.AttributeType.HasValue && metadataAttribute.AttributeType.Value == AttributeType.Domain)
                    return metadataAttribute.DomainEntityId.Name;
            }
            return string.Empty;
        }

        private void DeleteEntityMembers(Identifier modelId, Identifier customVersionId, string entityToDeleteName)
        {
            if (this.deletedEntityMembers.Contains(entityToDeleteName))
                return;
            CustomEntity customEntityFromName = this.GetCustomEntityFromName(entityToDeleteName);
            if (MDSWrapper.GetMembers(modelId, customVersionId, customEntityFromName, string.Empty).Count > 0)
                this.DeleteAllMembersFromSelectedEntity(customEntityFromName);
            this.deletedEntityMembers.Add(entityToDeleteName);
        }

        private CustomEntity GetCustomEntityFromName(string currentEntityName)
        {
            CustomEntity customEntity1 = (CustomEntity)null;
            foreach (CustomEntity customEntity2 in this.ucManageEntities1.lstEntities.Items)
            {
                if (customEntity2 != null && customEntity2.Name == currentEntityName)
                    customEntity1 = customEntity2;
            }
            return customEntity1;
        }

        private void btDeleteAllMembersFromAllEntities_Click(object sender, EventArgs e)
        {
            if (this.lstModels.SelectedItem == null || this.lstVersions.SelectedItem == null)
                return;

            OperationResult or = new OperationResult();
            Identifier modelId = this.lstModels.SelectedItem as Identifier;
            Identifier identifier = (this.lstVersions.SelectedItem as CustomVersion).Identifier;
            foreach (CustomEntity customEntity in this.ucManageEntities1.lstEntities.Items)
            {
                if (MDSWrapper.GetMembers(modelId, identifier, customEntity, "").Count > 0)
                    or = this.DeleteMembersRecursive(or, modelId, identifier, customEntity);
            }
        }

        private OperationResult DeleteMembersRecursive(OperationResult or, Identifier modelId, Identifier versionId, CustomEntity ce)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                {
                    Metadata metaData = MDSWrapper.GetMetaData(new International(), ref or, modelId, versionId, (Identifier)ce.entityId, MDAction.AttributesOnly);
                    if (metaData != null)
                    {
                        Identifier dbaEntity = this.GetDbaEntity(metaData);
                        if (dbaEntity == null)
                        {
                            this.BulkDeleteMembersFromEntity(ce);
                        }
                        else
                        {
                            CustomEntity customEntity = this.FindCustomEntity(dbaEntity);
                            if (customEntity != null)
                                this.DeleteMembersRecursive(or, modelId, versionId, customEntity);
                        }
                    }
                }
                return or;
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = ex.Message;
                return or;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private CustomEntity FindCustomEntity(Identifier EntId)
        {
            foreach (CustomEntity customEntity in this.ucManageEntities1.lstEntities.Items)
            {
                if (customEntity.entityId == EntId)
                    return customEntity;
            }
            return (CustomEntity)null;
        }

        public Identifier GetDbaEntity(Metadata md)
        {
            foreach (MetadataAttribute metadataAttribute in md.Attributes)
            {
                if (metadataAttribute.AttributeType.HasValue && metadataAttribute.AttributeType.Value == AttributeType.Domain)
                    return metadataAttribute.DomainEntityId;
            }
            return (Identifier)null;
        }

        private bool ValueNotInKeys(KeyValuePair<string, string> kvp, Dictionary<int, KeyValuePair<string, string>> valueCollection)
        {
            return Enumerable.Count<char>((IEnumerable<char>)Enumerable.FirstOrDefault<KeyValuePair<string, string>>((IEnumerable<KeyValuePair<string, string>>)valueCollection.Values, (Func<KeyValuePair<string, string>, bool>)(p => p.Value == kvp.Value)).Value) > 0;
        }

        private void btValidateMember_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (this.ucManageEntities1.lstEntities.SelectedItem != null && this.lstModels.SelectedItem != null && this.lstVersions.SelectedItem != null)
                {
                    EntityMembers entityMembers = new EntityMembers();
                    entityMembers.EntityId = (Identifier)((CustomEntity)this.ucManageEntities1.lstEntities.SelectedItem).entityId;
                    entityMembers.ModelId = (Identifier)this.lstModels.SelectedItem;
                    entityMembers.VersionId = ((CustomVersion)this.lstVersions.SelectedItem).Identifier;
                    entityMembers.MemberType = new MemberType?(MemberType.NotSpecified);
                    entityMembers.MemberType = new MemberType?(MemberType.Leaf);
                    entityMembers.Members = new List<Common.MDSService.Member>();

                    {
                        foreach (CustomMember customMember in Enumerable.ToList<CustomMember>(Enumerable.Cast<CustomMember>((IEnumerable)this.ucManageMembers1.lstMembers.CheckedItems)))
                            entityMembers.Members.Add(new Common.MDSService.Member()
                            {
                                MemberId = customMember.MemberId
                            });
                        ValidationProcessCriteria ValidationProcessCriteria = new ValidationProcessCriteria();
                        ValidationProcessCriteria.EntityId = entityMembers.EntityId;
                        ValidationProcessCriteria.Members = new List<MemberIdentifier>((IList<MemberIdentifier>)Enumerable.ToList<MemberIdentifier>(Enumerable.Select<Common.MDSService.Member, MemberIdentifier>((IEnumerable<Common.MDSService.Member>)entityMembers.Members, (Func<Common.MDSService.Member, MemberIdentifier>)(x => x.MemberId))));
                        ValidationProcessCriteria.ModelId = entityMembers.ModelId;
                        ValidationProcessCriteria.VersionId = entityMembers.VersionId;
                        ValidationProcessOptions ValidationProcessOptions = new ValidationProcessOptions();
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
                        MessageBox.Show(((object)stringBuilder1).ToString(), "Information & Errors");
                        this.RefreshLstMembersAttributes((Identifier)this.lstModels.SelectedItem, (CustomEntity)this.ucManageEntities1.lstEntities.SelectedItem, (CustomVersion)this.lstVersions.SelectedItem);
                    }
                }
                else
                    toolStripStatusLabel1.Text = "Member Code cannot be empty!";
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = ex.Message;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private bool IsExistingNode(TreeNodeCollection tnc, TreeNode newNode, bool searchAllChildren)
        {
            return Enumerable.Count<TreeNode>((IEnumerable<TreeNode>)tnc.Find(newNode.Name, searchAllChildren)) > 0;
        }

        private void btTest_Click(object sender, EventArgs e)
        {
            if (this.lstModels.SelectedItem == null || this.lstVersions.SelectedItem == null)
                return;
            string name1 = (this.ucManageEntities1.lstEntities.SelectedItem as CustomEntity).Name;
            string name2 = (this.lstModels.SelectedItem as Identifier).Name;
            string name3 = (this.lstVersions.SelectedItem as CustomVersion).Name;
            List<CustomMember> pMdmMembers = new List<CustomMember>();
            for (int index = 1; index <= 4000; ++index)
            {
                MemberIdentifier memberIdentifier1 = new MemberIdentifier();
                memberIdentifier1.Code = "Code" + index.ToString();
                memberIdentifier1.Name = "Name" + index.ToString();
                MemberIdentifier memberIdentifier2 = memberIdentifier1;
                Common.MDSService.Member m = new Common.MDSService.Member()
                {
                    MemberId = memberIdentifier2
                };
                m.Attributes = new List<Common.MDSService.Attribute>();
                Identifier identifier = new Identifier()
                {
                    Name = "myTestAtt"
                };
                m.Attributes.Add(new Common.MDSService.Attribute()
                {
                    Identifier = identifier,
                    Value = (object)("AttValue" + index.ToString())
                });
                CustomMember customMember = new CustomMember(m);
                pMdmMembers.Add(customMember);
            }
            this.EntityMembersCreate(name1, name2, name3, pMdmMembers, true);
        }

        public EntityMembers EntityMembersCreate(string pEntityName, string pModelName, string pVersionName, List<CustomMember> pMdmMembers, bool bCreate)
        {
            International International = new International();
            EntityMembers Members = new EntityMembers();
            Members.Members = new List<Common.MDSService.Member>();
            Members.EntityId = new Identifier()
            {
                Name = pEntityName
            };
            Members.ModelId = new Identifier()
            {
                Name = pModelName
            };
            Members.VersionId = new Identifier()
            {
                Name = pVersionName
            };
            foreach (CustomMember customMember in pMdmMembers)
            {
                Common.MDSService.Member member = new Common.MDSService.Member();
                MemberIdentifier memberIdentifier = new MemberIdentifier();
                memberIdentifier.Code = customMember.Code;
                memberIdentifier.MemberType = MemberType.Leaf;
                memberIdentifier.Id = new Guid();
                memberIdentifier.Name = customMember.Name;
                member.MemberId = memberIdentifier;
                member.Attributes = new List<Common.MDSService.Attribute>();
                foreach (Common.MDSService.Attribute attribute in customMember.mbr.Attributes)
                    member.Attributes.Add(new Common.MDSService.Attribute()
                    {
                        Identifier = new Identifier()
                        {
                            Name = attribute.Identifier.Name
                        },
                        Value = attribute.Value,
                        Type = AttributeValueType.String
                    });
                Members.Members.Add(member);
            }
            if (bCreate)
            {

                {
                    DateTime now = DateTime.Now;
                    OperationResult or;
                    MDSWrapper.ServiceClient.EntityMembersMerge(International, Members, false, out or);
                    TimeSpan timeSpan = DateTime.Now.Subtract(now);
                    MessageBox.Show(string.Concat(new object[4]
          {
            (object) "members merged : ",
            (object) Enumerable.Count<Common.MDSService.Member>((IEnumerable<Common.MDSService.Member>) Members.Members),
            (object) "\r\ntime elapsed (seconds):",
            (object) timeSpan.TotalSeconds.ToString()
          }));
                }
            }
            return Members;
        }

        private void btTest2_Click(object sender, EventArgs e)
        {
            if (this.lstModels.SelectedItem == null || this.lstVersions.SelectedItem == null)
                return;
            string name1 = (this.ucManageEntities1.lstEntities.SelectedItem as CustomEntity).Name;
            Identifier modelId = this.lstModels.SelectedItem as Identifier;
            string name2 = (this.lstModels.SelectedItem as Identifier).Name;
            Identifier identifier1 = (this.lstVersions.SelectedItem as CustomVersion).Identifier;
            string name3 = (this.lstVersions.SelectedItem as CustomVersion).Name;
            List<CustomMember> pMdmMembers = new List<CustomMember>();
            for (int index = 1; index <= 4000; ++index)
            {
                MemberIdentifier memberIdentifier1 = new MemberIdentifier();
                memberIdentifier1.Code = "Code" + index.ToString();
                memberIdentifier1.Name = "Name" + index.ToString();
                MemberIdentifier memberIdentifier2 = memberIdentifier1;
                Common.MDSService.Member m = new Common.MDSService.Member()
                {
                    MemberId = memberIdentifier2
                };
                m.Attributes = new List<Common.MDSService.Attribute>();
                Identifier identifier2 = new Identifier()
                {
                    Name = "myTestAtt"
                };
                m.Attributes.Add(new Common.MDSService.Attribute()
                {
                    Identifier = identifier2,
                    Value = (object)("myValue" + index.ToString())
                });
                CustomMember customMember = new CustomMember(m);
                pMdmMembers.Add(customMember);
            }
            List<EntityMembers> modelMembers = new List<EntityMembers>();
            modelMembers.Add(this.EntityMembersCreate(name1, name2, name3, pMdmMembers, false));
            DateTime now = DateTime.Now;
            OperationResult or = new OperationResult();
            this.StagingGet(this.ModelMembersBulkMerge(modelMembers), true, true, true, false, ref or);
            this.ProcessUnbatchedStaging(modelId, identifier1);
            TimeSpan timeSpan = DateTime.Now.Subtract(now);
            MessageBox.Show(string.Concat(new object[4]
      {
        (object) "members (bulk) inserted  : ",
        (object) Enumerable.Count<Common.MDSService.Member>((IEnumerable<Common.MDSService.Member>) Enumerable.First<EntityMembers>((IEnumerable<EntityMembers>) modelMembers).Members),
        (object) "\r\ntime elapsed (seconds):",
        (object) timeSpan.TotalSeconds.ToString()
      }));
        }

        public void ProcessUnbatchedStaging(Identifier modelId, Identifier versionId)
        {

            {
                OperationResult OperationResult = new OperationResult();
                MDSWrapper.ServiceClient.StagingProcess(new International(), true, new StagingUnbatchedCriteria()
                {
                    ModelId = modelId,
                    VersionId = versionId
                }, out OperationResult);
            }
        }

        public List<StagingBatch> StagingGet(List<Identifier> stagingBatch, bool ReturnAllCriteria, bool ReturnMembers, bool ReturnAttributes, bool ReturnRelationShips, ref OperationResult or)
        {
            List<StagingUnbatchedInformation> UnbatchedInformation = new List<StagingUnbatchedInformation>();
            List<StagingBatch> collection1 = new List<StagingBatch>();

            or = new OperationResult();
            List<StagingBatch> collection2 = MDSWrapper.ServiceClient.StagingGet(new International(), true, new StagingResultCriteria()
            {
                All = ReturnAllCriteria,
                Attributes = ReturnAttributes,
                Members = ReturnMembers,
                Relationships = ReturnRelationShips
            }, new StagingSearchCriteria()
            {
                StagingBatches = stagingBatch,
                StagingDataStatus = StagingDataStatus.All
            }, out or, out UnbatchedInformation);
            List<string> list = new List<string>();
            foreach (StagingBatchError stagingBatchError in Enumerable.First<StagingBatch>((IEnumerable<StagingBatch>)collection2).Errors)
                list.Add(stagingBatchError.ErrorCode + " - " + stagingBatchError.TargetCode);
            return collection2;

        }

        public List<Identifier> ModelMembersBulkMerge(List<EntityMembers> modelMembers)
        {
            List<Identifier> StagingBatches = new List<Identifier>();

            {
                OperationResult operationResult = new OperationResult();
                operationResult = MDSWrapper.ServiceClient.ModelMembersBulkMerge(new International(), modelMembers, out StagingBatches);
            }
            return StagingBatches;
        }

        public List<Identifier> ModelMembersBulkDelete(List<EntityMembers> modelMembers)
        {
            List<Identifier> StagingBatches = new List<Identifier>();

            {
                OperationResult operationResult = new OperationResult();
                operationResult = MDSWrapper.ServiceClient.ModelMembersBulkDelete(new International(), modelMembers, out StagingBatches);
            }
            return StagingBatches;
        }

        private void ucManageMembers1_Load(object sender, EventArgs e)
        {
        }

        private void btEntityManager_Click(object sender, EventArgs e)
        {
            ((Control)new EntityManager()).Show();
        }

        private void btValidateVersion_Click(object sender, EventArgs e)
        {
            if (this.lstModels.SelectedItem == null || this.lstVersions.SelectedItem == null)
                return;
            string name1 = (this.lstModels.SelectedItem as Identifier).Name;
            string name2 = (this.lstVersions.SelectedItem as CustomVersion).Name;

            {
                ValidationProcessOptions ValidationProcessOptions = new ValidationProcessOptions()
                {
                    CommitVersion = false
                };
                ValidationProcessCriteria ValidationProcessCriteria = new ValidationProcessCriteria();
                ValidationProcessCriteria.ModelId = this.lstModels.SelectedItem as Identifier;
                ValidationProcessCriteria.VersionId = (this.lstVersions.SelectedItem as CustomVersion).Identifier;
                List<ValidationIssue> ValidationIssueList = new List<ValidationIssue>();
                ValidationProcessResult ValidationProcessResult = new ValidationProcessResult();
                MDSWrapper.ServiceClient.ValidationProcess(new International(), ValidationProcessCriteria, ValidationProcessOptions, out ValidationIssueList, out ValidationProcessResult);
            }
        }

        public EntityMembers EntityMemberCreate(string pEntityName, string pModelName, string pVersionName, List<CustomMember> pMdmMembers, bool bCreate)
        {
            International International = new International();
            EntityMembers Members = new EntityMembers();
            Members.EntityId = new Identifier()
            {
                Name = pEntityName
            };
            Members.ModelId = new Identifier()
            {
                Name = pModelName
            };
            Members.VersionId = new Identifier()
            {
                Name = pVersionName
            };
            Members.Members = new List<Member>();
            foreach (CustomMember customMember in pMdmMembers)
            {
                Member member = new Member();
                MemberIdentifier memberIdentifier = new MemberIdentifier();
                memberIdentifier.Code = customMember.Code;
                memberIdentifier.MemberType = MemberType.Leaf;
                memberIdentifier.Id = new Guid();
                memberIdentifier.Name = customMember.Name;
                member.MemberId = memberIdentifier;
                member.Attributes = new List<Common.MDSService.Attribute>();
                foreach (Common.MDSService.Attribute attribute in customMember.mbr.Attributes)
                    member.Attributes.Add(new Common.MDSService.Attribute()
                    {
                        Identifier = new Identifier()
                        {
                            Name = attribute.Identifier.Name
                        },
                        Value = attribute.Value,
                        Type = AttributeValueType.String
                    });
                Members.Members.Add(member);
            }
            if (bCreate)
            {

                {
                    DateTime now = DateTime.Now;
                    OperationResult or;
                    MDSWrapper.ServiceClient.EntityMembersMerge(International, Members, false, out or);
                    TimeSpan timeSpan = DateTime.Now.Subtract(now);
                    MessageBox.Show(string.Concat(new object[4]
          {
            (object) "members merged : ",
            (object) Enumerable.Count<Common.MDSService.Member>((IEnumerable<Common.MDSService.Member>) Members.Members),
            (object) "\r\ntime elapsed (seconds):",
            (object) timeSpan.TotalSeconds.ToString()
          }));
                }
            }
            return Members;
        }

        private void btBusinessRulesManager_Click(object sender, EventArgs e)
        {
            (new BusinessRulesManager()).Show();
        }



        private void btModelDiagramManager_Click(object sender, EventArgs e)
        {
            (new ModelDiagramManager()).Show();
        }

        private void btUserRightsManager_Click(object sender, EventArgs e)
        {
            //var userMgmt = new UserRightsManager();
            var userMgmt = new PermissionsManager();

            userMgmt.Show();
        }

        private void btPackageDeploy_Click(object sender, EventArgs e)
        {
            ((Control)new PackageDeployment()).Show();
        }

        private void btConnManager_Click(object sender, EventArgs e)
        {
            Form1.ShowConfigurationManager();
        }

        private static void ShowConfigurationManager()
        {
            Form1.cm = new ConfigurationManager();
            ((Control)Form1.cm).Show();
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (Form1.cm == null)
                return;
            Form1.cm.Activate();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }





        private void btTestExportViewUpdate_Click(object sender, EventArgs e)
        {
            OperationResult outOR;
            List<ExportView> colEV = MDSWrapper.ServiceClient.ExportViewListGet(new International(), out outOR);

            var or2 = MDSWrapper.ServiceClient.ExportViewUpdate(new International(), colEV.First());


            var or3 = MDSWrapper.ServiceClient.ExportViewUpdate(new International(), new ExportView()
             {
                 ModelId = this.lstModels.SelectedItem as Identifier,
                 DerivedHierarchyId = new Identifier(),
                 Levels = 0,
                 EntityId = (this.ucManageEntities1.lstEntities.SelectedItem as CustomEntity).entityId,
                 Identifier = new Identifier() { Name = "SV_" + (this.ucManageEntities1.lstEntities.SelectedItem as CustomEntity).Name },
                 VersionId = (this.lstVersions.SelectedItem as CustomVersion).Identifier,
                 IsDirty = false,
                 ViewFormat = ExportViewFormat.LeafAttributes
             });

        }



        /// <summary>
        /// For use by user controls.
        /// </summary>
        internal ToolStripProgressBar ProgressBar
        {
            get { return progressBar1; }
        }



        private void cbEndPointAddress_SelectionChangeCommitted(object sender, EventArgs e)
        {
            btRefreshConnection_Click(sender, e);
        }
    }
}

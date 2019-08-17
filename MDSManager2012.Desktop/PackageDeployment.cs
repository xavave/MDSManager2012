// Type: MDSManager.PackageDeployment
// Assembly: MDSManager, Version=1.0.7.2, Culture=neutral, PublicKeyToken=null
// Assembly location: C:\Users\Xavier\Documents\Visual Studio 2010\Projects\MDSManager\MDSManager.exe

using Common;
using Common.MDSService;
//using Microsoft.MasterDataServices.Deployment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MDSManager2012.Desktop.AppLogic;

namespace MDSManager2012.Desktop
{
    public class PackageDeployment :  BaseForm
    {
        private IContainer components = (IContainer)null;
        private Label label1;
        private ComboBox cbModel;
        private Label lblError;
        private GroupBox groupBox3;
        private Button btExportPkg;
        private Label label2;
        private Button btImportPkg;
        private ToolTip toolTip1;
        private OpenFileDialog openFileDialog1;
        private CheckBox ckIncludeData;

        public PackageDeployment()
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbModel = new System.Windows.Forms.ComboBox();
            this.lblError = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ckIncludeData = new System.Windows.Forms.CheckBox();
            this.btExportPkg = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btImportPkg = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 64;
            this.label1.Text = "Model";
            // 
            // cbModel
            // 
            this.cbModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbModel.FormattingEnabled = true;
            this.cbModel.Location = new System.Drawing.Point(50, 12);
            this.cbModel.Name = "cbModel";
            this.cbModel.Size = new System.Drawing.Size(305, 21);
            this.cbModel.TabIndex = 63;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(0, 326);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 65;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.ckIncludeData);
            this.groupBox3.Controls.Add(this.btExportPkg);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.btImportPkg);
            this.groupBox3.Location = new System.Drawing.Point(11, 58);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(344, 68);
            this.groupBox3.TabIndex = 66;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Package Import/Export";
            // 
            // ckIncludeData
            // 
            this.ckIncludeData.AutoSize = true;
            this.ckIncludeData.Location = new System.Drawing.Point(230, 10);
            this.ckIncludeData.Name = "ckIncludeData";
            this.ckIncludeData.Size = new System.Drawing.Size(84, 17);
            this.ckIncludeData.TabIndex = 51;
            this.ckIncludeData.Text = "include data";
            this.ckIncludeData.UseVisualStyleBackColor = true;
            // 
            // btExportPkg
            // 
            this.btExportPkg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btExportPkg.BackgroundImage = global::MDSManager2012.Desktop.Properties.Resources.export_icon;
            this.btExportPkg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btExportPkg.Location = new System.Drawing.Point(188, 26);
            this.btExportPkg.Name = "btExportPkg";
            this.btExportPkg.Size = new System.Drawing.Size(36, 36);
            this.btExportPkg.TabIndex = 39;
            this.toolTip1.SetToolTip(this.btExportPkg, "Export Package");
            this.btExportPkg.UseVisualStyleBackColor = true;
            this.btExportPkg.Click += new System.EventHandler(this.btExportPkg_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, -16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 50;
            // 
            // btImportPkg
            // 
            this.btImportPkg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btImportPkg.BackgroundImage = global::MDSManager2012.Desktop.Properties.Resources.import_icon;
            this.btImportPkg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btImportPkg.Location = new System.Drawing.Point(139, 26);
            this.btImportPkg.Name = "btImportPkg";
            this.btImportPkg.Size = new System.Drawing.Size(36, 36);
            this.btImportPkg.TabIndex = 40;
            this.toolTip1.SetToolTip(this.btImportPkg, "Import Package");
            this.btImportPkg.UseVisualStyleBackColor = true;
            this.btImportPkg.Click += new System.EventHandler(this.btImportPkg_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Package files|*.pkg";
            // 
            // PackageDeployment
            // 
            this.ClientSize = new System.Drawing.Size(367, 137);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbModel);
            this.MaximumSize = new System.Drawing.Size(383, 176);
            this.Name = "PackageDeployment";
            this.Text = "Package Deployment";
            this.Load += new System.EventHandler(this.PackageDeployment_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void PackageDeployment_Load(object sender, EventArgs e)
        {
            var errorMessage = String.Empty;
            CheckIfServiceUp();
                
        }

        public override void CheckIfServiceUpCompleted(ServiceCheckCompletedEventArgs e)
        {
            Tools.HandleErrors(e.Result, true);
            GetModels();
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

        private void btExportPkg_Click(object sender, EventArgs e)
        {
            MessageBox.Show("in progress for v2012...");
            //  MDSWrapper mdsWrapper = new MDSWrapper();
            //  Identifier modelId = this.cbModel.SelectedItem as Identifier;
            //  if (modelId == null)
            //      return;
            // 
            //  {
            //      OperationResult OperationResult = new OperationResult();
            //      List<EntityMembers> collection = serviceClient.ModelMembersGet(new International(), new ModelMembersGetCriteria()
            //      {
            //          Models = new List<Identifier>()
            //{
            //  modelId
            //},
            //          Entities = new List<Identifier>(),
            //          Versions = new List<Identifier>()
            //      }, new ModelMembersResultCriteria()
            //      {
            //          IncludeLeafMembers = true
            //      }, out OperationResult);
            //      EntityMembersInformation membersInformation = new EntityMembersInformation();
            //      new Package()
            //      {
            //          BusinessRules = mdsWrapper.BusinessRulesGet(modelId, true),
            //          ModelId = modelId,
            //          Metadata = new Metadata(),
            //          MasterData = collection
            //      }.Settings = new PackageSettings()
            //      {
            //          ContainsData = this.ckIncludeData.Checked,
            //          CreatedBy = Globals.UserName,
            //          CreatedDate = DateTime.Now,
            //          DeploymentType = DeploymentType.Complete
            //      };
            //  }
        }

        private void btImportPkg_Click(object sender, EventArgs e)
        {
            MessageBox.Show("in progress for v2012...");
            //try
            //{
            //    Cursor.Current = Cursors.WaitCursor;
            //    if (this.openFileDialog1.ShowDialog() != DialogResult.OK)
            //        return;
            //    Package.Deserialize(this.openFileDialog1.FileName);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    Cursor.Current = Cursors.Default;
            //}
        }
    }
}

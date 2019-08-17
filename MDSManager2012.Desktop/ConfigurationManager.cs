// Type: MDSManager.ConfigurationManager
// Assembly: MDSManager, Version=1.0.7.2, Culture=neutral, PublicKeyToken=null
// Assembly location: C:\Users\Xavier\Documents\Visual Studio 2010\Projects\MDSManager\MDSManager.exe

using Common;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace MDSManager2012.Desktop
{
    public class ConfigurationManager : Form
    {
        private const int EM_SETCUEBANNER = 0x1501;
        private const int EM_GETCUEBANNER = 0x1502;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessageW(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);


        private MainConfiguration conf = (MainConfiguration)null;
        private IContainer components = (IContainer)null;
        private GroupBox groupBox1;
        private ListBox lsbEndpoints;
        private GroupBox groupBoxSave;
        private Button btDeleteConfigValue;
        private Button btSaveConfig;
        private Label label9;
        private Label label4;
        private Label label3;
        private TextBox tbConfigname;
        private MaskedTextBox txtPassword;
        private TextBox txtUsername;
        private Label label2;
        private TextBox txtEndpoint;
        private Label label1;
        private TextBox txtDomain;
        private LinkLabel btOpenEndPointUrl;
        private Label label11;
        private RadioButton rbBasicHttpBinding;
        private RadioButton rbWSHttpBinding;

        public ConfigurationManager()
        {
            this.InitializeComponent();
        }

        private void btDeleteConfigValue_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (this.lsbEndpoints.Items.Count <= 0)
                    return;
                MainConfiguration config = MainConfiguration.GetConfig();
                config.DeleteConfigValue(this.tbConfigname.Text);
                int selectedIndex = this.lsbEndpoints.SelectedIndex;
                this.BindConfig();
                if (this.lsbEndpoints.Items.Count >= selectedIndex && this.lsbEndpoints.Items.Count > 0)
                    this.lsbEndpoints.SelectedIndex = selectedIndex - 1;
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

        private void BindConfig()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.conf = MainConfiguration.GetConfig();
                if (this.conf == null)
                    return;
                this.BindLsbEndPoints(this.conf.ConfigValues);
                ConfigValue configValue = Enumerable.FirstOrDefault<ConfigValue>((IEnumerable<ConfigValue>)this.conf.ConfigValues);
                if (configValue != null)
                    this.BindConfig(configValue.ConfigName);
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

        private void BindLsbEndPoints(List<ConfigValue> configValues)
        {
            this.lsbEndpoints.DataSource = configValues;
            this.lsbEndpoints.DisplayMember = "ConfigName";
            Form1 form1 = Form1.staticMainForm;
            if (form1 == null)
                return;
            form1.cbEndPointAddress.DataSource = configValues;
            form1.cbEndPointAddress.DisplayMember = "ConfigName";
        }

        private void BindConfig(string configname)
        {
            ConfigValue configValue =conf.ConfigValues.FirstOrDefault(c => c.ConfigName == configname);
            if (configValue == null)
                return;

            this.txtDomain.Text = configValue.Domain;
            this.txtUsername.Text = configValue.UserName;
            this.txtPassword.Text = configValue.Password;
            this.tbConfigname.Text = configValue.ConfigName;
            rbBasicHttpBinding.Checked = configValue.BindingType == BindingType.BasicHttpBinding;
            rbWSHttpBinding.Checked = configValue.BindingType == BindingType.WSHttpBinding;
            this.txtEndpoint.Text = configValue.EndpointAddress;
        }


        private void ConfigurationManager_Load(object sender, EventArgs e)
        {
            this.BindConfig();

            SendMessageW(tbConfigname.Handle, EM_SETCUEBANNER, 0, "ex: myOfficeConfig01");
            SendMessageW(txtEndpoint.Handle, EM_SETCUEBANNER, 0, "ex: http://localhost:3000/Service/Service.svc");
            SendMessageW(txtDomain.Handle, EM_SETCUEBANNER, 0, "ex: Microsoft-Corp");

            
         
        }

        private void btSaveConfig_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (string.IsNullOrEmpty(this.txtEndpoint.Text))
                    return;
                if (Uri.IsWellFormedUriString(this.txtEndpoint.Text, UriKind.Absolute))
                {
                    Cursor.Current = Cursors.WaitCursor;
                    var bindingType = this.rbBasicHttpBinding.Checked ? BindingType.BasicHttpBinding : BindingType.WSHttpBinding;
                    var config = MainConfiguration.GetConfig();
                    config.SetConfig(this.tbConfigname.Text, this.txtDomain.Text, this.txtUsername.Text, this.txtPassword.Text, new Uri(this.txtEndpoint.Text), bindingType);
                    int selectedIndex = this.lsbEndpoints.SelectedIndex;
                    BindConfig();
                    lsbEndpoints.SelectedIndex = selectedIndex;
                }
                else
                    MessageBox.Show("The endpoint uri is not valid!");
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

        private void lsbEndpoints_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = sender as ListBox;
            if (comboBox == null || comboBox.SelectedIndex <= -1)
                return;
            BindConfig((comboBox.SelectedItem as ConfigValue).ConfigName);
        }

        private void btOpenEndPointUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtEndpoint.Text))
                return;
            Tools.OpenUrl(this.txtEndpoint.Text);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lsbEndpoints = new System.Windows.Forms.ListBox();
            this.groupBoxSave = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.rbBasicHttpBinding = new System.Windows.Forms.RadioButton();
            this.rbWSHttpBinding = new System.Windows.Forms.RadioButton();
            this.btOpenEndPointUrl = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.btDeleteConfigValue = new System.Windows.Forms.Button();
            this.btSaveConfig = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbConfigname = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.MaskedTextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEndpoint = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBoxSave.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lsbEndpoints);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 239);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(919, 266);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Saved Connections";
            // 
            // lsbEndpoints
            // 
            this.lsbEndpoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbEndpoints.FormattingEnabled = true;
            this.lsbEndpoints.ItemHeight = 16;
            this.lsbEndpoints.Location = new System.Drawing.Point(3, 18);
            this.lsbEndpoints.Name = "lsbEndpoints";
            this.lsbEndpoints.Size = new System.Drawing.Size(913, 245);
            this.lsbEndpoints.TabIndex = 8;
            this.lsbEndpoints.SelectedIndexChanged += new System.EventHandler(this.lsbEndpoints_SelectedIndexChanged);
            this.lsbEndpoints.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsbEndpoints_MouseDoubleClick);
            // 
            // groupBoxSave
            // 
            this.groupBoxSave.Controls.Add(this.label11);
            this.groupBoxSave.Controls.Add(this.rbBasicHttpBinding);
            this.groupBoxSave.Controls.Add(this.rbWSHttpBinding);
            this.groupBoxSave.Controls.Add(this.btOpenEndPointUrl);
            this.groupBoxSave.Controls.Add(this.label1);
            this.groupBoxSave.Controls.Add(this.txtDomain);
            this.groupBoxSave.Controls.Add(this.btDeleteConfigValue);
            this.groupBoxSave.Controls.Add(this.btSaveConfig);
            this.groupBoxSave.Controls.Add(this.label9);
            this.groupBoxSave.Controls.Add(this.label4);
            this.groupBoxSave.Controls.Add(this.label3);
            this.groupBoxSave.Controls.Add(this.tbConfigname);
            this.groupBoxSave.Controls.Add(this.txtPassword);
            this.groupBoxSave.Controls.Add(this.txtUsername);
            this.groupBoxSave.Controls.Add(this.label2);
            this.groupBoxSave.Controls.Add(this.txtEndpoint);
            this.groupBoxSave.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxSave.Location = new System.Drawing.Point(0, 0);
            this.groupBoxSave.Name = "groupBoxSave";
            this.groupBoxSave.Size = new System.Drawing.Size(919, 239);
            this.groupBoxSave.TabIndex = 3;
            this.groupBoxSave.TabStop = false;
            this.groupBoxSave.Text = "Connection Configuration";
            this.groupBoxSave.Enter += new System.EventHandler(this.groupBoxSave_Enter);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 206);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 17);
            this.label11.TabIndex = 28;
            this.label11.Text = "Binding Type";
            // 
            // rbBasicHttpBinding
            // 
            this.rbBasicHttpBinding.AutoSize = true;
            this.rbBasicHttpBinding.Location = new System.Drawing.Point(304, 204);
            this.rbBasicHttpBinding.Name = "rbBasicHttpBinding";
            this.rbBasicHttpBinding.Size = new System.Drawing.Size(136, 21);
            this.rbBasicHttpBinding.TabIndex = 27;
            this.rbBasicHttpBinding.Text = "BasicHttpBinding";
            this.rbBasicHttpBinding.UseVisualStyleBackColor = true;
            // 
            // rbWSHttpBinding
            // 
            this.rbWSHttpBinding.AutoSize = true;
            this.rbWSHttpBinding.Checked = true;
            this.rbWSHttpBinding.Location = new System.Drawing.Point(153, 204);
            this.rbWSHttpBinding.Name = "rbWSHttpBinding";
            this.rbWSHttpBinding.Size = new System.Drawing.Size(124, 21);
            this.rbWSHttpBinding.TabIndex = 26;
            this.rbWSHttpBinding.TabStop = true;
            this.rbWSHttpBinding.Text = "WSHttpBinding";
            this.rbWSHttpBinding.UseVisualStyleBackColor = true;
            // 
            // btOpenEndPointUrl
            // 
            this.btOpenEndPointUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btOpenEndPointUrl.AutoSize = true;
            this.btOpenEndPointUrl.Location = new System.Drawing.Point(647, 67);
            this.btOpenEndPointUrl.Name = "btOpenEndPointUrl";
            this.btOpenEndPointUrl.Size = new System.Drawing.Size(165, 17);
            this.btOpenEndPointUrl.TabIndex = 25;
            this.btOpenEndPointUrl.TabStop = true;
            this.btOpenEndPointUrl.Text = "Test Endpoint in browser";
            this.btOpenEndPointUrl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btOpenEndPointUrl_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "User Domain";
            // 
            // txtDomain
            // 
            this.txtDomain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDomain.Location = new System.Drawing.Point(151, 95);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(490, 22);
            this.txtDomain.TabIndex = 3;
            // 
            // btDeleteConfigValue
            // 
            this.btDeleteConfigValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDeleteConfigValue.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btDeleteConfigValue.Location = new System.Drawing.Point(810, 196);
            this.btDeleteConfigValue.Name = "btDeleteConfigValue";
            this.btDeleteConfigValue.Size = new System.Drawing.Size(97, 27);
            this.btDeleteConfigValue.TabIndex = 7;
            this.btDeleteConfigValue.Text = "Delete";
            this.btDeleteConfigValue.UseVisualStyleBackColor = true;
            this.btDeleteConfigValue.Click += new System.EventHandler(this.btDeleteConfigValue_Click);
            // 
            // btSaveConfig
            // 
            this.btSaveConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSaveConfig.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btSaveConfig.Location = new System.Drawing.Point(661, 196);
            this.btSaveConfig.Name = "btSaveConfig";
            this.btSaveConfig.Size = new System.Drawing.Size(133, 27);
            this.btSaveConfig.TabIndex = 6;
            this.btSaveConfig.Text = "Save / Update";
            this.btSaveConfig.UseVisualStyleBackColor = true;
            this.btSaveConfig.Click += new System.EventHandler(this.btSaveConfig_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(133, 17);
            this.label9.TabIndex = 7;
            this.label9.Text = "Configuration Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Username";
            // 
            // tbConfigname
            // 
            this.tbConfigname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbConfigname.Location = new System.Drawing.Point(151, 23);
            this.tbConfigname.Name = "tbConfigname";
            this.tbConfigname.Size = new System.Drawing.Size(490, 22);
            this.tbConfigname.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(151, 164);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(490, 22);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.Location = new System.Drawing.Point(151, 130);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(490, 22);
            this.txtUsername.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Endpoint Address";
            // 
            // txtEndpoint
            // 
            this.txtEndpoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEndpoint.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtEndpoint.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txtEndpoint.Location = new System.Drawing.Point(152, 61);
            this.txtEndpoint.Name = "txtEndpoint";
            this.txtEndpoint.Size = new System.Drawing.Size(490, 22);
            this.txtEndpoint.TabIndex = 2;
            this.txtEndpoint.TextChanged += new System.EventHandler(this.txtEndpoint_TextChanged);
            // 
            // ConfigurationManager
            // 
            this.ClientSize = new System.Drawing.Size(919, 505);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxSave);
            this.Name = "ConfigurationManager";
            this.Text = "MDS Manager : Edit Connection Configurations";
            this.Load += new System.EventHandler(this.ConfigurationManager_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBoxSave.ResumeLayout(false);
            this.groupBoxSave.PerformLayout();
            this.ResumeLayout(false);

        }

        private void groupBoxSave_Enter(object sender, EventArgs e)
        {

        }

        private void txtEndpoint_TextChanged(object sender, EventArgs e)
        {

        }

        private void lsbEndpoints_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //TODO Select the connection
            this.Close();
        }
    }
}

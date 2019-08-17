// Type: MDSManager.DisplayList
// Assembly: MDSManager, Version=1.0.7.2, Culture=neutral, PublicKeyToken=null
// Assembly location: C:\Users\Xavier\Documents\Visual Studio 2010\Projects\MDSManager\MDSManager.exe
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MDSManager2012.Desktop
{
    public class DisplayList : Form
    {
        private IContainer components = (IContainer)null;
        public TextBox txtDisplayList;

        public DisplayList()
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
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(DisplayList));
            this.txtDisplayList = new TextBox();
            this.SuspendLayout();
            this.txtDisplayList.Dock = DockStyle.Fill;
            this.txtDisplayList.Location = new Point(0, 0);
            this.txtDisplayList.Multiline = true;
            this.txtDisplayList.Name = "txtDisplayList";
            this.txtDisplayList.ScrollBars = ScrollBars.Both;
            this.txtDisplayList.Size = new Size(342, 422);
            this.txtDisplayList.TabIndex = 0;
            this.AutoScaleDimensions = new SizeF(6f, 13f);
            
            this.ClientSize = new Size(342, 422);
            this.Controls.Add((Control)this.txtDisplayList);
            this.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            this.Name = "DisplayList";
            this.Text = "Display List";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

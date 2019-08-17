using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;
using Common.MDSService;

namespace MDSManager2012.Desktop.AppLogic
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {


        }
        public void CheckIfServiceUp()
        {
            Cursor.Current = Cursors.WaitCursor;

            MDSWrapper.CheckIfServiceUp();

        }



        public virtual void CheckIfServiceUpCompleted(ServiceCheckCompletedEventArgs e) { }



    }
}

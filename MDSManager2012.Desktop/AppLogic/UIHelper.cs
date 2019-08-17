using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace MDSManager2012.Desktop
{
    
    public class UIHelper
    {
        public static void TreatException(Exception exc, string userFriendlyMsg = "")
        {
            MessageBox.Show(userFriendlyMsg + exc.Message);
            
        }


       
        public static string[] SelectExportViewFile(string initialDirectory)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Multiselect = true;
                openFileDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
                openFileDialog.InitialDirectory = initialDirectory;
                openFileDialog.Title = "Select an xml import file";
                return openFileDialog.ShowDialog() == DialogResult.OK ? openFileDialog.FileNames : (string[])null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

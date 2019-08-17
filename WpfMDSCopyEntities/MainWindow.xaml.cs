using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.MasterDataServices.ExcelAddInCore.MDSService;
using Microsoft.MasterDataServices.ExcelAddInCore.Operations;
using Microsoft.MasterDataServices.ExcelAddInCore.Types.Operations;

using System.Diagnostics;

namespace MdsCopyEntities
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btConnect_Click(object sender, RoutedEventArgs e)
        {
            //Note that the wrapper is dynamic
            //dynamic wrapper = AccessPrivateWrapper.FromType
            //    (typeof(Microsoft.MasterDataServices.ExcelAddInCore.Connections).Assembly, "ConnectionManager");

            ////Access the private members
            //wrapper.PrivateMethodInPrivateClass(); 

        }
    }
}

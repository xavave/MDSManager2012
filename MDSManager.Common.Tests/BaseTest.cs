using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace MDSManager.Common.Tests
{
    public class BaseTest
    {
        internal static string modelName;
        internal static string folderToExport = "D:\\MDSManagerTests";

        /// <summary>
        /// The name of the user principal to use in unit tests related to privileges export and import.
        /// </summary>
        internal static string UserToExport;

        internal static void Initialize()
        {
            var config = System.Configuration.ConfigurationManager.AppSettings;
            modelName = config.Get("ModelName");
            UserToExport = config.Get("UserToExport");
            var _testConfiguration = new ConfigValue("TestConfig", config.Get("Domain"), config.Get("UserName"), config.Get("Password"), new Uri(config.Get("MDSInstance1")) , global::Common.BindingType.WSHttpBinding);

            MDSWrapper.Configuration = _testConfiguration;

        }
    }
}

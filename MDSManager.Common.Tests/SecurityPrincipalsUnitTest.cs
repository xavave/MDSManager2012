using System;
using System.Diagnostics;
using Common;
using Common.MDSService;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Common.Model;
using System.Configuration;
using System.Collections.Generic;

namespace MDSManager.Common.Tests
{
    [TestClass]
    public class SecurityPrincipalsUnitTest : BaseTest
    {
        [ClassInitialize]
        public static void TestInitialize(TestContext context)
        {
            Initialize(); 
            
            //Setting the FUNCTION privileges for user
            var userToExport = MDSWrapper.UserSecurityPrincipalsGet(UserToExport).Users.FirstOrDefault();
                       
        }


        [TestCleanup]
        private void TestCleanUp()
        {
            
        }


        [TestMethod]
        public void UserSecurityPrincipalsGet()
        {
            var model = MDSWrapper.GetModelByName(modelName, global::Common.MDSService.ResultType.Identifiers);
            var userToExport = MDSWrapper.UserSecurityPrincipalsGet(UserToExport);
            Assert.IsTrue(userToExport != null);
            Assert.IsTrue(userToExport.Users.Count == 1);
            Assert.IsTrue(userToExport.Users.FirstOrDefault().Identifier.Name.Equals(UserToExport, StringComparison.InvariantCultureIgnoreCase));
       }



        [TestMethod]
        public void SecurityPrincipalsExportTest()
        {
            
            var userToExport = MDSWrapper.UserSecurityPrincipalsGet(UserToExport);
            Assert.IsTrue(userToExport != null && userToExport.Users.Any(), "No security principals returned! Connection: " + MDSWrapper.Configuration.EndpointAddress);

            var fileName = String.Format(global::Common.Constants.StringFormatUserPrincipals, userToExport.Users.FirstOrDefault().Identifier.Id);
            MDSWrapper.SecurityPrincipalsExport(Path.Combine(folderToExport, fileName), new SecurityInformation(userToExport.Users));

            Assert.IsTrue(File.Exists(Path.Combine(folderToExport, fileName)));
            //File.Delete(Path.Combine(folderToExport, fileName));
        }

        [TestMethod]
        public void SecurityPrincipalsImportTest()
        {
            var userToExport = MDSWrapper.UserSecurityPrincipalsGet(UserToExport);
            Assert.IsTrue(userToExport != null & userToExport.Users.Any(), "No security principals returned! Connection: " + MDSWrapper.Configuration.EndpointAddress);

            var fileName = String.Format(global::Common.Constants.StringFormatUserPrincipals, userToExport.Users.FirstOrDefault().Identifier.Id);
            MDSWrapper.SecurityPrincipalsExport(Path.Combine(folderToExport, fileName), new SecurityInformation(userToExport.Users));

            //switching to another environment
            var config = ConfigurationManager.AppSettings;            
            MDSWrapper.Configuration = new ConfigValue("MDS Local 2", config.Get("Domain"), config.Get("UserName"), config.Get("Password"), new Uri("http://localhost:82/Service/service.svc"), BindingType.WSHttpBinding);
            MDSWrapper.SecurityPrincipalsImport(Path.Combine(folderToExport, fileName),PrincipalType.UserAccount,SecurityPrincipalsOptions.ExcludeAllPrivileges, false);
            var principals = MDSWrapper.UserSecurityPrincipalsGet(UserToExport);
            var importedUser = principals.Users.FirstOrDefault();

             
    
            //checking if the principal exists in the 2nd environment
            Assert.IsTrue(importedUser.Identifier.Name == importedUser.Identifier.Name, "The user identifier does not match the expected result");
            Assert.IsTrue(importedUser.SecurityPrivilege.FunctionPrivileges.Count == 0, "The function privileges were not copied correctly");
            Assert.IsTrue(importedUser.SecurityPrivilege.ModelPrivileges.Count == 0, "The model privileges were not copied correctly");
            Assert.IsTrue(importedUser.SecurityPrivilege.HierarchyMemberPrivileges.Count == 0, "The hierarc privileges were not copied correctly");

            //Deleting the user
            MDSWrapper.SecurityPrincipalsDelete( principals, PrincipalType.UserAccount);

        }

       


    }
}

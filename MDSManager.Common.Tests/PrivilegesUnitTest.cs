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
    public class PrivilegesUnitTest : BaseTest
    {
        [ClassInitialize]
        public static void TestInitialize(TestContext context)
        {
            Initialize(); 
            
            //Setting the FUNCTION privileges for user
            var userToExport = MDSWrapper.UserSecurityPrincipalsGet(UserToExport).Users.FirstOrDefault();
            var functionPriv = new List<FunctionPrivilege> {
                new FunctionPrivilege{ Function = FunctionalArea.SystemAdministration, IsAuthorized = true, PrincipalId = userToExport.Identifier,PrincipalType = PrincipalType.UserAccount},
                new FunctionPrivilege{ Function = FunctionalArea.Versions, IsAuthorized = true,PrincipalId = userToExport.Identifier,PrincipalType = PrincipalType.UserAccount}
            };
            
            var securityPrivilege = userToExport.SecurityPrivilege;
            securityPrivilege.FunctionPrivileges =  functionPriv;
            var result = MDSWrapper.SecurityPrivilegesCreate(securityPrivilege);            
        }


        [TestCleanup]
        private void TestCleanUp()
        {
            //if (_wrapper != null) _wrapper.Dispose();
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
        public void ExportSecurityPrivilegesTest()
        {
            var model = MDSWrapper.GetModelByName(modelName, global::Common.MDSService.ResultType.Identifiers);

            var userToExport = MDSWrapper.UserSecurityPrincipalsGet(UserToExport);
            Assert.IsTrue(userToExport != null && userToExport.Users.Any(), "No security principals returned! Connection: " + MDSWrapper.Configuration.EndpointAddress);

            var fileName = String.Format(global::Common.Constants.StringFormatUserPrivileges, userToExport.Users.FirstOrDefault().Identifier.Id);
            MDSWrapper.SecurityPrivilegesExport(model.Identifier, folderToExport, fileName, userToExport.Users.FirstOrDefault());

            Assert.IsTrue(File.Exists(Path.Combine(folderToExport, fileName)));
            //File.Delete(Path.Combine(folderToExport, fileName));
        }

        [TestMethod]
        public void ImportUserSecurityPrivilegesFunctionPrivilegesTest()
        {
            var userToExport = MDSWrapper.UserSecurityPrincipalsGet(UserToExport);
            Assert.IsTrue(userToExport != null & userToExport.Users.Any(), "No security principals returned! Connection: " + MDSWrapper.Configuration.EndpointAddress);

            var fileName = String.Format(global::Common.Constants.StringFormatUserPrivileges, userToExport.Users.FirstOrDefault().Identifier.Id);
            MDSWrapper.SecurityPrivilegesExport(null, folderToExport, fileName, userToExport.Users.FirstOrDefault());

            //switching to another environment
            var config = ConfigurationManager.AppSettings;
            
            MDSWrapper.Configuration = new ConfigValue("MDS Local 2", config.Get("Domain"), config.Get("UserName"), config.Get("Password"), new Uri("http://localhost:82/Service/service.svc"), BindingType.WSHttpBinding);
            MDSWrapper.SecurityPrivilegesImport(Path.Combine(folderToExport, fileName), SecurityPrivilegesOptions.FunctionPrivileges, false);
           
            var importedUser = MDSWrapper.UserSecurityPrincipalsGet(UserToExport).Users.FirstOrDefault();

            var functPriv = importedUser.SecurityPrivilege.FunctionPrivileges;
            foreach (var item in functPriv)
            {
                Trace.WriteLine(String.Format("Function privilege {0} = {1}",item.Function,item.IsAuthorized));
                
            }
            //checking if the principal exists in the 2nd environment
            Assert.IsTrue(importedUser.Identifier.Name == importedUser.Identifier.Name, "The user identifier does not match the expected result");
            Assert.IsTrue(importedUser.SecurityPrivilege.FunctionPrivileges.Count == 2, "The function privileges were not copied correctly");
            Assert.IsTrue(importedUser.SecurityPrivilege.ModelPrivileges.Count == 0, "The model privileges were not copied correctly");
            Assert.IsTrue(importedUser.SecurityPrivilege.HierarchyMemberPrivileges.Count == 0, "The hierarc privileges were not copied correctly");

            //Deleting the user
            MDSWrapper.SecurityPrincipalsDelete(importedUser);

         
            Assert.IsTrue(File.Exists(Path.Combine(folderToExport, fileName)));
        }



    }
}

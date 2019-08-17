using System;
using System.Diagnostics;
using Common;
using Common.MDSService;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Common.Model;

namespace MDSManager.Common.Tests
{
    [TestClass]
    public class MDSWrapperTests : BaseTest
    {
        [ClassInitialize]
        public static void TestInitialize(TestContext context)
        {
            Initialize();           
        }

        [TestCleanup]
        private void TestCleanUp()
        {
            //if (_wrapper != null) _wrapper.Dispose();
        }

        [TestMethod]
        public void GetModelByNameTest()
        {
            var model = MDSWrapper.GetModelByName(modelName, global::Common.MDSService.ResultType.Identifiers);
            Trace.Write(model.Identifier.Name);
            Assert.IsNotNull(model);
            Assert.IsTrue(model.Identifier.Name.Equals(modelName));
        }


        [TestMethod]
        public void UserSecurityPrincipalsGetTest()
        {
            //var model = _wrapper.GetModelByName(modelName, global::Common.MDSService.ResultType.Identifiers);
            var users = MDSWrapper.UserSecurityPrincipalsGet();
            Trace.WriteLine("Users from instance:");
            foreach (User user in users.Users)
                Trace.WriteLine(user.Identifier.Name);
            Assert.IsNotNull(users.Users);
        }

       

        [TestMethod]
        public void GroupSecurityPrincipalsGetTest()
        {
            //var model = _wrapper.GetModelByName(modelName, global::Common.MDSService.ResultType.Identifiers);
            var users = MDSWrapper.GroupSecurityPrincipalsGet();
            Trace.Write("Groups from instance:");
            foreach (User user in users.Users)
                Trace.Write(user.DisplayName);
            Assert.IsNotNull(users.Users);
        }
    }
}

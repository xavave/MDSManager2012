// Type: Common.Globals
// Assembly: Common, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null
// Assembly location: C:\Users\Xavier\Documents\Visual Studio 2010\Projects\MDSManager\Common.dll

using System;

namespace Common
{
    public enum BindingType
    {
        WSHttpBinding,
        BasicHttpBinding,
    }
    public enum MemberAction
    {
        AddMember = 1,
        UpdateMember = 2,
        DeleteMember = 3,
    }
    public class Constants
    {
        public const string ConfigurationFileName = "MDSManager.config";
        private const string defaultEndPointName = "WSHttpBinding_IService";

        public static string StringFormatUserPrivileges = "MDS_UserPrivileges_{0}.xml";
        public static string StringFormatUserPrincipals = "MDS_UserPrincipals_{0}.xml";

        public static string StringFormatGroupPrivileges = "MDS_GroupPrivileges_{0}.xml";
        public static string StringFormatGroupPrincipals = "MDS_GroupPrincipals_{0}.xml";
    }

   
}

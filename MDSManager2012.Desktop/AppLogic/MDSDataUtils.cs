using System.Data;
using Common.MDSService;

namespace MDSManager2012.Desktop.AppLogic
{
    public static class MDSDataUtils
    {
        public static DataTable NewBusinessRuleDataTable()
        {
            var dataSet = new DataTable();
            dataSet.Columns.Add("ID");
            dataSet.Columns.Add("Entity");
            dataSet.Columns.Add("Priority");
            dataSet.Columns.Add("Status");
            dataSet.Columns.Add("Name");
            dataSet.Columns.Add("Description");
            dataSet.Columns.Add("Condition text");
            dataSet.Columns.Add("Action text");
            return dataSet;
        }

        public static void NewBRDataRow(DataTable dataSet, BusinessRule businessRule)
        {
            var row = dataSet.NewRow();
            row[0] = businessRule.Identifier.Id;
            row[1] = businessRule.Identifier.EntityId.Name;
            row[2] = businessRule.Priority;
            row[3] = businessRule.Status;
            row[4] = businessRule.Identifier.Name;
            row[5] = businessRule.Description;
            row[6] = businessRule.RuleConditionText;
            row[7] = businessRule.RuleActionText;
            dataSet.Rows.Add(row);
        }

        public static DataTable NewPermissionDataTable()
        {
            var dataSet = new DataTable();
            dataSet.Columns.Add("ID");
            dataSet.Columns.Add("Model");
            dataSet.Columns.Add("Principal");
            dataSet.Columns.Add("Type");
            dataSet.Columns.Add("Name");
            dataSet.Columns.Add("Member");
            dataSet.Columns.Add("Permission");
            return dataSet;
        }

        public static void NewPermissionDataRow(DataTable dataSet, Identifier principalIdentifier, ModelPrivilege modelPrivilege)
        {
            var row = dataSet.NewRow();
            row[0] = modelPrivilege.Identifier;
            row[1] = modelPrivilege.ModelId.Name;
            row[2] = principalIdentifier.Name;
            row[3] = modelPrivilege.ObjectType;
            row[4] = modelPrivilege.ObjectId.Name;
            row[5] = string.Empty;
            row[6] = modelPrivilege.Permission;
            
            dataSet.Rows.Add(row);
        }

        public static void NewPermissionDataRow(DataTable dataSet, Identifier principalIdentifier, HierarchyMemberPrivilege hierarchyMemberPrivilege)
        {
            var row = dataSet.NewRow();
            row[0] = hierarchyMemberPrivilege.Identifier;
            row[1] = hierarchyMemberPrivilege.ModelId.Name;
            row[2] = principalIdentifier.Name;
            row[3] = "Hierarchy Member";
            row[4] = hierarchyMemberPrivilege.HierarchyId.Name;
            row[5] = hierarchyMemberPrivilege.MemberId.Code + hierarchyMemberPrivilege.MemberId.Name;
            row[6] = hierarchyMemberPrivilege.Permission;
            dataSet.Rows.Add(row);
        }
    }
}

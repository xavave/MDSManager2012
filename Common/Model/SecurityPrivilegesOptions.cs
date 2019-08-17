using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Model
{
    /// <summary>
    /// Options for importing and exporting privileges from and to XML files.
    /// </summary>
    [Flags]
    public enum SecurityPrivilegesOptions
    {
        FunctionPrivileges = 0x0,
        ModelPrivileges = 0x1,
        HierarchyMemberPrivileges = 0x2
    }

    /// <summary>
    /// Options for importing and exporting security principals from and to XML files.
    /// </summary>
    [Flags]
    public enum SecurityPrincipalsOptions
    {
        ExcludeFunctionPrivileges = 1,
        ExcludeModelPrivileges = 2,
        ExcludeHierarchyMemberPrivileges = 4,
        ExcludeAllPrivileges = ExcludeFunctionPrivileges | ExcludeModelPrivileges | ExcludeHierarchyMemberPrivileges

    }
}

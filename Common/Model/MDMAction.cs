using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Model
{
    public enum MDSObjectType
    {
        Model,
        Version,
        Entity,
        Attribute
    }



    public enum MDAction
    {
        All,
        ModelsOnly,
        EntitiesOnly,
        AttributesOnly,
        AttributesDetails,
        VersionsOnly,
        FlagsOnly,
        DerivedHierarchiesOnly,
        AttributeGroupsOnly,
    }
}

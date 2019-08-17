// Type: Common.BusinessRuleSet
// Assembly: Common, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null
// Assembly location: C:\Users\Xavier\Documents\Visual Studio 2010\Projects\MDSManager\Common.dll

using Common.MDSService;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Common
{
    //[DataContract(Name = "BusinessRules", Namespace = "http://schemas.microsoft.com/sqlserver/masterdataservices/2009/09")]
    //[Serializable]
    //[Obsolete]
    //public class BusinessRuleSet
    //{
    //    [DataMember(EmitDefaultValue = true)]
    //    public List<BRAction> BRActions { get; set; }

    //    [DataMember(EmitDefaultValue = false)]
    //    public List<BRCondition> BRConditions { get; set; }

    //    [DataMember(EmitDefaultValue = false)]
    //    public List<BRConditionTreeNode> BRConditionTreeNodes { get; set; }

    //    [DataMember(EmitDefaultValue = false)]
    //    public List<BusinessRule> BusinessRules { get; set; }

    //    public BusinessRuleSet()
    //    {
    //        this.Initialize();
    //    }

    //    private void Initialize()
    //    {
    //        this.BusinessRules = new List<BusinessRule>();
    //        this.BRConditionTreeNodes = new List<BRConditionTreeNode>();
    //        this.BRConditions = new List<BRCondition>();
    //        this.BRActions = new List<BRAction>();
    //    }

    //    [OnDeserializing]
    //    private void OnDeserializing(StreamingContext context)
    //    {
    //        this.Initialize();
    //    }
    //}
}

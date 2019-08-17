// Type: Common.CustomNode
// Assembly: Common, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null
// Assembly location: C:\Users\Xavier\Documents\Visual Studio 2010\Projects\MDSManager\Common.dll

namespace Common
{
    public class CustomNode
    {
        public string ChildName { get; set; }

        public string Name { get; set; }

        public CustomEntity Ent { get; set; }

        public CustomNode()
        {
        }

        public CustomNode(CustomEntity ent, string childName, string name)
        {
            this.ChildName = childName;
            this.Ent = ent;
            this.Name = name;
        }
    }
}

// Type: Common.CustomVersion
// Assembly: Common, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null
// Assembly location: C:\Users\Xavier\Documents\Visual Studio 2010\Projects\MDSManager\Common.dll

using Common.MDSService;

namespace Common
{
    public class CustomVersion
    {
        private Attribute _attribute { get; set; }

        private Identifier _identifier { get; set; }

        private Version _version { get; set; }

        private string _Name { get; set; }

        public string Name
        {
            get
            {
                return this._Name;
            }
        }

        public Version Version
        {
            get
            {
                return this._version;
            }
        }

        public Identifier Identifier
        {
            get
            {
                return (Identifier)this._version.Identifier;
            }
        }

        public CustomVersion()
        {
        }

        public CustomVersion(Version v)
        {
            this._version = v;
            this._identifier = (Identifier)v.Identifier;
            this._Name = v.Identifier.Name;
        }
    }
}

// Type: Common.CustomFlag
// Assembly: Common, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null
// Assembly location: C:\Users\Xavier\Documents\Visual Studio 2010\Projects\MDSManager\Common.dll

using Common.MDSService;

namespace Common
{
    public class CustomFlag
    {
        private Attribute _attribute { get; set; }

        private Identifier _identifier { get; set; }

        private VersionFlag _versionFlag { get; set; }

        private string _Name { get; set; }

        public string Name
        {
            get
            {
                return this._Name;
            }
        }

        public VersionFlag Flag
        {
            get
            {
                return this._versionFlag;
            }
        }

        public Identifier Identifier
        {
            get
            {
                return (Identifier)this._versionFlag.Identifier;
            }
        }

        public CustomFlag()
        {
        }

        public CustomFlag(VersionFlag vf)
        {
            this._versionFlag = vf;
            this._identifier = (Identifier)vf.Identifier;
            this._Name = vf.Identifier.Name;
        }
    }
}

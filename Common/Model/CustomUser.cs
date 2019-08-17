// Type: Common.CustomUser
// Assembly: Common, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null
// Assembly location: C:\Users\Xavier\Documents\Visual Studio 2010\Projects\MDSManager\Common.dll

using Common.MDSService;

namespace Common
{
    public class CustomUser
    {
        public CustomUser(User u)
        {
            this._user = u;

        }

        private User _user { get; set; }

        public string DisplayName
        {
            get
            {
                return _user.DisplayName;
            }
        }

        public string Name
        {
            get { return _user.Identifier.Name; }
        }

        public User User
        {
            get
            {
                return this._user;
            }
        }

        public Identifier Identifier
        {
            get
            {
                return _user.Identifier;
            }
        }

        public static implicit operator User(CustomUser customUser)
        {
            return customUser._user;
        }

       



    }

    public class CustomGroup
    {
        private Group _group { get; set; }

        public string Name
        {
            get { return _group.Identifier.Name; }
        }

        public Group Group
        {
            get
            {
                return this._group;
            }
        }

        public Identifier Identifier
        {
            get
            {
                return _group.Identifier;
            }
        }

        public CustomGroup(Group u)
        {
            this._group = u;

        }

        public static implicit operator Group(CustomGroup customGroup)
        {
            return customGroup._group;
        }
    }
}

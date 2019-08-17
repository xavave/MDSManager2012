using Common.MDSService;
using System.Collections.Generic;

namespace Common
{
    public class CustomMember
    {
        private Member _m { get; set; }

        private List<Parent> _parents { get; set; }

        private MemberIdentifier _memberIdentifier { get; set; }

        public MemberIdentifier MemberId
        {
            get
            {
                return _m.MemberId;
            }
        }

        public Member mbr
        {
            get
            {
                return this._m;
            }
        }

        public string NameCode
        {
            get
            {
                return _m.MemberId.Name + " {" +  _m.MemberId.Code + "}";
      
            }
        }

        public string CodeName
        {
            get
            {
                return _m.MemberId.Code + " {" + _m.MemberId.Name + "}";
            }
        }

        public string Name
        {
            get
            {
                return _m.MemberId.Name;
            }
        }

        public string Code
        {
            get
            {
                return _m.MemberId.Code;
            }
        }

       public CustomMember(Member m)
        {
            this._m = m;
           this._parents = m.Parents;
      
        }
    }
}

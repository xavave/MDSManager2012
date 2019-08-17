// Type: Common.CustomAttribute
// Assembly: Common, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null
// Assembly location: C:\Users\Xavier\Documents\Visual Studio 2010\Projects\MDSManager\Common.dll

using Common.MDSService;

namespace Common
{
    public class CustomAttribute
    {
        private Attribute _attribute { get; set; }

        private Identifier _identifier { get; set; }

        private string _valueName { get; set; }

        private string _name { get; set; }

        private object _value { get; set; }

        private string _nameValue { get; set; }

        public string NameValue
        {
            get
            {
                return this._nameValue;
            }
        }

        public string ValueName
        {
            get
            {
                return this._valueName;
            }
        }

        public string Name
        {
            get
            {
                return this._name;
            }
        }

        public object Value
        {
            get
            {
                return this._value;
            }
        }

        public CustomAttribute()
        {
        }

        public CustomAttribute(Attribute attribute)
        {
            this._identifier = attribute.Identifier;
            this._valueName = string.Concat(new object[4]
      {
        attribute.Type == AttributeValueType.Domain ? (object) ((Identifier) attribute.Value).Name : attribute.Value,
        (object) " {",
        (object) this._identifier.Name,
        (object) "}"
      });
            this._name = this._identifier.Name;
            this._value = attribute.Value;
            this._nameValue = string.Concat(new object[4]
      {
        (object) this._identifier.Name,
        (object) " {",
        attribute.Type == AttributeValueType.Domain ? (object) ((Identifier) attribute.Value).Name : attribute.Value,
        (object) "}"
      });
        }
    }
}

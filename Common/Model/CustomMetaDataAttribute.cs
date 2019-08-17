// Type: Common.CustomMetaDataAttribute
// Assembly: Common, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null
// Assembly location: C:\Users\Xavier\Documents\Visual Studio 2010\Projects\MDSManager\Common.dll

using Common.MDSService;

namespace Common
{
    public class CustomMetaDataAttribute
    {
        private MetadataAttribute _attribute { get; set; }

        private Identifier _identifier { get; set; }

        private string _typeName { get; set; }

        private string _name { get; set; }

        private object _value { get; set; }

        private string _nameType { get; set; }

        private Identifier _domainEntityId { get; set; }

        private AttributeType? _attributeType { get; set; }

        public AttributeType? attributeType
        {
            get
            {
                return this._attributeType;
            }
        }

        public MetadataAttribute attribute
        {
            get
            {
                return this._attribute;
            }
        }

        public string NameType
        {
            get
            {
                return this._nameType;
            }
        }

        public Identifier DomainEntityId
        {
            get
            {
                return this._domainEntityId;
            }
        }

        public string TypeName
        {
            get
            {
                return this._typeName;
            }
        }

        public string Name
        {
            get
            {
                return this._name;
            }
        }

        public CustomMetaDataAttribute()
        {
        }

        public CustomMetaDataAttribute(MetadataAttribute attribute)
        {
            this._attribute = attribute;
            this._identifier = (Identifier)attribute.Identifier;
            CustomMetaDataAttribute metaDataAttribute1 = this;
            AttributeType? attributeType;
            string str1;
            if (!attribute.AttributeType.HasValue)
            {
                str1 = string.Empty;
            }
            else
            {
                attributeType = attribute.AttributeType;
                str1 = ((object)attributeType.Value).ToString();
            }
            string str2 = " {";
            string name1 = this._identifier.Name;
            string str3 = "}";
            string str4 = str1 + str2 + name1 + str3;
            metaDataAttribute1._typeName = str4;
            this._name = this._identifier.Name;
            attributeType = attribute.AttributeType;
            int num;
            if (attributeType.HasValue)
            {
                attributeType = attribute.AttributeType;
                num = attributeType.Value != AttributeType.Domain ? 1 : 0;
            }
            else
                num = 1;
            if (num == 0)
                this._domainEntityId = attribute.DomainEntityId;
            CustomMetaDataAttribute metaDataAttribute2 = this;
            string name2 = this._identifier.Name;
            string str5 = " {";
            attributeType = attribute.AttributeType;
            string str6;
            if (!attributeType.HasValue)
            {
                str6 = string.Empty;
            }
            else
            {
                attributeType = attribute.AttributeType;
                str6 = ((object)attributeType.Value).ToString();
            }
            string str7 = "}";
            string str8 = name2 + str5 + str6 + str7;
            metaDataAttribute2._nameType = str8;
        }
    }
}

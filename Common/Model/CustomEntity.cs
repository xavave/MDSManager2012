// Type: Common.CustomEntity
// Assembly: Common, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null
// Assembly location: C:\Users\Xavier\Documents\Visual Studio 2010\Projects\MDSManager\Common.dll

using Common.MDSService;
using System.Collections.Generic;
using System.Collections.Generic;
using Common.Model;

namespace Common
{
    public class CustomEntity
    {
        private Entity _e { get; set; }

        private string _name { get; set; }

        private List<Parent> _parents { get; set; }

        private ModelContextIdentifier _entityId { get; set; }

        public ModelContextIdentifier entityId
        {
            get
            {
                return this._entityId;
            }
        }

        public Entity ent
        {
            get
            {
                return this._e;
            }
        }

        public string Name
        {
            get
            {
                return this._name;
            }
        }

        public CustomEntity()
        {
        }

        public CustomEntity(Entity e)
        {
            this._e = e;
            this._entityId = e.Identifier;
            this._name = this._entityId.Name;
        }

        public CustomEntity(Entity e, Identifier versionId)
        {
            this._e = e;
            this._entityId = e.Identifier;
            this._name = this._entityId.Name;
        }

        public static List<Identifier> GetDBAEntities(Identifier modelId, Identifier customVersionId, Entity ent)
        {
            List<Entity> collection = new List<Entity>();
            OperationResult or = new OperationResult();

            Metadata metaData = MDSWrapper.GetMetaData(new International(), ref or, modelId, customVersionId, (Identifier)ent.Identifier, MDAction.EntitiesOnly);
            if (metaData != null)
                return CustomEntity.GetChildDBAEntitiesId(modelId, customVersionId, metaData);

            return (List<Identifier>)null;
        }

        private static List<Identifier> GetChildDBAEntitiesId(Identifier modelId, Identifier customVersionId, Metadata md)
        {
            List<Identifier> list = new List<Identifier>();
            foreach (MetadataAttribute metadataAttribute in md.Attributes)
            {
                int num;
                if (metadataAttribute.Identifier != null)
                {
                    AttributeType? attributeType = metadataAttribute.AttributeType;
                    if (attributeType.HasValue)
                    {
                        attributeType = metadataAttribute.AttributeType;
                        if (attributeType.Value == AttributeType.Domain)
                        {
                            num = metadataAttribute.DomainEntityId == null ? 1 : 0;
                            goto label_7;
                        }
                    }
                }
                num = 1;
            label_7:
                if (num == 0 && !list.Contains(metadataAttribute.DomainEntityId))
                    list.Add(metadataAttribute.DomainEntityId);
            }
            return list;
        }
    }
}

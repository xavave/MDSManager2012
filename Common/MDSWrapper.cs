// Type: Common.MDSWrapper
// Assembly: Common, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null
// Assembly location: C:\Users\Xavier\Documents\Visual Studio 2010\Projects\MDSManager\Common.dll

using Common.MDSService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Common.Exceptions;
using Common.Utils;
using Common.Model;

namespace Common
{
    public class MDSWrapper : IDisposable
    {
        private static ServiceClient _client;
        public static ServiceClient ServiceClient { get { EnsureClient(); return _client; } }

        private static ConfigValue _configuration;

        /// <summary>
        /// The configuration to be used. Setting a new configuration will close the current connection.
        /// </summary>
        public static ConfigValue Configuration
        {
            get { return _configuration; }
            set { CloseClient(); _configuration = value; }
        }


        private static void EnsureClient()
        {
            if (_configuration == null)
                throw new Exception("No configuration was provided!");

            if (_client != null)
            {
                if (_client.State != System.ServiceModel.CommunicationState.Opened &&
                    _client.State != System.ServiceModel.CommunicationState.Created)
                    CloseClient();
                else
                    return;
            }

            var wrapper = new ServiceClientWrapper(_configuration);
            _client = wrapper.CreateServiceClient();
            return;
        }


        [Obsolete]
        public MDSWrapper()
        {
            EnsureClient();
        }




        public static bool CheckIfServiceUp()
        {

            if (!Configuration.EndpointUri.IsWellFormedOriginalString())
            {
                throw new MDSManagerException("The URL is not well formed.");

            }
            EnsureClient();

            _client.ServiceCheckAsync(new International());

            return true;


        }



        public static List<MDSService.Model> ModelGet()
        {
            EnsureClient();
            var or = new OperationResult();
            Metadata metaData = MDSWrapper.GetMetaData(new International(), ref or, null, null, null, MDAction.ModelsOnly);
            Tools.HandleErrors(or, true);

            return metaData.Models;

        }

        public static MDSService.Model GetModelByName(string modelName, ResultType modelResultType)
        {
            EnsureClient();

            MetadataResultOptions ResultOptions = new MetadataResultOptions();
            MetadataSearchCriteria SearchCriteria = new MetadataSearchCriteria();
            SearchCriteria.Models = new List<Identifier>()
        {
          new Identifier()
          {
            Name = modelName
          }
        };
            SearchCriteria.Versions = new List<Identifier>()
        {
          new Identifier()
        };
            SearchCriteria.Entities = new List<Identifier>()
        {
          new Identifier()
        };
            SearchCriteria.VersionFlags = new List<Identifier>()
        {
          new Identifier()
        };
            SearchCriteria.DerivedHierarchies = new List<Identifier>()
        {
          new Identifier()
        };
            SearchCriteria.AttributeGroups = new List<Identifier>()
        {
          new Identifier()
        };
            SearchCriteria.SearchOption = MDSService.SearchOption.UserDefinedObjectsOnly;
            ResultOptions.Models = modelResultType;
            ResultOptions.Entities = ResultType.Identifiers;
            ResultOptions.DerivedHierarchies = ResultType.Identifiers;
            ResultOptions.Versions = ResultType.Identifiers;
            ResultOptions.VersionFlags = ResultType.Identifiers;
            ResultOptions.AttributeGroups = ResultType.Details;

            OperationResult OperationResult;
            Metadata metadata = _client.MetadataGet(new International(), ResultOptions, SearchCriteria, out OperationResult);

            if (OperationResult.Errors.Count > 0)
                throw new Exception("Error on GetModelByName: " + OperationResult.Errors[0].Description);
            if (metadata.Models.Count == 0)
                throw new Exception("GetModelByName - no model found with the name=" + modelName);
            else
                return metadata.Models.FirstOrDefault();


        }
        /*
        public static Identifier GetModelIdFromName(_client c, Uri mdsURL, string modelName)
        {
            try
            {
                MetadataResultOptions ResultOptions = new MetadataResultOptions();
                ResultOptions.Models = ResultType.Identifiers;

                MetadataSearchCriteria SearchCriteria = new MetadataSearchCriteria
                {
                    Models = new List<Identifier> { IdentifierUtils.NewFromName(modelName) },
                    SearchOption = Common.MDSService.SearchOption.UserDefinedObjectsOnly
                };
                
                Metadata metadata1 = new Metadata();
                OperationResult OperationResult = new OperationResult();
                Metadata metadata2 = c.MetadataGet(new International(), ResultOptions, SearchCriteria, out OperationResult);
                c.Close();
                if (OperationResult.Errors.Count > 0)
                    throw new Exception("Error on GetModelByName: " + OperationResult.Errors[0].Description);
                if (metadata2.Models.Count == 0)
                    throw new Exception("GetModelByName - no model found with the name=" + modelName);
                else
                    return Enumerable.First<Model>((IEnumerable<Model>)metadata2.Models).Identifier;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public static Identifier GetEntityIdFromName(_client c, string mdsURL, string modelName, string versionName, string entityName)
        {
            try
            {
                MetadataResultOptions ResultOptions = new MetadataResultOptions();
                MetadataSearchCriteria SearchCriteria = new MetadataSearchCriteria();
                Identifier identifier = new Identifier();
                SearchCriteria.Models = new List<Identifier>()
        {
          new Identifier()
          {
            Name = modelName
          }
        };
                SearchCriteria.Versions = new List<Identifier>()
        {
          new Identifier()
          {
            Name = versionName
          }
        };
                SearchCriteria.Entities = new List<Identifier>()
        {
          new Identifier()
          {
            Name = entityName
          }
        };
                SearchCriteria.SearchOption = Common.MDSService.SearchOption.UserDefinedObjectsOnly;
                ResultOptions.Entities = ResultType.Identifiers;
                Metadata metadata1 = new Metadata();
                OperationResult OperationResult = new OperationResult();
                Metadata metadata2 = c.MetadataGet(new International(), ResultOptions, SearchCriteria, out OperationResult);
                c.Close();
                string message = Tools.HandleErrors(OperationResult);
                if (!string.IsNullOrEmpty(message))
                    throw new Exception(message);
                else
                    return (Identifier)Enumerable.FirstOrDefault<Entity>((IEnumerable<Entity>)metadata2.Entities).Identifier;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Identifier GetVersionIdFromName(_client c, string mdsURL, string modelName, string versionName)
        {
            try
            {
                MetadataResultOptions ResultOptions = new MetadataResultOptions();
                MetadataSearchCriteria SearchCriteria = new MetadataSearchCriteria();
                SearchCriteria.Models = new List<Identifier>()
        {
          new Identifier()
          {
            Name = modelName
          }
        };
                SearchCriteria.Versions = new List<Identifier>()
        {
          new Identifier()
          {
            Name = versionName
          }
        };
                SearchCriteria.SearchOption = Common.MDSService.SearchOption.UserDefinedObjectsOnly;
                ResultOptions.Versions = ResultType.Identifiers;
                Metadata metadata1 = new Metadata();
                OperationResult OperationResult = new OperationResult();
                Metadata metadata2 = c.MetadataGet(new International(), ResultOptions, SearchCriteria, out OperationResult);
                c.Close();
                string message = Tools.HandleErrors(OperationResult);
                if (!string.IsNullOrEmpty(message))
                    throw new Exception(message);
                else
                    return (Identifier)Enumerable.FirstOrDefault<Common.MDSService.Version>((IEnumerable<Common.MDSService.Version>)metadata2.Versions).Identifier;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
         * */

        public static Metadata GetVersionsAndFlagsInMetaData(Identifier ModelId)
        {
            EnsureClient();
            MetadataResultOptions ResultOptions = new MetadataResultOptions();
            MetadataSearchCriteria SearchCriteria = new MetadataSearchCriteria();
            SearchCriteria.Models = new List<Identifier>()
        {
          ModelId
        };
            SearchCriteria.Versions = new List<Identifier>()
        {
          new Identifier()
        };
            SearchCriteria.VersionFlags = new List<Identifier>()
        {
          new Identifier()
        };
            SearchCriteria.SearchOption = Common.MDSService.SearchOption.UserDefinedObjectsOnly;
            ResultOptions.Versions = ResultType.Identifiers;
            ResultOptions.VersionFlags = ResultType.Identifiers;


            OperationResult or;
            var result = _client.MetadataGet(new International(), ResultOptions, SearchCriteria, out or);

            Tools.HandleErrors(or, true);

            return result;


        }

        public static List<Member> GetMembers(Identifier modelId, Identifier versionId, CustomEntity entity, string SearchTerm)
        {
            try
            {
                EntityMembersGetCriteria MembersGetCriteria = new EntityMembersGetCriteria();
                MembersGetCriteria.EntityId = (Identifier)entity.entityId;
                MembersGetCriteria.ModelId = modelId;
                MembersGetCriteria.VersionId = versionId;
                MembersGetCriteria.AttributeGroupId = new Identifier();
                MembersGetCriteria.PageSize = new int?(10000);
                MembersGetCriteria.DisplayType = new DisplayType?(DisplayType.NameCode);
                MembersGetCriteria.MemberReturnOption = MemberReturnOption.DataAndCounts;
                if (!string.IsNullOrEmpty(SearchTerm.Trim()))
                    MembersGetCriteria.SearchTerm = SearchTerm;
                EntityMembersInformation EntityMembersInformation = new EntityMembersInformation();

                {
                    Metadata metadata = new Metadata();
                    OperationResult OperationResult = new OperationResult();
                    EntityMembers entityMembers = _client.EntityMembersGet(new International(), MembersGetCriteria, out EntityMembersInformation, out OperationResult);

                    string message = Tools.HandleErrors(OperationResult);
                    if (!string.IsNullOrEmpty(message))
                        throw new Exception(message);
                    else
                        return entityMembers.Members;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int GetEntityMemberCount(Identifier modelId, Identifier versionId, CustomEntity entity, string SearchTerm)
        {
            EntityMembersGetCriteria MembersGetCriteria = new EntityMembersGetCriteria();
            MembersGetCriteria.EntityId = (Identifier)entity.entityId;
            MembersGetCriteria.ModelId = modelId;
            MembersGetCriteria.VersionId = versionId;
            MembersGetCriteria.AttributeGroupId = new Identifier();
            MembersGetCriteria.PageSize = new int?(10000);
            MembersGetCriteria.DisplayType = new DisplayType?(DisplayType.NameCode);
            MembersGetCriteria.MemberReturnOption = MemberReturnOption.Counts;
            if (!string.IsNullOrEmpty(SearchTerm.Trim()))
                MembersGetCriteria.SearchTerm = SearchTerm;
            EntityMembersInformation EntityMembersInformation = new EntityMembersInformation()
                {
                    MemberCount = 1
                };

            {
                Metadata metadata = new Metadata();
                OperationResult OperationResult = new OperationResult();
                var entityMembers = _client.EntityMembersGet(new International(), MembersGetCriteria, out EntityMembersInformation, out OperationResult);

                string message = Tools.HandleErrors(OperationResult);
                if (!string.IsNullOrEmpty(message))
                    throw new Exception(message);



                return entityMembers.Members.Count;

            }
        }

        public Metadata GetMetaData(International intl, ref OperationResult or, Identifier ModelId)
        {
            try
            {
                MetadataResultOptions ResultOptions = new MetadataResultOptions();
                MetadataSearchCriteria SearchCriteria = new MetadataSearchCriteria();
                SearchCriteria.Models = new List<Identifier> { ModelId };
                SearchCriteria.Versions = new List<Identifier>();
                SearchCriteria.Entities = new List<Identifier>();
                SearchCriteria.VersionFlags = new List<Identifier>();
                SearchCriteria.DerivedHierarchies = new List<Identifier>();
                SearchCriteria.AttributeGroups = new List<Identifier>();
                SearchCriteria.SearchOption = Common.MDSService.SearchOption.UserDefinedObjectsOnly;
                ResultOptions.Models = ResultType.Identifiers;
                ResultOptions.Entities = ResultType.Identifiers;
                ResultOptions.DerivedHierarchies = ResultType.Identifiers;
                ResultOptions.Versions = ResultType.Identifiers;
                ResultOptions.VersionFlags = ResultType.Identifiers;
                ResultOptions.AttributeGroups = ResultType.Details;
                Metadata metadata1 = new Metadata();
                Metadata metadata2 = _client.MetadataGet(new International(), ResultOptions, SearchCriteria, out or);
                string message = Tools.HandleErrors(or);
                if (!string.IsNullOrEmpty(message))
                    throw new Exception(message);
                else
                    return metadata2;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Metadata GetMetaData(International intl, ref OperationResult or, Identifier ModelId, Identifier VersionId, Identifier EntityId, MDAction mdAction)
        {
            try
            {
                EnsureClient();
                MetadataResultOptions ResultOptions = new MetadataResultOptions();
                MetadataSearchCriteria SearchCriteria = new MetadataSearchCriteria();
                SearchCriteria.Models = new List<Identifier>()
        {
          ModelId
        };
                SearchCriteria.DerivedHierarchies = new List<Identifier>()
        {
          new Identifier()
        };
                SearchCriteria.AttributeGroups = new List<Identifier>()
        {
          new Identifier()
        };
                SearchCriteria.Versions = new List<Identifier>()
        {
          VersionId
        };
                SearchCriteria.Entities = new List<Identifier>()
        {
          EntityId
        };
                SearchCriteria.Attributes = new List<Identifier>();
                SearchCriteria.SearchOption = Common.MDSService.SearchOption.BothUserDefinedAndSystemObjects;
                switch (mdAction)
                {
                    case MDAction.All:
                        ResultOptions.Models = ResultType.Details;
                        ResultOptions.Entities = ResultType.Details;
                        ResultOptions.DerivedHierarchies = ResultType.Details;
                        ResultOptions.Versions = ResultType.Details;
                        ResultOptions.VersionFlags = ResultType.Details;
                        ResultOptions.Attributes = ResultType.Details;
                        break;
                    case MDAction.ModelsOnly:
                        SearchCriteria.SearchOption = Common.MDSService.SearchOption.UserDefinedObjectsOnly;
                        ResultOptions.Models = ResultType.Identifiers;
                        ResultOptions.Entities = ResultType.None;
                        ResultOptions.DerivedHierarchies = ResultType.None;
                        ResultOptions.Versions = ResultType.None;
                        ResultOptions.VersionFlags = ResultType.None;
                        ResultOptions.Attributes = ResultType.None;
                        break;
                    case MDAction.EntitiesOnly:
                        ResultOptions.Models = ResultType.None;
                        ResultOptions.Entities = ResultType.Identifiers;
                        ResultOptions.DerivedHierarchies = ResultType.None;
                        ResultOptions.Versions = ResultType.None;
                        ResultOptions.VersionFlags = ResultType.None;
                        ResultOptions.Attributes = ResultType.None;
                        break;
                    case MDAction.AttributesOnly:
                        ResultOptions.Models = ResultType.None;
                        ResultOptions.Entities = ResultType.None;
                        ResultOptions.DerivedHierarchies = ResultType.None;
                        ResultOptions.Versions = ResultType.None;
                        ResultOptions.VersionFlags = ResultType.None;
                        ResultOptions.Attributes = ResultType.Identifiers;
                        break;
                    case MDAction.AttributesDetails:
                        ResultOptions.Models = ResultType.None;
                        ResultOptions.Entities = ResultType.None;
                        ResultOptions.DerivedHierarchies = ResultType.None;
                        ResultOptions.Versions = ResultType.None;
                        ResultOptions.VersionFlags = ResultType.None;
                        ResultOptions.Attributes = ResultType.Details;
                        break;
                    case MDAction.VersionsOnly:
                        ResultOptions.Models = ResultType.None;
                        ResultOptions.Entities = ResultType.None;
                        ResultOptions.DerivedHierarchies = ResultType.None;
                        ResultOptions.Versions = ResultType.Identifiers;
                        ResultOptions.VersionFlags = ResultType.None;
                        ResultOptions.Attributes = ResultType.None;
                        break;
                    case MDAction.FlagsOnly:
                        ResultOptions.Models = ResultType.None;
                        ResultOptions.Entities = ResultType.None;
                        ResultOptions.DerivedHierarchies = ResultType.None;
                        ResultOptions.Versions = ResultType.None;
                        ResultOptions.VersionFlags = ResultType.Identifiers;
                        ResultOptions.Attributes = ResultType.None;
                        break;
                    case MDAction.DerivedHierarchiesOnly:
                        ResultOptions.Models = ResultType.None;
                        ResultOptions.Entities = ResultType.None;
                        ResultOptions.DerivedHierarchies = ResultType.None;
                        ResultOptions.Versions = ResultType.None;
                        ResultOptions.VersionFlags = ResultType.None;
                        ResultOptions.Attributes = ResultType.None;
                        ResultOptions.DerivedHierarchies = ResultType.Identifiers;
                        break;
                    case MDAction.AttributeGroupsOnly:
                        ResultOptions.Models = ResultType.None;
                        ResultOptions.Entities = ResultType.None;
                        ResultOptions.DerivedHierarchies = ResultType.None;
                        ResultOptions.Versions = ResultType.None;
                        ResultOptions.VersionFlags = ResultType.None;
                        ResultOptions.Attributes = ResultType.None;
                        ResultOptions.AttributeGroups = ResultType.Identifiers;
                        break;
                }
                Metadata metadata1 = new Metadata();


                Metadata metadata2 = _client.MetadataGet(new International(), ResultOptions, SearchCriteria, out or);
                string message = Tools.HandleErrors(or);
                if (!string.IsNullOrEmpty(message))
                    throw new Exception(message);
                else
                    return metadata2;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Exists(Identifier id, MDSObjectType type)
        {
            Metadata metadata = null;
            OperationResult result = null;
            var searchCriteria = new MetadataSearchCriteria
            {
                SearchOption = MDSService.SearchOption.UserDefinedObjectsOnly
            };

            var resultOptions = new MetadataResultOptions { };

            switch (type)
            {
                case MDSObjectType.Entity:
                    searchCriteria.Entities = id.ToList();
                    resultOptions.Entities = ResultType.Identifiers;

                    break;
                case MDSObjectType.Model:
                    searchCriteria.Models = id.ToList();
                    resultOptions.Models = ResultType.Identifiers;
                    break;
                case MDSObjectType.Attribute:
                    searchCriteria.Attributes = id.ToList();
                    resultOptions.Attributes = ResultType.Identifiers;
                    break;
                default:
                    throw new ArgumentException("The object type is not supported");
            }

            //MemberTypes = new List<> { MemberType.
            metadata = _client.MetadataGet(new International(), resultOptions, searchCriteria, out result);

            Tools.HandleErrors(result, true);

            switch (type)
            {
                case MDSObjectType.Entity:
                    return metadata.Entities.Any();

                case MDSObjectType.Model:
                    return metadata.Models.Any();

                case MDSObjectType.Attribute:
                    return metadata.Attributes.Any();

                default:
                    return false;
            }

        }

        public static Identifier GetEntityIdFromName(Identifier modelId, string entityName)
        {
            EnsureClient();

            MetadataResultOptions ResultOptions = new MetadataResultOptions();
            MetadataSearchCriteria SearchCriteria = new MetadataSearchCriteria();
            SearchCriteria.Models = new List<Identifier>()
        {
          modelId
        };
            SearchCriteria.Versions = new List<Identifier>()
        {
          new Identifier()
          {
            Name = "VERSION_1"
          }
        };
            SearchCriteria.Entities = new List<Identifier>()
        {
          new Identifier()
          {
            Name = entityName
          }
        };
            SearchCriteria.SearchOption = Common.MDSService.SearchOption.UserDefinedObjectsOnly;
            ResultOptions.Entities = ResultType.Identifiers;
            Metadata metadata1 = new Metadata();
            OperationResult OperationResult = new OperationResult();
            Metadata metadata2 = _client.MetadataGet(new International(), ResultOptions, SearchCriteria, out OperationResult);

            string message = Tools.HandleErrors(OperationResult);
            if (!string.IsNullOrEmpty(message))
                throw new Exception(message);
            if (metadata2.Entities.FirstOrDefault() != null)
                return metadata2.Entities.FirstOrDefault().Identifier;
            else
                return null;
        }

        private static OperationResult CreateAttributeGroup(Identifier modelId, Entity entityId)
        {
            try
            {
                OperationResult OperationResult = (OperationResult)null;
                Metadata Metadata = new Metadata();
                if (entityId != null)
                {
                    OperationResult = new OperationResult();
                    Metadata.AttributeGroups = new List<AttributeGroup>();
                    List<AttributeGroup> attributeGroups = Metadata.AttributeGroups;
                    AttributeGroup attributeGroup1 = new AttributeGroup();
                    attributeGroup1.Attributes = new List<MetadataAttribute>();
                    attributeGroup1.FullName = "TestAttributeGroup";
                    attributeGroup1.IsNameCodeFrozen = false;
                    AttributeGroup attributeGroup2 = attributeGroup1;
                    MemberTypeContextIdentifier contextIdentifier1 = new MemberTypeContextIdentifier();
                    contextIdentifier1.EntityId = (Identifier)entityId.Identifier;
                    contextIdentifier1.MemberType = MemberType.Leaf;
                    contextIdentifier1.ModelId = modelId;
                    MemberTypeContextIdentifier contextIdentifier2 = contextIdentifier1;
                    attributeGroup2.Identifier = contextIdentifier2;
                    attributeGroup1.IsSystem = false;
                    AttributeGroup attributeGroup3 = attributeGroup1;
                    attributeGroups.Add(attributeGroup3);

                    {
                        _client.MetadataCreate(new International(), Metadata, true, out OperationResult);

                        string message = Tools.HandleErrors(OperationResult);
                        if (!string.IsNullOrEmpty(message))
                            throw new Exception(message);
                    }
                }
                return OperationResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ExportView> GetSubscriptionViewList(out OperationResult or)
        {
            var list = new List<ExportView>();
            or = new OperationResult();
            list = _client.ExportViewListGet(new International(), out or);
            Tools.HandleErrors(or, true);

            return list;
        }

        public static StringBuilder CopyAttributes(Identifier newModelId, CustomEntity entity, CustomVersion version, System.Collections.Generic.List<CustomMetaDataAttribute> selAttributes)
        {
            OperationResult OperationResult = new OperationResult();
            try
            {
                StringBuilder err = new StringBuilder();

                foreach (CustomMetaDataAttribute attribute in selAttributes)
                {
                    err.AppendLine(MDSWrapper.ManageMember(newModelId, entity, version, attribute).ToString());

                }


                if (OperationResult == null || OperationResult.Errors != null && OperationResult.Errors.Count != 0)
                    throw new Exception();

                return err;

            }
            catch (Exception ex)
            {
                StringBuilder stringBuilder = new StringBuilder();
                if (OperationResult != null && OperationResult.Errors.Count > 0)
                {
                    foreach (Common.MDSService.Error error in OperationResult.Errors)
                        stringBuilder.AppendFormat("{0}" + Environment.NewLine, (object)(error.Code + " - " + error.Description));
                }
                if (stringBuilder.Length > 0)
                    throw new Exception(((object)stringBuilder).ToString());
                else
                    throw ex;
            }

        }
        public static StringBuilder ManageMember(Identifier modelId, CustomEntity entity, CustomVersion version, CustomMetaDataAttribute att)
        {
            try
            {
                var sbErrors = new StringBuilder();
                if (att != null && entity != null && modelId != null && version != null)
                {
                    EntityMembers Members = new EntityMembers();
                    Members.EntityId = (Identifier)entity.entityId;
                    Members.ModelId = modelId;
                    Members.VersionId = version.Identifier;

                    Members.MemberType = MemberType.Leaf;
                    Members.Members = new List<Common.MDSService.Member>();
                    Common.MDSService.Member newmember = new Common.MDSService.Member();
                    newmember.MemberId = new MemberIdentifier();
                    newmember.MemberId.Name = att.Name;
                    newmember.MemberId.Code = att.Name;

                    newmember.Attributes = new List<Common.MDSService.Attribute>();

                    Common.MDSService.Attribute attribute2 = new Common.MDSService.Attribute();

                    attribute2.Identifier = new Identifier() { Id = Guid.NewGuid(), Name = att.Name };

                    newmember.Attributes.Add(attribute2);

                    Members.Members.Add(newmember);
                    OperationResult operationResult = new OperationResult();

                    List<MemberIdentifier> col = new List<MemberIdentifier>();

                    col = MDSWrapper.ServiceClient.EntityMembersCreate(new International(), Members, false, out  operationResult);


                    if (operationResult.Errors != null && operationResult.Errors.Count > 0)
                    {
                        foreach (Common.MDSService.Error error in operationResult.Errors)
                            sbErrors.AppendLine(Members.Members[0].MemberId.Code + " - " + error.Code + " - " + error.Description);

                    }
                }
                else
                    sbErrors.AppendLine("Member Code cannot be empty!");

                return sbErrors;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static StringBuilder ManageMember(Common.MemberAction action, Identifier modelId, CustomEntity entity, CustomVersion version, CustomMember member, string attributeName, string attributeValue)
        {
            try
            {
                var sbErrors = new StringBuilder();
                if (!string.IsNullOrEmpty(attributeValue) && entity != null && modelId != null && version != null)
                {
                    EntityMembers Members = new EntityMembers();
                    Members.EntityId = (Identifier)entity.entityId;
                    Members.ModelId = modelId;
                    Members.VersionId = version.Identifier;
                    Members.MemberType = new MemberType?(MemberType.NotSpecified);
                    Members.MemberType = new MemberType?(MemberType.Leaf);
                    Members.Members = new List<Common.MDSService.Member>();
                    Common.MDSService.Member newmember = new Common.MDSService.Member();
                    newmember.MemberId = action != Common.MemberAction.UpdateMember ? new MemberIdentifier() : (member != null ? newmember.MemberId : new MemberIdentifier());
                    newmember.MemberId.Name = attributeName;
                    newmember.MemberId.Code = attributeValue;
                    if (action == Common.MemberAction.UpdateMember)
                    {
                        newmember.Attributes = new List<Common.MDSService.Attribute>();
                        Common.MDSService.Attribute attribute1 = new Common.MDSService.Attribute();
                        attribute1.Identifier = new Identifier();
                        attribute1.Identifier.Name = "Code";
                        attribute1.Value = (object)char.MinValue;
                        attribute1.Value = (object)newmember.MemberId.Code;
                        newmember.Attributes.Add(attribute1);
                        Common.MDSService.Attribute attribute2 = new Common.MDSService.Attribute();
                        attribute2.Identifier = new Identifier();
                        attribute2.Identifier.Name = "Name";
                        attribute2.Value = (object)char.MinValue;
                        attribute2.Value = (object)newmember.MemberId.Name;
                        newmember.Attributes.Add(attribute2);
                    }
                    Members.Members.Add(newmember);
                    OperationResult operationResult = new OperationResult();

                    List<MemberIdentifier> col = new List<MemberIdentifier>();
                    if (action == Common.MemberAction.AddMember)
                        col = MDSWrapper.ServiceClient.EntityMembersCreate(new International(), Members, false, out  operationResult);
                    if (action == Common.MemberAction.UpdateMember)
                        MDSWrapper.ServiceClient.EntityMembersUpdate(new International(), Members);
                    if (action == Common.MemberAction.DeleteMember)
                        operationResult = MDSWrapper.ServiceClient.EntityMembersDelete(new International(), Members);


                    if (operationResult.Errors != null && operationResult.Errors.Count > 0)
                    {
                        foreach (Common.MDSService.Error error in operationResult.Errors)
                            sbErrors.AppendLine(Members.Members[0].MemberId.Code + " - " + error.Code + " - " + error.Description);

                    }
                }
                else
                    sbErrors.AppendLine("Member Code cannot be empty!");

                return sbErrors;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static string ImportSubscriptionViews(string[] strArray, Identifier modelId, CustomVersion versionId, CustomFlag customFlag, bool bAppendToViewName, string txtAppendToViewName, bool bImportViewManual, bool bBasedOnVersion, bool bBasedOnFlag, List<Identifier> derivedHierarchies, List<CustomEntity> customEntities)
        {
            try
            {
                EnsureClient();
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportView));
                if (strArray == null || Enumerable.Count<string>((IEnumerable<string>)strArray) <= 0)
                    throw new SubscriptionViewException("No subscription views selected for import!");
                StringBuilder sb = new StringBuilder();
                foreach (string path in strArray)
                {
                    if (File.Exists(path))
                    {
                        FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                        ExportView exportV = (ExportView)xmlSerializer.Deserialize((Stream)fileStream);
                        fileStream.Close();
                        sb.AppendLine(CreateExportView(exportV, modelId, versionId, customFlag, bAppendToViewName, txtAppendToViewName, bImportViewManual, bBasedOnVersion, bBasedOnFlag, derivedHierarchies, customEntities).ToString());
                    }
                    else
                        sb.AppendLine(path + " does not seem to exist!");
                }
                if (sb.Length <= 0)
                    throw new Exception("Subscription view(s) successfully imported");
                // MessageBox.Show(((object)stringBuilder).ToString(), "Errors List");
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Cursor.Current = Cursors.Default;
            }
        }

        private static StringBuilder CreateExportView(ExportView exportV, Identifier modelId, CustomVersion versionId, CustomFlag customFlag, bool bAppendToViewName, string txtAppendToViewName, bool bImportViewManual, bool bBasedOnVersion, bool bBasedOnFlag, List<Identifier> derivedHierarchies, List<CustomEntity> customEntities)
        {
            EnsureClient();
            //Cursor.Current = Cursors.WaitCursor;
            StringBuilder stringBuilder = new StringBuilder();

            {
                if (bAppendToViewName && !string.IsNullOrEmpty(txtAppendToViewName))
                    exportV.Identifier.Name = exportV.Identifier.Name + txtAppendToViewName;
                if (bImportViewManual)
                {
                    exportV.ModelId = modelId;
                    if (!bBasedOnVersion)
                        throw new SubscriptionViewException("You must select a version if you choose to import views \"based on the selected version\"");
                    exportV.VersionId = versionId.Identifier;
                }
                else if (bBasedOnFlag)
                {
                    if (customFlag == null)
                        throw new SubscriptionViewException("You must select a flag if you choose to import views \"based on the selected flag\"");
                    exportV.VersionId = new Identifier();
                    exportV.VersionFlagId = customFlag.Identifier;
                }
                exportV.EntityId = GetEntityIdForSubscriptionViewImport(exportV, customEntities);
                exportV.DerivedHierarchyId = GetDerivedHierarchyIdForSubscriptionViewImport(exportV, derivedHierarchies);
                OperationResult operationResult1 = new OperationResult();
                OperationResult operationResult2 = _client.ExportViewCreate(new International(), exportV);
                if (operationResult2.Errors.Count > 0)
                    stringBuilder.AppendLine(exportV.Identifier.Name + " - " + Enumerable.First<Error>((IEnumerable<Error>)operationResult2.Errors).Code + " - " + Enumerable.First<Error>((IEnumerable<Error>)operationResult2.Errors).Description);
            }
            return stringBuilder;

        }

        private static Identifier GetDerivedHierarchyIdForSubscriptionViewImport(ExportView exportV, List<Identifier> derivedHierarchies)
        {
            try
            {
                Identifier identifier1 = !string.IsNullOrEmpty(exportV.DerivedHierarchyId.Name) ? exportV.DerivedHierarchyId : (Identifier)null;
                if (identifier1 != null)
                {
                    foreach (Identifier identifier2 in derivedHierarchies)
                    {
                        if (identifier2.Name == identifier1.Name)
                            return identifier2;
                    }
                }
                return (Identifier)null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ExportSubscriptionViews(string folderName, List<Identifier> exportViews)
        {
            OperationResult or;
            var lstEV = MDSWrapper.GetSubscriptionViewList(out or);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportView));
            List<ExportView> collection = new List<ExportView>();
            foreach (Identifier identifier in exportViews)
            {
                Identifier i = identifier;
                collection.Add(Enumerable.First<ExportView>((IEnumerable<ExportView>)lstEV, (Func<ExportView, bool>)(p => p.Identifier.Id == i.Id)));
            }
            foreach (ExportView exportView in collection)
            {
                TextWriter textWriter = (TextWriter)new StreamWriter(folderName + exportView.Identifier.Name + ".xml");
                xmlSerializer.Serialize(textWriter, (object)exportView);
                textWriter.Close();
            }
        }

        private static Identifier GetEntityIdForSubscriptionViewImport(ExportView exportV, List<CustomEntity> customEntities)
        {
            try
            {
                Identifier identifier1 = !string.IsNullOrEmpty(exportV.EntityId.Name) ? exportV.EntityId : (Identifier)null;
                if (identifier1 != null)
                {
                    foreach (CustomEntity customEntity in customEntities)
                    {
                        Identifier identifier2 = (Identifier)customEntity.entityId;
                        if (identifier2.Name == identifier1.Name)
                            return identifier2;
                    }
                }
                return (Identifier)null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void CreateBR2(string strEntityName, string strAttributeName, string strModelName)
        {

            BusinessRules BusinessRuleSet = new BusinessRules();

            BusinessRule objBR = new BusinessRule();
            BusinessRuleSet.BusinessRulesMember = new List<BusinessRule> { };

            objBR.Identifier = new MemberTypeContextIdentifier();
            objBR.Identifier.ModelId = new Identifier { Name = strModelName };
            objBR.Identifier.EntityId = new Identifier { Name = strEntityName };

            objBR.Identifier.MemberType = MemberType.Leaf;
            objBR.Identifier.Name = "BR_" + strEntityName + "_9" + strAttributeName + "_NOTNULL";
            objBR.Priority = 10;
            objBR.BRConditionTree = new BRConditionTreeNode();
            objBR.BRConditionTree.LogicalOperator = LogicalOperator.Or;
            objBR.BRConditionTree.Sequence = 1;
            // Create the rule condition
            BRCondition objBRCond = new BRCondition();
            objBR.BRConditionTree.BRConditions = new List<BRCondition> { };
            objBR.BRConditionTree.BRConditions.Add(objBRCond);
            objBRCond.Sequence = 1;
            // Create the condition prefix argument for not null attribute.
            BRAttributeArgument objBA = new BRAttributeArgument();
            objBRCond.PrefixArgument = objBA;
            objBA.PropertyName = BRPropertyName.Value;
            objBA.AttributeId = new Identifier { Name = strAttributeName };
            // Set condition operator
            objBRCond.Operator = BRItemType.IsEqual;
            // Set the postfix argument "is blank".

            BRBlankArgument objPF = new BRBlankArgument();
            objBRCond.PostfixArguments = new List<object> { };
            objBRCond.PostfixArguments.Add(objPF);

            // Create the rule action.
            BRAction objBRActn = new BRAction();
            objBR.BRActions = new List<BRAction> { };
            objBR.BRActions.Add(objBRActn);
            objBRActn.Sequence = 1;
            // Set the action prefix argument for not null attribute.
            BRAttributeArgument objBRActnPF = new BRAttributeArgument();
            objBRActn.PrefixArgument = objBRActnPF;
            objBRActnPF.PropertyName = BRPropertyName.Value;

            objBRActnPF.AttributeId = new Identifier { Name = strAttributeName };
            // Set the action operator.
            objBRActn.Operator = BRItemType.IsEqual;
            // Set the action postfix argument.

            BRAttributeArgument objPF2 = new BRAttributeArgument() { AttributeId = new Identifier() { Name = "Val" } };
            objPF2.PropertyName = BRPropertyName.Value;
            objBRActn.PostfixArguments = new List<object> { };
            objBRActn.PostfixArguments.Add(objPF2);

            BusinessRuleSet.BusinessRulesMember.Add(objBR);

            {
                var or = _client.BusinessRulesCreate(new International(), ref BusinessRuleSet, true);
            }
        }
        public static void BusinessRuleCreate(Identifier modelId, CustomEntity cEntityId)
        {
            try
            {
                BRAction brAction1 = new BRAction();
                brAction1.Sequence = 1;
                brAction1.Operator = BRItemType.DefaultsToGeneratedValue;
                BRAction brAction2 = brAction1;
                BRAttributeArgument attributeArgument1 = new BRAttributeArgument();
                attributeArgument1.AttributeId = new Identifier()
                {
                    Name = "Code"
                };
                attributeArgument1.PropertyName = BRPropertyName.Anchor;
                BRAttributeArgument attributeArgument2 = attributeArgument1;
                brAction2.PrefixArgument = attributeArgument2;
                BRAction brAction3 = brAction1;
                List<object> collection1 = new List<object>();
                List<object> collection2 = collection1;
                BRFreeformArgument freeformArgument1 = new BRFreeformArgument();
                freeformArgument1.PropertyName = BRPropertyName.StartingValue;
                freeformArgument1.Value = "1";
                BRFreeformArgument freeformArgument2 = freeformArgument1;
                collection2.Add((object)freeformArgument2);
                List<object> collection3 = collection1;
                BRFreeformArgument freeformArgument3 = new BRFreeformArgument();
                freeformArgument3.PropertyName = BRPropertyName.IncrementValue;
                freeformArgument3.Value = "1";
                BRFreeformArgument freeformArgument4 = freeformArgument3;
                collection3.Add((object)freeformArgument4);
                List<object> collection4 = collection1;
                brAction3.PostfixArguments = collection4;
                BRAction brAction4 = brAction1;
                BusinessRule businessRule1 = new BusinessRule();
                businessRule1.Status = BRStatus.Active;
                BusinessRule businessRule2 = businessRule1;
                MemberTypeContextIdentifier contextIdentifier1 = new MemberTypeContextIdentifier();
                contextIdentifier1.ModelId = modelId;
                contextIdentifier1.EntityId = (Identifier)cEntityId.entityId;
                contextIdentifier1.MemberType = MemberType.Leaf;
                contextIdentifier1.Name = "New rule (2)";
                MemberTypeContextIdentifier contextIdentifier2 = contextIdentifier1;
                businessRule2.Identifier = contextIdentifier2;
                businessRule1.BRActions = new List<BRAction>()
        {
          brAction4
        };
                businessRule1.Priority = 10;
                BusinessRule businessRule3 = businessRule1;
                BusinessRules BusinessRuleSet = new BusinessRules()
                {
                    BusinessRulesMember = new List<BusinessRule>()
          {
            businessRule3
          }
                };

                {
                    string message = Tools.HandleErrors(_client.BusinessRulesCreate(new International(), ref BusinessRuleSet, true));
                    if (!string.IsNullOrEmpty(message))
                        throw new Exception(message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                // Cursor.Current = Cursors.Default;
            }
        }

        public static BusinessRules BusinessRuleDeserialize(string fileName)
        {
            Stream stream = null;
            try
            {
                if (!File.Exists(fileName))
                    throw new MDSManagerException("Cannot find the specified file!");

                stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                return (BusinessRules)new XmlSerializer(typeof(BusinessRules)).Deserialize(stream);
            }
            catch (InvalidOperationException ex)
            {
                //for example, the XML contains invalid data
                if (ex.InnerException != null)
                    throw new MDSManagerException("An error occured loading the the business rules from XML. Make sure this is a valid file. Error: " + ex.InnerException.Message);
                else
                    throw new MDSManagerException("An error occured loading the the business rules from XML. Make sure this is a valid file. Error: " + ex.InnerException.Message);
            }
            catch (Exception exc)
            {
                throw new MDSManagerException("An error occured loading the the business rules from XML. Make sure this is a valid file. Error: " + exc.Message);
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
        }

        private static BusinessRule BusinessRuleInstanciate(Guid BRId, string BRName, string ModelName, string EntityName, MemberType memType, int priority, List<BRAction> BRActions, int internalId, string ruleActionText, string ruleConditionTest)
        {
              BusinessRule businessRule1 = new BusinessRule()
                {
                    Priority = priority
                };
                var contextIdentifier1 = new MemberTypeContextIdentifier
                 {
                     Id = BRId,
                     Name = BRName,
                     ModelId = IdentifierUtils.NewFromName(ModelName),
                     EntityId = IdentifierUtils.NewFromName(EntityName),
                     MemberType = memType,
                     InternalId = internalId
                 };

                businessRule1.Identifier = contextIdentifier1;
                businessRule1.RuleActionText = ruleActionText;
                businessRule1.RuleConditionText = ruleConditionTest;
                businessRule1.BRActions = BRActionsInstanciate(BRActions, businessRule1.Identifier);
                return businessRule1;
           
        }

        public static string BusinessRulesCopy(BusinessRules brs, Identifier sourceModelId, Identifier targetModelId)
        {

            int num = 0;
            var stringBuilder = new StringBuilder("these business rule related entities does not exists in target model:");
            stringBuilder.AppendLine();
            var businessRuleSet = new BusinessRules();
            foreach (BusinessRule businessRule1 in brs.BusinessRulesMember)
            {
                var identifier = GetEntityIdFromName(targetModelId, businessRule1.Identifier.EntityId.Name);
                if (identifier != null)
                {
                    businessRuleSet.BusinessRulesMember = new List<BusinessRule>();
                    var businessRule2 = BusinessRuleInstanciate(Guid.NewGuid(), businessRule1.Identifier.Name, targetModelId.Name, businessRule1.Identifier.EntityId.Name, businessRule1.Identifier.MemberType, businessRule1.Priority, businessRule1.BRActions, businessRule1.Identifier.InternalId, businessRule1.RuleActionText, businessRule1.RuleConditionText);
                    businessRuleSet.BRActions = BRActionsInstanciate(brs.BRActions, businessRule2.Identifier);
                    businessRuleSet.BRConditions = BRConditionsInstanciate(brs.BRConditions, businessRule2.Identifier);
                    businessRuleSet.BRConditionTreeNodes = BRConditionTreeNodesInstanciate(brs.BRConditionTreeNodes, businessRule2.Identifier);
                    businessRuleSet.BusinessRulesMember.Add(businessRule2);
                }
                else
                {
                    stringBuilder.AppendLine(businessRule1.Identifier.EntityId.Name);
                    ++num;
                }

                {
                    string message = Tools.HandleErrors(_client.BusinessRulesClone(new International(), businessRuleSet));
                    if (!string.IsNullOrEmpty(message))
                        throw new Exception(message);
                }
                if (num == 0)
                    stringBuilder = new StringBuilder();
            }
            return stringBuilder.ToString();

        }

        public static string BusinessRulesClone(BusinessRules rules, Identifier targetModelId)
        {
            var stringBuilder = new StringBuilder("Business rules clone log:");

            //the business rules in the file must be from the same model
            //this is just a double-check; files created by the tool will always meet this condition
            var sameModel = true;
            var modelId = rules.BusinessRulesMember[0].Identifier.ModelId.Id;
            foreach (BusinessRule businessRule in rules.BusinessRulesMember)
            {
                if (!businessRule.Identifier.ModelId.Id.Equals(modelId))
                {
                    sameModel = false;
                    break;
                }
            }
            if (!sameModel)
                throw new ArgumentException("The rules must be all from the same model!", "rules");

            //Checking if model if of the rules is the same as the target model
            if (!modelId.Equals(targetModelId.Id))
                throw new ArgumentException("The target model and the source model do not have the same ID. Use only across cloned models.", "targetModelId");

            var result = _client.BusinessRulesClone(new International(), rules);
            stringBuilder.AppendLine(Tools.HandleErrors(result, false));

            return stringBuilder.ToString();

        }

        private static List<BRConditionTreeNode> BRConditionTreeNodesInstanciate(IEnumerable<BRConditionTreeNode> BRConditionTreeNodes, MemberTypeContextIdentifier BRId)
        {
            var collection = new List<BRConditionTreeNode>();
            foreach (BRConditionTreeNode conditionTreeNode in BRConditionTreeNodes)
                collection.Add(new BRConditionTreeNode
                    {
                        BRConditions = BRConditionsInstanciate(conditionTreeNode.BRConditions, BRId),
                        BusinessRuleId = BRId,
                        ConditionTreeChildNodes = conditionTreeNode.ConditionTreeChildNodes,
                        ConditionTreeParentNode = conditionTreeNode.ConditionTreeParentNode,
                        LogicalOperator = conditionTreeNode.LogicalOperator,
                        Identifier = new Identifier
                            {
                                Name = conditionTreeNode.Identifier.Name,
                                Id = Guid.NewGuid()
                            },
                        Sequence = conditionTreeNode.Sequence
                    });
            return collection;
        }

        private static List<BRAction> BRActionsInstanciate(IEnumerable<BRAction> BRActions, MemberTypeContextIdentifier BRId)
        {
            List<BRAction> collection1 = new List<BRAction>();
            foreach (BRAction brAction1 in BRActions)
            {
                BRAction brAction2 = new BRAction();
                brAction2.Identifier = new Identifier()
                    {
                        Id = Guid.NewGuid(),
                        Name = brAction1.Identifier.Name
                    };
                brAction2.BusinessRuleId = BRId;
                BRAction brAction3 = brAction2;
                brAction3.PrefixArgument = new BRAttributeArgument();
                brAction3.PrefixArgument.PropertyName = brAction1.PrefixArgument.PropertyName;
                brAction3.PrefixArgument.AttributeId = new Identifier();
                brAction3.PrefixArgument.AttributeId.Id = Guid.NewGuid();
                brAction3.PrefixArgument.AttributeId.Name = brAction1.PrefixArgument.AttributeId.Name;
                brAction3.Operator = brAction1.Operator;
                List<object> collection2 = new List<object>();
                foreach (object obj in brAction1.PostfixArguments)
                {
                    BRBlankArgument brBlankArgument1 = obj as BRBlankArgument;
                    BRFreeformArgument freeformArgument1 = obj as BRFreeformArgument;
                    if (brBlankArgument1 != null)
                    {
                        List<object> collection3 = collection2;
                        BRBlankArgument brBlankArgument2 = new BRBlankArgument();
                        brBlankArgument2.Identifier = new Identifier()
                            {
                                Id = Guid.NewGuid(),
                                Name = brBlankArgument1.Identifier.Name
                            };
                        brBlankArgument2.PropertyName = brBlankArgument1.PropertyName;
                        BRBlankArgument brBlankArgument3 = brBlankArgument2;
                        collection3.Add((object)brBlankArgument3);
                    }
                    else if (freeformArgument1 != null)
                    {
                        List<object> collection3 = collection2;
                        BRFreeformArgument freeformArgument2 = new BRFreeformArgument();
                        freeformArgument2.Identifier = new Identifier()
                            {
                                Id = Guid.NewGuid(),
                                Name = freeformArgument1.Identifier.Name
                            };
                        freeformArgument2.Value = freeformArgument1.Value;
                        freeformArgument2.PropertyName = freeformArgument1.PropertyName;
                        BRFreeformArgument freeformArgument3 = freeformArgument2;
                        collection3.Add((object)freeformArgument3);
                    }
                }
                brAction3.PostfixArguments = collection2;
                brAction3.Text = brAction1.Text;
                brAction3.Sequence = brAction1.Sequence;
                collection1.Add(brAction3);
            }
            return collection1;
        }

        public static List<BRCondition> BRConditionsInstanciate(List<BRCondition> BRconditions, MemberTypeContextIdentifier BRId)
        {
            List<BRCondition> collection = new List<BRCondition>();
            var brCondition1 = new BRCondition();
            foreach (BRCondition brCondition2 in BRconditions)
            {
                brCondition1.BusinessRuleId = BRId;
                brCondition1.ConditionTreeNodeId = new Identifier
                    {
                        Name = brCondition2.ConditionTreeNodeId.Name
                    };
                brCondition1.Identifier = new Identifier
                    {
                        Id = Guid.NewGuid(),
                        Name = brCondition2.Identifier.Name
                    };
                brCondition1.Operator = brCondition2.Operator;
                brCondition1.PrefixArgument = brCondition2.PrefixArgument;
                brCondition1.PostfixArguments = brCondition2.PostfixArguments;
                brCondition1.Sequence = brCondition2.Sequence;
                brCondition1.Text = brCondition2.Text;
                collection.Add(brCondition1);
            }
            return collection;
        }

        public static BusinessRules BusinessRulesGet(Identifier modelId)
        {
            try
            {

                {
                    BRGetCriteria GetCriteria = new BRGetCriteria()
                    {
                        ModelId = modelId,
                        MemberType = BREntityMemberType.NotSpecified
                    };
                    BRResultOptions ResultOptions = new BRResultOptions()
                    {
                        BusinessRules = ResultType.Details,

                    };
                    OperationResult OperationResult;
                    BusinessRules businessRules = _client.BusinessRulesGet(new International(), GetCriteria, ResultOptions, out OperationResult);
                    string message = Tools.HandleErrors(OperationResult);
                    if (!string.IsNullOrEmpty(message))
                        throw new Exception(message);
                    else
                        return businessRules;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static BusinessRules BusinessRulesGet(Identifier modelId, bool bReturnBusinessRuleSet = false)
        {
            try
            {

                {
                    BRGetCriteria GetCriteria = new BRGetCriteria()
                    {
                        ModelId = modelId,
                        MemberType = BREntityMemberType.NotSpecified
                    };
                    BRResultOptions ResultOptions = new BRResultOptions()
                    {
                        BusinessRules = ResultType.Details
                    };
                    OperationResult OperationResult;
                    var businessRules = _client.BusinessRulesGet(new International(), GetCriteria, ResultOptions, out OperationResult);
                    string message = Tools.HandleErrors(OperationResult);
                    if (!string.IsNullOrEmpty(message))
                        throw new Exception(message);
                    return businessRules;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string BusinessRulesExport(string exportFileName, BusinessRules brs)
        {
            TextWriter textWriter = null;
            try
            {
                var xmlSerializer = new XmlSerializer(typeof(BusinessRules), new Type[]
        {
          typeof (BRAttributeValueArgument),
          typeof (BRBlankArgument),
          typeof (BRDomainBasedAttributeArgument)
        });
                textWriter = new StreamWriter(exportFileName);
                xmlSerializer.Serialize(textWriter, (object)brs);
                return "Business Rules successfully exported to file " + exportFileName;
            }

            finally
            {
                if (textWriter != null)
                    textWriter.Close();
            }
        }

        public static SecurityPrincipals DeleteUser(User user)
        {
            var securityPrincipals = new SecurityPrincipals();
            try
            {

                if (user != null)
                {
                    var criteria = new SecurityPrincipalsDeleteCriteria { Users = new List<Identifier> { user.Identifier } };

                    {
                        string message = Tools.HandleErrors(_client.SecurityPrincipalsDelete(new International(), criteria));
                        if (!string.IsNullOrEmpty(message))
                            throw new Exception(message);
                    }
                }
                return securityPrincipals;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static SecurityPrincipals UpdateUsersList()
        {
            var criteria = new SecurityPrincipalsCriteria
                {
                    All = true,
                    SecurityResolutionType = SecurityResolutionType.Users,
                    Identifiers = new List<Identifier>(),
                    Type = PrincipalType.UserAccount,
                    ResultType = ResultType.Details,
                    ModelPrivilege = ResultType.Details,
                    FunctionPrivilege = ResultType.Details
                };
            SecurityPrincipals Principals;
            string message =
                Tools.HandleErrors(_client.SecurityPrincipalsGet(new International(), criteria, out Principals));
            if (!string.IsNullOrEmpty(message))
                throw new Exception(message);
            return Principals;
        }



        public static SecurityPrincipals UserSecurityPrincipalsGet(string userAccount)
        {
            return GetUsersAndGroups(PrincipalType.UserAccount, IdentifierUtils.NewFromName(userAccount), SecurityResolutionType.Users);
        }
        public static SecurityPrincipals UserSecurityPrincipalsGet()
        {
            return GetUsersAndGroups(PrincipalType.UserAccount, null, SecurityResolutionType.Users);
        }
        public static SecurityPrincipals GroupSecurityPrincipalsGet()
        {
            return GetUsersAndGroups(PrincipalType.Group, null, SecurityResolutionType.UserAndGroup);
        }

        private static SecurityPrincipals GetUsersAndGroups(PrincipalType principalType, Identifier principalId, SecurityResolutionType resolutionType)
        {
            EnsureClient();
            var criteria = new SecurityPrincipalsCriteria
                {
                    All = true,
                    SecurityResolutionType = resolutionType,
                    Type = principalType,
                    ResultType = ResultType.Details,
                    ModelPrivilege = ResultType.Details,
                    HierarchyMemberPrivilege = ResultType.Details,
                    FunctionPrivilege = ResultType.Details
                };


            if (principalId != null)
            {
                criteria.All = false;
                criteria.Identifiers = new List<Identifier> { principalId };

            }


            SecurityPrincipals result;
            string message = Tools.HandleErrors(_client.SecurityPrincipalsGet(new International(), criteria, out result));
            if (!string.IsNullOrEmpty(message))
                throw new Exception(message);

            return result;
        }


        
        public static SecuritySet SecurityPrincipalsImport(string fileFullPathAndName, PrincipalType principalType, SecurityPrincipalsOptions options, bool isUpdate)
        {
            if (principalType == PrincipalType.None)
                throw new ArgumentOutOfRangeException("principalType", "PrincipalType.None is not a valid option");

            if (string.IsNullOrEmpty(fileFullPathAndName))
                throw new ArgumentNullException("fileFullPathAndName");

            EnsureClient();

            SecurityPrincipals principals = null;



            principals = Tools.DeserializeFile<SecurityPrincipals>(fileFullPathAndName);

            //Forcing null according to PrincipalType
            if (principalType == PrincipalType.UserAccount)
            {
                principals.Groups = null;

                foreach (var principal in principals.Users)
                {

                    if (options.HasFlag(SecurityPrincipalsOptions.ExcludeFunctionPrivileges))
                        principal.SecurityPrivilege.FunctionPrivileges = null;

                    if (options.HasFlag(SecurityPrincipalsOptions.ExcludeHierarchyMemberPrivileges))
                        principal.SecurityPrivilege.HierarchyMemberPrivileges = null;

                    if (options.HasFlag(SecurityPrincipalsOptions.ExcludeModelPrivileges))
                        principal.SecurityPrivilege.ModelPrivileges = null;

                }

            }
            //Forcing null according to PrincipalType
            if (principalType == PrincipalType.Group)
            {
                principals.Users = null;
                foreach (var principal in principals.Groups)
                {
                    if (options.HasFlag(SecurityPrincipalsOptions.ExcludeFunctionPrivileges))
                        principal.SecurityPrivilege.FunctionPrivileges = null;

                    if (options.HasFlag(SecurityPrincipalsOptions.ExcludeHierarchyMemberPrivileges))
                        principal.SecurityPrivilege.HierarchyMemberPrivileges = null;

                    if (options.HasFlag(SecurityPrincipalsOptions.ExcludeModelPrivileges))
                        principal.SecurityPrivilege.ModelPrivileges = null;
                }

            }

            if (!isUpdate)
            {
                SecuritySet SecuritySet;
                var operationResult = _client.SecurityPrincipalsCreate(new International(), principals, out SecuritySet);
                Tools.HandleErrors(operationResult);
                return SecuritySet;

            }
            else
                _client.SecurityPrincipalsUpdate(new International(), principals);
            return null;

        }

        public static void SecurityPrincipalsExport(string principalsFileName, SecurityInformation securityInformation)
        {
            Tools.SerializeSecurityXml(principalsFileName, securityInformation);
        }

        public static void SecurityPrincipalsExport(string principalsFileName, PrincipalType principalType)
        {
            EnsureClient();

            var users = GetUsersAndGroups(PrincipalType.UserAccount, null, SecurityResolutionType.Users);

            var groups = GetUsersAndGroups(PrincipalType.Group, null, SecurityResolutionType.UserAndGroup);
            // Set users and groups objects to securityInformation.
            var securityInformation = new SecurityInformation { Users = users.Users, Groups = groups.Groups };
            SecurityPrincipalsExport(principalsFileName, securityInformation);

        }


        public static SecuritySet SecurityPrivilegesCreate(SecurityPrivileges privileges)
        {
            EnsureClient();
            SecuritySet result;
            var opResult = _client.SecurityPrivilegesCreate(new International(), privileges, out result);

            if (opResult.Errors.Any())
                throw new Exception(opResult.Errors.FirstOrDefault().Description);

            return result;
        }

        public static OperationResult SecurityPrincipalsDelete(User userToDelete)
        {
            return SecurityPrincipalsDelete(new SecurityPrincipals() { Users = new List<User> { userToDelete } }, PrincipalType.UserAccount);
        }

        public static OperationResult SecurityPrincipalsDelete(SecurityPrincipals principalsToDelete, PrincipalType principalType)
        {
            EnsureClient();
            OperationResult operationResult = null;
            var criteria = new SecurityPrincipalsDeleteCriteria();
            if (principalType == PrincipalType.UserAccount)
                criteria.Users = (from user in principalsToDelete.Users
                                  select user.Identifier).ToList();
            if (principalType == PrincipalType.Group)
                criteria.Groups = (from grps in principalsToDelete.Groups
                                   select grps.Identifier).ToList();
            operationResult = _client.SecurityPrincipalsDelete(new International(), criteria);

            if (operationResult.Errors.Any())
                throw new Exception(operationResult.Errors.FirstOrDefault().Description);

            return operationResult;

        }

        public static void SecurityPrivilegesImport(string fullFilePathAndName, SecurityPrivilegesOptions options, bool isUpdate = false)
        {
            if (string.IsNullOrEmpty(fullFilePathAndName))
                throw new ArgumentNullException("fullFilePathAndName");

            var privileges = Tools.DeserializeFile<SecurityPrivileges>(fullFilePathAndName);

            if (!options.HasFlag(SecurityPrivilegesOptions.ModelPrivileges))
                privileges.ModelPrivileges = null;
            if (!options.HasFlag(SecurityPrivilegesOptions.HierarchyMemberPrivileges))
                privileges.HierarchyMemberPrivileges = null;
            if (!options.HasFlag(SecurityPrivilegesOptions.FunctionPrivileges))
                privileges.FunctionPrivileges = null;


            if (isUpdate)
            {

                _client.SecurityPrivilegesUpdate(new International(), privileges);

            }
            else
            {
                SecuritySet securitySet;
                _client.SecurityPrivilegesCreate(new International(), privileges, out securitySet);
            }

        }

        /// <summary>
        /// Export the security privileges of one user in one model.
        /// </summary>
        /// <param name="modelId"></param>
        /// <param name="folderName"></param>
        /// <param name="privilegesFileName"></param>
        /// <param name="user"></param>
        public static void SecurityPrivilegesExport(Identifier modelId, string folderName, string privilegesFileName, User user)
        {
            SecurityPrivilegesExport(modelId, folderName, privilegesFileName, PrincipalType.UserAccount, user.Identifier);
        }

        public static void SecurityPrivilegesExport(Identifier modelId, string folderName, string privilegesFileName, Group group)
        {
            SecurityPrivilegesExport(modelId, folderName, privilegesFileName, PrincipalType.Group, group.Identifier);

        }

        public static void SecurityPrivilegesExport(Identifier modelIdentifier, string folderName, string privilegesFileName, PrincipalType type, Identifier principalId)
        {

            var criteria = new SecurityPrivilegesGetCriteria
            {
                FunctionPrivilegesCriteria = new FunctionPrivilegesCriteria { PrincipalType = type, PrincipalId = principalId, ResultType = ResultType.Details },
                HierarchyMemberPrivilegesCriteria = new HierarchyMemberPrivilegesCriteria { PrincipalType = type, PrincipalId = principalId, ResultType = ResultType.Details },
            };
            if (modelIdentifier != null)
            {
                criteria.ModelPrivilegesCriteria = new ModelPrivilegesCriteria { ModelId = modelIdentifier, PrincipalType = type, PrincipalId = principalId };
            }


            SecurityPrivileges privilegesResult;
            EnsureClient();

            OperationResult operationResult = _client.SecurityPrivilegesGet(new International(), criteria, out privilegesResult);
            Tools.HandleErrors(operationResult);
            Tools.SerializeSecurityXml(privilegesFileName, privilegesResult);

        }


        public static List<ModelPrivilege> GetXMLModelPrivilege(Identifier modelId, string fileName, ServiceClient c)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SecurityPrivileges));
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            SecurityPrivileges securityPrivileges = xmlSerializer.Deserialize((Stream)fileStream) as SecurityPrivileges;
            fileStream.Close();
            List<ModelPrivilege> collection = new List<ModelPrivilege>();
            foreach (ModelPrivilege modelPrivilege in securityPrivileges.ModelPrivileges)
            {
                if (modelPrivilege.ModelId.Id == modelId.Id)
                    collection.Add(modelPrivilege);
            }
            return collection;
        }



       

        public static Metadata MetadataCreate(Metadata Metadata, bool p)
        {
            EnsureClient();
            OperationResult result;
            return _client.MetadataCreate(new International(), Metadata, true, out result);
        }

        private static void CloseClient()
        {
            if (_client == null) return;

            try
            {
                if (_client.State != System.ServiceModel.CommunicationState.Faulted && _client.State != System.ServiceModel.CommunicationState.Closed)
                    _client.Close();
                else
                    _client.Abort();
            }
            catch (Exception) { }
            finally
            {
                _client = null;
            }
        }
        public void Dispose()
        {
            CloseClient();
        }



    }
}

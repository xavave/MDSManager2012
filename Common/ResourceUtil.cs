// Type: Common.ResourceUtil
// Assembly: Common, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null
// Assembly location: C:\Users\Xavier\Documents\Visual Studio 2010\Projects\MDSManager\Common.dll

using System.ComponentModel;
using System.Globalization;
using System.Resources;

namespace Common
{
    public class ResourceUtil
    {
        private static CultureInfo resourceCulture;
        private static ResourceManager resourceMan;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture
        {
            get
            {
                return CultureInfo.CurrentCulture;
            }
            set
            {
                ResourceUtil.resourceCulture = value;
            }
        }

        internal static string ErrorDeployerBatchProcessing
        {
            get
            {
                return ResourceUtil.ResourceManager.GetString("ErrorDeployerBatchProcessing", ResourceUtil.resourceCulture);
            }
        }

        internal static string ErrorDeployerClone
        {
            get
            {
                return ResourceUtil.ResourceManager.GetString("ErrorDeployerClone", ResourceUtil.resourceCulture);
            }
        }

        internal static string ErrorDeployerCreateMetadata
        {
            get
            {
                return ResourceUtil.ResourceManager.GetString("ErrorDeployerCreateMetadata", ResourceUtil.resourceCulture);
            }
        }

        internal static string ErrorDeployerDeleteModel
        {
            get
            {
                return ResourceUtil.ResourceManager.GetString("ErrorDeployerDeleteModel", ResourceUtil.resourceCulture);
            }
        }

        internal static string ErrorDeployerNew
        {
            get
            {
                return ResourceUtil.ResourceManager.GetString("ErrorDeployerNew", ResourceUtil.resourceCulture);
            }
        }

        internal static string ErrorDeployerNoValidModel
        {
            get
            {
                return ResourceUtil.ResourceManager.GetString("ErrorDeployerNoValidModel", ResourceUtil.resourceCulture);
            }
        }

        internal static string ErrorDeployerUpdate
        {
            get
            {
                return ResourceUtil.ResourceManager.GetString("ErrorDeployerUpdate", ResourceUtil.resourceCulture);
            }
        }

        internal static string ErrorPackageDeserialize
        {
            get
            {
                return ResourceUtil.ResourceManager.GetString("ErrorPackageDeserialize", ResourceUtil.resourceCulture);
            }
        }

        internal static string ErrorPackageValidationIncompatibleVersion
        {
            get
            {
                return ResourceUtil.ResourceManager.GetString("ErrorPackageValidationIncompatibleVersion", ResourceUtil.resourceCulture);
            }
        }

        internal static string ErrorPackageValidationMetadataNull
        {
            get
            {
                return ResourceUtil.ResourceManager.GetString("ErrorPackageValidationMetadataNull", ResourceUtil.resourceCulture);
            }
        }

        internal static string ErrorPackageValidationMultipleMetadata
        {
            get
            {
                return ResourceUtil.ResourceManager.GetString("ErrorPackageValidationMultipleMetadata", ResourceUtil.resourceCulture);
            }
        }

        internal static string ErrorPackageValidationNoMatchForDataVersion
        {
            get
            {
                return ResourceUtil.ResourceManager.GetString("ErrorPackageValidationNoMatchForDataVersion", ResourceUtil.resourceCulture);
            }
        }

        internal static string ErrorPackageValidationUnexpectedBusinessRuleComponents
        {
            get
            {
                return ResourceUtil.ResourceManager.GetString("ErrorPackageValidationUnexpectedBusinessRuleComponents", ResourceUtil.resourceCulture);
            }
        }

        internal static string ErrorReaderGetUserDefinedMetadata
        {
            get
            {
                return ResourceUtil.ResourceManager.GetString("ErrorReaderGetUserDefinedMetadata", ResourceUtil.resourceCulture);
            }
        }

        internal static string ErrorReaderModelExistsModelIdNull
        {
            get
            {
                return ResourceUtil.ResourceManager.GetString("ErrorReaderModelExistsModelIdNull", ResourceUtil.resourceCulture);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals((object)ResourceUtil.resourceMan, (object)null))
                    ResourceUtil.resourceMan = new ResourceManager("Microsoft.MasterDataServices.Deployment.ResourceUtil", typeof(ResourceUtil).Assembly);
                return ResourceUtil.resourceMan;
            }
        }

        internal ResourceUtil()
        {
        }
    }
}

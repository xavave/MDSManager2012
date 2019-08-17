// Type: MDSManager.ModellingDataContext
// Assembly: MDSManager, Version=1.0.7.2, Culture=neutral, PublicKeyToken=null
// Assembly location: C:\Users\Xavier\Documents\Visual Studio 2010\Projects\MDSManager\MDSManager.exe


using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using MDSManager2012.Desktop.Properties;


namespace MDSManager2012.Desktop
{
    [Database(Name = "MDSmodelling")]
    public class ModellingDataContext : DataContext
    {
        private static MappingSource mappingSource = (MappingSource)new AttributeMappingSource();

        static ModellingDataContext()
        {
        }

        public ModellingDataContext()
            : base(Settings.Default.MDSmodellingConnectionString, ModellingDataContext.mappingSource)
        {
        }

        public ModellingDataContext(string connection)
            : base(connection, ModellingDataContext.mappingSource)
        {
        }

        public ModellingDataContext(IDbConnection connection)
            : base(connection, ModellingDataContext.mappingSource)
        {
        }

        public ModellingDataContext(string connection, MappingSource mappingSource)
            : base(connection, mappingSource)
        {
        }

        public ModellingDataContext(IDbConnection connection, MappingSource mappingSource)
            : base(connection, mappingSource)
        {
        }
    }
}

using Common.MDSService;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Data;

namespace Common
{
    public static class MDSModelling
    {
        public static List<string> GetConnectionStrings(string applicationPath)
        {
            List<string> list = new List<string>();
            System.Configuration.Configuration configuration = ConfigurationManager.OpenExeConfiguration(applicationPath);
            if (configuration != null && configuration.ConnectionStrings != null && configuration.ConnectionStrings.ConnectionStrings.Count > 0)
            {
                foreach (ConnectionStringSettings connectionStringSettings in (ConfigurationElementCollection)configuration.ConnectionStrings.ConnectionStrings)
                    list.Add(connectionStringSettings.ConnectionString);
            }
            return list;
        }
        public static string CreateTable(string connectionString, string tableName, string attachDbFileName,string modellingDbName, string defaultSchema)
        {
            try
            {
                Server server = MDSModelling.ConnectToServer(connectionString);
                if (server != null)
                {
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);

                    if (!string.IsNullOrWhiteSpace(modellingDbName))
                    {
                        Database database = server.Databases[modellingDbName];
                        if (database == null)
                        {
                            database = new Database();
                            database.Name = modellingDbName;
                            server.AttachDatabase(builder.InitialCatalog, new StringCollection() { builder.AttachDBFilename }, AttachOptions.None);
                        }
                        if (!database.Schemas.Contains(defaultSchema))
                        {
                            database.Schemas.Add(new Schema(database, defaultSchema));
                            database.Alter();
                        }
                        if (!database.Tables.Contains(tableName, defaultSchema))
                        {
                            Table table = new Table(database, tableName, defaultSchema);
                            table.Columns.Add(new Column((SqlSmoObject)table, "ID")
                            {
                                DataType = DataType.Int,
                                Nullable = false,
                                Identity = true,
                                IdentitySeed = 1L,
                                IdentityIncrement = 1L
                            });
                            Index index = new Index((SqlSmoObject)table, "PK_" + tableName);
                            index.IndexKeyType = IndexKeyType.DriPrimaryKey;
                            index.IndexedColumns.Add(new IndexedColumn(index, "ID"));
                            table.Indexes.Add(index);
                            table.Create();
                        }
                    }
                    else
                        throw new Exception("database Name (= initial catalog) is empty");
                }
                else
                    throw new Exception("cannot find server");
            }
            catch (Exception ex)
            {
                return ex.Message + (ex.InnerException == null || string.IsNullOrEmpty(ex.InnerException.Message) ? string.Empty : " ; " + ex.InnerException.Message);
            }
            return string.Empty;
        }
        public static string CreateTable(string dataSource, string initialCatalog, string dataBaseName, string tableName, string attachDbFileName, string defaultSchema)
        {
            try
            {
                Server server = MDSModelling.ConnectToServer(dataSource, initialCatalog);
                Database database = server.Databases[dataBaseName];
                if (database == null)
                {
                    database = new Database();
                    database.Name = dataBaseName;
                    server.AttachDatabase(dataBaseName, new StringCollection() { attachDbFileName });
                }
                if (!database.Schemas.Contains(defaultSchema))
                {
                    database.Schemas.Add(new Schema(database, defaultSchema));
                    database.Alter();
                }
                if (!database.Tables.Contains(tableName, defaultSchema))
                {
                    Table table = new Table(database, tableName, defaultSchema);
                    table.Columns.Add(new Column((SqlSmoObject)table, "ID")
                    {
                        DataType = DataType.Int,
                        Nullable = false,
                        Identity = true,
                        IdentitySeed = 1L,
                        IdentityIncrement = 1L
                    });
                    Index index = new Index((SqlSmoObject)table, "PK_" + tableName);
                    index.IndexKeyType = IndexKeyType.DriPrimaryKey;
                    index.IndexedColumns.Add(new IndexedColumn(index, "ID"));
                    table.Indexes.Add(index);
                    table.Create();
                }
            }
            catch (Exception ex)
            {
                return ex.Message + (ex.InnerException == null || string.IsNullOrEmpty(ex.InnerException.Message) ? string.Empty : " ; " + ex.InnerException.Message);
            }
            return string.Empty;
        }

        private static Server ConnectToServer(string dataSource, string initialCatalog)
        {
            return new Server(new ServerConnection(new SqlConnection(string.Format("Data Source={0};Initial Catalog={1};Integrated Security=SSPI;", (object)dataSource, (object)initialCatalog))));

        }
        private static Server ConnectToServer(string connectionString)
        {
            return new Server(new ServerConnection(new SqlConnection(connectionString)));

        }
        public static string CreateRelationShips(string dataSource, string initialCatalog, string DataBase, string parentTableName, string childTableName)
        {
            try
            {
                Database database = MDSModelling.ConnectToServer(dataSource, initialCatalog).Databases[DataBase];
                Table table1 = database.Tables[childTableName];
                Table table2 = database.Tables[parentTableName];
                if (table1 != null && table2 != null)
                {
                    ForeignKey foreignKey = new ForeignKey(table1, "FK_" + childTableName + "_" + parentTableName);
                    ForeignKeyColumn foreignKeyColumn = new ForeignKeyColumn(foreignKey, "ID", "ID");
                    foreignKey.Columns.Add(foreignKeyColumn);
                    foreignKey.ReferencedTable = parentTableName;
                    if (!table1.ForeignKeys.Contains(foreignKey.Name))
                        foreignKey.Create();
                }
            }
            catch (Exception ex)
            {
                return ex.Message + (ex.InnerException == null || string.IsNullOrEmpty(ex.InnerException.Message) ? string.Empty : " ; " + ex.InnerException.Message);
            }
            return string.Empty;
        }

        public static void AddColumn(string connectionString, string dbName, string tableName, MetadataAttribute att)
        {
            try
            {
                Server server = MDSModelling.ConnectToServer(connectionString);
                if (server == null) throw new Exception("cannot find server");
                Database database = server.Databases[dbName];
                if (database == null) throw new Exception("cannot find database : " + dbName);
                if (database.Tables[tableName].Columns.Contains(att.Identifier.Name))
                    return;
                database.Tables[tableName].Columns.Add(new Column((SqlSmoObject)database.Tables[tableName], att.Identifier.Name)
                {
                    DataType = DataType.VarChar(50),
                    Nullable = false
                });
                database.Tables[tableName].Alter();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public static void DropExistingDb(string connectionString, string dbName)
        {
            try
            {
                Server server = MDSModelling.ConnectToServer(connectionString);
                if (server != null)
                {
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);

                    if (string.IsNullOrWhiteSpace(dbName)) throw new Exception("dbName (initial catalog) is empty");
                    else
                    {
                        Database database = server.Databases[dbName];
                        if (database == null)
                            throw new Exception(string.Format("database with name {0} not found", dbName));
                        database.Drop();
                    }
                }
                else
                    throw new Exception(string.Format("cannot connect to SQL server with connection string : {0}", connectionString));
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void DropExistingDb(string dataSource, string initialCatalog, string DataBase)
        {
            try
            {
                Database database = MDSModelling.ConnectToServer(dataSource, initialCatalog).Databases[DataBase];
                if (database == null)
                    return;
                database.Drop();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private static SqlConnection conn = null;
        private static SqlCommand cmd = null;
        public static void CreateNewDb(string connectionString, string dbName)
        {
            try
            {
                // Create a connection
                conn = new SqlConnection(connectionString);
                // Open the connection
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                string sql = "CREATE DATABASE mydb ON PRIMARY"
                + "(Name=" + dbName + ", filename = '.\\mydb_data.mdf', size=3,"
                + "maxsize=5, filegrowth=10%)log on"
                + "(name=mydbb_log, filename='.\\mydb_log.ldf',size=3,"
                + "maxsize=20,filegrowth=1)";
                ExecuteSQLStmt(connectionString, sql);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        private static void ExecuteSQLStmt(string connectionString, string sql)
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();

            conn.ConnectionString = connectionString;
            conn.Open();
            cmd = new SqlCommand(sql, conn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ae)
            {
                throw ae;
            }
        }
    }
}

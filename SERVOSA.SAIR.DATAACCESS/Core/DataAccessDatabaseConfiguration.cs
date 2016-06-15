using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.DATAACCESS.Core
{
    public class DataAccessDatabaseConfiguration
    {
        private static DatabaseProviderFactory _databaseFactory = new DatabaseProviderFactory();
        private static string _dataBaseName;

        public static void SetOperation(string operationName)
        {
            _dataBaseName = operationName;
        }

        public static Database GetDataBase()
        {
            if (String.IsNullOrWhiteSpace(_dataBaseName))
                return _databaseFactory.CreateDefault();
            else
            {
                SqlConnectionStringBuilder commonConnection = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["SERVOSAIR"].ConnectionString);
                SqlConnectionStringBuilder connectionBuilder = new SqlConnectionStringBuilder();
                connectionBuilder.DataSource = commonConnection.DataSource;
                connectionBuilder.InitialCatalog = _dataBaseName;
                connectionBuilder.IntegratedSecurity = true;

                SqlDatabase sqlDatabase = new SqlDatabase(connectionBuilder.ConnectionString);
                return sqlDatabase;
            }
        }
    }
}

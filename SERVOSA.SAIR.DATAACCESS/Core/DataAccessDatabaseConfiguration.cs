using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
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
            _dataBaseName = $"SAIR_{operationName}";
        }

        public static Database GetDataBase()
        {
            if (String.IsNullOrWhiteSpace(_dataBaseName))
                return _databaseFactory.CreateDefault();
            else
            {
                string myConnectionString = "";

                SqlDatabase sqlDatabase = new SqlDatabase(myConnectionString);
                return sqlDatabase;
            }
        }
    }
}

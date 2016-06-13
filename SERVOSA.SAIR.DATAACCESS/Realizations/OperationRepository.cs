using Microsoft.Practices.EnterpriseLibrary.Data;
using SERVOSA.SAIR.DATAACCESS.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.DATAACCESS.Realizations
{
    public class OperationRepository : IOperationRepository
    {
        private Database _servosaDB;

        public OperationRepository()
        {
            DatabaseProviderFactory databaseFactory = new DatabaseProviderFactory();
            _servosaDB = databaseFactory.CreateDefault();
        }

        public string CreateOperation(string operationName)
        {
            object[] operationParameters = new object[] { operationName };

            var executionResultDatabase = _servosaDB.ExecuteNonQuery("SAIR_CreateOperation", operationParameters);
            var executionResultDataDatabase = _servosaDB.ExecuteNonQuery("SAIR_POPULATEOPERATION", operationParameters);

            return operationName;
        }
    }
}

using Microsoft.Practices.EnterpriseLibrary.Data;
using SERVOSA.SAIR.DATAACCESS.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SERVOSA.SAIR.DATAACCESS.Models.Operations;
using SERVOSA.SAIR.DATAACCESS.Core;

namespace SERVOSA.SAIR.DATAACCESS.Realizations
{
    public class OperationRepository : IOperationRepository
    {
        private Database _servosaDB;

        public OperationRepository()
        {
            DatabaseProviderFactory databaseFactory = new DatabaseProviderFactory();
            _servosaDB = DataAccessDatabaseConfiguration.GetDataBase();
        }

        public string CreateOperation(string operationName)
        {
            object[] operationParameters = new object[] { operationName };

            var executionResultDatabase = _servosaDB.ExecuteNonQuery("SAIR_CreateOperation", operationParameters);
            var executionResultDataDatabase = _servosaDB.ExecuteNonQuery("SAIR_POPULATEOPERATION", operationParameters);

            return operationName;
        }

        public IList<OperationModel> ListAllOperations()
        {
            object[] listOperationParameters = new object[] { };
            var operationRowMapper = MapBuilder<OperationModel>.MapNoProperties().MapByName(prop => prop.OperationId)
                .MapByName(prop => prop.OperationName).Build();
            var listOperations = _servosaDB.ExecuteSprocAccessor("SAIR_LISTOPERATIONS", operationRowMapper, listOperationParameters);
            return listOperations.ToList();
        }
    }
}

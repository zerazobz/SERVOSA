﻿using Microsoft.Practices.EnterpriseLibrary.Data;
using SERVOSA.SAIR.DATAACCESS.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SERVOSA.SAIR.DATAACCESS.Models.Operations;
using SERVOSA.SAIR.DATAACCESS.Core;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Data.SqlClient;
using System.Configuration;

namespace SERVOSA.SAIR.DATAACCESS.Realizations
{
    public class OperationRepository : IOperationRepository
    {
        private Microsoft.Practices.EnterpriseLibrary.Data.Database _servosaDB;

        public OperationRepository()
        {
            DatabaseProviderFactory databaseFactory = new DatabaseProviderFactory();
            _servosaDB = databaseFactory.CreateDefault();
                //DataAccessDatabaseConfiguration.GetDataBase();
        }

        public OperationDbModel CreateOperation(string operationName)
        {
            string operationDatabaseName = String.Empty;
            int databaseId = 0;
            int operationId = 0;
            object[] operationParameters = new object[] { operationName, null, null, null };

            using (var createDbCommand = _servosaDB.GetStoredProcCommand("SAIR_CreateOperation", operationParameters))
            {
                createDbCommand.CommandTimeout = 300;
                var executionResultDatabase = _servosaDB.ExecuteNonQuery(createDbCommand);
                operationDatabaseName = _servosaDB.GetParameterValue(createDbCommand, "@operationNormalizedName").ToString();
                databaseId = Convert.ToInt32(_servosaDB.GetParameterValue(createDbCommand, "@databaseId"));
                operationId = Convert.ToInt32(_servosaDB.GetParameterValue(createDbCommand, "@operationId"));
            }

            return new OperationDbModel()
            {
                DataBaseId = databaseId,
                DataBaseName = operationDatabaseName,
                OperationId = operationId,
                OperationName = operationName
            };
        }

        public int DeleteOperation(int operationId, string operationDatabaseName)
        {
            var executionResult = _servosaDB.ExecuteNonQuery("SAIR_OPERD", new object[] { operationId, operationDatabaseName });
            return executionResult;
        }

        public OperationDbModel GetOperationById(int idOperation)
        {
            object[] idOperationParameter = new object[] { idOperation };
            var operationRowMapper = MapBuilder<OperationDbModel>.MapNoProperties()
                .MapByName(prop => prop.OperationId).MapByName(prop => prop.OperationName)
                .MapByName(prop => prop.DataBaseId).MapByName(prop => prop.DataBaseName)
                .Build();
            var operationIdentityResult = _servosaDB.ExecuteSprocAccessor("SAIR_OPERS_ById", operationRowMapper, idOperationParameter);
            return operationIdentityResult.FirstOrDefault();
        }

        public IList<OperationDbModel> ListAllOperations()
        {
            object[] listOperationParameters = new object[] { };
            var operationRowMapper = MapBuilder<OperationDbModel>.MapNoProperties()
                .MapByName(prop => prop.OperationId).MapByName(prop => prop.OperationName)
                .MapByName(prop => prop.DataBaseId).MapByName(prop => prop.DataBaseName)
                .MapByName(prop => prop.UserName)
                .Build();
            var listOperations = _servosaDB.ExecuteSprocAccessor("SAIR_LISTOPERATIONS", operationRowMapper, listOperationParameters);
            return listOperations.ToList();
        }

        public int UpdateOperationModel(int operationId, string newOperationName)
        {
            var executionResult = _servosaDB.ExecuteNonQuery("SAIR_OPERU", new object[] { operationId, newOperationName });
            return executionResult;
        }
    }
}

using Microsoft.Practices.EnterpriseLibrary.Data;
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

            ////Set Source SQL Server Instance Information
            //SqlConnectionStringBuilder connectionBuilder = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["SERVOSASAIR_CLEAN"].ConnectionString);
            //Server server = new Server(connectionBuilder.DataSource);

            ////Set Source Database Name [Database to Copy]
            //Microsoft.SqlServer.Management.Smo.Database database = server.Databases["SERVOSASAIR_CLEAN"];
            ////server.ConnectionContext.ConnectTimeout = 300000;
            //Transfer transfer = new Transfer(database);
            ////transfer.BulkCopyTimeout = 0;

            ////Yes I want to Copy All the Database Objects
            //transfer.CopyAllObjects = true;
            ////In case if the Destination Database / Objects Exists Drop them First
            //transfer.DropDestinationObjectsFirst = true;
            ////Copy Database Schema
            //transfer.CopySchema = true;
            ////Copy Database Data Get Value from bCopyData Parameter
            //transfer.CopyData = true;
            ////Set Destination SQL Server Instance Name
            //transfer.DestinationServer = connectionBuilder.DataSource;
            ////Create The Database in Destination Server
            //transfer.CreateTargetDatabase = false;
            ////transfer.CopyAllDefaults = true;
            ////transfer.Options.DriDefaults = true;
            //transfer.Options.DriAll = true;
            //////Set Destination Database Name
            ////Microsoft.SqlServer.Management.Smo.Database destionationDatabase = new Microsoft.SqlServer.Management.Smo.Database(server, operationDatabaseName);
            //////Create Empty Database at Destination
            ////destionationDatabase.Create();
            ////Set Destination Database Name
            //transfer.DestinationDatabase = operationDatabaseName;
            ////Include If Not Exists Clause in the Script
            //transfer.Options.IncludeIfNotExists = true;
            ////Start Transfer
            //transfer.TransferData();
            ////Release Server variable
            //server = null;
            return new OperationDbModel()
            {
                DataBaseId = databaseId,
                DataBaseName = operationDatabaseName,
                OperationId = operationId,
                OperationName = operationName
            };
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
                .Build();
            var listOperations = _servosaDB.ExecuteSprocAccessor("SAIR_LISTOPERATIONS", operationRowMapper, listOperationParameters);
            return listOperations.ToList();
        }
    }
}

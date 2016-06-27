using SERVOSA.SAIR.DATAACCESS.Models.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.DATAACCESS.Contracts
{
    public interface IOperationRepository
    {
        OperationDbModel CreateOperation(string operationName, bool azureRemoteGeneration);
        IList<OperationDbModel> ListAllOperations();
        OperationDbModel GetOperationById(int idOperation);
        int UpdateOperationModel(int operationId, string newOperationName);
        int DeleteOperation(int operationId, string operationDatabaseName);
    }
}

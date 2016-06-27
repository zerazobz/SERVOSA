using SERVOSA.SAIR.SERVICE.Models.Operaion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Contracts
{
    public interface IOperationService
    {
        OperationServiceModel CreateOperation(string operationName, bool azureRemoteGeneration);
        IList<OperationServiceModel> ListAllOperations();
        OperationServiceModel GetOperationById(int idOperation);
        int UpdateOperationName(int operationId, string newOperationName);
        int DeleteOperation(int operationId, string operationName);
    }
}

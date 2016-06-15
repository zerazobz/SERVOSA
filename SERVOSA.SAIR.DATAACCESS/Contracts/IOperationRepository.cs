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
        OperationDbModel CreateOperation(string operationName);
        IList<OperationDbModel> ListAllOperations();
        OperationDbModel GetOperationById(int idOperation);
    }
}

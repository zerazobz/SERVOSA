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
        string CreateOperation(string operationName);
        IList<OperationModel> ListAllOperations();
    }
}

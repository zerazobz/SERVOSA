using SERVOSA.SAIR.DATAACCESS.Contracts;
using SERVOSA.SAIR.SERVICE.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SERVOSA.SAIR.SERVICE.Models.Operaion;
using AutoMapper;
using SERVOSA.SAIR.SERVICE.Core;

namespace SERVOSA.SAIR.SERVICE.Realizations
{
    public class OperationService : IOperationService
    {
        private readonly IOperationRepository _operationRepository;

        public OperationService(IOperationRepository injectedOperaiontRep)
        {
            _operationRepository = injectedOperaiontRep;
        }

        public string CreateOperation(string operationName)
        {
            return _operationRepository.CreateOperation(operationName);
        }

        public IList<OperationServiceModel> ListAllOperations()
        {
            OperationServiceModel mapResult = null;

            return _operationRepository.ListAllOperations().Select(oP =>
            {
                mapResult = Mapper.Map<OperationServiceModel>(oP);
                return mapResult;
            }).ToList();
        }
    }
}

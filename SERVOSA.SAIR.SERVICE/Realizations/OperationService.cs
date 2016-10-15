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

        public OperationServiceModel CreateOperation(string operationName)
        {
            var operationEntity = _operationRepository.CreateOperation(operationName);
            var operationServiceModel = Mapper.Map<OperationServiceModel>(operationEntity);
            return operationServiceModel;
        }

        public int DeleteOperation(int operationId, string operationName)
        {
            return _operationRepository.DeleteOperation(operationId, operationName);
        }

        public OperationServiceModel GetOperationById(int idOperation)
        {
            var operationIdentity = _operationRepository.GetOperationById(idOperation);
            var operationServiceModel = Mapper.Map<OperationServiceModel>(operationIdentity);
            return operationServiceModel;
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

        public int UpdateOperationName(int operationId, string newOperationName)
        {
            return _operationRepository.UpdateOperationModel(operationId, newOperationName);
        }
    }
}

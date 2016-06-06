using SERVOSA.SAIR.SERVICE.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SERVOSA.SAIR.SERVICE.Models.Types;
using SERVOSA.SAIR.DATAACCESS.Contracts;

namespace SERVOSA.SAIR.SERVICE.Realizations
{
    public class TypeService : ITypeService
    {
        private IDriverTypeRepository _typeRepository;

        public TypeService(IDriverTypeRepository injectedTypeRepo)
        {
            _typeRepository = injectedTypeRepo;
        }

        public IList<TypeServiceModel> GetAllTypesByTable(string tableCode)
        {
            TypeServiceModel resultType = null;
            var collectionResult = _typeRepository.GetAllByTable(tableCode).Select(t =>
            {
                TypeServiceModel.ToServiceModel(t, ref resultType);
                return resultType;
            }).ToList();
            return collectionResult;
        }
    }
}

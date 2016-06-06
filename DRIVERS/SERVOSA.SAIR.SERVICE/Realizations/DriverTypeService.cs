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
    public class DriverTypeService : IDriverTypeService
    {
        private IDriverTypeRepository _typeRepository;

        public DriverTypeService(IDriverTypeRepository injectedTypeRepo)
        {
            _typeRepository = injectedTypeRepo;
        }

        public IList<DriverTypeServiceModel> GetAllTypesByTable(string tableCode)
        {
            DriverTypeServiceModel resultType = null;
            var collectionResult = _typeRepository.GetAllByTable(tableCode).Select(t =>
            {
                DriverTypeServiceModel.ToServiceModel(t, ref resultType);
                return resultType;
            }).ToList();
            return collectionResult;
        }
    }
}

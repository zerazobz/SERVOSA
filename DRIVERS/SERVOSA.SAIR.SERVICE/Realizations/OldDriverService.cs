using SERVOSA.SAIR.DATAACCESS.Contracts;
using SERVOSA.SAIR.DATAACCESS.Models.Driver;
using SERVOSA.SAIR.DATAACCESS.Models.Vehicle;
using SERVOSA.SAIR.SERVICE.Contracts;
using SERVOSA.SAIR.SERVICE.Models;
using SERVOSA.SAIR.SERVICE.Models.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Realizations
{
    public class OldDriverService:IOldDriverService
    {
         private readonly IDriverOldRepository _driverRepository;

        public OldDriverService(IDriverOldRepository injectedDriverRepo)
        {
            _driverRepository = injectedDriverRepo;
        }

        public int Create(OldDriverServiceModel viewModel)
        {
            DriverOldModel model = null;
            OldDriverServiceModel.ToModel(viewModel, ref model);
            return _driverRepository.Create(model);
        }

        public int Delete(OldDriverServiceModel viewModel)
        {
            DriverOldModel model = null;
            OldDriverServiceModel.ToModel(viewModel, ref model);
            return _driverRepository.Delete(model);
        }

        public IList<OldDriverServiceModel> GetAll()
        {
            OldDriverServiceModel viewModel = null;
            return _driverRepository.GetAll().Select(v =>
            {
                OldDriverServiceModel.ToViewModel(v, ref viewModel);
                return viewModel;
            }).ToList();
        }

        public IList<OldDriverServiceModel> GetAllFiltered(int minRow, int maxRow)
        {
            OldDriverServiceModel vehicleViewModel = null;
            return _driverRepository.GetAllFiltered(minRow, maxRow).Select(v =>
            {
                OldDriverServiceModel.ToViewModel(v, ref vehicleViewModel);
                return vehicleViewModel;
            }).ToList();
        }

        public OldDriverServiceModel GetById(int id)
        {
            OldDriverServiceModel DriverServiceModel = null;
            var vehicleResult = _driverRepository.GetById(id);
            OldDriverServiceModel.ToViewModel(vehicleResult, ref DriverServiceModel);
            return DriverServiceModel;
        }

        public int Update(OldDriverServiceModel viewModel)
        {
            DriverOldModel model = null;
            OldDriverServiceModel.ToModel(viewModel, ref model);
            return _driverRepository.Update(model);
        }

        public IList<OldDriverServiceModel> GetVehicleRowDataForTable(string tableName)
        {
            OldDriverServiceModel viewModel = null;
            return _driverRepository.GetAll().Select(v =>
            {
                OldDriverServiceModel.ToViewModel(v, ref viewModel);
                return viewModel;
            }).ToList();
        }

        public IList<OldDriverRelatedTableServiceModel> GetRelatedTablesToDriver()
        {
            OldDriverRelatedTableServiceModel vehicleRelatedVM = null;
            var relatedVehiclesCollection = _driverRepository.GetRelatedTablesToDriver().Select(rVT =>
            {
                OldDriverRelatedTableServiceModel.ToServiceModel(rVT, ref vehicleRelatedVM);
                return vehicleRelatedVM;
            }).ToList();
            return relatedVehiclesCollection;
        }

        public IList<string> GetListRelatedTablesToDriver()
        {
            return GetRelatedTablesToDriver().Select(rV => rV.ForeignTable).ToList();
        }
    }
}

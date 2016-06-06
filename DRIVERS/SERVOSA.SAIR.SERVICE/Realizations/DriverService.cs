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
    public class DriverService:IDriverService
    {
         private readonly IDriverOldRepository _driverRepository;

        public DriverService(IDriverOldRepository injectedDriverRepo)
        {
            _driverRepository = injectedDriverRepo;
        }

        public int Create(DriverServiceModel viewModel)
        {
            DriverOldModel model = null;
            DriverServiceModel.ToModel(viewModel, ref model);
            return _driverRepository.Create(model);
        }

        public int Delete(DriverServiceModel viewModel)
        {
            DriverOldModel model = null;
            DriverServiceModel.ToModel(viewModel, ref model);
            return _driverRepository.Delete(model);
        }

        public IList<DriverServiceModel> GetAll()
        {
            DriverServiceModel viewModel = null;
            return _driverRepository.GetAll().Select(v =>
            {
                DriverServiceModel.ToViewModel(v, ref viewModel);
                return viewModel;
            }).ToList();
        }

        public IList<DriverServiceModel> GetAllFiltered(int minRow, int maxRow)
        {
            DriverServiceModel vehicleViewModel = null;
            return _driverRepository.GetAllFiltered(minRow, maxRow).Select(v =>
            {
                DriverServiceModel.ToViewModel(v, ref vehicleViewModel);
                return vehicleViewModel;
            }).ToList();
        }

        public DriverServiceModel GetById(int id)
        {
            DriverServiceModel DriverServiceModel = null;
            var vehicleResult = _driverRepository.GetById(id);
            DriverServiceModel.ToViewModel(vehicleResult, ref DriverServiceModel);
            return DriverServiceModel;
        }

        public int Update(DriverServiceModel viewModel)
        {
            DriverOldModel model = null;
            DriverServiceModel.ToModel(viewModel, ref model);
            return _driverRepository.Update(model);
        }

        public IList<DriverServiceModel> GetVehicleRowDataForTable(string tableName)
        {
            DriverServiceModel viewModel = null;
            return _driverRepository.GetAll().Select(v =>
            {
                DriverServiceModel.ToViewModel(v, ref viewModel);
                return viewModel;
            }).ToList();
        }

        public IList<DriverRelatedTableServiceModel> GetRelatedTablesToDriver()
        {
            DriverRelatedTableServiceModel vehicleRelatedVM = null;
            var relatedVehiclesCollection = _driverRepository.GetRelatedTablesToVehicle().Select(rVT =>
            {
                DriverRelatedTableServiceModel.ToServiceModel(rVT, ref vehicleRelatedVM);
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

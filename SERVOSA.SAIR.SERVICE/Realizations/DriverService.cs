using SERVOSA.SAIR.DATAACCESS.Contracts;
using SERVOSA.SAIR.DATAACCESS.Models.Driver;
using SERVOSA.SAIR.DATAACCESS.Models.Vehicle;
using SERVOSA.SAIR.SERVICE.Contracts;
using SERVOSA.SAIR.SERVICE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Realizations
{
    public class DriverService:IDriverService
    {
         private readonly IDriverRepository _driverRepository;

        public DriverService(IDriverRepository injectedDriverRepo)
        {
            _driverRepository = injectedDriverRepo;
        }

        public int Create(DriverServiceModel viewModel)
        {
            DriverModel model = null;
            DriverServiceModel.ToModel(viewModel, ref model);
            return _driverRepository.Create(model);
        }

        public int Delete(DriverServiceModel viewModel)
        {
            DriverModel model = null;
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
            DriverModel model = null;
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
        /*
        public IList<VehicleHeadRowServiceModel> GetVehicleRowDataForTable(string tableName)
        {
            VehicleHeadRowServiceModel modelResult = null;
            var vehicleData = _driverRepository.GetRowDataForTable(tableName).Select(vD =>
            {
                VehicleHeadRowServiceModel.ToServiceModel(vD, ref modelResult);
                return modelResult;
            }).ToList();

            return vehicleData;
        }
        
        public IList<VehicleVariableDataServiceModel> GetVehicleVariableTableData(string tableName, int vehicleCode)
        {
            VehicleVariableDataServiceModel serviceModel = null;
            var dataResult = _driverRepository.GetVehicleVariableTableData(tableName, vehicleCode).Select(vD =>
            {
                VehicleVariableDataServiceModel.ToServiceModel(vD, ref serviceModel);
                return serviceModel;
            }).ToList();
            return dataResult;
        }
         **/
    }
}

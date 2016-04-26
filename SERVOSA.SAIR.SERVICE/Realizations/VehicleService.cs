using SERVOSA.SAIR.DATAACCESS.Contracts;
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
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository injectedVehicleRepo)
        {
            _vehicleRepository = injectedVehicleRepo;
        }

        public int Create(VehicleServiceModel viewModel)
        {
            VehicleModel model = null;
            VehicleServiceModel.ToModel(viewModel, ref model);
            return _vehicleRepository.Create(model);
        }

        public int Delete(VehicleServiceModel viewModel)
        {
            VehicleModel model = null;
            VehicleServiceModel.ToModel(viewModel, ref model);
            return _vehicleRepository.Delete(model);
        }

        public IList<VehicleServiceModel> GetAll()
        {
            VehicleServiceModel viewModel = null;
            return _vehicleRepository.GetAll().Select(v =>
            {
                VehicleServiceModel.ToViewModel(v, ref viewModel);
                return viewModel;
            }).ToList();
        }

        public IList<VehicleServiceModel> GetAllFiltered(int minRow, int maxRow)
        {
            VehicleServiceModel vehicleViewModel = null;
            return _vehicleRepository.GetAllFiltered(minRow, maxRow).Select(v =>
            {
                VehicleServiceModel.ToViewModel(v, ref vehicleViewModel);
                return vehicleViewModel;
            }).ToList();
        }

        public VehicleServiceModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(VehicleServiceModel viewModel)
        {
            VehicleModel model = null;
            VehicleServiceModel.ToModel(viewModel, ref model);
            return _vehicleRepository.Update(model);
        }
    }
}

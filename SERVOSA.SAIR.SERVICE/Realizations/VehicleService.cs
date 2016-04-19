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

        public int Create(VehicleViewModel viewModel)
        {
            VehicleModel model = null;
            VehicleViewModel.ToModel(viewModel, ref model);
            return _vehicleRepository.Create(model);
        }

        public int Delete(VehicleViewModel viewModel)
        {
            VehicleModel model = null;
            VehicleViewModel.ToModel(viewModel, ref model);
            return _vehicleRepository.Delete(model);
        }

        public IList<VehicleViewModel> GetAll()
        {
            VehicleViewModel viewModel = null;
            return _vehicleRepository.GetAll().Select(v =>
            {
                VehicleViewModel.ToViewModel(v, ref viewModel);
                return viewModel;
            }).ToList();
        }

        public IList<VehicleViewModel> GetAllFiltered(int minRow, int maxRow)
        {
            VehicleViewModel vehicleViewModel = null;
            return _vehicleRepository.GetAllFiltered(minRow, maxRow).Select(v =>
            {
                VehicleViewModel.ToViewModel(v, ref vehicleViewModel);
                return vehicleViewModel;
            }).ToList();
        }

        public VehicleViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(VehicleViewModel viewModel)
        {
            VehicleModel model = null;
            VehicleViewModel.ToModel(viewModel, ref model);
            return _vehicleRepository.Update(model);
        }
    }
}

using SERVOSA.SAIR.DATAACCESS.Contracts;
using SERVOSA.SAIR.DATAACCESS.Models.DB;
using SERVOSA.SAIR.SERVICE.Contracts;
using SERVOSA.SAIR.SERVICE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Realizations
{
    public class DriverDBServices : IDriverDBServices
    {
        private readonly IDBTablesRepository _tableRepository;
        private readonly IDriverDBColumnsRepository _columnRepository;

        public DriverDBServices(IDBTablesRepository injectedTableRepo, IDriverDBColumnsRepository injectedColumnRepo)
        {
            _tableRepository = injectedTableRepo;
            _columnRepository = injectedColumnRepo;
        }

        public Tuple<int, DriverTableServiceModel> CreateTable(DriverTableServiceModel viewModel)
        {
            DriverTableModel model = null;
            DriverTableServiceModel.ToModel(viewModel, ref model);

            var resultExecution = _tableRepository.CreateTableAndReturnsNormalizedName(model);

            IDriverTableServiceModel viewModelResult = null;
            DriverTableServiceModel.ToViewModel(resultExecution.Item2, ref viewModelResult);

            return new Tuple<int, DriverTableServiceModel>(resultExecution.Item1, (DriverTableServiceModel)viewModelResult);
        }

        public Tuple<int, DriverColumnServiceModel> CreateColumn(DriverColumnServiceModel viewModel)
        {
            DriverColumnModel model = null;
            DriverColumnServiceModel.ToModel(viewModel, ref model);
            var resultExecution = _columnRepository.CreateColumnAndReturnNormalizedName(model);

            DriverColumnServiceModel viewModelResult = null;
            DriverColumnServiceModel.ToViewModel(resultExecution.Item2, ref viewModelResult);
            return new Tuple<int, DriverColumnServiceModel>(resultExecution.Item1, viewModelResult);
        }

        public IList<DriverTableServiceModel> ListAllTables()
        {
            IDriverTableServiceModel viewModel = null;
            var listTables = _tableRepository.GetAll().Select(t =>
            {
                DriverTableServiceModel.ToViewModel(t, ref viewModel);
                return (DriverTableServiceModel)viewModel;
            }).ToList();
            return listTables;
        }

        public IList<DriverTableColumnServiceModel> ListVehicleVarsTablesWithDefinition()
        {
            DriverTableColumnServiceModel viewModel = null;
            var listTables = _tableRepository.ListAllVehicleVarsTablesWithDefinition().Select(t =>
            {
                DriverTableColumnServiceModel.ToServiceModel(t, ref viewModel);
                return viewModel;
            }).ToList();
            return listTables;
        }

        public IList<DriverTableColumnServiceModel> ListDriversVarsTablesWithDefinition()
        {
            DriverTableColumnServiceModel viewModel = null;
            var listTables = _tableRepository.ListAllDriverVarsTablesWithDefinition().Select(t =>
            {
                DriverTableColumnServiceModel.ToServiceModel(t, ref viewModel);
                return viewModel;
            }).ToList();
            return listTables;
        }
    }
}

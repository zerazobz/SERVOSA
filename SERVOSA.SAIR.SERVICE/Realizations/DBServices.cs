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
    public class DBServices : IDBServices
    {
        private readonly IDBTablesRepository _tableRepository;
        private readonly IDBColumnsRepository _columnRepository;

        public DBServices(IDBTablesRepository injectedTableRepo, IDBColumnsRepository injectedColumnRepo)
        {
            _tableRepository = injectedTableRepo;
            _columnRepository = injectedColumnRepo;
        }

        public Tuple<int, TableServiceModel> CreateTable(TableServiceModel viewModel)
        {
            TableModel model = null;
            TableServiceModel.ToModel(viewModel, ref model);

            var resultExecution = _tableRepository.CreateTableAndReturnsNormalizedName(model);

            TableServiceModel viewModelResult = null;
            TableServiceModel.ToViewModel(resultExecution.Item2, ref viewModelResult);

            return new Tuple<int, TableServiceModel>(resultExecution.Item1, viewModelResult);
        }

        public Tuple<int, ColumnServiceModel> CreateColumn(ColumnServiceModel viewModel)
        {
            ColumnModel model = null;
            ColumnServiceModel.ToModel(viewModel, ref model);
            var resultExecution = _columnRepository.CreateColumnAndReturnNormalizedName(model);

            ColumnServiceModel viewModelResult = null;
            ColumnServiceModel.ToViewModel(resultExecution.Item2, ref viewModelResult);
            return new Tuple<int, ColumnServiceModel>(resultExecution.Item1, viewModelResult);
        }

        public IList<TableServiceModel> ListAllTables()
        {
            TableServiceModel viewModel = null;
            var listTables = _tableRepository.GetAll().Select(t =>
            {
                TableServiceModel.ToViewModel(t, ref viewModel);
                return viewModel;
            }).ToList();
            return listTables;
        }

        public IList<TableColumnServiceModel> ListTablesColumnCompleteData()
        {
            TableColumnServiceModel viewModel = null;
            var listTables = _tableRepository.ListAllDataTables().Select(t =>
            {
                TableColumnServiceModel.ToServiceModel(t, ref viewModel);
                return viewModel;
            }).ToList();
            return listTables;
        }
    }
}

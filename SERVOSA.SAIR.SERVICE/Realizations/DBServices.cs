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

        public Tuple<int, TableViewModel> CreateTable(TableViewModel viewModel)
        {
            TableModel model = null;
            TableViewModel.ToModel(viewModel, ref model);

            var resultExecution = _tableRepository.CreateTableAndReturnsNormalizedName(model);

            TableViewModel viewModelResult = null;
            TableViewModel.ToViewModel(resultExecution.Item2, ref viewModelResult);

            return new Tuple<int, TableViewModel>(resultExecution.Item1, viewModelResult);
        }

        public Tuple<int, ColumnViewModel> CreateColumn(ColumnViewModel viewModel)
        {
            ColumnModel model = null;
            ColumnViewModel.ToModel(viewModel, ref model);
            var resultExecution = _columnRepository.CreateColumnAndReturnNormalizedName(model);

            ColumnViewModel viewModelResult = null;
            ColumnViewModel.ToViewModel(resultExecution.Item2, ref viewModelResult);
            return new Tuple<int, ColumnViewModel>(resultExecution.Item1, viewModelResult);
        }

        public IList<TableViewModel> ListAllTables()
        {
            TableViewModel viewModel = null;
            var listTables = _tableRepository.GetAll().Select(t =>
            {
                TableViewModel.ToViewModel(t, ref viewModel);
                return viewModel;
            }).ToList();
            return listTables;
        }
    }
}

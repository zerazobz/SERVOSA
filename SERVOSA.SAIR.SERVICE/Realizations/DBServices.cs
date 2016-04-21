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

        public DBServices(IDBTablesRepository injectedTableRepo)
        {
            _tableRepository = injectedTableRepo;
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

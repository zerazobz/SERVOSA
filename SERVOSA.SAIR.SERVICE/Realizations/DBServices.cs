﻿using SERVOSA.SAIR.DATAACCESS.Contracts;
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

            ITableServiceModel viewModelResult = null;
            TableServiceModel.ToViewModel(resultExecution.Item2, ref viewModelResult);

            return new Tuple<int, TableServiceModel>(resultExecution.Item1, (TableServiceModel)viewModelResult);
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
            ITableServiceModel viewModel = null;
            var listTables = _tableRepository.GetAll().Select(t =>
            {
                TableServiceModel.ToViewModel(t, ref viewModel);
                return (TableServiceModel)viewModel;
            }).ToList();
            return listTables;
        }

        public IList<TableColumnServiceModel> ListVehicleVarsTablesWithDefinition()
        {
            TableColumnServiceModel viewModel = null;
            var listTables = _tableRepository.ListAllVehicleVarsTablesWithDefinition().Select(t =>
            {
                TableColumnServiceModel.ToServiceModel(t, ref viewModel);
                return viewModel;
            }).ToList();
            return listTables;
        }

        public IList<TableColumnServiceModel> ListDriversVarsTablesWithDefinition()
        {
            TableColumnServiceModel viewModel = null;
            var listTables = _tableRepository.ListAllDriverVarsTablesWithDefinition().Select(t =>
            {
                TableColumnServiceModel.ToServiceModel(t, ref viewModel);
                return viewModel;
            }).ToList();
            return listTables;
        }

        public string ChangeVehicleTableName(string tableName, string newTableName)
        {
            return _tableRepository.ChangeTableName("vehiclevars", tableName, newTableName);
        }

        public string ChangeDriverTableName(string tableName, string newTableName)
        {
            return _tableRepository.ChangeTableName("drivervars", tableName, newTableName);
        }

        public int RemoveVehicleTable(string tableName)
        {
            return _tableRepository.RemoveTable(tableName, "V");
        }

        public int RemoveDriverTable(string tableName)
        {
            return _tableRepository.RemoveTable(tableName, "D");
        }
    }
}

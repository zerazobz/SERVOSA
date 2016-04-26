﻿using SERVOSA.SAIR.SERVICE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Contracts
{
    public interface IDBServices
    {
        Tuple<int, TableServiceModel> CreateTable(TableServiceModel viewModel);
        IList<TableServiceModel> ListAllTables();
        Tuple<int, ColumnServiceModel> CreateColumn(ColumnServiceModel viewModel);
        IList<TableColumnServiceModel> ListTablesColumnCompleteData();
    }
}

﻿using SERVOSA.SAIR.SERVICE.Core;
using SERVOSA.SAIR.SERVICE.Models.TableData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Contracts
{
    public interface ITableDataService
    {
        Tuple<bool, int, string> InsertTableData(string tableName, Dictionary<string, Tuple<SERVOSASqlTypes, Object>> tableData);
        Tuple<bool, int, string> UpdateTableData(string tableName, int vehicleId, Dictionary<string, Tuple<SERVOSASqlTypes, object>> tableData);
    }
}

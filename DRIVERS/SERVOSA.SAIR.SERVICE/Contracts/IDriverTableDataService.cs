using SERVOSA.SAIR.SERVICE.Core;
using SERVOSA.SAIR.SERVICE.Models;
using SERVOSA.SAIR.SERVICE.Models.TableData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Contracts
{
    public interface IDriverTableDataService
    {
        Tuple<bool, int, string> InsertTableData(string tableName, Dictionary<string, Tuple<SERVOSASqlTypes, Object>> tableData, bool variableData);
        Tuple<bool, int, string> UpdateTableData(string tableName, int vehicleId, Dictionary<string, Tuple<SERVOSASqlTypes, object>> tableData, bool variableData);
        //Tuple<bool, int, string> InsertOrUpdateVariableData(VehicleVariableDataServiceModel model, Dictionary<string, Tuple<SERVOSASqlTypes, Object>> tableData);
        Tuple<bool, int, string> InsertOrUpdateData(DriverVariableDataServiceModel model);
    }
}

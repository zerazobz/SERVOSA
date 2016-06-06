using SERVOSA.SAIR.DATAACCESS.Core;
using SERVOSA.SAIR.DATAACCESS.Models.Vehicle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.DATAACCESS.Contracts
{
    public interface IDriverRepository : IRepository<DriverModel>
    {
        IList<DriverModel> GetAllFiltered(int minRow, int maxRow);
        IList<DriverModel> GetAllFilteredBySearchTerm(string searchTerm);
        IList<VehicleHeadRowDataModel> GetRowDataForTable(string tableName);
        IList<DriverVariableTableDataModel> GetVehicleVariableTableData(string tableName, int vehicleId);
        IList<DriverRelatedTableToEntityModel> GetRelatedTablesToVehicle();
        DataSet GetVariableDataToExport(string tableName);
        DataSet GetVehicleDataToExport(int vehicleCode);
    }
}

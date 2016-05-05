using SERVOSA.SAIR.DATAACCESS.Models.Vehicle;
using SERVOSA.SAIR.SERVICE.Contracts.Common;
using SERVOSA.SAIR.SERVICE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Contracts
{
    public interface IVehicleService : IServiceRepository<VehicleServiceModel>
    {
        IList<VehicleServiceModel> GetAllFiltered(int minRow, int maxRow);
        IList<VehicleHeadRowServiceModel> GetVehicleRowDataForTable(string tableName);
        IList<VehicleVariableDataServiceModel> GetVehicleVariableTableData(string tableName, int vehicleCode);
    }
}

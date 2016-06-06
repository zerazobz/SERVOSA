using SERVOSA.SAIR.DATAACCESS.Models.Vehicle;
using SERVOSA.SAIR.SERVICE.Contracts.Common;
using SERVOSA.SAIR.SERVICE.Models;
using SERVOSA.SAIR.SERVICE.Models.Vehicle;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Contracts
{
    public interface IDriverService : IServiceRepository<VehicleServiceModel>
    {
        IList<VehicleServiceModel> GetAllFiltered(int minRow, int maxRow);
        IList<VehicleServiceModel> GetAllFilteredBySearchTerm(string searchTerm);
        IList<VehicleHeadRowServiceModel> GetVehicleRowDataForTable(string tableName);
        VehicleVariableDataServiceModel GetVehicleVariableTableData(string tableName, int vehicleCode);
        IList<DriverRelatedTableServiceModel> GetRelatedTablesToVehicle();
        IList<string> GetListRelatedTablesToVehicle();
        void GenerateReportForTable(string tableName, Stream streamData);
        void GenerateReportForVehicle(int vehicleCode, Stream streamData);
    }
}

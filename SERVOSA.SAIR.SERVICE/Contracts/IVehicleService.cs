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
    public interface IVehicleService : IServiceRepository<VehicleServiceModel>
    {
        IList<VehicleServiceModel> GetAllFiltered(int minRow, int maxRow);
        IList<VehicleHeadRowServiceModel> GetVehicleRowDataForTable(string tableName);
        VehicleVariableDataServiceModel GetVehicleVariableTableData(string tableName, int vehicleCode);
        IList<VehicleRelatedTableServiceModel> GetRelatedTablesToVehicle();
        IList<string> GetListRelatedTablesToVehicle();
        void GenerateReportForTable(string tableName, Stream streamData);
        void GenerateReportForVehicle(int vehicleCode, Stream streamData);
    }
}

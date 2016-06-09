using SERVOSA.SAIR.DATAACCESS.Models.Driver;
using SERVOSA.SAIR.SERVICE.Contracts.Common;
using SERVOSA.SAIR.SERVICE.Models;
using SERVOSA.SAIR.SERVICE.Models.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Contracts
{
    public interface IDriverService : IServiceRepository<DriverServiceModel>
    {
        IList<DriverServiceModel> GetAllFiltered(int minRow, int maxRow);
        IList<DriverServiceModel> GetAllFilteredBySearchTerm(string searchTerm);
        IList<DriverHeadRowServiceModel> GetDriverRowDataForTable(string tableName);
        DriverVariableDataServiceModel GetDriverVariableTableData(string tableName, int driverCode);
        IList<DriverRelatedTableServiceModel> GetRelatedTablesToDriver();
        IList<string> GetListRelatedTablesToDriver();
        void GenerateReportForTable(string tableName, Stream streamData);
        void GenerateReportForDriver(int driverCode, Stream streamData);
    }
}

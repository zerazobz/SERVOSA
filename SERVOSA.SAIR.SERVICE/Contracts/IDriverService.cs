using SERVOSA.SAIR.DATAACCESS.Models.Driver;
using SERVOSA.SAIR.SERVICE.Contracts.Common;
using SERVOSA.SAIR.SERVICE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SERVOSA.SAIR.SERVICE.Contracts
{
    public interface IDriverService : IServiceRepository<DriverServiceModel>
    {
         IList<DriverServiceModel> GetAllFiltered(int minRow, int maxRow);
         IList<DriverServiceModel> GetVehicleRowDataForTable(string tableName);
    }
}

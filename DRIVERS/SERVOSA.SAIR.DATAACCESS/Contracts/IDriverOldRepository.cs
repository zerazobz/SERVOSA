using SERVOSA.SAIR.DATAACCESS.Core;
using SERVOSA.SAIR.DATAACCESS.Models.Driver;
using SERVOSA.SAIR.DATAACCESS.Models.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SERVOSA.SAIR.DATAACCESS.Contracts
{
    public interface IDriverOldRepository : IRepository<DriverOldModel>
    {
        IList<DriverOldModel> GetAllFiltered(int minRow, int maxRow);
        IList<DriverOldModel> GetRowDataForTable(string tableName);
        IList<DriverRelatedTableToEntityModel> GetRelatedTablesToVehicle();
    }
}

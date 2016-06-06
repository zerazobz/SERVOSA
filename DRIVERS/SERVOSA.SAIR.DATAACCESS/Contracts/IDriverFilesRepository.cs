using SERVOSA.SAIR.DATAACCESS.Models.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.DATAACCESS.Contracts
{
    public interface IDriverFilesRepository
    {
        IList<DriverFileModel> GetListDrivers(string tableName, int driverCode);
        int InsertDriver(DriverFileModel model);
        int DeleteDriver(DriverFileModel model);
    }
}

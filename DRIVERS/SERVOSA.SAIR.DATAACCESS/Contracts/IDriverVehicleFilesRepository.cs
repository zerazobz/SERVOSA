using SERVOSA.SAIR.DATAACCESS.Models.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.DATAACCESS.Contracts
{
    public interface IDriverVehicleFilesRepository
    {
        IList<DriverFileModel> GetListVehicles(string tableName, int vehicleCode);
        int InsertVehicle(DriverFileModel model);
        int DeleteVehicle(DriverFileModel model);
    }
}

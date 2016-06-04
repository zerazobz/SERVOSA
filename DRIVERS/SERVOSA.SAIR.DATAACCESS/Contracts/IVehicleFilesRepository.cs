using SERVOSA.SAIR.DATAACCESS.Models.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.DATAACCESS.Contracts
{
    public interface IVehicleFilesRepository
    {
        IList<VehicleFileModel> GetListVehicles(string tableName, int vehicleCode);
        int InsertVehicle(VehicleFileModel model);
        int DeleteVehicle(VehicleFileModel model);
    }
}

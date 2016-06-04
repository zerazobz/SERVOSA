using SERVOSA.SAIR.SERVICE.Models.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Contracts
{
    public interface IVehicleFileService
    {
        IList<VehicleFileServiceModel> GetFilesByTableNameAndVehicleId(string tableName, int vehicleId);
        Tuple<bool, int, string> InsertVehicleFile(VehicleFileServiceModel model);
        Tuple<bool, int, string> DeleteVehicleFile(VehicleFileServiceModel model);
    }
}

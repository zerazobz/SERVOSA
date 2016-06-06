using SERVOSA.SAIR.SERVICE.Models.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Contracts
{
    public interface IDriverFileService
    {
        IList<DriverFileServiceModel> GetFilesByTableNameAndVehicleId(string tableName, int vehicleId);
        Tuple<bool, int, string> InsertVehicleFile(DriverFileServiceModel model);
        Tuple<bool, int, string> DeleteVehicleFile(DriverFileServiceModel model);
    }
}

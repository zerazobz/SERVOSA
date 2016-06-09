using SERVOSA.SAIR.SERVICE.Models.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Contracts
{
    public interface IDriverFileService
    {
        IList<DriverFileServiceModel> GetFilesByTableNameAndDriverId(string tableName, int driverId);
        Tuple<bool, int, string> InsertDriverFile(DriverFileServiceModel model);
        Tuple<bool, int, string> DeleteDriverFile(DriverFileServiceModel model);
    }
}

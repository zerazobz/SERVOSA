using SERVOSA.SAIR.DATAACCESS.Core;
using SERVOSA.SAIR.DATAACCESS.Models.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.DATAACCESS.Contracts
{
    public interface IVehicleRepository : IRepository<VehicleModel>
    {
        IList<VehicleModel> GetAllFiltered(int minRow, int maxRow);
    }
}

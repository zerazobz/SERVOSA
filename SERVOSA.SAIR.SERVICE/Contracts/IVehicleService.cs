using SERVOSA.SAIR.SERVICE.Contracts.Common;
using SERVOSA.SAIR.SERVICE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Contracts
{
    public interface IVehicleService : IServiceRepository<VehicleViewModel>
    {
        IList<VehicleViewModel> GetAllFiltered(int minRow, int maxRow);
    }
}

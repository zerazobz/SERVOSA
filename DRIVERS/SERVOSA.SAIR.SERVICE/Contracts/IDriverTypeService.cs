using SERVOSA.SAIR.SERVICE.Models.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Contracts
{
    public interface IDriverTypeService
    {
        IList<DriverTypeServiceModel> GetAllTypesByTable(string tableCode);
    }
}

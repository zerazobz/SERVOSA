using SERVOSA.SAIR.DATAACCESS.Models.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.DATAACCESS.Contracts
{
    public interface IDriverTypeRepository
    {
        IList<DriverTypeModel> GetAllByTable(string tableCode);
    }
}

using SERVOSA.SAIR.DATAACCESS.Models.Driver;
using SERVOSA.SAIR.SERVICE.Contracts.Common;
using SERVOSA.SAIR.SERVICE.Models;
using SERVOSA.SAIR.SERVICE.Models.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SERVOSA.SAIR.SERVICE.Contracts
{
    public interface IOldDriverService : IServiceRepository<OldDriverServiceModel>
    {
        IList<OldDriverServiceModel> GetAllFiltered(int minRow, int maxRow);
        IList<OldDriverRelatedTableServiceModel> GetRelatedTablesToDriver();
        IList<string> GetListRelatedTablesToDriver();
    }
}

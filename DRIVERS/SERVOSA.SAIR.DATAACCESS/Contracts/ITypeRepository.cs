using SERVOSA.SAIR.DATAACCESS.Models.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.DATAACCESS.Contracts
{
    public interface ITypeRepository
    {
        IList<TypeModel> GetAllByTable(string tableCode);
    }
}

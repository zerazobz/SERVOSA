using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.SERVICE.Contracts.Common
{
    public interface IServiceRepository<T>
    {
        IList<T> GetAll();
        T GetById(int id);
        int Create(T viewModel);
        int Update(T viewModel);
        int Delete(T viewModel);
    }
}

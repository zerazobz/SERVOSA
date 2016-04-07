using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVOSA.SAIR.DATAACCESS.Core
{
    public interface IRepository<T>
    {
        IList<T> GetAll();
        T GetById(int id);
        int Create(T entity);
        int Update(T entity);
        int Delete(T entity);
    }
}
